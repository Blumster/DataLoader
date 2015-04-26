using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct ConfigNewCharacter
    {
        [XmlElement("CBIDArmor")] public UInt32 Armor;
        [XmlElement("IDClass")] public Byte Class;
        [XmlElement("IDOptionCode")] public Int32 OptionCode;

        [XmlElement("CBIDPowerPlant")] public UInt32 PowerPlant;
        [XmlElement("IDRace")] public UInt32 Race;

        [XmlElement("CBIDRaceItem")] public UInt32 RaceItem;

        [XmlElement("IDSkillBattleMode1")] public UInt32 SkillBattleMode1;

        [XmlElement("IDSkillBattleMode2")] public UInt32 SkillBattleMode2;

        [XmlElement("IDSkillBattleMode3")] public UInt32 SkillBattleMode3;
        [XmlElement("IDStartingSkill1")] public UInt32 StartSkill;
        [XmlElement("IDStartingTown")] public UInt32 StartTown;
        [XmlElement("CBIDTrailer")] public Int32 Trailer;
        [XmlElement("CBIDVehicle")] public UInt32 Vehicle;
        [XmlElement("CBIDWeapon")] public UInt32 Weapon;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Race, Class);
        }
    }
}