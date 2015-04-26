using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct DamageArray : IReadableStruct<DamageArray>
    {
        public Int16[] Damage;

        public DamageArray Read(BinaryReader br)
        {
            Damage = br.Read<Int16>(6);

            return this;
        }
    }
}