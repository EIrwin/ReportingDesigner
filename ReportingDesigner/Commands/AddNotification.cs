using System;
using System.Windows.Input;
using ReportingDesigner.Models;

namespace ReportingDesigner.Commands
{
    public class AddNotification:ICommand
    {
        public Notification Notification { get; set; }

        public AddNotification(Notification notification)
        {
            Notification = notification;
        }
        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
