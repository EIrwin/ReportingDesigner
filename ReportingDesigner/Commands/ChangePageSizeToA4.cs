using System;
using System.Windows.Input;
using ReportingDesigner.Utility;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class ChangePageSizeToA4:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer) parameter).ChangePageSize(PageSizes.A4);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}