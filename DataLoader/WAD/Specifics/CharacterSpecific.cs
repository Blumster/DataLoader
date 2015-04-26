using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    public struct CharacterSpecific
    {
        public Byte Class;
        public Byte Flags;
        public Int16 HPFactor;
        public Int16 HPStart;
        public Int32 IsMale;
        public Byte Race;
        private Byte _skip;

        public static CharacterSpecific Read(BinaryReader br)
        {
            return new CharacterSpecific
            {
                IsMale = br.ReadInt32(),
                HPStart = br.ReadInt16(),
                HPFactor = br.ReadInt16(),
                Flags = br.ReadByte(),
                Class = br.ReadByte(),
                Race = br.ReadByte(),
                _skip = br.ReadByte()
            };
        }
    }
}