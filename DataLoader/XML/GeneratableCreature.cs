using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct GeneratableCreature
    {
        [XmlElement("IDCloneBase")] public UInt32 CloneBase;
    }
}
