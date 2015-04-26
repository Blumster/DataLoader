using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Module
    {
        [XmlElement("IDFaction")] public Int32 FactionId;
        [XmlElement("strFilename")] public String FileName;
        [XmlElement("strFormat")] public String Format;
        [XmlElement("IDModule")] public UInt32 Id;
        [XmlElement("tinNumberOfSpawns")] public Byte NumberOfSpawns;

        [XmlElement("tinType")] public Byte Type;

        [XmlElement("intValidTilesets")] public Int32 ValidTilesets;
    }
}