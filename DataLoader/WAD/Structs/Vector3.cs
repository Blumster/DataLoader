using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct Vector3 : IReadableStruct<Vector3>
    {
        public Single X;
        public Single Y;
        public Single Z;

        public Vector3 Read(BinaryReader br)
        {
            X = br.ReadSingle();
            Y = br.ReadSingle();
            Z = br.ReadSingle();

            return this;
        }

        public override string ToString()
        {
            return String.Format("X: {0} | Y: {1} | Z: {2}", X, Y, Z);
        }
    }
}