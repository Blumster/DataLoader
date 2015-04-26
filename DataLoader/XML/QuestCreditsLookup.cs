using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct QuestCreditsLookup
    {
        [XmlElement("IDQuestCreditsIndex")] public Byte QuestCreditsIndex;
        [XmlElement("rlLevelCredits")]      public Single LevelCredits;
    }
}
