using System;
using System.Collections.Generic;

namespace ReportingDesigner.ViewModels
{
    public class PageViewModel
    {
        public Guid Id { get; set; }

        public int PageNumber { get; set; }

        public List<ReportControlViewModel> Controls { get; set; }

        public PageViewModel()
        {
            Controls = new List<ReportControlViewModel>();
        }
    }
}