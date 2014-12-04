﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportingDesigner.Events;
using ReportingDesigner.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for Designer.xaml
    /// </summary>
    public partial class Designer:RadDiagram
    {
        private ReportViewModel _viewModel;
        public ReportViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                DataContext = _viewModel;
                _viewModel = value;
            }
        }

        public Designer()
        {
            InitializeComponent();
        }

        private void Diagram_AdditionalContentActivated(object sender, AdditionalContentActivatedEventArgs e)
        {
            var view = e.ContextItems.First() as ViewBase;

            if (view != null)
            {
                var model = view.DataContext as ViewModels.ViewModelBase;
                this.Diagram.SettingPane.DataContext = model;
            }
        }

        private void Diagram_PreviewDrop(object sender, DragEventArgs e)
        {
            var item = (ToolboxItemViewModel)e.Data.GetData(e.Data.GetFormats()[0]);

            //Generate the ViewModel based on the business
            //object that the ListBoxViewModel references
            //IComponentModel model = (IComponentModel)Activator.CreateInstance(item.ComponentType);

            //ControlViewModel viewModel = (ControlViewModel)Activator.CreateInstance(item.ViewModelType, new object[] { model });
            //viewModel.Position = e.GetPosition(Diagram);
            //viewModel.ViewType = item.ViewType;
            //viewModel.SettingsViewType = item.SettingsViewType;
            //ViewModel.Controls.Add(viewModel);

            ////Generate the View based on the business
            ////object that the ListBoxViewModel references
            //ControlView view = (ControlView)Activator.CreateInstance(item.ViewType);
            //view.DataContext = viewModel;
            //view.PreviewMouseLeftButtonDown += Diagram_ControlClicked;
            //Diagram.AddShape(view);

        }
    }
}