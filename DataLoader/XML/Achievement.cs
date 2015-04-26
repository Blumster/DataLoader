using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Achievement
    {
        [XmlElement("strDescription")] public String Description;
        [XmlElement("IDAchievement")] public UInt32 IDAchievement;

        [XmlElement("IDSkillCast")] public Int32 IDSkillCast;
        [XmlElement("strLogoFilename")] public String LogoFileName;
        [XmlElement("strRequirements")] public String Requirements;

        [XmlElement("intSkillLevel")] public Int32 SkillLevel;
        [XmlElement("strTitle")] public String Title;

        public override string ToString()
        {
            return String.Format("ID: {0} | {1}", IDAchievement, Title);
        }
    }
}