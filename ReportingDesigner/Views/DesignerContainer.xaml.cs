using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using ReportingDesigner.Controls;
using Telerik.Windows.Controls;
using Size = System.Drawing.Size;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for DesignerContainer.xaml
    /// </summary>
    public partial class DesignerContainer : RadDiagram
    {
        public DesignerContainer()
        {
            InitializeComponent();
            InitializeNewPagePanes();
        }

        private void InitializeNewPagePanes()
        {
            //Grab Location Parameters
            double x = DesignerCanvasShape.Position.X;
            double y = DesignerCanvasShape.Position.Y;

            //Position 'Add Page Before' Pane
            AddPageBeforePane addPageBeforePane = new AddPageBeforePane();
            addPageBeforePane.Position = new Point(x, y - 50);
            Container.AddShape(addPageBeforePane);

            //Position 'Add Page After' Pane
            AddPageAfterPane addPageAfterPane = new AddPageAfterPane();
            addPageAfterPane.Position = new Point(x, y + DesignerCanvasShape.Height + 25);
            Container.AddShape(addPageAfterPane);
        }

        public void ToggleGridLines()
        {
            DesignerCanvas.IsBackgroundSurfaceVisible = !DesignerCanvas.IsBackgroundSurfaceVisible;
        }

        public void ChangePageSize(Size size)
        {
            
        }

        public void AddNewPage()
        {
            
        }
    }
}
