using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Commands;
using ReportingDesigner.Extensibility.Container;
using ReportingDesigner.Extensibility.Events;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views;

namespace ReportingDesigner
{
    public partial class ReportWindow : Window
    {
        private ICommandBus _commandBus;

        public ReportWindow()
        {
            InitializeComponent();
            InitializeToolbox();

            _commandBus = ServiceLocator.GetService<ICommandBus>();
            _commandBus.AddHandler<AddNotification>((command) => 
                NotificationPanel.AddNotification(command.Notification));
        }

        public void InitializeToolbox()
        {
            var toolboxComponents = new List<ToolboxComponentAnnouncement>()
                        {
                            new ToolboxComponentAnnouncement()
                                {
                                    Category = "General",
                                    Display = "Textblock",
                                    Name = "Textblock",
                                    ViewModelType = typeof(TextBlockViewModel),
                                    ViewType = typeof(TextBlockView),
                                    SettingsViewType = typeof(TextBlockSettingsView)
                                },                            
                            new ToolboxComponentAnnouncement()
                                {
                                    Category = "General",
                                    Display = "Page Number",
                                    Name = "Page Number",
                                    ViewModelType = typeof(PageNumberControlViewModel),
                                    ViewType = typeof(PageNumberControl),
                                    SettingsViewType = typeof(PageNumberSettingsView)
                                },    
                        };


            Toolbox.LoadToolboxComponents(toolboxComponents);
        }

        private void Designer_ViewportChanged(object sender, Telerik.Windows.Diagrams.Core.PropertyEventArgs<Rect> e)
        {
            PageViewModel currentPage = Designer.GetCurrentPage();

            //We only want to update if page number has changed
            if (currentPage != null && currentPage.PageNumber != PageNumberView.GetPageNumber())
                PageNumberView.SetPageNumber(currentPage.PageNumber);
        }
    }
}
