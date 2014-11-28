using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.Models
{
    public class ToolboxComponentAnnouncement
    {

        public string Name { get; set; }

        public string Display { get; set; }

        public string Category { get; set; }

        public string ImagePath { get; set; }

        public Type ViewType { get; set; }

        public Type ViewModelType { get; set; }

        public Type ComponentType { get; set; }

        public Type SettingsViewType { get; set; }
    }
}
