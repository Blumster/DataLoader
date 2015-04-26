using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    public struct PowerPlantSpecific
    {
        public Int16 CoolRate;
        public Int32 HeatMaximum;
        public Int32 PowerMaximum;
        public Int16 PowerRegenerate;

        public static PowerPlantSpecific Read(BinaryReader br)
        {
            return new PowerPlantSpecific
            {
                HeatMaximum = br.ReadInt32(),
                PowerMaximum = br.ReadInt32(),
                PowerRegenerate = br.ReadInt16(),
                CoolRate = br.ReadInt16()
            };
        }
    }
}