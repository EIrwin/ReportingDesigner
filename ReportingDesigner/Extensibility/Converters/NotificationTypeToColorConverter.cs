using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using ReportingDesigner.Models;

namespace ReportingDesigner.Extensibility.Converters
{
    public class NotificationTypeToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var notification = (Notification) value;

            string color = string.Empty;

            switch (notification.Type)
            {
                case Notifications.NotificationType.Error :
                    color = Colors.Red.ToString();
                    break;
                case Notifications.NotificationType.Info :
                    color = Colors.White.ToString();
                    break;
                case Notifications.NotificationType.Warning:
                    color = Colors.Yellow.ToString();
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
