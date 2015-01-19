using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using ReportingDesigner.ViewModels;
using Telerik.Windows.Diagrams.Core;
using UserControl = System.Windows.Controls.UserControl;

namespace ReportingDesigner.Views
{
    public partial class PageNumberSettingsView : UserControl
    {
        public PageNumberSettingsView()
        {
            InitializeComponent();
        }


        //We need to decide if this should be a command or not, or even be handled through events
        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            Guid pinId = Guid.NewGuid();

            var viewModel = (PageNumberControlViewModel) this.DataContext;
            viewModel.PinID = pinId;

            //Find what page the control is on
            viewModel.Report.Pages
                .OrderBy(p => p.PageNumber)
                .Skip(viewModel.Page.PageNumber)
                .ToList()
                .ForEach(page =>
                    {
                        var model = new PageNumberControlViewModel(viewModel.Report, page);
                        model.PinID = pinId;
                        model.Position = new Point(viewModel.Position.X, viewModel.Position.Y + (page.Bottom - page.Top));
                        page.Controls.Add(model);

                        //TODO: Need to add to designer
                    });
        }

        //We need to decide if this should be a command or not, or even be handled through events
        private void UnpinButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
