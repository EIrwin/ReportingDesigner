using System;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.Events
{
    public class ApplyTemplateInitArgs:EventArgs
    {
        public TemplateApplicationMethod TemplateApplicationMethod { get; set; }

        public PageTemplate PageTemplate { get; set; }

        public int Page { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public ApplyTemplateInitArgs(TemplateApplicationMethod templateApplicationMethod,PageTemplate pageTemplate)
        {
            TemplateApplicationMethod = templateApplicationMethod;
            PageTemplate = pageTemplate;
        }
    }
}
