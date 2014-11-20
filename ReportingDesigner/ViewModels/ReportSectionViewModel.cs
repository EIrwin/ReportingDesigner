using System.Collections.Generic;

namespace ReportingDesigner.ViewModels
{
    public class ReportSectionViewModel:ReportItemViewModel
    {
        public string Name { get; set; }

        public List<ReportControlViewModel> Controls { get; set; }

        public ReportSectionViewModel()
        {
            Controls = new List<ReportControlViewModel>();
        }
    }
}