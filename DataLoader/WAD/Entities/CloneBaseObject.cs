using System;
using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseObject : CloneBase
    {
        public SimpleObjectSpecific SimpleObjectSpecific;

        public CloneBaseObject(BinaryReader br)
            : base(br)
        {
            SimpleObjectSpecific = SimpleObjectSpecific.Read(br);
        }

        public override String ToString()
        {
            return String.Format("Id: {2} | CBO: {0} | {1}", CloneBaseSpecific.UniqueName, CloneBaseSpecific.ShortDesc, CloneBaseSpecific.CloneBaseId);
        }
    }
}