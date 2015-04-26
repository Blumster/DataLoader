using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBasePowerPlant : CloneBaseObject
    {
        public PowerPlantSpecific PowerPlantSpecific;

        public CloneBasePowerPlant(BinaryReader br)
            : base(br)
        {
            PowerPlantSpecific = PowerPlantSpecific.Read(br);
        }
    }
}