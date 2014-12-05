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
    }
}
