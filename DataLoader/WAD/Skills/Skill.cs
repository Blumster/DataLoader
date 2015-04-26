using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.WAD.Skills
{
    using Interfaces;

    public struct Skill : IReadableStruct<Skill>
    {
        public Int32 AffectedObjectType;
        public Int32 AffectedSubType;
        public Int32 AffectedTarget;
        public Int32 CategoryId;
        public Int32 Class;
        public String Description;
        public List<SkillElement> Elements;
        public Int32 GroupId;
        public Int32 Id;
        public Int32 IsChain;
        public Int32 IsSpray;
        public Byte LocationLine;
        public Byte LocationTree;
        public Byte MaxSkillLevel;
        public Byte MinimumLevel;
        public String Name;
        public Int16 NumOfElements;
        public Byte OptionalAction;
        public Int32 Race;
        public Int32 SkillOptional1;
        public Int32 SkillOptional2;
        public Int32 SkillOptional3;
        public Int32 SkillOptional4;
        public Int32 SkillPrerequisite1;
        public Int32 SkillPrerequisite2;
        public Int32 SkillPrerequisite3;
        public Byte SkillType;
        public Int32 StatusEffect;
        public Int32 SummonedCreatureId;
        public Int32 TargetObjectType;
        public Int32 TargetSubType;
        public Int32 TargetType;
        public Int32 UseBodyForArc;
        public String XMLName;

        public Skill Read(BinaryReader br)
        {
            Id = br.ReadInt32();
            Class = br.ReadInt32();
            Race = br.ReadInt32();
            TargetType = br.ReadInt32();
            TargetSubType = br.ReadInt32();
            TargetObjectType = br.ReadInt32();
            AffectedTarget = br.ReadInt32();
            AffectedSubType = br.ReadInt32();
            AffectedObjectType = br.ReadInt32();
            StatusEffect = br.ReadInt32();
            SkillPrerequisite1 = br.ReadInt32();
            SkillPrerequisite2 = br.ReadInt32();
            SkillPrerequisite3 = br.ReadInt32();
            LocationTree = br.ReadByte();
            LocationLine = br.ReadByte();
            MinimumLevel = br.ReadByte();
            SkillType = br.ReadByte();
            Name = br.ReadUnicodeString(33);
            Description = br.ReadUnicodeString(1025);
            XMLName = br.ReadUnicodeString(65);

            br.ReadBytes(2);

            IsChain = br.ReadInt32();
            IsSpray = br.ReadInt32();
            OptionalAction = br.ReadByte();
            MaxSkillLevel = br.ReadByte();

            br.ReadBytes(2);

            UseBodyForArc = br.ReadInt32();
            GroupId = br.ReadInt32();
            CategoryId = br.ReadInt32();
            SummonedCreatureId = br.ReadInt32();
            SkillOptional1 = br.ReadInt32();
            SkillOptional2 = br.ReadInt32();
            SkillOptional3 = br.ReadInt32();
            SkillOptional4 = br.ReadInt32();
            NumOfElements = br.ReadInt16();

            br.ReadBytes(2);

            Elements = NumOfElements > 0 ? new List<SkillElement>(br.ReadStruct<SkillElement>(NumOfElements)) : new List<SkillElement>(0);

            return this;
        }
    }
}