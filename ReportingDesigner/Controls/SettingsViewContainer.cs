using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Controls
{
    public class SettingsViewContainer : StackPanel
    {
        public SettingsViewContainer()
        {
            this.Loaded += SettingsViewContainer_Loaded;
        }

        protected void SettingsViewContainer_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelBase model = (ViewModelBase)DataContext;
            UserControl settingsView = (UserControl)Activator.CreateInstance(model.SettingsViewType);
            settingsView.DataContext = model;
            this.Children.Clear();
            this.Children.Add(settingsView);
        }
    }
}
