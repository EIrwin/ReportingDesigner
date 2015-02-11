using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels
{
    public class PageTemplateViewModel : INotifyPropertyChanged
    {
        private bool _showGridLines;
        private bool _showMarginLines;
        private List<PageViewModel> _pages;
        private PageTemplate _pageTemplate;

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

        public PageTemplateViewModel(PageTemplate pageTemplate)
        {
            _pageTemplate = pageTemplate;
        }

        public PageTemplateViewModel(FormatSettings formatSettings)
        {
            _pageTemplate = new PageTemplate()
                {
                    Name = "Template - " + DateTime.Now,
                    Description = "My Template.",
                    FormatSettings = formatSettings,
                };

            ShowGridLines = true;
            ShowMarginLines = true;

            Pages = new List<PageViewModel>();
        }

        public PageTemplateViewModel(string name,FormatSettings formatSettings)
        {
            _pageTemplate = new PageTemplate()
                {
                    Name = name,
                    Description = "My Template",
                    FormatSettings = formatSettings
                };

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