using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.ViewModels
{
    public class PageNumberViewModel
    {
        public int PageNumber { get; set; }

        public PageNumberViewModel()
        {
            PageNumber = 1;
        }
    }
}
