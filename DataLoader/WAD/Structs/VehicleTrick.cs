using System;
using System.IO;

namespace DataLoader.WAD.Structs
{
    using Interfaces;

    public struct VehicleTrick : IReadableStruct<VehicleTrick>
    {
        public String Description;
        public Byte ExclusiveGroup;
        public String FileName;
        public String GroupDescription;
        public Byte GroupId;
        public Int32 Id;
        public Int32 VehicleId;

        public VehicleTrick Read(BinaryReader br)
        {
            Id = br.ReadInt32();
            VehicleId = br.ReadInt32();
            ExclusiveGroup = br.ReadByte();
            GroupId = br.ReadByte();
            FileName = br.ReadUnicodeString(65);
            Description = br.ReadUnicodeString(33);
            GroupDescription = br.ReadUnicodeString(33);

            return this;
        }

        public override string ToString()
        {
            return String.Format("Id: {0} | File: {1} | Desc: {2} | GDesc: {3}", Id, FileName, Description, GroupDescription);
        }
    }
}