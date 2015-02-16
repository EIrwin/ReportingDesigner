﻿using System;
using System.Linq;
using System.Windows;
using ReportingDesigner.Events;
using ReportingDesigner.Extensibility.Serialization;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views;
using Telerik.Windows.Controls;

namespace ReportingDesigner.Extensibility.PageTemplates
{
    public class SinglePageApplicationStrategy:TemplateApplicationStrategy
    {
        public override void ApplyTemplate(TemplateApplicationEventArgs args,DesignerContainer designer)
        {
            if (designer == null)
                throw new ArgumentNullException("designer");

            if (args == null)
                throw new ArgumentNullException("args");


            var reportViewModel = designer.ViewModel;

            
            //grab current page view model
            var pageViewModel = reportViewModel.Pages.FirstOrDefault(p => p.PageNumber == args.Page);

            //if the page cannot be identified
            //we just dont want to do anything
            if (pageViewModel == null) return;

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
                    var viewModel = (ReportControlViewModel)Activator.CreateInstance(viewModelType, new object[] { null, null });
                    viewModel.Position = new Point(e.Shape.Position.X, e.Shape.Position.Y + pageViewModel.Top);
                    ((FrameworkElement)e.Shape).DataContext = viewModel;

                    //update view model with deserialized property values
                    var info = new SerializationInfo(e.SerializationInfo);
                    ((ISerializable)e.Shape).Deserialize(info);

                    pageViewModel.Controls.Add(viewModel);
                    pageViewModel.PageTemplate = args.PageTemplate;

                    e.Shape.IsEnabled = false;
                    e.Shape.Position = viewModel.Position;

                    designer.DesignerCanvas.AddShape(e.Shape);
                }

            };
            templateDiagram.Load(args.PageTemplate.Data);
        }
    }
}