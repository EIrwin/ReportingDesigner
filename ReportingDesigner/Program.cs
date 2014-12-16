using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportingDesigner.ViewModels;

namespace ReportingDesigner
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            App app = new App();

            app.Run(new ReportWindow());

        }
    }
}
