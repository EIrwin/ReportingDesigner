using System;

namespace ReportingDesigner.Events
{
    public class OptionsSelectedEventArgs:EventArgs
    {
        public string Name { get; set; }

        public OptionsSelectedEventArgs(string name)
        {
            Name = name;
        }
    }
}