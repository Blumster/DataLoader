using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Region
    {
        [XmlElement("IDRegion")] public UInt32 Id;
        [XmlElement("bitIsFrontier")] public String _isFrontier;
        [XmlElement("tinTerrainType")] public Byte TerrainType;
        [XmlElement("strName")] public String Name;
        [XmlElement("IDOwningFaction")] public Int32 OwningFaction;
        [XmlElement("strQuestTitle")] public String QuestTitle;
        [XmlElement("strQuestDescription")] public String QuestDescription;
        [XmlElement("sinLevel")] public Byte Level;
        [XmlElement("IDHighwayObject")] public UInt32 HighwayObject;
    }
}
