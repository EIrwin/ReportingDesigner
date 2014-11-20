using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.ViewModels
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<PageViewModel> Pages { get; set; }

        public ReportViewModel()
        {
            Pages = new List<PageViewModel>();
        }
    }
}
