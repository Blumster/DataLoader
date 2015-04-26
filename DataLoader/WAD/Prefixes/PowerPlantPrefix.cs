using System;
using System.IO;

namespace DataLoader.WAD.Prefixes
{
    using Interfaces;

    public struct PowerPlantPrefix : IReadableStruct<PowerPlantPrefix>
    {
        public BasePrefix BasePrefix;
        public Single CoolDownPercent;
        public Int32 CoolingRateAdjust;
        public Single CoolingRatePercent;

        public Int32 HeadAdjust;
        public Single HeatPercent;
        public Int32 PowerAdjust;
        public Single PowerPercent;
        public Int32 PowerRegenRateAdjust;
        public Single PowerRegenRatePercent;

        public PowerPlantPrefix Read(BinaryReader br)
        {
            BasePrefix.Read(br);

            HeatPercent = br.ReadSingle();
            HeadAdjust = br.ReadInt32();
            PowerPercent = br.ReadSingle();
            PowerAdjust = br.ReadInt32();
            CoolingRatePercent = br.ReadSingle();
            CoolingRateAdjust = br.ReadInt32();
            PowerRegenRatePercent = br.ReadSingle();
            PowerRegenRateAdjust = br.ReadInt32();
            CoolDownPercent = br.ReadSingle();

            return this;
        }
    }
}