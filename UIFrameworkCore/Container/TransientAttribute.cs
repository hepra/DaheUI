using Microsoft.Extensions.DependencyInjection;
using System;

namespace UIFrameworkCore.DependencyInjectionExtension
{
    public class TransientAttribute : DependencyInjectionAttribute
    {
        public TransientAttribute(Type serviceType) : base(serviceType, ServiceLifetime.Transient)
        {
        }
    }
}
