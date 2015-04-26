using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct FrRr : IReadableStruct<FrRr>
    {
        public Single Front;
        public Single Rear;

        public FrRr Read(BinaryReader br)
        {
            Front = br.ReadSingle();
            Rear = br.ReadSingle();

            return this;
        }
    }
}