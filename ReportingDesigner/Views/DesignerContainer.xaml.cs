using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ReportingDesigner.Controls;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;
using Telerik.Windows.Controls;

namespace ReportingDesigner.Views
{
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

        private const double DefaultMargin = 40;
        private const double DefaultPageHeight = 750;
        private List<MarginShape> _marginShapes; 

        public DesignerContainer()
        {
            _marginShapes = new List<MarginShape>();

            InitializeComponent();
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

        private void UpdateMarginsShape(object sender, EventArgs e)
        {
            _marginShapes.ForEach(marginShape =>
            {
                var pageViewModel = (PageViewModel)marginShape.DataContext;

                //TODO: Do we want to update position here or upstream?
                marginShape.Position = new Point(ViewModel.FormatSettings.Margin.Left, pageViewModel.Top + ViewModel.FormatSettings.Margin.Top);
                marginShape.Height = DefaultPageHeight - (ViewModel.FormatSettings.Margin.Top + ViewModel.FormatSettings.Margin.Bottom);
                marginShape.Width = DesignerCanvas.ActualWidth - (ViewModel.FormatSettings.Margin.Left + ViewModel.FormatSettings.Margin.Right);
            });
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

        public void AddFirstPage()
        {
            
        }

        public void AddLastPage()
        {
            var lastPage = ViewModel.Pages.Last();

            var pageViewModel = new PageViewModel(lastPage.Bottom + 1, (lastPage.Bottom + 1) + DefaultPageHeight)
            {
                PageNumber = lastPage.PageNumber + 1
            };

            var marginShape = new MarginShape
            {
                //TODO: Do we want to update position here or upstream?
                Position = new Point(ViewModel.FormatSettings.Margin.Left, pageViewModel.Top + ViewModel.FormatSettings.Margin.Top),
                DataContext = pageViewModel
            };

            marginShape.Loaded += UpdateMarginsShape;

            ViewModel.Pages.Add(pageViewModel);
            _marginShapes.Add(marginShape);

            DesignerCanvas.AddShape(marginShape);

            DesignerCanvasShape.Height = pageViewModel.Bottom;
        }

        
    }
}
