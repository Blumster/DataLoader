using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct HeadBody : IReadableStruct<HeadBody>
    {
        public Int32 CloneBase;
        public String FileName;
        public Int32 Id;
        public Int32 IsBody;
        public Int32 IsHead;
        public Int32 MaxTextures;
        private Byte[] _skip;

        public HeadBody Read(BinaryReader br)
        {
            Id = br.ReadInt32();
            CloneBase = br.ReadInt32();
            IsHead = br.ReadInt32();
            IsBody = br.ReadInt32();
            FileName = br.ReadUnicodeString(65);
            _skip = br.ReadBytes(2);
            MaxTextures = br.ReadInt32();

            return this;
        }

        public override string ToString()
        {
            return String.Format("Id: {0} | File: {1} ", Id, FileName);
        }
    }
}