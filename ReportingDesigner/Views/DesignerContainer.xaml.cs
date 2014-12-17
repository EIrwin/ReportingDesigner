using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using ReportingDesigner.Controls;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;
using Telerik.Windows.Controls;
using Size = System.Drawing.Size;

namespace ReportingDesigner.Views
{
    /// <summary>
    /// Interaction logic for DesignerContainer.xaml
    /// </summary>
    public partial class DesignerContainer : RadDiagram
    {
        private ReportViewModel _viewModel;
        public ReportViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        private AddPageBeforePane _addPageBeforePane;
        private AddPageAfterPane _addPageAfterPane;

        public DesignerContainer()
        {
            InitializeComponent();
            InitializeNewPagePanes();
            InitializeReport();
        }

        private void InitializeReport()
        {
            //Step 1: Initialize FormatSettings Object
            //This can be done using a factory eventually
            //Assume we have retrieved instance to type
            //of factory that we need to use
            FormatSettingsFactory factory = new LetterFormatSettingsFactory();
            FormatSettings settings = factory.CreateFormatSettings(UnitType.Points,PageOrientation.Portrait);

            //Step 2: Initialize Report Model with FormatSettings
            var report = new Report();

            //Step 3: Initialize ReportViewModel object
            //with the format settings and report model
            ViewModel = new ReportViewModel(report,settings);
        }

        private void InitializeNewPagePanes()
        {
            //Grab Location Parameters
            double x = DesignerCanvasShape.Position.X;
            double y = DesignerCanvasShape.Position.Y;

            //Check if pane already exists, remove if it does
            if (Container.Shapes.Any(p => Equals(p, _addPageBeforePane)))
                Container.RemoveShape(_addPageBeforePane);

            //Check if pane already exists, remove if it does
            if (Container.Shapes.Any(p => Equals(p, _addPageAfterPane)))
                Container.RemoveShape(_addPageAfterPane);

            //Position 'Add Page Before' Pane
            _addPageBeforePane = new AddPageBeforePane();
            _addPageBeforePane.Position = new Point(x, y - 50);
            Container.AddShape(_addPageBeforePane);

            //Position 'Add Page After' Pane
            _addPageAfterPane = new AddPageAfterPane();
            _addPageAfterPane.Position = new Point(x, y + DesignerCanvasShape.Height + 25);
            Container.AddShape(_addPageAfterPane);
        }

        public void ToggleGridLines()
        {
            ViewModel.ShowGridLines = !ViewModel.ShowGridLines;
        }

        //THE FOLLOWING IS ONLY TEMPORARY
        public void AddNewPage()
        {
            //For now we are just going to add a page to the end of the page
            DesignerCanvasShape.Height = DesignerCanvasShape.Height*2;

            //We need to reinitialize the add page panes
            InitializeNewPagePanes();
        }
    }
}
