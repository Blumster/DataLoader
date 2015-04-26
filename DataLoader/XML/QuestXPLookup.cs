using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct QuestXPLookup
    {
        [XmlElement("IDQuestXPIndex")] public Byte QuestXPIndex;
        [XmlElement("rlLevelXP")] public Single LevelXP;
    }
}
