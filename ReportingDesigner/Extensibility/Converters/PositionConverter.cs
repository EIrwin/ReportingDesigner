using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ReportingDesigner.Extensibility.Converters
{
    public class PositionConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = int.Parse(parameter.ToString());
            double height = 0;

            var position = new Point();

            if (values[0] is Point)
                position = (Point) values[0];

            if (values.Length == 2)
                height = (double) values[1];

            position.Y = (int) (position.Y + offset + height);
            
            return position;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
