using System;
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
using ReportingDesigner.Models;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Controls.Diagrams.Extensions;

namespace ReportingDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
