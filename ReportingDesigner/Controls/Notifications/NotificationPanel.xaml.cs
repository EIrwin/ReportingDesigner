using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportingDesigner.Models;

namespace ReportingDesigner.Controls.Notifications
{
    /// <summary>
    /// Interaction logic for NotificationPanel.xaml
    /// </summary>
    public partial class NotificationPanel : UserControl
    {
        public NotificationPanel()
        {
            InitializeComponent();

            DataContext = new NotificationPanelViewModel();
        }

        public void AddNotification(Notification notification)
        {
            var viewModel = (NotificationPanelViewModel) DataContext;

            viewModel.Notifications.Add(notification);
        }
    }
}
