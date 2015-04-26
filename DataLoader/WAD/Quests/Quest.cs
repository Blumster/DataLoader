using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.WAD.Quests
{
    using Interfaces;

    public struct Quest : IReadableStruct<Quest>
    {
        public Int32 Achievement;
        public Int16 ActiveObjectiveOverride;
        public Int16 AutoAssing;
        public Int32 Continent;
        public Int32 Discipline;
        public Int32 DisciplineValue;
        public Int32 Id;
        public Int16 IsRepeatable;
        public Int32[] Item;
        public Int16[] ItemIsKit;
        public Int32[] ItemQuantity;
        public Int32[] ItemTemplate;
        public Single[] ItemValue;
        public Int32 NPC;
        public String Name;
        public Byte NumberOfObjectives;

        public List<QuestObjective> Objectives;
        public Int32 Pocket;
        public Int32 Priority;
        public Int32 Region;
        public Int16 ReqClass;
        public Int32 ReqLevelMax;
        public Int32 ReqLevelMin;
        public Int32[] ReqMissionId;
        public Int16 ReqRace;
        public Int32 RequirementEventId;
        public Int32 RequirementsNegative;
        public Int32 RequirementsOred;
        public Int32 RewardDiscipline;
        public Int32 RewardDisciplineValue;
        public Int32 RewardUnassignedDisciplinePoints;
        public Int16 TargetLevel;
        public Byte Type;

        public Quest Read(BinaryReader br)
        {
            Id = br.ReadInt32();
            Name = br.ReadUnicodeString(65);
            Type = br.ReadByte();

            br.ReadByte();

            NPC = br.ReadInt32();
            Priority = br.ReadInt32();
            ReqRace = br.ReadInt16();
            ReqClass = br.ReadInt16();
            ReqLevelMin = br.ReadInt32();
            ReqLevelMax = br.ReadInt32();
            ReqMissionId = br.Read<Int32>(4);
            IsRepeatable = br.ReadInt16();

            br.ReadBytes(2);

            Item = br.Read<Int32>(4);
            ItemTemplate = br.Read<Int32>(4);
            ItemValue = br.Read<Single>(4);
            ItemIsKit = br.Read<Int16>(4);
            ItemQuantity = br.Read<Int32>(4);
            AutoAssing = br.ReadInt16();
            ActiveObjectiveOverride = br.ReadInt16();
            Continent = br.ReadInt32();
            Achievement = br.ReadInt32();
            Discipline = br.ReadInt32();
            DisciplineValue = br.ReadInt32();
            RewardDiscipline = br.ReadInt32();
            RewardDisciplineValue = br.ReadInt32();
            RewardUnassignedDisciplinePoints = br.ReadInt32();
            RequirementEventId = br.ReadInt32();
            TargetLevel = br.ReadInt16();

            br.ReadBytes(2);

            RequirementsOred = br.ReadInt32();
            RequirementsNegative = br.ReadInt32();
            Region = br.ReadInt32();
            Pocket = br.ReadInt32();
            NumberOfObjectives = br.ReadByte();

            br.ReadBytes(7);

            Objectives = new List<QuestObjective>(br.ReadStruct<QuestObjective>(br.ReadInt32()));
            return this;
        }
    }
}