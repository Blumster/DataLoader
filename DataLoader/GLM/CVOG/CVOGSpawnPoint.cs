using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using Entities;

    public class CVOGSpawnPoint : CVOGClonedObjectBase // stabil pont: -352 == activation range | off: 80 h
    {
        public Single ActivationRange;
        public Byte ChampionChance;
        public Boolean FactionDirty;
        public Boolean HasChampion;
        public Single InitialPatrolDistance;
        public Vector4 Location;
        public Int32 Loot;
        public Single LootChance;
        public Single LootPercent;
        public UInt64 MapPathCOID;
        public UInt32 OriginalFaction;
        public Vector4 Quaternion;
        public Single Radius;
        public Byte RandomlyOffsetSpawnPosition;
        public Single RespawnTime;
        public Byte SpawnChance;
        public List<SpawnList> SpawnLists = new List<SpawnList>();
        public Boolean UseGenerator;

        public override void Unserialize(BinaryReader br, UInt32 mapVersion)
        {
            ReadTriggerEvents(br, mapVersion);

            Location = Vector4.Read(br);
            Quaternion = Vector4.Read(br);
            Radius = br.ReadSingle();
            RespawnTime = br.ReadSingle();
            ActivationRange = br.ReadSingle();

            UseGenerator = br.ReadBoolean();
            HasChampion = br.ReadBoolean();
            ChampionChance = br.ReadByte();
            SpawnChance = br.ReadByte();
            var j = br.ReadByte();

            if (mapVersion >= 31)
                RandomlyOffsetSpawnPosition = br.ReadByte();

            if (mapVersion >= 29)
                for (var i = 0; i < 12; ++i)
                    SpawnLists.Add(SpawnList.Read(br));
            else // UNREACHABLE CODE
                Debug.Assert(false, "Unreachable code reached!");

            Loot = br.ReadInt32();
            LootPercent = br.ReadSingle();
            MapPathCOID = br.ReadUInt64();
            InitialPatrolDistance = br.ReadSingle();

            if (mapVersion >= 15)
            {
                FactionDirty = br.ReadBoolean();
                OriginalFaction = br.ReadUInt32();
            }

            if (mapVersion >= 24)
                LootChance = br.ReadSingle();

            if (mapVersion >= 32)
            {
                var str = br.ReadLengthedString();
            }
        }
    }

    public struct SpawnList
    {
        public Boolean IsTemplate;
        public Byte LevelOffset;
        public Byte LowerNumberOfSpawns;
        public Int32 SpawnType;
        public Byte UpperNumberOfSpawns;

        public static SpawnList Read(BinaryReader br)
        {
            var sl = new SpawnList {LowerNumberOfSpawns = br.ReadByte(), UpperNumberOfSpawns = br.ReadByte()};

            br.ReadBytes(2);

            sl.SpawnType = br.ReadInt32();
            sl.LevelOffset = br.ReadByte();
            sl.IsTemplate = br.ReadBoolean();

            br.ReadBytes(2);

            return sl;
        }
    }
}