using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ReportingDesigner.Events
{
    public class MarginChangedEventArgs:EventArgs
    {
        public Thickness Margin { get; set; }
        public MarginChangedEventArgs()
        {
            
        }
        public MarginChangedEventArgs(Thickness margin)
        {
            Margin = margin;
        }
    }
}
