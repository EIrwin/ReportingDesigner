using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ReportingDesigner.Extensibility
{
    public static class FormatSettingsFactory
    {
        public static FormatSettings CreateFormatSettings(PageOrientation orientation, double dpi, PageFormat pageFormat)
        {
            return new FormatSettings(orientation, pageFormat, 0, 0);
        }

        public static FormatSettings CreateFormatSettings(PageOrientation orientation, double dpi, PageFormat pageFormat,
                                                          Thickness margin)
        {
            return new FormatSettings(orientation, pageFormat, 0, 0, margin);
        }
    }
}
