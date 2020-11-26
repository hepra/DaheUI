using Microsoft.Extensions.DependencyInjection;
using System;

namespace UIFrameworkCore.DependencyInjectionExtension
{
    public class ScopedAttribute : DependencyInjectionAttribute
    {
        public ScopedAttribute(Type serviceType) : base(serviceType, ServiceLifetime.Scoped)
        {
        }
    }
}
