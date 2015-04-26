using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct QuestBaseCredit
    {
        [XmlElement("IDTargetLevel")] public Byte TargetLevel;
        [XmlElement("intBaseCredits")] public Int32 BaseCredits;
    }
}