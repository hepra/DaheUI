using System;

namespace UIFrameworkCore.DependencyInjectionExtension
{
    public class ExportAttribute : SingletonAttribute
    {
        public ExportAttribute(Type serviceType) : base(serviceType)
        {
        }
    }
}
