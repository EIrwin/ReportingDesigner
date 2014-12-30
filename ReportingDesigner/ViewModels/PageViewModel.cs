﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReportingDesigner.ViewModels
{
    public class PageViewModel:INotifyPropertyChanged
    {
        private Guid _id;
        private int _pageNumber;
        private List<ReportControlViewModel> _controls;

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

        public PageViewModel(double top, double bottom)
        {
            Top = top;
            Bottom = bottom;

            Controls = new List<ReportControlViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}