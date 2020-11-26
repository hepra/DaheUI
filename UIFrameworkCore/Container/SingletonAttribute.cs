using Microsoft.Extensions.DependencyInjection;
using System;

namespace UIFrameworkCore.DependencyInjectionExtension
{
    public class SingletonAttribute : DependencyInjectionAttribute
    {
        public SingletonAttribute(Type serviceType) : base(serviceType, ServiceLifetime.Singleton)
        {
        }
    }
}
