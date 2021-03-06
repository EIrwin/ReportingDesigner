﻿using System;
using System.Linq;
using System.Windows;
using ReportingDesigner.Events;
using ReportingDesigner.Extensibility.Services;
using ReportingDesigner.Properties;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using ISerializable = ReportingDesigner.Extensibility.Serialization.ISerializable;
using SerializationInfo = ReportingDesigner.Extensibility.Serialization.SerializationInfo;

namespace ReportingDesigner.Extensibility.PageTemplates
{
    public class AllPagesApplicationStrategy:TemplateApplicationStrategy
    {
        public override void ApplyTemplate(TemplateApplicationEventArgs args, DesignerContainer designer)
        {
            if (designer == null)
                throw new ArgumentNullException("designer");

            if (args == null)
                throw new ArgumentNullException("args");


            var reportViewModel = designer.ViewModel;

            foreach (var pageViewModel in reportViewModel.Pages)
            {
                //load into a diagram so we can handle
                //shape deserialization separately
                var templateDiagram = new RadDiagram();
                templateDiagram.ShapeDeserialized += (o, e) =>
                    {
                        if (e.Shape is ISerializable)
                        {
                            //grab type metadata from SerializationInfo object4
                            var viewModelTypeInfo = e.SerializationInfo["VM.ViewModelType"];
                            Type viewModelType = Type.GetType(viewModelTypeInfo.ToString());

                            //initialize view model from deserialized property values
                            var viewModel =
                                (ReportControlViewModel)
                                Activator.CreateInstance(viewModelType, new object[] {null, null});
                            viewModel.Position = new Point(e.Shape.Position.X, e.Shape.Position.Y + pageViewModel.Top);
                            ((FrameworkElement) e.Shape).DataContext = viewModel;

                            //update view model with deserialized property values
                            var info = new SerializationInfo(e.SerializationInfo);
                            ((ISerializable) e.Shape).Deserialize(info);

                            pageViewModel.Controls.Add(viewModel);
                            pageViewModel.PageTemplate = args.PageTemplate;

                            e.Shape.IsEnabled = Settings.Default.AllowTemplateControlEdit;
                            e.Shape.Position = viewModel.Position;

                            designer.DesignerCanvas.AddShape(e.Shape);

                            if (Settings.Default.AllowTemplateControlEdit)
                            {
                                ((ReportControlView) e.Shape).PreviewMouseLeftButtonDown += (obj, a) =>
                                    {
                                        var view = (ReportControlView) obj;
                                        //we want to specify a draggable area
                                        //reflect the current page dimensions
                                        var draggableArea = new Rect(new Point(0, pageViewModel.Top),
                                                                     new Size(
                                                                         designer.ViewModel.FormatSettings.PageFormat
                                                                                 .PageSize.Width,
                                                                         designer.ViewModel.FormatSettings.PageFormat
                                                                                 .PageSize.Height));

                                        //we can set the ControlDraggingService as the 
                                        //IDraggingService to be used when dragged
                                        IDraggingService draggingService =
                                            new ControlDraggingService(designer.DesignerCanvas, draggableArea, view);
                                        designer.DesignerCanvas.ServiceLocator.Register(draggingService);
                                    };
                            }
                        }

                    };
                templateDiagram.Load(args.PageTemplate.Data);
            }
        }

        public override void UnapplyTemplate(TemplateApplicationEventArgs args, DesignerContainer designer)
        {
            if (designer == null)
                throw new ArgumentNullException("designer");

            if (args == null)
                throw new ArgumentNullException("args");

            foreach (var pageViewModel in designer.ViewModel.Pages)
            {
                //if the page cannot be identified
                //we just dont want to do anything
                if (pageViewModel == null) return;

                //remove all of the controls that
                //are located within the dimensions
                //of the page that was defined
                designer.DesignerCanvas.Shapes
                        .Where(
                            shape => shape.Position.Y >= pageViewModel.Top && shape.Position.Y <= pageViewModel.Bottom)
                        .ToList()
                        .ForEach(shape =>
                        {
                            //We only want to remove report controls
                            //witht he IsTemplateControl flag set to true
                            //Controls such as MarginShape will have a non
                            //ReportControlViewModel type DataContext
                            var viewModel = ((FrameworkElement)shape).DataContext;
                            if (viewModel is ReportControlViewModel &&
                                ((ReportControlViewModel)viewModel).IsTemplateControl)
                            {
                                designer.DesignerCanvas.RemoveShape(shape);
                                pageViewModel.Controls.Remove((ReportControlViewModel)viewModel);
                            }
                        });
            }
        }
    }
}