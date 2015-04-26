using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseTinkeringKit : CloneBaseObject
    {
        public TinkeringKitSpecific TinkeringKitSpecific;

        public CloneBaseTinkeringKit(BinaryReader br)
            : base(br)
        {
            TinkeringKitSpecific = TinkeringKitSpecific.Read(br);
        }
    }
}