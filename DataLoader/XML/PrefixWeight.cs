using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct PrefixWeight
    {
        [XmlElement("IDPrefix")]    public UInt32 PrefixId;
        [XmlElement("sinCategory")] public Byte Category;
        [XmlElement("sinWeight")]   public Byte Weight;
    }
}
