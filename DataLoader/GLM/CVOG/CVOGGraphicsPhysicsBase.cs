using System;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    public class CVOGGraphicsPhysicsBase : CVOGClonedObjectBase
    {
        public CVOGGraphicsBase CVOGGraphicsBase = new CVOGGraphicsBase();
        public CVOGPhysicsBase CVOGPhysicsBase = new CVOGPhysicsBase();

        public override void Unserialize(BinaryReader br, UInt32 mapVersion)
        {
            CVOGGraphicsBase.UnserializeCreateEffect(br, mapVersion);
            CVOGGraphicsBase.UnserializeTooltip(br, mapVersion);
            ReadTriggerEvents(br, mapVersion);
            CVOGPhysicsBase.UnSerialize(br, mapVersion);
        }
    }
}