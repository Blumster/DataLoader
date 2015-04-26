using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseGadget : CloneBaseObject
    {
        public GadgetSpecific GadgetSpecific;

        public CloneBaseGadget(BinaryReader br)
            : base(br)
        {
            GadgetSpecific = GadgetSpecific.Read(br);
        }
    }
}