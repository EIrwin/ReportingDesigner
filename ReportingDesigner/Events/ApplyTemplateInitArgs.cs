using System;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.Events
{
    public class TemplateApplicationEventArgs:EventArgs
    {
        public TemplateApplicationMethod TemplateApplicationMethod { get; set; }

        public PageTemplate PageTemplate { get; set; }

        public int Page { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public TemplateApplicationEventArgs(TemplateApplicationMethod templateApplicationMethod,PageTemplate pageTemplate)
        {
            TemplateApplicationMethod = templateApplicationMethod;
            PageTemplate = pageTemplate;
        }
    }
}
