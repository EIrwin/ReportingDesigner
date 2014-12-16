using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.Extensibility
{
    public static class PageSizeFactory
    {
        public static PageSize Create()
        {
            return new PageSize(0, 0);
        }
    }
}
