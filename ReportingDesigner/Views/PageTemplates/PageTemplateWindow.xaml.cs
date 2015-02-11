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
        //This constructor is used if they 
        //do not have an existing page template
        public PageTemplateWindow()
        {
            //We want to initialize default format
            //settings here so they can be passed into the 
            //PageTemplateViewModel
            var pageFormat = new PageFormat();
            pageFormat.PageSize = new PageSize(Convert.ToDouble(DefaultFormats.Height), Convert.ToDouble(DefaultFormats.Width));
            pageFormat.UnitType = UnitType.Millimeters;

            var settings = FormatSettingsFactory.CreateFormatSettings(PageOrientation.Portrait, 300, pageFormat, new Thickness(Convert.ToDouble(DefaultFormats.Margin)));

            InitializeComponent();
            InitializeToolbox();
            DataContext = new PageTemplateViewModel("Template", settings);
        }

        //This constructor is used if
        //they are opening this window with 
        //an existing page template
        public PageTemplateWindow(PageTemplateViewModel viewModel)
        {
            InitializeComponent();
            InitializeToolbox();
            DataContext = viewModel;
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
