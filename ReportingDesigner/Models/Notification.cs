using System;
using ReportingDesigner.Extensibility.Notifications;

namespace ReportingDesigner.Models
{
    public class Notification
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public DateTime Timestamp { get; set; }
        public NotificationType Type { get; set; }

        public Notification(string message,NotificationType type)
        {
            Message = message;
            Timestamp = DateTime.Now;
            Type = type;
        }
        public Notification(string title,string message,NotificationType type)
        {
            Title = title;
            Message = message;
            Timestamp = DateTime.Now;
            Type = type;
        }
    }
}
