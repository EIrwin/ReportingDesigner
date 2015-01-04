using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
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
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        private readonly List<MarginShape> _marginShapes;

        public DesignerContainer()
        {
            _marginShapes = new List<MarginShape>();

            InitializeComponent();
            InitializeNewReport();
        }

        private void InitializeNewReport()
        {
            //TODO: This needs to be put through a factory
            var pageFormat = new PageFormat();
            pageFormat.PageSize = new PageSize(Convert.ToDouble(DefaultFormats.Height),Convert.ToDouble(DefaultFormats.Width));
            pageFormat.UnitType = UnitType.Millimeters;

            //Step 1: Initialize FormatSettings Object
            var settings = FormatSettingsFactory.CreateFormatSettings(PageOrientation.Portrait, 300,pageFormat,new Thickness(Convert.ToDouble(DefaultFormats.Margin)));

            //Step 2: Initialize Report Model with FormatSettings
            var report = new Report();

            //Step 3: Initialize ReportViewModel object
            ViewModel = new ReportViewModel(report, settings);

            //Step 4: Initialize First Page ViewModel
            var pageViewModel = new PageViewModel(0, ViewModel.FormatSettings.PageFormat.PageSize.Height, 1);

            //Step 5: Initialize Margin for First Page
            var marginShape = new MarginShape
                {
                    Position = new Point(ViewModel.FormatSettings.Margin.Left, ViewModel.FormatSettings.Margin.Top),
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
                    var pageViewModel = (PageViewModel) marginShape.DataContext;
                    marginShape.Position = new Point(ViewModel.FormatSettings.Margin.Left,pageViewModel.Top + ViewModel.FormatSettings.Margin.Top);
                    marginShape.Height = ViewModel.FormatSettings.PageFormat.PageSize.Height - (ViewModel.FormatSettings.Margin.Top + ViewModel.FormatSettings.Margin.Bottom);
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
            var editMarginsWindow = new EditMarginsWindow(ViewModel.FormatSettings.Margin);
            editMarginsWindow.MarginChanged += (o, args) =>
            {
                ViewModel.FormatSettings.Margin = args.Margin;//?
                UpdateMarginsShape(o, args);
            };
            editMarginsWindow.Show();
        }

        public void AddFirstPage()
        {
            var pageViewModel = new PageViewModel(0, ViewModel.FormatSettings.PageFormat.PageSize.Height, 1);

            var marginShape = new MarginShape
                {
                    Position = new Point(ViewModel.FormatSettings.Margin.Left, ViewModel.FormatSettings.Margin.Top),
                    DataContext = pageViewModel
                };

            marginShape.Loaded += UpdateMarginsShape;

            //We need to clear the original 
            //page collection so we can re-initialize
            //it with updated dimensions and positions
            ViewModel.Pages.Clear();

            //Adjust margin positions
            _marginShapes.ForEach(margin =>
                {
                    var page = (PageViewModel)margin.DataContext;
                    var newViewModel =
                        new PageViewModel(page.Top + ViewModel.FormatSettings.PageFormat.PageSize.Height + 1,
                                          page.Bottom + ViewModel.FormatSettings.PageFormat.PageSize.Height + 1,
                                          page.PageNumber + 1);

                    ViewModel.Pages.Add(newViewModel);
                    margin.DataContext = newViewModel;
                    margin.Position = new Point(margin.Position.X, margin.Position.Y + ViewModel.FormatSettings.PageFormat.PageSize.Height + 1);
                });

            ViewModel.Pages.Add(pageViewModel);
            _marginShapes.Add(marginShape);

            DesignerCanvas.AddShape(marginShape);

            //The height of the canvas is equivalent to the 'bottom' of the last page
            DesignerCanvasShape.Height = ViewModel.Pages.Max(p => p.Bottom);
        }

        public void AddLastPage()
        {
            var lastPage = ViewModel.Pages.Last();

            var pageViewModel = new PageViewModel(lastPage.Bottom + 1, (lastPage.Bottom + 1) +
                                                  ViewModel.FormatSettings.PageFormat.PageSize.Height, lastPage.PageNumber + 1);

            var marginShape = new MarginShape
            {
                Position = new Point(ViewModel.FormatSettings.Margin.Left, pageViewModel.Top + ViewModel.FormatSettings.Margin.Top),
                DataContext = pageViewModel
            };

            marginShape.Loaded += UpdateMarginsShape;

            ViewModel.Pages.Add(pageViewModel);
            _marginShapes.Add(marginShape);

            DesignerCanvas.AddShape(marginShape);

            //Update designer canvas height to appropriate 'bottom' value
            DesignerCanvasShape.Height = pageViewModel.Bottom;
        }
    }
}
