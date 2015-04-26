using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct CreatureEnhancement
    {
        [XmlElement("sinAttackRankAdjust")] public SByte AttackRankAdjust;
        [XmlElement("sinCombatAdjust")] public SByte ComabtAdjust;
        [XmlElement("rlHPPercentage")] public Single HpPercentage;
        [XmlElement("IDCreatureEnhancement")] public UInt32 Id;

        [XmlElement("sinLevelAdjust")] public SByte LevelAdjust;

        [XmlElement("strName")] public String Name;
        [XmlElement("sinPerceptionAdjust")] public SByte PerceptionAdjust;
        [XmlElement("IDSkillArmor")] public Int32 SkillArmor;
        [XmlElement("tinTreasureRolls")] public Byte TreasureRolls;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Id, Name);
        }
    }
}