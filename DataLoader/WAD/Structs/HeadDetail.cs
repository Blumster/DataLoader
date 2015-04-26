using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct HeadDetail : IReadableStruct<HeadDetail>
    {
        public Int32 CloneBase;
        public Int32 DisableHair;
        public String FileName;
        public Int32 HeadBody;
        public Int32 Id;
        public Int32 MaxTextures;
        public Byte Type;
        private Byte _skip;

        public HeadDetail Read(BinaryReader br)
        {
            Id = br.ReadInt32();
            HeadBody = br.ReadInt32();
            CloneBase = br.ReadInt32();
            FileName = br.ReadUnicodeString(65);
            Type = br.ReadByte();
            _skip = br.ReadByte();
            MaxTextures = br.ReadInt32();
            DisableHair = br.ReadInt32();

            return this;
        }

        public override string ToString()
        {
            return String.Format("Id: {0} | File: {1} ", Id, FileName);
        }
    }
}