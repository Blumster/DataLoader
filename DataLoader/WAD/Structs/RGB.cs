using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct RGB : IReadableStruct<RGB>
    {
        public Single B;
        public Single G;
        public Single R;

        public RGB Read(BinaryReader br)
        {
            R = br.ReadSingle();
            G = br.ReadSingle();
            B = br.ReadSingle();

            return this;
        }

        public override string ToString()
        {
            return String.Format("R: {0} | G: {1} | B: {2}", R, G, B);
        }
    }
}