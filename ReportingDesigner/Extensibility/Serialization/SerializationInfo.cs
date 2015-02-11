using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Diagrams.Core;

namespace ReportingDesigner.Extensibility.Serialization
{
    public class SerializationInfo
    {
        private readonly Telerik.Windows.Diagrams.Core.SerializationInfo _info;

        public SerializationInfo(object info)
        {
            _info = (Telerik.Windows.Diagrams.Core.SerializationInfo) info;
        }

        public string this[string key] 
        {
            get { return _info[key].ToString(); }
            set { _info[key] = value; } 
        }
    }
}
