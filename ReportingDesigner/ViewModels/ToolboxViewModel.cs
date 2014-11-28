using System.Collections.Generic;

namespace ReportingDesigner.ViewModels
{
    public class ToolboxViewModel
    {
        public List<ToolboxItemViewModel> Items { get; set; }

        public ToolboxViewModel()
        {
            Items = new List<ToolboxItemViewModel>();
        }
    }
}