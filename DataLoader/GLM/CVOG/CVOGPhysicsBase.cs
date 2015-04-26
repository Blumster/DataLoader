using System;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using Entities;

    public class CVOGPhysicsBase
    {
        public void UnSerialize(BinaryReader br, UInt32 mapVersion)
        {
            var a = Vector4.Read(br);
            var b = Vector4.Read(br);
            var c = br.ReadSingle();
            var d = br.ReadSingle();
            var e = br.ReadByte();
        }
    }
}