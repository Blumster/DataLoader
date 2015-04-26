using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseArmor : CloneBaseObject
    {
        public ArmorSpecific ArmorSpecific;

        public CloneBaseArmor(BinaryReader br)
            : base(br)
        {
            ArmorSpecific = ArmorSpecific.Read(br);
        }
    }
}