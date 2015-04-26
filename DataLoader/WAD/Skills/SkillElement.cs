using System;
using System.IO;

namespace DataLoader.WAD.Skills
{
    using Interfaces;

    public struct SkillElement : IReadableStruct<SkillElement>
    {
        public Int32 ElementType;
        public Byte EquationType;
        public Int32 SkillId;
        public Single ValueBase;
        public Single ValuePerLevel;

        public SkillElement Read(BinaryReader br)
        {
            SkillId = br.ReadInt32();
            ElementType = br.ReadInt32();
            EquationType = br.ReadByte();

            br.ReadBytes(3);

            ValueBase = br.ReadSingle();
            ValuePerLevel = br.ReadSingle();

            return this;
        }
    }
}