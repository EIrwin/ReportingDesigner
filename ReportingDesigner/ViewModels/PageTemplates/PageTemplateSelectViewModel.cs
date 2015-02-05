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
    public class PageTemplateSelectViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<PageTemplate> _pageTemplates;
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
