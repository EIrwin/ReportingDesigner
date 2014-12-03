using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace ReportingDesigner.Views
{
    public class ViewBase:RadDiagramShape
    {
        public ViewBase()
        {
            //We want to remove the default connectors
            //before we define our own connection points
            this.Loaded += (o, e) => this.Connectors.ToList().ForEach(connector =>
            {
                if (connector.Name == ConnectorPosition.Auto.ToString() ||
                    connector.Name == ConnectorPosition.Bottom.ToString() ||
                    connector.Name == ConnectorPosition.Top.ToString() ||
                    connector.Name == ConnectorPosition.Left.ToString() ||
                    connector.Name == ConnectorPosition.Right.ToString())
                {
                    this.Connectors.Remove(connector);
                }
            });
        }
    }
}
