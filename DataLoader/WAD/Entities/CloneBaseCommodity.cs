using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseCommodity : CloneBaseObject
    {
        public CommoditySpecific CommoditySpecific;

        public CloneBaseCommodity(BinaryReader br)
            : base(br)
        {
            CommoditySpecific = CommoditySpecific.Read(br);
        }
    }
}