using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace fancierProfile.Converters
{
    public class FileToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string filePath)
            {
                return new Uri(filePath, UriKind.RelativeOrAbsolute);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
