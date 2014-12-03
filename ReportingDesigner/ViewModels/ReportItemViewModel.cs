using System;
using System.ComponentModel;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace ReportingDesigner.ViewModels
{
    public class ReportItemViewModel:NodeViewModelBase
    {
        private Guid _id;
        private string _name;
        private string _description;

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
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public Type ViewType { get; set; }

        public Type SettingsViewType { get; set; }

    }
}