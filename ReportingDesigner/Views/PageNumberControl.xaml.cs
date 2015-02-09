using System.Collections.Generic;
using System.Windows;
using ReportingDesigner.Extensibility.Serialization;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner.Views
{
    public partial class PageNumberControl : ReportControlView
    {
        private PageNumberControlViewModel _viewModel 
        {
            get { return (PageNumberControlViewModel)DataContext; }
        }

        public PageNumberControl()
        {
            InitializeComponent();
        }

        public override IDictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
                {
                    {"PageNumber", _viewModel.PageNumber.ToString()},
                    {SerializablePropertyNames.ViewModelType, typeof (PageNumberControlViewModel).ToString()}
                };
        }

        public override void Deserialize(SerializationInfo info)
        {
            _viewModel.PageNumber = int.Parse(info["VM.PageNumber"]);
        }
    }
}
