using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using ReportingDesigner.Annotations;
using ReportingDesigner.Models;

namespace ReportingDesigner.Controls.Notifications
{
    public class NotificationPanelViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Notification> _notifications;
        public ObservableCollection<Notification> Notifications
        {
            get { return _notifications; }
            set
            {
                if (Equals(value, _notifications)) return;
                _notifications = value;
                OnPropertyChanged("Notifications");
            }
        }

        public NotificationPanelViewModel()
        {
            Notifications = new ObservableCollection<Notification>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}