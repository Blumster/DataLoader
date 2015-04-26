using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using WAD.Structs;

    public class CVOGRoadNodeBase
    {
        public String FileName;
        public List<Int32> NodeIds = new List<Int32>();
        public Vector3 Position;
        public UInt32 UniqueId;

        public virtual void UnSerialize(BinaryReader br, UInt32 mapVersion)
        {
            UniqueId = br.ReadUInt32();
            Position = new Vector3().Read(br);
            FileName = br.ReadStringOn(260);

            uint nodeCount = br.ReadUInt32();
            for (int i = 0; i < nodeCount; ++i)
                NodeIds.Add(br.ReadInt32());
        }
    }
}