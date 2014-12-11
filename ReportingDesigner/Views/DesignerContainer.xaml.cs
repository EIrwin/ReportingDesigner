using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
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
