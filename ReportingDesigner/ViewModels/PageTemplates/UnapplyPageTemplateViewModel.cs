using System.Collections.ObjectModel;
using System.ComponentModel;
using ReportingDesigner.Annotations;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.ViewModels.PageTemplates
{
    public class UnapplyPageTemplateViewModel : INotifyPropertyChanged
    {
        private TemplateApplicationMethod _applicationMethod;

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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}