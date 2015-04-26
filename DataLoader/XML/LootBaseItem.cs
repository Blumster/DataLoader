using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct LootBaseItem
    {
        [XmlElement("intType")] public Byte Type;
        [XmlElement("IDCloneBase")] public UInt32 CloneBase;
    }
}
