using System;
using System.Collections.Generic;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels
{
    public class ControlViewModel:ViewModelBase
    {
        private Guid _id;
        private string _name;
        private bool _showMarginLines;
        private List<PageViewModel> _pages;
        private bool _showGridLines;
        private FormatSettings _formatSettings;

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

        public FormatSettings FormatSettings
        {
            get { return _formatSettings; }
            set
            {
                if (_formatSettings != value)
                {
                    _formatSettings = value;
                    OnPropertyChanged("FormatSettings");
                }
            }
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
            set
            {
                if (_showMarginLines != value)
                {
                    _showMarginLines = value;
                    OnPropertyChanged("ShowMarginLines");
                }
            }
        }

        public List<PageViewModel> Pages
        {
            get { return _pages; }
            set
            {
                if (_pages != value)
                {
                    _pages = value;
                    OnPropertyChanged("Pages");
                }
            }
        }
    }
}