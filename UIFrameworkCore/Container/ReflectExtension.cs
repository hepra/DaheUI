//using Autofac;
//using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;
using UIFrameworkCore.DependencyInjectionExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UIFrameworkCore
{
    public static class ReflectExtension
    {
        public static IEnumerable<Type> ScannerDependencyInjection(this Assembly assembly)
        {
            return assembly.GetTypes().Where(type => type.GetCustomAttribute<DependencyInjectionAttribute>() != null);
        }

        #region Msdi
        public static void Scanner(this IServiceCollection services, Assembly assembly, bool isValidate = false)
        {
            //if (isValidate)
            //{
            //    if (!assembly.GetTypes().Any(_type => typeof(IPlugValidationHandler).IsAssignableFrom(_type)))
            //        throw new NotImplementedException($"{assembly} 未实现:{typeof(IPlugValidationHandler)}");
            //}

            foreach(var type in assembly.ScannerDependencyInjection())
            {
                var attribute = type.GetCustomAttribute<DependencyInjectionAttribute>();

                switch (attribute.Lifetime)
                {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(attribute.ServiceType, type);
                        break;

                    case ServiceLifetime.Scoped:
                        services.AddScoped(attribute.ServiceType, type);
                        break;

                    default:
                        services.AddTransient(attribute.ServiceType, type);
                        break;
                }
            }
        }

        public static void ScannerFile(this IServiceCollection services, string path)
        {
            //if (!factory.TryKey(path))
            //{
            //    var assembly = Assembly.LoadFile(path);

            //    services.Scanner(assembly);
            //}
            //else
            //{
            //    factory
            //}
            try
            {
                var assembly = Assembly.LoadFile(path);

                services.Scanner(assembly);
            }
            catch(Exception ex)
            {
                throw new Exception($"file load Error:{path}", ex);
            }
        }

        public static void Scanner(this IServiceCollection services, string path)
        {
            var assembly = Assembly.LoadFile(path);

            services.Scanner(assembly, true);
        }

        public static void Scanner(this IServiceCollection services, IEnumerable<string> files)
        {
            foreach(var file in files)
            {
                services.Scanner(file);
            }
        }

        public static void Scanner(this IServiceCollection services, string directory, string searchPattern)
        {
            var files = Directory.EnumerateFiles(directory, searchPattern)./*Select(_fullname=>_fullname.Replace(directory, "")).*/ToList();
            services.Scanner(files);
        }
        #endregion
    }
}
