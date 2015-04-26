using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct TypeName
    {
        [XmlElement("intType")] public Byte Type;
        [XmlElement("strName")] public String Name;
    }
}
