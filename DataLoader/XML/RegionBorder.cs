using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct RegionBorder
    {
        [XmlElement("IDRegion")] public UInt32 RegionId;
        [XmlElement("IDRegionBordering")] public UInt32 RegionBordering;
    }
}
