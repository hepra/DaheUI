using Microsoft.Extensions.DependencyInjection;
using System;

namespace UIFrameworkCore.DependencyInjectionExtension
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyInjectionAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }
        public Type ServiceType { get; }

        public DependencyInjectionAttribute(Type serviceType, ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }
    }
}
