namespace ReportingDesigner.ViewModels
{
    public class PageNumberControlViewModel:ReportControlViewModel
    {
        private int _pageNumber;
        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (_pageNumber != value)
                {
                    _pageNumber = value;
                    OnPropertyChanged("PageNumber");
                }
            }
        }

        public PageNumberControlViewModel(ReportViewModel report, PageViewModel page) : base(report, page)
        {
            PageNumber = 0;
        }
    }
}
