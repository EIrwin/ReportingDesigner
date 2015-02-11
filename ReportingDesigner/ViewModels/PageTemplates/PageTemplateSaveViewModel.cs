using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ReportingDesigner.Annotations;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels.PageTemplates
{
    public class PageTemplateSaveViewModel:INotifyPropertyChanged
    {
        private PageTemplate _pageTemplate;

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
