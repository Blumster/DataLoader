using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct TileSet
    {
        [XmlElement("IDTileSet")] public Byte Id;
        [XmlElement("strName")] public String Name;
    }
}
