using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UI框架.converter
{
    public class PathToImageSource : IValueConverter
    {

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null || !(value.GetType() == typeof(string)))
                    return value;
                var iconString = value as string;
                 return SetSource(iconString);
            }
        private ImageSource SetSource(string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (string.IsNullOrEmpty(fileName))
                {
                    return null;
                }
                BitmapImage image = new BitmapImage();

                using (System.IO.FileStream ms = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.DecodePixelWidth = 2048;
                    image.EndInit();
                    image.Freeze();
                }
                return image;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DependencyProperty.UnsetValue;
            }

    }
}
