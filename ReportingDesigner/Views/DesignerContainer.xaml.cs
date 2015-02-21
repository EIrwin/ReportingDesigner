using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MongoDB.Bson;
using MongoDB.Driver;
using ReportingDesigner.Controls;
using ReportingDesigner.Events;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Extensibility.PageTemplates;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views.PageTemplates;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using ViewModelBase = ReportingDesigner.ViewModels.ViewModelBase;

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

        private readonly List<PageBreakShape> _pageBreakShapes;

        public EventHandler<ReportControlClickedEventArgs> ControlClicked { get; set; }

        public DesignerContainer()
        {
            _marginShapes = new List<MarginShape>();
            _pageBreakShapes = new List<PageBreakShape>();

            InitializeComponent();
            InitializeNewReport();

            DesignerCanvas.DataContext = DataContext;
            DesignerCanvas.PreviewDrop += DesignerCanvas_PreviewDrop;
            DesignerCanvas.AdditionalContentActivated += DesignerCanvas_AdditionalContentActivated;


            //The following is only temporary
            DesignerCanvas.DragOver += (o, e) =>
                {

                    var position = e.GetPosition(this.DesignerCanvas);
                    PageViewModel targetPage = GetPage(position);
                    
                };
        }


        private void DesignerCanvas_AdditionalContentActivated(object sender, Telerik.Windows.Controls.Diagrams.AdditionalContentActivatedEventArgs e)
        {
            var view = (ViewBase)e.ContextItems.First();

            if (view != null)
            {
                var model = (ViewModelBase)view.DataContext;
                this.DesignerCanvas.SettingPane.DataContext = model;
            }
            
        }

        private void DesignerCanvas_PreviewDrop(object sender, DragEventArgs e)
        {
            var item = (ToolboxItemViewModel)e.Data.GetData(e.Data.GetFormats()[0]);

            PageViewModel pageViewModel = GetPage(e.GetPosition(this.DesignerCanvas));

            ReportControlViewModel viewModel = (ReportControlViewModel)Activator.CreateInstance(item.ViewModelType, new object[] {ViewModel,pageViewModel });
            viewModel.Position = e.GetPosition(this.DesignerCanvas);
            viewModel.ViewType = item.ViewType;
            viewModel.SettingsViewType = item.SettingsViewType;

            pageViewModel.Controls.Add(viewModel);

            ReportControlView view = (ReportControlView)Activator.CreateInstance(item.ViewType);
            view.DataContext = viewModel;

            var draggableArea = new Rect(new Point(0, pageViewModel.Top),
                                         new Size(ViewModel.FormatSettings.PageFormat.PageSize.Width,
                                                  ViewModel.FormatSettings.PageFormat.PageSize.Height));

            IDraggingService draggingService =  new Extensibility.Services.TemplateControlDraggingService(this.DesignerCanvas,draggableArea,view);
            DesignerCanvas.ServiceLocator.Register(draggingService);
            this.DesignerCanvas.AddShape(view);
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

            UpdatePageBreaks();
        }

        private void UpdatePageBreaks()
        {
            _pageBreakShapes.ForEach(pageBreak => DesignerCanvas.RemoveShape(pageBreak));
            _pageBreakShapes.Clear();

            ViewModel.Pages.OrderBy(page => page.PageNumber).ToList().ForEach(page =>
                {
                    PageBreakShape pageBreak = new PageBreakShape();
                    pageBreak.Position = new Point(0, page.Bottom + 1);
                    pageBreak.Width = ViewModel.FormatSettings.PageFormat.PageSize.Width;

                    _pageBreakShapes.Add(pageBreak);

                    DesignerCanvas.AddShape(pageBreak);
                });
        }

        public PageViewModel GetCurrentPage()
        {
            //The following logic is for
            //determining the current page number
            double bottom = this.Viewport.Bottom;
            double top = this.Viewport.Top;

            double middle = (bottom - top) / 2;
            double threshold = top + middle;

            PageViewModel currentPage = null;

            ViewModel.Pages.ForEach(p =>
            {
                if (p.Top <= threshold && p.Bottom >= threshold)
                    currentPage = p;
            });

            return currentPage;
        }

        public PageViewModel GetPage(Point location)
        {
            //The following logic is for
            //determining the page number of
            //the specified location

            PageViewModel page = null;

            ViewModel.Pages.ForEach(p =>
            {
                if (p.Top <= location.Y && p.Bottom >= location.Y)
                    page = p;
            });

            return page;
        }

        public PageViewModel GetPage(int pageNumber)
        {
            return ViewModel.Pages.FirstOrDefault(p => p.PageNumber == pageNumber);
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

        public void TogglePageBreaks()
        {
            if (_pageBreakShapes.Any())
            {
                _pageBreakShapes.ForEach(pageBreak => DesignerCanvas.RemoveShape(pageBreak));
                _pageBreakShapes.Clear();
            }
            else
            {
                UpdatePageBreaks();
            }

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

        public void AddPageBefore()
        {
            //var currentPage = GetCurrentPage();

            //ViewModel.Pages.Where(p => p.PageNumber <= currentPage.PageNumber)
            //         .ToList()
            //         .ForEach(page =>
            //             {

            //             });

            //var pageViewModel = new PageViewModel();

            //var marginShape = new MarginShape()
            //    {
            //        Background = new SolidColorBrush(Colors.Blue),
            //    };

            //marginShape.Loaded += UpdateMarginsShape;

            //ViewModel.Pages.Add(pageViewModel);
            //_marginShapes.Add(marginShape);

            //DesignerCanvas.AddShape(marginShape);

            ////The height of the canvas is equivalent to the 'bottom' of the last page
            //DesignerCanvasShape.Height = ViewModel.Pages.Max(p => p.Bottom);
        }

        public void AddPageAfter()
        {
            
        }

        public void PinControl()
        {
            Guid pinId = Guid.NewGuid();

            var control = this.DesignerCanvas.SelectedItem as ViewBase;

            if (control == null) return;

            var viewModel = (ReportControlViewModel) control.DataContext;
            viewModel.PinID = pinId;
            viewModel.Report.Pages
                .OrderBy(p => p.PageNumber)
                .Skip(viewModel.Page.PageNumber)
                .ToList()
                .ForEach(page =>
                    {
                        var model = (ReportControlViewModel)Activator.CreateInstance(viewModel.GetType(), new object[] {viewModel.Report, page});
                        model.PinID = pinId;
                        model.Position = new Point(viewModel.Position.X, viewModel.Position.Y + page.Top);
                        model.SettingsViewType = viewModel.SettingsViewType;
                        model.ViewType = viewModel.ViewType;

                        page.Controls.Add(model);

                        var view = (ReportControlView)Activator.CreateInstance(model.ViewType);
                        view.DataContext = model;
                        view.Position = model.Position;
                        DesignerCanvas.AddShape(view);
                    });
        
        }
        
        public void UnpinControl()
        {

        }

        public void CreatePageTemplate()
        {
            var window = new PageTemplateWindow();
            window.ShowDialog();
        }

        public void EditPageTemplate()
        {
            var window = new PageTemplateSelectWindow();
            window.TemplateSelected += (o, e) =>
                {
                    var viewModel = new PageTemplateViewModel(e.PageTemplate);
                    var templateWindow = new PageTemplateWindow(viewModel);
                    templateWindow.ShowDialog();
                };
            window.ShowDialog();
        }

        public void ApplyPageTemplate()
        {
            var window = new ApplyPageTemplateWindow();
            window.ApplyTemplateInit += (o, e) =>
                {
                    var strategy = TemplateApplicationStrategyFactory.Create(e.TemplateApplicationMethod);
                    strategy.ApplyTemplate(e, this);
                };
            window.ShowDialog();
        }

        public void UnapplyPageTemplate()
        {
            var window = new UnapplyPageTemplateWindow();
            window.ApplyTemplateInit += (o, e) =>
                {
                    var strategy = TemplateApplicationStrategyFactory.Create(e.TemplateApplicationMethod);
                    strategy.UnapplyTemplate(e, this);
                };
            window.ShowDialog();
        }
    }
}
