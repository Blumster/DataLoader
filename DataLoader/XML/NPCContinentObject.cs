using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct NPCContinentObject
    {
        [XmlElement("IDCloneBaseNPC")] public UInt32 CloneBaseNPC;

        [XmlElement("IDContinentObject")] public UInt32 ContinentObject;
    }
}