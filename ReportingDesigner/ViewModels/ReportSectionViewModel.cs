using System.Collections.Generic;

namespace ReportingDesigner.ViewModels
{
    public class ReportSectionViewModel:ReportItemViewModel
    {
        private List<ReportControlViewModel> _controls;

        public List<ReportControlViewModel> Controls
        {
            get { return _controls; }
            set
            {
                _controls = value;
            }
        }

        public ReportSectionViewModel()
        {
            Controls = new List<ReportControlViewModel>();
        }
    }
}