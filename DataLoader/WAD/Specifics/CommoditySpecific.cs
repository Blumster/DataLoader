using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    public struct CommoditySpecific
    {
        public Int32 CommodityGroupType;
        public Single DropChance;
        public Int32 Group;
        public Byte MaterialDifficulty;
        public Int32 MaxLevel;
        public Int32 MinLevel;
        public Byte Purity;
        public Byte PurityFrom;
        public Int32 RefineTarget;
        public Int32 RefinesFrom;
        public Int32 Value;
        private Int16 _skip1, _skip2;
        private Byte _skip3;

        public static CommoditySpecific Read(BinaryReader br)
        {
            return new CommoditySpecific
            {
                RefineTarget = br.ReadInt32(),
                Value = br.ReadInt32(),
                MaterialDifficulty = br.ReadByte(),
                Purity = br.ReadByte(),
                _skip1 = br.ReadInt16(),
                Group = br.ReadInt32(),
                RefinesFrom = br.ReadInt32(),
                PurityFrom = br.ReadByte(),
                _skip2 = br.ReadInt16(),
                _skip3 = br.ReadByte(),
                CommodityGroupType = br.ReadInt32(),
                MinLevel = br.ReadInt32(),
                MaxLevel = br.ReadInt32(),
                DropChance = br.ReadSingle()
            };
        }
    }
}