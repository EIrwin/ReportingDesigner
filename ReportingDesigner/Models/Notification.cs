using System.ComponentModel;
using ReportingDesigner.Annotations;

namespace ReportingDesigner.Models
{
    public class Notification:INotifyPropertyChanged
    {
        private string _message;
        private string _title;

        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message) return;
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public Notification(string message)
        {
            Message = message;
        }
        public Notification(string title,string message)
        {
            Title = title;
            Message = message;
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
