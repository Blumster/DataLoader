using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using Entities;

    public class CVOGStore : CVOGClonedObjectBase
    {
        public Boolean IsJunkyard;
        public Boolean IsSouvenirStore;
        public Boolean IsVehicleStore;
        public List<ItemTypes> ItemsTypes = new List<ItemTypes>();

        public Vector4 Location;
        public UInt32 MaxLevel;
        public UInt32 MinLevel;
        public Vector4 Quaternion;
        public String StoreName;

        public override void Unserialize(BinaryReader br, UInt32 mapVersion)
        {
            Location = Vector4.Read(br);
            Quaternion = Vector4.Read(br);

            if (((((mapVersion <= 50) ? 1 : 0) - 1) & 20) + 10 > 0)
            {
                var count = (UInt32) (((((mapVersion <= 50) ? 1 : 0) - 1) & 20) + 10);
                for (int i = 0; i < count; ++i)
                    ItemsTypes.Add(ItemTypes.Read(br));
            }

            if (mapVersion >= 39)
            {
                StoreName = br.ReadLengthedString();
                MinLevel = br.ReadUInt32();
                MaxLevel = br.ReadUInt32();
            }

            if (mapVersion > 40)
                IsJunkyard = br.ReadBoolean();

            if (mapVersion >= 50)
                IsVehicleStore = br.ReadBoolean();

            if (mapVersion >= 61)
                IsSouvenirStore = br.ReadBoolean();
        }
    }

    public struct ItemTypes
    {
        public Int32 CBID;
        public Byte ItemType;
        public Single Percentage;
        public Byte Unlimited;
        public Int32 Value;

        public static ItemTypes Read(BinaryReader br)
        {
            return new ItemTypes
                {
                    ItemType = br.ReadByte(),
                    Percentage = br.ReadSingle(),
                    Value = br.ReadInt32(),
                    Unlimited = br.ReadByte(),
                    CBID = br.ReadInt32()
                };
        }
    }
}

/*
-40 m_strStoreName
-36 m_lStoreMinLevel
-32 m_lStoreMaxLevel



*/