using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using Entities;

    public class CVOGOutPost : CVOGClonedObjectBase
    {
        public Single CaptureRadius;
        public Boolean IsOutpost;
        public Vector4 Location;
        public String OutPostName;
        public List<OutpostInformation> OutpostInformations = new List<OutpostInformation>();
        public Single OutpostXPScalar;
        public UInt32 VarTotalBeacons;

        public override void Unserialize(BinaryReader br, uint mapVersion)
        {
            Location = Vector4.Read(br);
            OutPostName = br.ReadStringOn(65);
            OutpostXPScalar = br.ReadSingle();

            if (mapVersion >= 56)
            {
                CaptureRadius = br.ReadSingle();
                VarTotalBeacons = br.ReadUInt32();
            }

            if (mapVersion >= 59)
                IsOutpost = br.ReadBoolean();

            for (var j = 0;;)
            {
                var oinfo = new OutpostInformation
                {
                    BeaconVar = br.ReadUInt32(),
                    Spawns = new List<Int64>(),
                    Objects = new List<Int64>(),
                    OutpostSkills = new List<OutpostSkill>(),
                    Reactions = new List<Int64>()
                };

                var spawnCount = br.ReadInt32();
                for (var i = 0; i < spawnCount; ++i)
                    oinfo.Spawns.Add(br.ReadInt64());

                var objectCount = br.ReadInt32();
                for (var i = 0; i < objectCount; ++i)
                    oinfo.Objects.Add(br.ReadInt64());

                var skillCount = br.ReadInt32();
                for (var i = 0; i < skillCount; ++i)
                    oinfo.OutpostSkills.Add(OutpostSkill.Read(br));

                if (mapVersion >= 58)
                {
                    var reactionCount = br.ReadUInt32();
                    for (var i = 0; i < reactionCount; ++i)
                        oinfo.Reactions.Add(br.ReadInt64());
                }

                OutpostInformations.Add(oinfo);

                if (mapVersion >= 57 || j < 2)
                    if (++j < 4)
                        continue;

                break;
            }
        }
    }

    public class OutpostInformation
    {
        public UInt32 BeaconVar;
        public List<Int64> Objects;
        public List<OutpostSkill> OutpostSkills;
        public List<Int64> Reactions;
        public List<Int64> Spawns;
    }

    public struct OutpostSkill
    {
        public Byte Layer;
        public Single RequiredBeaconPercantage;
        public UInt32 SkillId;
        public UInt32 SkillLevel;

        public static OutpostSkill Read(BinaryReader br)
        {
            var os = new OutpostSkill
                {
                    SkillId = br.ReadUInt32(),
                    SkillLevel = br.ReadUInt32(),
                    RequiredBeaconPercantage = br.ReadSingle(),
                    Layer = br.ReadByte()
                };

            br.ReadBytes(3);

            return os;
        }
    }
}