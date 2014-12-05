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
using ReportingDesigner.Commands;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

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

    }
}
