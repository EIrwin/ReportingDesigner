using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReportingDesigner.ViewModels
{
    public class ReportViewModel:INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private string _description;
        private List<PageViewModel> _pages;

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

        public List<PageViewModel> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        public ReportViewModel()
        {
            Pages = new List<PageViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
