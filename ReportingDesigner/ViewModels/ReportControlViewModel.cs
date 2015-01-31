using System;

namespace ReportingDesigner.ViewModels
{
    public class ReportControlViewModel:ControlViewModel
    {
        public Guid PinID { get; set; }

        public PageViewModel Page { get; private set; }

        public ReportViewModel Report { get; private set; }
        
        public ReportControlViewModel(ReportViewModel report,PageViewModel page)
        {
            Report = report;
            Page = page;
        }
    }
}