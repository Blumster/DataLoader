using System;
using System.IO;

namespace DataLoader.WAD.Prefixes
{
    using Interfaces;
    using Structs;

    public struct ArmorPrefix : IReadableStruct<ArmorPrefix>
    {
        public Int16 ArmorFactorAdjust;
        public Single ArmorFactorPercent;
        public BasePrefix BasePrefix;
        public DamageArray ResistAdjust;

        public ArmorPrefix Read(BinaryReader br)
        {
            BasePrefix.Read(br);

            ArmorFactorPercent = br.ReadSingle();
            ArmorFactorAdjust = br.ReadInt16();
            ResistAdjust = br.ReadStruct<DamageArray>();

            br.ReadBytes(2);

            return this;
        }
    }
}