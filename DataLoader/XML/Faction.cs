using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Faction
    {
        [XmlElement("IDFaction")] public Int32 Id;

        [XmlElement("strLongFactionName")] public String LongFactionName;
        [XmlElement("strShortFactionName")] public String ShortFactionName;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1} | {2}", Id, ShortFactionName, LongFactionName);
        }
    }
}