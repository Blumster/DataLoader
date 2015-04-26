using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct NPCDialogueRandom
    {
        [XmlElement("IDCloneBase")] public UInt32 CloneBase;
        [XmlElement("strDialogue")] public String Dialogue;
        [XmlElement("IDNPCDialogueRandom")] public UInt32 Id;
    }
}