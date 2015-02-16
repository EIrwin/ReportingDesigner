using System;
using System.Collections.Generic;
using System.ComponentModel;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels
{
    public class PageViewModel:INotifyPropertyChanged
    {
        private Guid _id;
        private int _pageNumber;
        private List<ReportControlViewModel> _controls;
        private PageTemplate _pageTemplate;

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
        public List<ReportControlViewModel> Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }
        public double Top { get; private set; }
        public double Bottom { get; private set; }
        public PageTemplate PageTemplate
        {
            get { return _pageTemplate; }
            set 
            {
                if (_pageTemplate != value)
                {
                    _pageTemplate = value;
                    OnPropertyChanged("PageTemplate");
                }

            }
        }

        public PageViewModel(double top, double bottom)
        {
            Top = top;
            Bottom = bottom;

            Controls = new List<ReportControlViewModel>();
            _controls = new List<ReportControlViewModel>();
        }

        public PageViewModel(double top, double bottom, int pageNumber)
        {
            Top = top;
            Bottom = bottom;
            PageNumber = pageNumber;

            Controls = new List<ReportControlViewModel>();
            _controls = new List<ReportControlViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}