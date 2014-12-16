using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.Extensibility
{
    public class ReportFormatSettings
    {
        private readonly PageSize _pageSize;
        public PageSize PageSize {
            get { return _pageSize; }
        }
    }
}
