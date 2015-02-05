using System;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.Events
{
    public class TemplateSelectedEventArgs:EventArgs
    {
        public PageTemplate PageTemplate { get; set; }

        public TemplateSelectedEventArgs(PageTemplate pageTemplate)
        {
            PageTemplate = pageTemplate;
        }
    }
}