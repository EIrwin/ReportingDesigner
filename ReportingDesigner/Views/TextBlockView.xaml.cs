using System;
using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Extensibility.Serialization;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Views
{
    public partial class TextBlockView : ReportControlView
    {
        private TextBlockViewModel _viewModel
        {
            get { return (TextBlockViewModel) DataContext; }
        }

        public TextBlockView()
        {
            InitializeComponent();
        }

        public override IDictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
                {
                    {"VM.Text",_viewModel.Text},
                    {"VM.ViewModelType",_viewModel.GetType().ToString()},
                    {"VM.SettingsViewType",typeof(TextBlockSettingsView).ToString()},
                    {"VM.IsTemplateControl",_viewModel.IsTemplateControl.ToString()}
                };
        }

        public override void Deserialize(SerializationInfo info)
        {
            _viewModel.Text = info["VM.Text"];
            _viewModel.SettingsViewType = Type.GetType(info["VM.SettingsViewType"]);
            _viewModel.IsTemplateControl = bool.Parse(info["VM.IsTemplateControl"]);
        }
    }
}
