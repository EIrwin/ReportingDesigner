using System;
using System.Windows.Input;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class ChangePageSizeToLegal:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer)parameter).ChangePageSize(PageSizes.Legal);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}