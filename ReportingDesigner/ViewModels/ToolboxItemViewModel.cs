using System;

namespace ReportingDesigner.ViewModels
{
    public class ToolboxItemViewModel
    {
        public string Name { get; set; }

        public string Display { get; set; }

        public Type ViewType { get; set; }

        public Type ViewModelType { get; set; }

        public Type ComponentType { get; set; }

        public Type SettingsViewType { get; set; }
    }
}