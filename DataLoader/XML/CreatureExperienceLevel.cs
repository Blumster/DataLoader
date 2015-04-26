using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct CreatureExperienceLevel
    {
        [XmlElement("intExperience")] public UInt32 Experience;
        [XmlElement("IDCreatureLevel")] public Byte Level;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Level, Experience);
        }
    }
}