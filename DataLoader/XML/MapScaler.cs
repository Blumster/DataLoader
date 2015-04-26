using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct MapScaler
    {
        [XmlElement("rlHPModifier")] public Single HPModifier;
        [XmlElement("intNumPlayers")] public Int32 NumPlayers;
        [XmlElement("rlXPModifier")] public Single XPModifier;
    }
}