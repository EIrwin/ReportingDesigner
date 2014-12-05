﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ReportingDesigner.Commands
{
    public static class ReportingDesignerCommands
    {
        public static ICommand ToggleGridLines {
            get { return new ToggleGridLines(); }
        }

        public static ICommand ExportToBmp{
            get { return new ExportToBmp(); }
        }

        public static ICommand ExportToPng
        {
            get { return new ExportToPng(); }
        }
    }
}
