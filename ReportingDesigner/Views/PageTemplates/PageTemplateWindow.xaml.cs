using System;
using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views;

namespace ReportingDesigner
{
    public partial class PageTemplateWindow : Window
    {
        public PageTemplateWindow(PageTemplateViewModel viewModel)
        {
            InitializeComponent();
            InitializeToolbox();
            DataContext = viewModel;
        }

        public PageTemplateWindow()
        {
            var pageFormat = new PageFormat();
            pageFormat.PageSize = new PageSize(Convert.ToDouble(DefaultFormats.Height), Convert.ToDouble(DefaultFormats.Width));
            pageFormat.UnitType = UnitType.Millimeters;

            var settings = FormatSettingsFactory.CreateFormatSettings(PageOrientation.Portrait, 300, pageFormat, new Thickness(Convert.ToDouble(DefaultFormats.Margin)));

            InitializeComponent();
            InitializeToolbox();
            DataContext = new PageTemplateViewModel("Template", settings);       
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
    }
}
