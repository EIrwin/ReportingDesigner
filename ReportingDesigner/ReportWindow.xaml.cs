using System;
using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            //This should probably go a layer deeper
            double bottom = this.Designer.Viewport.Bottom;
            double top = this.Designer.Viewport.Top;
        }

        private void CalculatePageNumber()
        {
            //The following logic is for
            //determining the current page number
            //This is only temporary and will be 
            //cleaned up.

        }

        private void Designer_ViewportChanged(object sender, Telerik.Windows.Diagrams.Core.PropertyEventArgs<Rect> e)
        {
            Rect bounds = Designer.TransformToAncestor(this).TransformBounds(new Rect(0.0, 0.0, Designer.ActualWidth, Designer.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, this.ActualWidth, this.ActualHeight);
        }
    }
}
