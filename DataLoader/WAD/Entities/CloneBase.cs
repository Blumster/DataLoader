using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBase
    {
        public CloneBaseSpecific CloneBaseSpecific;

        public CloneBase(BinaryReader br)
        {
            CloneBaseSpecific = CloneBaseSpecific.Read(br);
        }

        public ObjectType Type
        {
            get { return (ObjectType) CloneBaseSpecific.Type; }
        }
    }
}