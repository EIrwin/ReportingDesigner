using System;
using System.Windows.Input;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class Print:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer) parameter).Print();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class RenderReport:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer) parameter).RenderReport();
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}