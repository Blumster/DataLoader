using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct ExperienceLevel
    {
        [XmlElement("iAttributePoints")] public Int32 AttributePoints;
        [XmlElement("intExperience")] public Int32 Experience;
        [XmlElement("IDLevel")] public UInt32 Id;

        [XmlElement("iResearchPoints")] public Int32 ResearchPoints;
        [XmlElement("iSkillPoints")] public Int32 SkillPoints;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Id, Experience);
        }
    }
}