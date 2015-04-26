using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using WAD.Structs;

    public class CVOGRoadJunction : CVOGRoadNodeBase
    {
        public List<Vector3> Directions = new List<Vector3>();
        public List<Vector3> Positions = new List<Vector3>();
        public Single Rotation;

        public override void UnSerialize(BinaryReader br, UInt32 mapVersion)
        {
            base.UnSerialize(br, mapVersion);

            Rotation = br.ReadSingle();

            if (mapVersion < 28)
                return;

            for (int i = 0; i < 6; ++i)
            {
                Positions.Add(new Vector3().Read(br));
                Directions.Add(new Vector3().Read(br));
            }
        }
    }
}