using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UIFrameworkCore.Settings.UIAttributes;

namespace UIFrameworkCore.Convert
{
    public class AutoValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TypeDescriptor.GetConverter(targetType).ConvertFrom(value?.ToString() ?? string.Empty);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var wrapper = parameter as PropertyInfoWrapper;
            var converter = TypeDescriptor.GetConverter(wrapper.PropertyInfo.PropertyType);

            var str = value.ToString();

            return converter.ConvertFrom(string.IsNullOrWhiteSpace(str) ? wrapper.ProxyValue.ToString() : str);
        }
    }
    public class PropertyInfoWrapper
    {
        public PropertyInfo PropertyInfo { get; set; }
        public object OwnerObject { get; set; }

        public object ProxyValue
        {
            get => PropertyInfo.GetValue(OwnerObject);
            set => PropertyInfo.SetValue(OwnerObject, value);
        }

        public string DisplayPropertyName => PropertyInfo.GetCustomAttribute<NameAliasAttribute>()?.AliasName ?? PropertyInfo.Name;
    }
}
