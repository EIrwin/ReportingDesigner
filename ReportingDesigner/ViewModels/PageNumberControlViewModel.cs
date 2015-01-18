namespace ReportingDesigner.ViewModels
{
    public class PageNumberControlViewModel:ReportControlViewModel
    {
        private ReportViewModel _reportViewModel;

        public PageNumberControlViewModel(ReportViewModel reportViewModel)
        {
            _reportViewModel = reportViewModel;
        }
    }
}
