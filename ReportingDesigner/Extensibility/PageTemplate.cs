using System;

namespace ReportingDesigner.Extensibility
{
    public class PageTemplate
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string Data { get; set; }

        public PageTemplate()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
    }
}
