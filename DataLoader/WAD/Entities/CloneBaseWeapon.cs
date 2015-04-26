using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseWeapon : CloneBaseObject
    {
        public WeaponSpecific WeaponSpecific;

        public CloneBaseWeapon(BinaryReader br)
            : base(br)
        {
            WeaponSpecific = WeaponSpecific.Read(br);
        }
    }
}