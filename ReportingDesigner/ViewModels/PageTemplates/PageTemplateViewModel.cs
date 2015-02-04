using System;
using System.Collections.Generic;
using System.ComponentModel;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels
{
    public class PageTemplateViewModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private FormatSettings _formatSettings;
        private bool _showGridLines;
        private bool _showMarginLines;
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

        public FormatSettings FormatSettings
        {
            get { return _formatSettings; }
            set { _formatSettings = value; }
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

        public List<PageViewModel> Pages
        {
            get { return _pages; }
            set
            {
                if (value != _pages)
                {
                    _pages = value;
                    OnPropertyChanged("Pages");
                }
            }
        }


        public PageTemplateViewModel(FormatSettings formatSettings)
        {
            Name = "My Page Template - " + DateTime.Now;
            FormatSettings = formatSettings;

            ShowGridLines = true;
            ShowMarginLines = true;

            Pages = new List<PageViewModel>();
        }

        public PageTemplateViewModel(string name,FormatSettings formatSettings)
        {
            Name = name;
            FormatSettings = formatSettings;

            ShowGridLines = true;
            ShowMarginLines = true;

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