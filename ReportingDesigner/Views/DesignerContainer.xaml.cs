using System;
using System.Collections.Generic;
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

        //temorary for margin integration
        private const double DefaultMargin = 40;
        private const double DefaultPageHeight = 750;
        private List<MarginShape> _marginShapes; 


        public DesignerContainer()
        {
            _marginShapes = new List<MarginShape>();

            InitializeComponent();
            InitializeNewPagePanes();
            InitializeNewReport();
        }

        private void InitializeNewReport()
        {
            //Step 1: Initialize FormatSettings Object
            FormatSettings settings = FormatSettingsFactory.CreateFormatSettings(PageOrientation.Portrait, 300, null,new Thickness(DefaultMargin));

            //Step 2: Initialize Report Model with FormatSettings
            var report = new Report();

            //Step 3: Initialize ReportViewModel object
            ViewModel = new ReportViewModel(report,settings);


            //the following section is temporary for margin integration
            var pageViewModel = new PageViewModel(0,DefaultPageHeight)
            {
                PageNumber = 1,
            };

            var marginShape = new MarginShape
            {
                Position = new Point(ViewModel.FormatSettings.Margin.Left,ViewModel.FormatSettings.Margin.Top),
                DataContext = pageViewModel
            };
            marginShape.Loaded += UpdateMarginsShape;

            _marginShapes.Add(marginShape);
            ViewModel.Pages.Add(pageViewModel);

            DesignerCanvas.AddShape(marginShape);
        }

        //The following is temporary for margin integration
        private void UpdateMarginsShape(object sender, EventArgs e)
        {
            _marginShapes.ForEach(marginShape =>
            {
                var pageViewModel = (PageViewModel)marginShape.DataContext;

                marginShape.Position = new Point(ViewModel.FormatSettings.Margin.Left, pageViewModel.Top + ViewModel.FormatSettings.Margin.Top);
                marginShape.Height = DesignerCanvas.ActualHeight - (ViewModel.FormatSettings.Margin.Top + ViewModel.FormatSettings.Margin.Bottom);
                marginShape.Width = DesignerCanvas.ActualWidth - (ViewModel.FormatSettings.Margin.Left + ViewModel.FormatSettings.Margin.Right);
            });
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

        public void ToggleMarginLines()
        {
            ViewModel.ShowMarginLines = !ViewModel.ShowMarginLines;

            _marginShapes.ForEach(marginShape =>
            {
                marginShape.Visibility = ViewModel.ShowMarginLines ? Visibility.Visible : Visibility.Hidden;

            });
        }

        public void EditMargins()
        {
            throw new NotImplementedException();
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
