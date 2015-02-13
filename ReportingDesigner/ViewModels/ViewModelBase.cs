using System;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace ReportingDesigner.ViewModels
{
    public class ViewModelBase : NodeViewModelBase
    {
        private bool _expandable;
        private bool _isTemplateControl;

        public bool Expandable
        {
            get { return _expandable; }
            set
            {
                if (_expandable != value)
                {
                    _expandable = value;
                    OnPropertyChanged("Expandable");
                }
            }
        }


        public Type ViewType { get; set; }

        public Type SettingsViewType { get; set; }

        public bool IsTemplateControl
        {
            get { return _isTemplateControl; }
            set
            {
                if (_isTemplateControl != value)
                {
                    _isTemplateControl = value;
                    OnPropertyChanged("IsTemplateControl");
                }
            }
        }
    }
}
