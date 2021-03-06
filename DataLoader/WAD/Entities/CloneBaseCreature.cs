﻿using System.IO;

namespace DataLoader.WAD.Entities
{
    using Specifics;

    public class CloneBaseCreature : CloneBaseObject
    {
        public CreatureSpecific CreatureSpecific;

        public CloneBaseCreature(BinaryReader br)
            : base(br)
        {
            CreatureSpecific = CreatureSpecific.Read(br);
        }
    }
}