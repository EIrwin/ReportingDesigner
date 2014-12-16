using System;
using System.Windows.Input;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class ChangePageSizeToLetter:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer)parameter).ChangePageSize(PageSizes.Letter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}