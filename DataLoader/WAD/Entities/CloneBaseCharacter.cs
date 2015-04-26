using System.Collections.Generic;
using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;
    using Structs;

    public class CloneBaseCharacter : CloneBaseCreature
    {
        public CharacterSpecific CharacterSpecific;
        public List<HeadBody> HashBody;
        public List<HeadDetail> HashEyes;
        public List<HeadDetail> HashHair;
        public List<HeadBody> HashHead;
        public List<HeadDetail> HashHeadDetail;
        public List<HeadDetail> HashHeadDetail2;
        public List<HeadDetail> HashHelmet;
        public List<HeadDetail> HashMouthes;

        public CloneBaseCharacter(BinaryReader br)
            : base(br)
        {
            CharacterSpecific = CharacterSpecific.Read(br);

            HashHead = new List<HeadBody>(br.ReadStruct<HeadBody>(br.ReadInt32()));
            HashBody = new List<HeadBody>(br.ReadStruct<HeadBody>(br.ReadInt32()));
            HashHeadDetail = new List<HeadDetail>(br.ReadStruct<HeadDetail>(br.ReadInt32()));
            HashHeadDetail2 = new List<HeadDetail>(br.ReadStruct<HeadDetail>(br.ReadInt32()));
            HashHair = new List<HeadDetail>(br.ReadStruct<HeadDetail>(br.ReadInt32()));
            HashEyes = new List<HeadDetail>(br.ReadStruct<HeadDetail>(br.ReadInt32()));
            HashHelmet = new List<HeadDetail>(br.ReadStruct<HeadDetail>(br.ReadInt32()));
            HashMouthes = new List<HeadDetail>(br.ReadStruct<HeadDetail>(br.ReadInt32()));
        }
    }
}