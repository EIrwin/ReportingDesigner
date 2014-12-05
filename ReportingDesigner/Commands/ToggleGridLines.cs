using System;
using System.Windows.Input;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class ToggleGridLines:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer) parameter).ToggleGridLines();
        }

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public event EventHandler CanExecuteChanged;
    }
}
