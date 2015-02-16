using System;
using System.Windows;
using ReportingDesigner.Events;
using ReportingDesigner.ViewModels;
using ReportingDesigner.Views;
using Telerik.Windows.Controls;
using ISerializable = ReportingDesigner.Extensibility.Serialization.ISerializable;
using SerializationInfo = ReportingDesigner.Extensibility.Serialization.SerializationInfo;

namespace ReportingDesigner.Extensibility.PageTemplates
{
    public class CurrentPageApplicationStrategy : TemplateApplicationStrategy
    {
        public override void ApplyTemplate(TemplateApplicationEventArgs args, DesignerContainer designer)
        {
            if (designer == null)
                throw new ArgumentNullException("designer");

            if (args == null)
                throw new ArgumentNullException("args");

            //grab current page view model
            var pageViewModel = designer.GetCurrentPage();

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