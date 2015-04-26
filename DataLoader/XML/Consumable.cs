using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Consumable
    {
        [XmlElement("CBIDItem")] public UInt32 Item;
        [XmlElement("sinLevelMax")] public Byte LevelMax;
        [XmlElement("sinLevelMin")] public Byte LevelMin;
        [XmlElement("intMaxVersion")] public Int32 MaxVersion;
        [XmlElement("intMinVersion")] public Int32 MinVersion;
        [XmlElement("intOffset")] public Int32 Offset;
        [XmlElement("IDFaction")] public Int32 Faction;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}-{2}", Item, LevelMin, LevelMax);
        }
    }
}