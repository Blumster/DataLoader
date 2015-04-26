using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    public struct GadgetSpecific
    {
        public UInt32 ObjectType;
        public Int32 Prefix;

        public static GadgetSpecific Read(BinaryReader br)
        {
            return new GadgetSpecific
            {
                Prefix = br.ReadInt32(),
                ObjectType = br.ReadUInt32()
            };
        }
    }
}