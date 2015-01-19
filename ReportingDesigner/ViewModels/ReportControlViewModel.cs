using System;

namespace ReportingDesigner.ViewModels
{
    public class ReportControlViewModel:ViewModelBase
    {
        public Guid PinID { get; set; }

        private Guid _id;
        private string _name;
        private string _description;

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public PageViewModel Page { get; private set; }

        public ReportViewModel Report { get; private set; }
        
        public ReportControlViewModel(ReportViewModel report,PageViewModel page)
        {
            Report = report;
            Page = page;
        }


        
    }
}