using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Result
    {
        [XmlElement("rlAttributeRequirementIncrease")] public Single AttributeReqIncrease;
        [XmlElement("intBaseValue")] public Int32 BaseValue;
        [XmlElement("CBIDIngredient1")] public Int32 CBIDIngredient1;

        [XmlElement("CBIDIngredient2")] public Int32 CBIDIngredient2;

        [XmlElement("CBIDIngredient3")] public Int32 CBIDIngredient3;

        [XmlElement("CBIDIngredient4")] public Int32 CBIDIngredient4;

        [XmlElement("CBIDIngredient5")] public Int32 CBIDIngredient5;
        [XmlElement("intClassRestriction")] public Int32 ClassRestriction;
        [XmlElement("intComplexity")] public Int32 Complexity;
        [XmlElement("IDPrefix")] public UInt32 IDPrefix;
        [XmlElement("IDSkill")] public Int32 IDSkill;

        [XmlElement("sinLevelOffset")] public Byte LevelOffset;
        [XmlElement("rlMassPercent")] public Single MassPercent;
        [XmlElement("strName")] public String Name;
        [XmlElement("intObjectType")] public Int32 ObjectType;
        [XmlElement("intRace")] public Int32 Race;
        [XmlElement("rlRarity")] public Single Rarity;

        [XmlElement("sinRequiredCombat")] public Byte RequiredCombat;

        [XmlElement("sinRequiredPerception")] public Byte RequiredPerception;

        [XmlElement("sinRequiredTech")] public Byte RequiredTech;

        [XmlElement("sinRequiredTheory")] public Byte RequiredTheory;
        [XmlElement("rlValuePercent")] public Single ValuePercent;

        [XmlElement("bitGadgetOnly")] public String _gadgetOnly;
        [XmlElement("bitIsComponent")] public String _isComponent;

        public Boolean IsComponent
        {
            get { return _isComponent == "Tr"; }
        }

        public Boolean GadgetOnly
        {
            get { return _gadgetOnly == "Tr"; }
        }

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", IDPrefix, Name);
        }
    }
}