using System;
using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner
{
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            InitializeToolbox();
        }

        public void InitializeToolbox()
        {
            var toolboxComponents = new List<ToolboxComponentAnnouncement>()
                        {
                            new ToolboxComponentAnnouncement()
                                    {
                                        Category = "General",
                                        Display = "Textblock",
                                        Name = "Textblock"
                                    },
                            new ToolboxComponentAnnouncement()
                                {
                                    Category = "General",
                                    Display = "Image",
                                    Name = "Image"
                                }
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
