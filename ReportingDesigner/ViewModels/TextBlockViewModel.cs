using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.ViewModels
{
    public class TextBlockViewModel:ReportControlViewModel
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
    }
}
