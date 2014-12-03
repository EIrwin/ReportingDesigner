using System;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace ReportingDesigner.ViewModels
{
    public class ViewModelBase : NodeViewModelBase
    {
        private bool _expandable;
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
    }
}
