using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using WAD.Structs;

    public class CVOGMapPath : CVOGClonedObjectBase
    {
        public UInt32 DefaultMapPath;
        public List<MapPathPoint> MapPathPoints = new List<MapPathPoint>();
        public String PathName;
        public Boolean ReverseDirection;

        public override void Unserialize(BinaryReader br, UInt32 mapVersion)
        {
            DefaultMapPath = br.ReadUInt32();
            ReverseDirection = br.ReadBoolean();
            PathName = br.ReadStringOn(64);

            var pointCount = br.ReadUInt32();
            for (var i = 0U; i < pointCount; ++i)
                MapPathPoints.Add(MapPathPoint.Read(br));
        }
    }

    public struct MapPathPoint
    {
        public Single AcceptDistance;
        public Vector3 Position;
        public UInt64 ReactionCOID;
        public UInt32 WaitTime;

        public static MapPathPoint Read(BinaryReader br)
        {
            var mp = new MapPathPoint
                {
                    Position = new Vector3().Read(br),
                    AcceptDistance = br.ReadSingle(),
                    ReactionCOID = br.ReadUInt64(),
                    WaitTime = br.ReadUInt32(),
                };

            br.ReadBytes(4);

            return mp;
        }
    }
}