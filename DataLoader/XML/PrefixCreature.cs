using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct PrefixCreature
    {
        [XmlElement("IDPrefix")] public UInt32 Id;
    }
}
