using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Tile
    {
        [XmlElement("IDTileSet")]   public Byte TileSetId;
        [XmlElement("IDTile")]      public Byte Id;
        [XmlElement("fltFriction")] public Single Friction;
    }
}
