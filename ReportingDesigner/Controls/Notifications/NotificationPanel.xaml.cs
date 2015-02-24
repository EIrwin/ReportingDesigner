using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ReportingDesigner.Models;

namespace ReportingDesigner.Controls.Notifications
{
    public partial class NotificationPanel : UserControl
    {
        private const int MAX_NOTIFICATIONS = 5;
        private const int SECONDS_TO_THROTTLE = 5;

        private readonly List<Notification> _buffer;

        public NotificationPanel()
        {
            _buffer = new List<Notification>();

            InitializeComponent();

            DataContext = new NotificationPanelViewModel();
        }

        private static object _lock = new object();

        public void AddNotification(Notification notification)
        {
            var viewModel = (NotificationPanelViewModel) DataContext;

            lock (_lock)
            {
                if (!viewModel.Notifications.Any())
                {
                    viewModel.Notifications.Add(notification);
                }
                else
                {
                    var frequencyLimit = TimeSpan.FromSeconds(SECONDS_TO_THROTTLE);

                    var throttle = viewModel.Notifications.Any(p =>
                    {
                        if (p.Message != notification.Message) return false;

                        var duration = notification.Timestamp.Subtract(p.Timestamp);
                        return duration <= frequencyLimit;
                    });

                    if (!throttle)
                        viewModel.Notifications.Add(notification);
                }
            }
        }
    }
}
