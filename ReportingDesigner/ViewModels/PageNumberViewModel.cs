using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ReportingDesigner.Annotations;

namespace ReportingDesigner.ViewModels
{
    public class PageNumberViewModel:INotifyPropertyChanged
    {
        private int _pageNumber;
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

        public PageNumberViewModel()
        {
            PageNumber = 1;
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
