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
                    {"Text",_viewModel.Text},
                    {SerializablePropertyNames.ViewModelType,_viewModel.GetType().ToString()}
                };
        }

        public override void Deserialize(SerializationInfo info)
        {
            _viewModel.Text = info["VM.Text"];
        }
    }
}
