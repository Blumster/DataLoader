using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    public struct TinkeringKitSpecific
    {
        public Int16 MaxSlotLevel;
        public UInt32 ObjectTypeRestriction;
        private Int16 _skip;

        public static TinkeringKitSpecific Read(BinaryReader br)
        {
            return new TinkeringKitSpecific
            {
                MaxSlotLevel = br.ReadInt16(),
                _skip = br.ReadInt16(),
                ObjectTypeRestriction = br.ReadUInt32()
            };
        }
    }
}