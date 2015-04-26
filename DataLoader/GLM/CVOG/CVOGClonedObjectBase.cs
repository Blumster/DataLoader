using System;
using System.Diagnostics;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using Entities;
    using WAD;
    using WAD.Entities;

    public abstract class CVOGClonedObjectBase
    {
        public UInt32 CBID;
        public UInt32 COID;
        public CloneBaseObject CloneBaseObject;
        public Boolean IsGlobal;
        public Byte Layer;

        public UInt64[] TriggerEvents;

        public abstract void Unserialize(BinaryReader br, UInt32 mapVersion);

        public void ReadTriggerEvents(BinaryReader br, UInt32 mapVersion)
        {
            TriggerEvents = br.Read<UInt64>(3);
        }

        public virtual void InitializeFromCBID(UInt32 cbid, SectorMap map)
        {
            CBID = cbid;
            CloneBaseObject = AssetManager.Instance.ContentHolder.GetCloneBaseObjectForCBID(CBID);
        }

        public void SetCOID(UInt32 coid)
        {
            COID = coid;
            IsGlobal = false;
        }

        public static CVOGClonedObjectBase AllocateNewObjectFromCBID(UInt32 cbid)
        {
            var clonebaseobj = AssetManager.Instance.ContentHolder.GetCloneBaseObjectForCBID(cbid);
            if (clonebaseobj == null)
                return null;

            switch (clonebaseobj.Type)
            {
                case ObjectType.Reaction:
                    return new CVOGReaction();

                case ObjectType.Trigger:
                    return new CVOGTrigger();

                case ObjectType.SpawnPoint:
                    return new CVOGSpawnPoint();

                case ObjectType.Store:
                    return new CVOGStore();

                case ObjectType.MapPath:
                    return new CVOGMapPath();

                case ObjectType.EnterPoint:
                    return new CVOGEnterPoint();

                case ObjectType.Outpost:
                    return new CVOGOutPost();

                    // Skip cases
                case ObjectType.ObjectGraphics:
                case ObjectType.ObjectGraphicsPhysics:
                case ObjectType.QuestObject:
                    return null;

                default:
                    Console.WriteLine(clonebaseobj.Type);
                    Debug.Assert(false, "Unreachable code reached!");
                    break;
            }

            return null;
        }
    }
}