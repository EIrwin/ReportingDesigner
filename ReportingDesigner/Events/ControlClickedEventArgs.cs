using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ReportingDesigner.Views;

namespace ReportingDesigner.Events
{
    public class ReportControlClickedEventArgs:RoutedEventArgs
    {
        public ReportControlView ControlView { get; set; }

        public ReportControlClickedEventArgs(ReportControlView controlView)
        {
            ControlView = controlView;
        }
    }
}
