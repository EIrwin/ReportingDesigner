using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportingDesigner.Extensibility.Serialization;

namespace ReportingDesigner.Views
{
    public abstract class ReportControlView:ViewBase,ISerializable
    {
        public new abstract IDictionary<string, string> Serialize();
        public abstract void Deserialize(SerializationInfo info);
    }
}
