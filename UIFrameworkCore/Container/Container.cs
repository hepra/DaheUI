using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
//using Autofac;
//using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using UIFrameworkCore.DependencyInjectionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

namespace UIFrameworkCore
{
    public class ServiceLocator
    {
        private ILifetimeScope serviceProvider;

        public void SetServiceProvider(ILifetimeScope serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TService GetRequiredService<TService>()
        {
            return serviceProvider.GetRequiredService<TService>();
        }

        public static ServiceLocator Instance { get; } = new ServiceLocator();
    }

    public static class ServiceCollectionExtension1
    {
        public static ServiceProvider BuilderMs(this IServiceCollection services)
        {
           // services.AddSingleton(c => c.GetRequiredService<IBrowserFactory>().Create());
            services.AddSingleton(c => c.GetRequiredService<ILoggerWarpFactory>().GetLogger());

            return services.BuildServiceProvider();
        }

        public static IContainer BuilderAutofacProxy(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            //var validateTypes = services
            //    .Where(_serviceDescript => 
            //        _serviceDescript.ImplementationType != null &&
            //        _serviceDescript.ServiceType == typeof(IControl) &&
            //        _serviceDescript.ValidateControl()
            //    )
            //    .ToList();

            //if (validateTypes.Count > 0)
            //{
            //    builder.Populates(services.Except(validateTypes));
            //}
            //else
                builder.Populates(services);

            //builder.Populate(services);
      //      builder.Register(c => c.Resolve<IBrowserFactory>().Create());
            builder.Register(c => c.Resolve<ILoggerWarpFactory>().GetLogger());

            var _container = builder.Build();

            return _container;

            //return new AutofacServiceProvider(_container);
        }

        public static bool ValidateControl(this ServiceDescriptor descriptor)
        {
            var implType = descriptor.ImplementationType;
            var ctor = implType.GetConstructors().First();
            var ctorParamTypes = ctor.GetParameters().Select(param => param.ParameterType).ToList();

            return !
                 ctorParamTypes.All(
                    parameterType => {
                        return
                            typeof(UserControl).IsAssignableFrom(parameterType) &&
                            parameterType.GetCustomAttribute<NoProxyAttribute>() != null;
                 });
        }
    }

    public class LoggerInterceptor : IInterceptor
    {
        private ILoggerInfo logger;

        public LoggerInterceptor(ILoggerInfo _logger)
        {
            logger = _logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                //logger.Info($"Before TargetType:{invocation.TargetType} Method:{invocation.MethodInvocationTarget}");
                invocation.Proceed();
                //logger.Info($"After TargetType:{invocation.TargetType} Method:{invocation.MethodInvocationTarget}");
            }
            catch(Exception ex)
            {
                logger.Error(ex, $"Exception TargetType:{invocation.TargetType} Method:{invocation.MethodInvocationTarget}");
            }
        }
    }

    public abstract class Container
    {
        private IServiceCollection services = new ServiceCollection();

        protected abstract void ConfigService(IServiceCollection services);
        //protected abstract List<Type> ConfigureDynamicProxy(IServiceCollection services);

        public IContainer BuildServiceProvider()
        {
            ConfigService(services);

            return services.BuilderAutofacProxy();
        }
    }

    internal static class ContainerBuilderExtension
    {
        public static void Populates(this ContainerBuilder builder, IEnumerable<ServiceDescriptor> services)
        {
            builder.RegisterType<LoggerInterceptor>();

            foreach(var service in services.Where(_service=>_service.ImplementationFactory == null))
            {
                //if (service.ImplementationInstance != null)
                //    builder.RegisterInstance(service);
                if (service.ImplementationType == service.ServiceType)
                    builder.RegisterClass(service);
                else
                    builder.RegisterInterface(service);
            }
        }

        internal static void RegisterClass(this ContainerBuilder builder, ServiceDescriptor descriptor)
        {
            switch (descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .SingleInstance(descriptor);
                    break;

                case ServiceLifetime.Scoped:
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .InstancePerLifetimeScope(descriptor);
                    break;

                default:
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .InstancePerDependency(descriptor);
                    break;
            }
        }

        internal static void RegisterInterface(this ContainerBuilder builder, ServiceDescriptor descriptor)
        {
            switch(descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .As(descriptor.ServiceType)
                        .SingleInstance(descriptor);
                    break;

                case ServiceLifetime.Scoped:
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .As(descriptor.ServiceType)
                        .InstancePerLifetimeScope(descriptor);
                    break;

                default:
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .As(descriptor.ServiceType)
                        .InstancePerDependency(descriptor);
                    break;
            }
        }

        internal static void SingleInstance(this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> builder,
    ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationType.GetCustomAttribute<NoProxyAttribute>() != null)
            {
                builder
                    .SingleInstance();
            }
            else
            {
                builder
                    .InterceptedBy(typeof(LoggerInterceptor))
                    .EnableInterfaceInterceptors()
                    .SingleInstance();
            }
        }

        internal static void InstancePerLifetimeScope(this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> builder,
            ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationType.GetCustomAttribute<NoProxyAttribute>() != null)
            {
                builder
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder
                    .InterceptedBy(typeof(LoggerInterceptor))
                    .EnableInterfaceInterceptors()
                    .InstancePerLifetimeScope();
            }
        }

        internal static void InstancePerDependency(this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> builder,
            ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationType.GetCustomAttribute<NoProxyAttribute>() != null)
            {
                builder
                    .InstancePerDependency();
            }
            else
            {
                builder
                    .InterceptedBy(typeof(LoggerInterceptor))
                    .EnableInterfaceInterceptors()
                    .InstancePerDependency();
            }
        }
    }

    public static class LifetimeScopeExtension
    {
        public static TService GetRequiredService<TService>(this ILifetimeScope scope)
        {
            var serviceType = typeof(TService);

            if (serviceType.IsGenericType)
            {
                var genericTypes = serviceType.GetGenericArguments();

                return scope.ResolveAll<TService>(genericTypes);
            }

            return scope.Resolve<TService>();
        }

        public static TService ResolveAll<TService>(this ILifetimeScope self, Type[] types)
        {
            Type enumerableOfType = typeof(IEnumerable<>).MakeGenericType(types);
            var obj = self.ResolveService(new TypedService(enumerableOfType));

            return (TService)obj;
        }
    }
}
