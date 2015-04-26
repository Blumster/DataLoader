using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;
    using Structs;

    public class CloneBaseVehicle : CloneBaseObject
    {
        public VehicleSpecific VehicleSpecific;

        public CloneBaseVehicle(BinaryReader br)
            : base(br)
        {
            VehicleSpecific = VehicleSpecific.Read(br);

            VehicleSpecific.Tricks = br.ReadStruct<VehicleTrick>(VehicleSpecific.NumberOfTricks);
        }
    }
}