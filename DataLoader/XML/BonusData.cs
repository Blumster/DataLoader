using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct BonusData
    {
        [XmlElement("intCBIDItemLarge")] public Int32 CBIDItemLarge;
        [XmlElement("intCBIDItemMed")] public Int32 CBIDItemMed;
        [XmlElement("intCBIDItemSmall")] public Int32 CBIDItemSmall;
        [XmlElement("IDCode")] public UInt32 IDCode;

        [XmlElement("intMedalID")] public Int32 MedalID;

        [XmlElement("strNotes")] public String Notes;
        [XmlElement("intSkillID")] public Int32 SkillID;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", IDCode, Notes);
        }
    }
}