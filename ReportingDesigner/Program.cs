using System;
using ReportingDesigner.Extensibility.Container;
using ReportingDesigner.Extensibility.Events;

namespace ReportingDesigner
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            App app = new App();

            //initialize application services/objects
            ServiceLocator.SetService<ICommandBus>(new CommandBus());

            app.Run(new ReportWindow());

        }
    }
}
