using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct LootRarity
    {
        [XmlElement("strDescription")] public String Description;
        [XmlElement("IDRarity")] public UInt32 Id;

        [XmlElement("rlRollModifier")] public Single RollModifier;
    }
}