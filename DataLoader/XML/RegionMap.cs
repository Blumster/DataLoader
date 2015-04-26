using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct RegionMap
    {
        [XmlElement("IDRegion")]    public UInt32 RegionId;
        [XmlElement("strFilename")] public String FileName;
    }
}
