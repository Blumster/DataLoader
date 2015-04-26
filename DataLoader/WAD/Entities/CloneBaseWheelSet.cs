using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseWheelSet : CloneBaseObject
    {
        public WheelSetSpecific WheelSetSpecific;

        public CloneBaseWheelSet(BinaryReader br)
            : base(br)
        {
            WheelSetSpecific = WheelSetSpecific.Read(br);
        }
    }
}