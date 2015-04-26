using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    using Structs;

    public struct ArmorSpecific
    {
        public Int16 ArmorFactor;
        public Int16 DefenseBonus;
        public Single DeflectionModifier;
        public DamageArray Resistances;

        public static ArmorSpecific Read(BinaryReader br)
        {
            return new ArmorSpecific
            {
                DeflectionModifier = br.ReadSingle(),
                ArmorFactor = br.ReadInt16(),
                Resistances = br.ReadStruct<DamageArray>(),
                DefenseBonus = br.ReadInt16()
            };
        }
    }
}