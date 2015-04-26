using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct ObjTypeRef
    {
        [XmlElement("TypeID")]      public UInt32 TypeId;
        [XmlElement("Description")] public String Description;
    }
}
