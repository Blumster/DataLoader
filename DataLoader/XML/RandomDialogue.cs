using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct RandomDialogue
    {
        [XmlElement("IDCloneBase")] public UInt32 CloneBase;
        [XmlElement("strDialogue")] public String Dialogue;
    }
}
