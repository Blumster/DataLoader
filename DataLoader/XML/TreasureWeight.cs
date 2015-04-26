using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct TreasureWeight
    {
        [XmlElement("CBIDLoot")] public UInt32 LootCBID;
        [XmlElement("sinCategory")] public Byte Category;
        [XmlElement("sinWeight")] public Byte Weight;
    }
}
