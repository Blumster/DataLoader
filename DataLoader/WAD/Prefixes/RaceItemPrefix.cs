using System;
using System.IO;

namespace DataLoader.WAD.Prefixes
{
    using Interfaces;

    public struct RaceItemPrefix : IReadableStruct<RaceItemPrefix>
    {
        public BasePrefix BasePrefix;

        public Int16 HazardCountBonus;
        public Single HazardCountBonusf;
        public Int16 HazardSecondsBonus;
        public Single HazardSecondsBonusf;

        public RaceItemPrefix Read(BinaryReader br)
        {
            BasePrefix.Read(br);

            HazardCountBonus = br.ReadInt16();

            br.ReadBytes(2);

            HazardCountBonusf = br.ReadSingle();
            HazardSecondsBonus = br.ReadInt16();

            br.ReadBytes(2);

            HazardSecondsBonusf = br.ReadSingle();

            return this;
        }
    }
}