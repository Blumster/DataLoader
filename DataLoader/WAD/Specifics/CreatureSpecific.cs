using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    using Structs;

    public class CreatureSpecific
    {
        public Int32 AIBehavior;
        public Int16 AttributeCombat;
        public Int16 AttributePerception;
        public Int16 AttributeTech;
        public Int16 AttributeTheory;
        public Int16 BaseLevel;
        public Byte BaseLootChance;
        public Byte BossType;
        public Int32 Color1;
        public Int32 Color2;
        public Int32 Color3;
        public Int16 DefensiveBonus;
        public Int16 DifficultyAdjust;
        public Byte Flags;
        public Single FlyingHeight;
        public Int32 HasTurret;
        public Single HearingRange;
        public Int32 IsNPC;
        public Int32 LootTableId;
        public Int32 NPCCanGamble;
        public String NPCIntro;
        public Int16 OffensiveBonus;
        public Single PhysicsScale;
        public Single RotationSpeed;
        public Dictionary<Byte, List<SkillSet>> Skills;
        public Single Speed;
        public Int16 TransformTime;
        public Single VisionArc;
        public Single VisionRange;
        public Single XPPercent;
        private Byte[] _skip;

        public static CreatureSpecific Read(BinaryReader br)
        {
            var c = new CreatureSpecific
            {
                Speed = br.ReadSingle(),
                VisionArc = br.ReadSingle(),
                VisionRange = br.ReadSingle(),
                HearingRange = br.ReadSingle(),
                RotationSpeed = br.ReadSingle(),
                PhysicsScale = br.ReadSingle(),
                FlyingHeight = br.ReadSingle(),
                AIBehavior = br.ReadInt32(),
                IsNPC = br.ReadInt32(),
                NPCCanGamble = br.ReadInt32(),
                HasTurret = br.ReadInt32(),
                TransformTime = br.ReadInt16(),
                BaseLevel = br.ReadInt16(),
                AttributeCombat = br.ReadInt16(),
                AttributeTech = br.ReadInt16(),
                AttributeTheory = br.ReadInt16(),
                AttributePerception = br.ReadInt16(),
                Flags = br.ReadByte(),
                BossType = br.ReadByte(),
                DifficultyAdjust = br.ReadInt16(),
                BaseLootChance = br.ReadByte(),
                _skip = br.ReadBytes(3),
                XPPercent = br.ReadSingle(),
                Color1 = br.ReadInt32(),
                Color2 = br.ReadInt32(),
                Color3 = br.ReadInt32(),
                OffensiveBonus = br.ReadInt16(),
                DefensiveBonus = br.ReadInt16(),
                LootTableId = br.ReadInt32(),
                Skills = new Dictionary<Byte, List<SkillSet>>(),
            };

            var asd = br.ReadInt32();
            if (asd != 0)
            {
                br.BaseStream.Position += 0;
            }

            var introLen = br.ReadInt32();
            c.NPCIntro = br.ReadUnicodeString(introLen);

            var aiCount = br.ReadInt32();
            for (var i = 0; i < aiCount; ++i)
            {
                var b = br.ReadByte();
                var lenn = br.ReadInt32();
                var stru = br.ReadStruct<SkillSet>(lenn);
                c.Skills.Add(b, new List<SkillSet>(stru));
            }

            return c;
        }
    }
}