using System;
using System.Windows.Input;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class LoadPageTemplate:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is PageTemplateDesignerContainer)
                ((PageTemplateDesignerContainer)parameter).LoadPageTemplate();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}