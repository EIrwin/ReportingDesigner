using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ReportingDesigner.Annotations;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels.PageTemplates
{
    public class ApplyPageTemplateViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<PageTemplate> _pageTemplates;
        private TemplateApplicationMethod _applicationMethod;
        private PageTemplate _pageTemplate;

        public ObservableCollection<PageTemplate> PageTemplates
        {
            get { return _pageTemplates; }
            set
            {
                if (Equals(value, _pageTemplates)) return;
                _pageTemplates = value;
                OnPropertyChanged("PageTemplates");
            }
        }

        public TemplateApplicationMethod ApplicationMethod
        {
            get { return _applicationMethod; }
            set
            {
                if (value == _applicationMethod) return;
                _applicationMethod = value;
                OnPropertyChanged("ApplicationMethod");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PageTemplate PageTemplate
        {
            get { return _pageTemplate; }
            set
            {
                if (Equals(value, _pageTemplate)) return;
                _pageTemplate = value;
                OnPropertyChanged("PageTemplate");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
