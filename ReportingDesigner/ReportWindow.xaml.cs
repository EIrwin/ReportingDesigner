using System;
using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Models;

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

        private void Designer_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private int CalculatePageNumber()
        {
            //The following logic is for
            //determining the current page number
            double bottom = this.Designer.Viewport.Bottom;
            double top = this.Designer.Viewport.Top;

            double middle = (bottom - top) / 2;
            double threshold = top + middle;

            int pageNumber = -1;

            Designer.ViewModel.Pages.ForEach(p =>
                {
                    if (p.Top <= threshold && p.Bottom >=threshold)
                        pageNumber = p.PageNumber;
                });

            return pageNumber;
        }

        private void Designer_ViewportChanged(object sender, Telerik.Windows.Diagrams.Core.PropertyEventArgs<Rect> e)
        {
            int currentPage = CalculatePageNumber();

            //We only want to update if page number has changed
            if (PageNumberView.GetPageNumber() != currentPage && currentPage != -1)
                PageNumberView.SetPageNumber(currentPage);
            
        }
    }
}
