using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct LootTable
    {
        [XmlElement("IDLootTable")] public UInt32 Id;
        [XmlElement("strLootTableName")] public String Name;
        [XmlElement("sinLootRolls")] public Byte LootRolls;
        [XmlElement("rlConsumableDropChance")] public Single ConsumableDropChance;
        [XmlElement("rlDropChance")] public Single DropChance;
        [XmlElement("rlDropLevelOffset")] public Single DropLevelOffset;
        [XmlElement("sinMaxLevelOffset")] public Byte MaxLevelOffset;
        [XmlElement("sinMaxEnhancementComplexity")] public Byte MaxEnhancementComplexity;
        [XmlElement("rlLevelOffsetMultiplier")] public Single LevelOffsetMultiplier;
        [XmlElement("intBaseChanceEnhanced")] public Int32 BaseChanceEnhanced;
        [XmlElement("intChanceEnhancedModifierPerLevel")] public Int32 ChanceEnhancedModifierPerLevel;
        [XmlElement("intChanceWeapon")] public Int32 ChanceWeapon;
        [XmlElement("intChanceArmor")] public Int32 ChanceArmor;
        [XmlElement("intChancePowerPlant")] public Int32 ChancePowerPlant;
        [XmlElement("intChanceWheelSet")] public Int32 ChanceWheelSet;
        [XmlElement("intChanceVehicle")] public Int32 ChanceVehicle;
        [XmlElement("intChanceGadget")] public Int32 ChanceGadget;
        [XmlElement("intChanceTinkeringKit")] public Int32 ChanceTinkeringKit;
        [XmlElement("intChanceAccessory")] public Int32 ChanceAccessory;
        [XmlElement("intChanceRaceItem")] public Int32 ChanceRaceItem;
        [XmlElement("intChanceOrnament")] public Int32 ChanceOrnament;
        [XmlElement("intChanceOther")] public Int32 ChanceOther;
        [XmlElement("rlDropCreditsChance")] public Single DropCreditsChance;
        [XmlElement("intMinCreditsDrop")] public Int32 MinCreditsDrop;
        [XmlElement("intMaxCreditsDrop")] public Int32 MaxCreditsDrop;
        [XmlElement("intChanceRarity_0")] public Int32 ChanceRarity0;
        [XmlElement("intChanceRarity_1")] public Int32 ChanceRarity1;
        [XmlElement("intChanceRarity_2")] public Int32 ChanceRarity2;
        [XmlElement("intChanceRarity_3")] public Int32 ChanceRarity3;
        [XmlElement("intChanceRarity_4")] public Int32 ChanceRarity4;
        [XmlElement("intChanceRarity_5")] public Int32 ChanceRarity5;
        [XmlElement("intChanceRarity_6")] public Int32 ChanceRarity6;
        [XmlElement("intChanceRarity_7")] public Int32 ChanceRarity7;
        [XmlElement("intChanceRarity_8")] public Int32 ChanceRarity8;
        [XmlElement("rlWeaponBrokenModifier")] public Single WeaponBrokenModifier;
        [XmlElement("rlArmorBrokenModifier")] public Single ArmorBrokenModifier;
        [XmlElement("rlPowerPlantBrokenModifier")] public Single PowerPlantBrokenModifier;
        [XmlElement("rlWheelsetBrokenModifier")] public Single WheelsetBrokenModifier;
        [XmlElement("rlVehicleBrokenModifier")] public Single VehicleBrokenModifier;
        [XmlElement("rlGadgetBrokenModifier")] public Single GadgetBrokenModifier;
        [XmlElement("rlTinkeringKitBrokenModifier")] public Single TinkeringKitBrokenModifier;
        [XmlElement("rlAccessoryBrokenModifier")] public Single AccessoryBrokenModifier;
        [XmlElement("rlOtherBrokenModifier")] public Single OtherBrokenModifier;
        [XmlElement("rlRaceItemBrokenModifier")] public Single RaceItemBrokenModifier;
        [XmlElement("rlOrnamentBrokenModifier")] public Single OrnamentBrokenModifier;
    }
}
