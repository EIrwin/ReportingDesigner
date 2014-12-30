using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using ReportingDesigner.Extensibility;
using ReportingDesigner.Models;

namespace ReportingDesigner.ViewModels
{
    public class ReportViewModel:INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private string _description;
        private List<PageViewModel> _pages;
        private FormatSettings _formatSettings;
        private Report _report;
        private bool _showGridLines;
        private bool _showMarginLines;

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

        public FormatSettings FormatSettings
        {
            get { return _formatSettings; }
            set { _formatSettings = value; }
        }

        public Report Report
        {
            get { return _report; }
            set { _report = value; }
        }

        public bool ShowGridLines
        {
            get { return _showGridLines; }
            set
            {
                if (_showGridLines != value)
                {
                    _showGridLines = value;
                    OnPropertyChanged("ShowGridLines");
                }
            }
        }

        public bool ShowMarginLines
        {
            get { return _showMarginLines; }
            set { _showMarginLines = value; }
        }

        public ReportViewModel(Report report,FormatSettings formatSettings)
        {
            
            Report = report;
            Pages = new List<PageViewModel>();
            FormatSettings = formatSettings;

            ShowGridLines = true;
            ShowMarginLines = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
