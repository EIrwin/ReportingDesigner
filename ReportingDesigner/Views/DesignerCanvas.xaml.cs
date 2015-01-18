using System;
using System.Windows;
using ReportingDesigner.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for DesignerCanvas.xaml
    /// </summary>
    public partial class DesignerCanvas : RadDiagram
    {
        public DesignerCanvas()
        {
            InitializeComponent();
        }

        private void Diagram_AdditionalContentActivated(object sender, AdditionalContentActivatedEventArgs e)
        {
            
        }

        private void Diagram_PreviewDrop(object sender, DragEventArgs e)
        {
            var item = (ToolboxItemViewModel)e.Data.GetData(e.Data.GetFormats()[0]);

            ReportViewModel reportViewModel = (ReportViewModel) this.DataContext;

            ReportControlViewModel viewModel = (ReportControlViewModel) Activator.CreateInstance(item.ViewModelType,new object[]{reportViewModel});
            viewModel.Position = e.GetPosition(this);
            viewModel.ViewType = item.ViewType;
            //viewModel.SettingsViewType = item.SettingsViewType;
            //ViewModel.Controls.Add(viewModel);

            ////Generate the View based on the business
            ////object that the ListBoxViewModel references
            ReportControlView view = (ReportControlView)Activator.CreateInstance(item.ViewType);
            view.DataContext = viewModel;
            //view.PreviewMouseLeftButtonDown += Diagram_ControlClicked;
            AddShape(view);
        }
    }
}
