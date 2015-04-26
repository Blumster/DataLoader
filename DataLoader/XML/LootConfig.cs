using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct LootConfig
    {
        [XmlElement("rlArmorRoll")] public Single ArmorRoll;
        [XmlElement("rlConsumableRoll")] public Single ConsumableRoll;

        [XmlElement("rlEnhanceAdd")] public Single EnhanceAdd;
        [XmlElement("rlEnhanceBase")] public Single EnhanceBase;

        [XmlElement("rlEnhanceLossPerEnhance")] public Single EnhanceLossPerEnhance;

        [XmlElement("rlEnhanceMax")] public Single EnhanceMax;
        [XmlElement("sinMaxNegOffset")] public Int32 MaxNegOffset;
        [XmlElement("sinMaxPosOffset")] public Int32 MaxPosOffset;
        [XmlElement("rlMiscRoll")] public Single MiscRoll;

        [XmlElement("rlPowerPlantRoll")] public Single PowerPlantRoll;

        [XmlElement("rlVehicleRoll")] public Single VehicleRoll;
        [XmlElement("rlWeaponRoll")] public Single WeaponRoll;

        [XmlElement("rlWheelSetRoll")] public Single WheelSetRoll;
    }
}