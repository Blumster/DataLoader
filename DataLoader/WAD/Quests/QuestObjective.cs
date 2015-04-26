using System;
using System.IO;

namespace DataLoader.WAD.Quests
{
    using Interfaces;

    public struct QuestObjective : IReadableStruct<QuestObjective>
    {
        public Int32 AttribPoints;
        public Int32 ContinentObject;
        public Single CreditScaler;
        public Int32 Credits;
        public Int16 CreditsIndex;
        public Byte LayerIndex;
        public String MapName;
        public Int32 ObjectiveId;
        public String ObjectiveName;
        public Int32 QuestId;
        public Int32 ReturnToNPC;
        public Byte Sequence;
        public Int32 SkillPoints;
        public Int32 WorldPosition;
        public Int32 XP;
        public Single XPBalanceScaler;
        public Int16 XPIndex;
        public Single XPScaler;

        public QuestObjective Read(BinaryReader br)
        {
            QuestId = br.ReadInt32();
            ObjectiveId = br.ReadInt32();
            Sequence = br.ReadByte();

            br.ReadBytes(1);

            ObjectiveName = br.ReadUnicodeString(65);
            MapName = br.ReadUnicodeString(65);

            br.ReadBytes(2);

            WorldPosition = br.ReadInt32();
            ContinentObject = br.ReadInt32();
            LayerIndex = br.ReadByte();

            br.ReadBytes(3);

            XP = br.ReadInt32();
            Credits = br.ReadInt32();
            AttribPoints = br.ReadInt32();
            SkillPoints = br.ReadInt32();
            ReturnToNPC = br.ReadInt32();

            XPIndex = br.ReadInt16();
            CreditsIndex = br.ReadInt16();

            XPScaler = br.ReadSingle();
            XPBalanceScaler = br.ReadSingle();
            CreditScaler = br.ReadSingle();

            return this;
        }
    }
}