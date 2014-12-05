using Telerik.Windows.Controls;

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
            DesignerCan.IsBackgroundSurfaceVisible = !DesignerCan.IsBackgroundSurfaceVisible;
        }

        public void ExportToBmp()
        {
            this.Export("Bmp");
        }

        public void ExportToPng()
        {
            this.Export("Png");
        }

    }
}
