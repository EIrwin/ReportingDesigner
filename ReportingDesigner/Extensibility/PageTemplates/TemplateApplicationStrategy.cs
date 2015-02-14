using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportingDesigner.Events;
using ReportingDesigner.Views;

namespace ReportingDesigner.Extensibility.PageTemplates
{
    public abstract class TemplateApplicationStrategy
    {
        public abstract void ApplyTemplate(TemplateApplicationEventArgs args,DesignerContainer designer);
    }
}
