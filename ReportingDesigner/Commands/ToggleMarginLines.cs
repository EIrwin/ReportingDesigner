﻿using System;
using System.Windows.Input;
using ReportingDesigner.Views;

namespace ReportingDesigner.Commands
{
    public class ToggleMarginLines:ICommand
    {
        public void Execute(object parameter)
        {
            if (parameter is DesignerContainer)
                ((DesignerContainer)parameter).ToggleMarginLines();

            if (parameter is PageTemplateDesignerContainer)
                ((PageTemplateDesignerContainer)parameter).ToggleMarginLines();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}