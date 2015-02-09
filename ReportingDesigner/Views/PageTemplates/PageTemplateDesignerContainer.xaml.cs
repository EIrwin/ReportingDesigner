using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using ReportingDesigner.Controls;
using ReportingDesigner.Data;
using ReportingDesigner.Events;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Extensibility.Serialization;
using ReportingDesigner.Models;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views.PageTemplates;
using Telerik.Windows.Controls;
using ViewModelBase = ReportingDesigner.ViewModels.ViewModelBase;

namespace ReportingDesigner.Views
{
    public partial class PageTemplateDesignerContainer : RadDiagram
    {
        private PageTemplateViewModel _viewModel;

        public PageTemplateViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        private readonly List<MarginShape> _marginShapes;

        public EventHandler<ReportControlClickedEventArgs> ControlClicked { get; set; }

        public PageTemplateDesignerContainer()
        {
            _marginShapes = new List<MarginShape>();

            InitializeComponent();

            this.Loaded += InitializePageTemplate;

            DesignerCanvas.DataContext = DataContext;
            DesignerCanvas.PreviewDrop += DesignerCanvas_PreviewDrop;
            DesignerCanvas.AdditionalContentActivated += DesignerCanvas_AdditionalContentActivated;
            DesignerCanvas.ShapeSerialized += DesignerCanvas_ShapeSerialized;
            DesignerCanvas.ShapeDeserialized += DesignerCanvas_ShapeDeserialized;
        }

        private void DesignerCanvas_ShapeSerialized(object sender, Telerik.Windows.Controls.Diagrams.ShapeSerializationRoutedEventArgs e)
        {
            if (e.Shape is ISerializable)
            {
                var serializationData = ((ISerializable) e.Shape).Serialize();

                foreach (var item in serializationData)
                    e.SerializationInfo["VM." + item.Key] = item.Value;
            }
        }

        private void DesignerCanvas_ShapeDeserialized(object sender, Telerik.Windows.Controls.Diagrams.ShapeSerializationRoutedEventArgs e)
        {
            if (e.Shape is ISerializable)
            {
                //grab type metadata from SerializationInfo object
                var viewModelTypeInfo = e.SerializationInfo[SerializablePropertyNames.ViewModelType];
                Type viewModelType = Type.GetType(viewModelTypeInfo.ToString());

                //initialize view model from deserialized property values
                var viewModel = (ReportControlViewModel) Activator.CreateInstance(viewModelType, new object[]{null,null});
                viewModel.Position = e.Shape.Position;
                ((FrameworkElement)e.Shape).DataContext = viewModel;

                //update view model with deserialized property values
                var info = new SerializationInfo(e.SerializationInfo);
                ((ISerializable) e.Shape).Deserialize(info);
            }
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

            PageViewModel pageViewModel = ViewModel.Pages.First();

            var viewModel = (ReportControlViewModel)Activator.CreateInstance(item.ViewModelType, new object[] {null,pageViewModel });
            viewModel.Position = e.GetPosition(this.DesignerCanvas);
            viewModel.ViewType = item.ViewType;
            viewModel.SettingsViewType = item.SettingsViewType;

            pageViewModel.Controls.Add(viewModel);

            var view = (ReportControlView)Activator.CreateInstance(item.ViewType);
            view.DataContext = viewModel;
            this.DesignerCanvas.AddShape(view);
        }

        private void InitializePageTemplate(object sender,EventArgs e)
        {
            DesignerCanvas.Clear();

            var pageFormat = new PageFormat();
            pageFormat.PageSize = new PageSize(Convert.ToDouble(DefaultFormats.Height),Convert.ToDouble(DefaultFormats.Width));
            pageFormat.UnitType = UnitType.Millimeters;

            //Step 1: Initialize FormatSettings Object
            var settings = FormatSettingsFactory.CreateFormatSettings(PageOrientation.Portrait, 300,pageFormat,new Thickness(Convert.ToDouble(DefaultFormats.Margin)));

            //Step 2: Initialize PageTemplateViewModel object
            ViewModel = ((PageTemplateViewModel) this.DataContext) == null
                            ? new PageTemplateViewModel(settings)
                            : (PageTemplateViewModel) this.DataContext;

            if (DesignerCanvas.DataContext == null) 
                DesignerCanvas.DataContext = DataContext;

            //Step 3: Initialize PageViewModel
            var pageViewModel = new PageViewModel(0, ViewModel.FormatSettings.PageFormat.PageSize.Height, 1);

            //Step 4: Initialize Margin
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
            DesignerCanvas.IsBackgroundSurfaceVisible = ViewModel.ShowGridLines;    //only temporary 
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

        public void SavePageTemplate()
        {
            string data = DesignerCanvas.Save();

            var dataContext = (PageTemplateViewModel) DataContext;
            var pageTemplate = new PageTemplate()
                {
                    Name = dataContext.Name,
                    Data = data
                };
            var pageTemplateRepository = new PageTemplateRepository();
            pageTemplateRepository.Insert(pageTemplate);
        }

        public void NewPageTemplate()
        {
            var window = new PageTemplateCreationOptionsWindow();
            window.OptionsSelected += (o, e) =>
                {
                    //we can load new page template and viewmodel here
                };
            window.ShowDialog();
        }

        public void LoadPageTemplate()
        {
            var window = new PageTemplateSelectWindow();
            window.TemplateSelected += (o, e) =>
                {
                    DesignerCanvas.Clear();
                    DesignerCanvas.Load(e.PageTemplate.Data);
                };
            window.ShowDialog();
        }
    }
}
