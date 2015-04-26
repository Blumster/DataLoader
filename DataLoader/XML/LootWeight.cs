using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct LootWeight
    {
        [XmlElement("CBIDDestroyed")] public UInt32 DestroyedId;
        [XmlElement("CBIDLoot")]      public UInt32 LootId;
        [XmlElement("sinWeight")]     public Int32 Weight;
    }
}
