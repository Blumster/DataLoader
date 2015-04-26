using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct VehicleTemplate
    {
        [XmlElement("IDVehicleTemplate")] public UInt32 Id;
        [XmlElement("CBIDVehicle")] public UInt32 VehicleCBID;
        [XmlElement("CBIDDriver")] public UInt32 DriverCBID;
        [XmlElement("CBIDWeaponTurret")] public Int32 TurretCBID;
        [XmlElement("CBIDWeaponFront")] public Int32 FrontCBID;
        [XmlElement("CBIDArmor")] public Int32 ArmorCBID;
        [XmlElement("sinBaseLevel")] public Byte BaseLevel;
        [XmlElement("tinLootChance")] public Byte LootChance;
        [XmlElement("tinLootRolls")] public Byte LootRolls;
        [XmlElement("IDSkill1")] public Int32 SkillId;
        [XmlElement("tinSkillRank1")] public Byte SkillRank;
        [XmlElement("strDescription")] public String Description;
        [XmlElement("strShortDesc")] public String ShortDescription;
        [XmlElement("intLootTableID")] public Int32 LootTableId;
        [XmlElement("intBaseHP")] public Int32 BaseHP;
        [XmlElement("CBIDWeaponDrop")] public Int32 WeaponDropCBID;
        [XmlElement("CBIDWeaponMelee")] public Int32 WeaponMeleeCBID;
    }
}
