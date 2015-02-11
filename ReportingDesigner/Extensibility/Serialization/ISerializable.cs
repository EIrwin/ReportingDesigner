using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingDesigner.Extensibility.Serialization
{
    public interface ISerializable
    {
        IDictionary<string, string> Serialize();
        void Deserialize(SerializationInfo info);
    }
}
