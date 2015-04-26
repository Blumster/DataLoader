using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct RegionFaction
    {
        [XmlElement("IDRegion")] public UInt32 RegionId;
        [XmlElement("IDFaction")] public Int32 FactionId;
    }
}
