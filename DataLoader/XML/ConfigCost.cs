using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct ConfigCost
    {
        [XmlElement("rlArmorAFExponent")] public Single ArmorAFExponent;
        [XmlElement("rlArmorCompareCorrosion")] public Single ArmorCompareCorrosion;
        [XmlElement("rlArmorCompareEnergy")] public Single ArmorCompareEnergy;
        [XmlElement("rlArmorCompareFire")] public Single ArmorCompareFire;

        [XmlElement("rlArmorCompareIce")] public Single ArmorCompareIce;
        [XmlElement("rlArmorComparePhysical")] public Single ArmorComparePhysical;

        [XmlElement("rlArmorCompareSpirit")] public Single ArmorCompareSpirit;
        [XmlElement("rlCompareArmor")] public Single CompareArmor;

        [XmlElement("rlComparePowerPlant")] public Single ComparePowerPlant;

        [XmlElement("rlCompareVehicle")] public Single CompareVehicle;
        [XmlElement("rlCompareWeapon")] public Single CompareWeapon;

        [XmlElement("rlPowerPlantHeatAverageExponent")] public Single PowerPlantHeatAverageExponent;

        [XmlElement("rlPowerPlantHeatFactorExponent")] public Single PowerPlantHeatFactorExponent;

        [XmlElement("rlPowerPlantPowerAverageExponent")] public Single PowerPlantPowerAverageExponent;

        [XmlElement("rlPowerPlantPowerFactorExponent")] public Single PowerPlantPowerFactorExponent;

        [XmlElement("rlPowerPlantPowerRegenRateExponent")] public Single PowerPlantPowerRegenRateExponent;
        [XmlElement("strUserModified")] public String UserModified;

        [XmlElement("rlVehicleArmorFactorExponent")] public Single VehicleArmorFactorExponent;

        [XmlElement("rlVehicleCoolRateExponent")] public Single VehicleCoolRateExponent;
        [XmlElement("rlVehicleHeatFactorExponent")] public Single VehicleHeatFactorExponent;
        [XmlElement("rlWeaponAOEMultiplier")] public Single WeaponAOEMultiplier;
        [XmlElement("rlWeaponCompareCorrosion")] public Single WeaponCompareCorrosion;
        [XmlElement("rlWeaponCompareEnergy")] public Single WeaponCompareEnergy;
        [XmlElement("rlWeaponCompareFire")] public Single WeaponCompareFire;

        [XmlElement("rlWeaponCompareIce")] public Single WeaponCompareIce;
        [XmlElement("rlWeaponComparePhysical")] public Single WeaponComparePhysical;
        [XmlElement("rlWeaponCompareSpirit")] public Single WeaponCompareSpirit;
        [XmlElement("rlWeaponDPSExponent")] public Single WeaponDPSExponent;
        [XmlElement("rlWeaponHeatMultiplier")] public Single WeaponHeatMultiplier;

        [XmlElement("rlWeaponRatingMultiplier")] public Single WeaponRatingMultiplier;
        [XmlElement("rlWeaponSprayMultiplier")] public Single WeaponSprayMultiplier;
        [XmlElement("dteModified")] public String _modified;

        public DateTime Modified
        {
            get { return DateTime.Parse(_modified); }
        }

        public override String ToString()
        {
            return String.Format("{0}", Modified);
        }
    }
}