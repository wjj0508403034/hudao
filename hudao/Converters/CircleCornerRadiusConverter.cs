using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace hudao.Converters
{
   public  class CircleCornerRadiusConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var height = (double) value;
            return new CornerRadius(height/2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
