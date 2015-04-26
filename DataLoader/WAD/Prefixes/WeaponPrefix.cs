using System;
using System.IO;

namespace DataLoader.WAD.Prefixes
{
    using Interfaces;
    using Structs;

    public struct WeaponPrefix : IReadableStruct<WeaponPrefix>
    {
        public Single AccucaryBonusPercent;
        public BasePrefix BasePrefix;
        public DamageArray DamageAdjustMaximum;
        public DamageArray DamageAdjustMinimum;

        public Single DamagePercentAll;
        public Single[] DamagePercentMaximum;
        public Single[] DamagePercentMinimum;
        public Single FiringArcPercent;
        public Int16 HeatAdjust;
        public Single HeatPercent;
        public Int16 OffenseBonus;
        public Single OffenseBonusPercent;
        public Int16 PenetrationBonus;
        public Int16 PowerPerShot;
        public Single RangePercent;
        public Single RechargeTimePercent;

        public WeaponPrefix Read(BinaryReader br)
        {
            BasePrefix.Read(br);

            FiringArcPercent = br.ReadSingle();
            RangePercent = br.ReadSingle();
            RechargeTimePercent = br.ReadSingle();
            HeatPercent = br.ReadSingle();
            HeatAdjust = br.ReadInt16();
            PowerPerShot = br.ReadInt16();
            DamagePercentAll = br.ReadSingle();
            DamagePercentMinimum = br.Read<Single>(6);
            DamagePercentMaximum = br.Read<Single>(6);
            DamageAdjustMinimum = br.ReadStruct<DamageArray>();
            DamageAdjustMaximum = br.ReadStruct<DamageArray>();
            OffenseBonus = br.ReadInt16();

            br.ReadBytes(2);

            OffenseBonusPercent = br.ReadSingle();
            AccucaryBonusPercent = br.ReadSingle();
            PenetrationBonus = br.ReadInt16();

            br.ReadBytes(2);

            return this;
        }
    }
}