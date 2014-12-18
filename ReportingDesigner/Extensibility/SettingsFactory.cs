using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.Extensibility
{
    public static class FormatSettingsFactory
    {
        public static FormatSettings CreateFormatSettings(PageOrientation orientation, double dpi, PageFormat pageFormat)
        {
            return new FormatSettings(orientation, pageFormat, 0, 0);   //only temporary
        }
    }
}
