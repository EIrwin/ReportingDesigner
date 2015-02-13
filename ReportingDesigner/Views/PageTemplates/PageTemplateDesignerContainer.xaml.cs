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
using ReportingDesigner.ViewModels.PageTemplates;
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
                    e.SerializationInfo[item.Key] = item.Value;
            }
        }

        private void DesignerCanvas_ShapeDeserialized(object sender, Telerik.Windows.Controls.Diagrams.ShapeSerializationRoutedEventArgs e)
        {
            if (e.Shape is ISerializable)
            {
                //grab type metadata from SerializationInfo object4
                var viewModelTypeInfo = e.SerializationInfo["VM.ViewModelType"];
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
            viewModel.IsTemplateControl = true; //very important

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
            var pageViewModel = new PageViewModel(0, ViewModel.PageTemplate.FormatSettings.PageFormat.PageSize.Height, 1);

            //Step 4: Initialize Margin
            var marginShape = new MarginShape
                {
                    Position = new Point(ViewModel.PageTemplate.FormatSettings.Margin.Left, ViewModel.PageTemplate.FormatSettings.Margin.Top),
                    DataContext = pageViewModel
                };

            marginShape.Loaded += UpdateMarginsShape;

            _marginShapes.Add(marginShape);
            ViewModel.Pages.Add(pageViewModel);

            DesignerCanvas.AddShape(marginShape);

            //If this is an existing template, we want to load
            //the previous template from the serialized xml.
            if(!string.IsNullOrEmpty(ViewModel.PageTemplate.Data))
                DesignerCanvas.Load(ViewModel.PageTemplate.Data);
        }

        private void UpdateMarginsShape(object sender, EventArgs e)
        {
            _marginShapes.ForEach(marginShape =>
                {
                    var pageViewModel = (PageViewModel) marginShape.DataContext;
                    marginShape.Position = new Point(ViewModel.PageTemplate.FormatSettings.Margin.Left,pageViewModel.Top + ViewModel.PageTemplate.FormatSettings.Margin.Top);
                    marginShape.Height = ViewModel.PageTemplate.FormatSettings.PageFormat.PageSize.Height - (ViewModel.PageTemplate.FormatSettings.Margin.Top + ViewModel.PageTemplate.FormatSettings.Margin.Bottom);
                    marginShape.Width = DesignerCanvas.ActualWidth - (ViewModel.PageTemplate.FormatSettings.Margin.Left + ViewModel.PageTemplate.FormatSettings.Margin.Right);
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

            //since the binding is not working here, we need to
            //change the visibility of each of margins manually
            DesignerCanvas.Shapes.Where(p => p is MarginShape).ToList().ForEach(shape =>
                {
                    shape.Visibility = ViewModel.ShowMarginLines ? Visibility.Visible : Visibility.Hidden;
                });

            //we want to keep the margin shapes in sync
            //with the actual shapes in case they are referenced elsewhere
            _marginShapes.ForEach(marginShape =>
            {
                marginShape.Visibility = ViewModel.ShowMarginLines ? Visibility.Visible : Visibility.Hidden;
            });
        }

        public void EditMargins()
        {
            var editMarginsWindow = new EditMarginsWindow(ViewModel.PageTemplate.FormatSettings.Margin);
            editMarginsWindow.MarginChanged += (o, args) =>
            {
                ViewModel.PageTemplate.FormatSettings.Margin = args.Margin;
                UpdateMarginsShape(o, args);
            };
            editMarginsWindow.Show();
        }

        public void SavePageTemplate()
        {
            var viewModel = new PageTemplateSaveViewModel()
                {
                    PageTemplate = ViewModel.PageTemplate
                };

            viewModel.PageTemplate.Data = DesignerCanvas.Save();
            var window = new PageTemplateSaveWindow(viewModel);
            window.ShowDialog();
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
