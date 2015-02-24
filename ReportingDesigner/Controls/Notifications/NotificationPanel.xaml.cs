using System;
using System.Linq;
using System.Windows.Controls;
using ReportingDesigner.Models;

namespace ReportingDesigner.Controls.Notifications
{
    public partial class NotificationPanel : UserControl
    {
        private const int SECONDS_TO_THROTTLE = 5;

        public NotificationPanel()
        {
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
                    if (!viewModel.Notifications.Any(p =>
                        {
                            if(p.Message != notification.Message)return false;

                            var duration = notification.Timestamp.Subtract(p.Timestamp);
                            return duration <= frequencyLimit;
                        }))
                        viewModel.Notifications.Add(notification);
                }
            }
        }
    }
}
