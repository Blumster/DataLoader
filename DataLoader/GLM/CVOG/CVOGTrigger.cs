using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    using Entities;

    public class CVOGTrigger : CVOGClonedObjectBase
    {
        public Single ActivateDelay;
        public Int32 ActivationCount;
        public Boolean AllConditionNeeded;
        public Boolean ApplyToAllColliders;
        public UInt32 Color;
        public Boolean DoCollision;
        public Boolean DoConditionals;
        public Boolean DoOnActivate;
        public Vector4 Location;
        public String Name;
        public Vector4 Quaternion;
        public Single Radius;
        public List<UInt64> Reactions = new List<UInt64>();
        public Single RetriggerDelay;
        public Boolean ShowMapTransitionDecals;
        public Byte TargetType;
        public List<TFID> Targets = new List<TFID>();
        public List<TriggerConditional> TriggerConditionals = new List<TriggerConditional>();
        public UInt32 TriggerId;

        public override void Unserialize(BinaryReader br, UInt32 mapVersion)
        {
            Location = Vector4.Read(br);
            Quaternion = Vector4.Read(br);
            Radius = br.ReadSingle();
            Name = br.ReadStringOn(64);
            RetriggerDelay = br.ReadSingle();
            ActivateDelay = br.ReadSingle();
            ActivationCount = br.ReadInt32();

            TargetType = br.ReadByte();
            DoCollision = br.ReadBoolean();
            DoConditionals = br.ReadBoolean();

            if (mapVersion >= 44)
                ShowMapTransitionDecals = br.ReadBoolean();

            DoOnActivate = br.ReadBoolean();
            AllConditionNeeded = br.ReadBoolean();

            if (mapVersion >= 60)
                ApplyToAllColliders = br.ReadBoolean();
            else
                ApplyToAllColliders = DoCollision && RetriggerDelay <= 0.0f;

            uint numReac = br.ReadUInt32();
            for (int i = 0; i < numReac; ++i)
                Reactions.Add(br.ReadUInt32());

            uint numTarget = br.ReadUInt32();
            for (int i = 0; i < numTarget; ++i)
                Targets.Add(TFID.Read(br));

            uint numConditials = br.ReadUInt32();
            for (int i = 0; i < numConditials; ++i)
                TriggerConditionals.Add(TriggerConditional.Read(br));

            if (mapVersion >= 9)
                Color = br.ReadUInt32();

            if (mapVersion >= 55)
                TriggerId = br.ReadUInt32();
        }
    }

    public struct TFID
    {
        public UInt64 COID;
        public Boolean Global;

        public static TFID Read(BinaryReader br)
        {
            return new TFID
                {
                    Global = br.ReadByte() != 0,
                    COID = br.ReadUInt32()
                };
        }
    }
}

/*
- 240 -> m_pPhantom
- 236 -> m_pListener
- 232 -> m_pHBLocationTrigger
- 228 -> m_cTargetType
- 227 -> m_cShapeType
- 226 -> m_bDoCollision
- 225 -> m_bDoConditionals
- 224 -> m_bDoOnActivate
- 223 -> m_bAllConditionsNeeded
- 222 -> m_bShowMapTransitionDecals
- 221 -> m_strName
- 156 -> m_vecTargetList
- 140 -> m_vecQueuedTargetList
- 124 -> m_vecReactions
- 108 -> m_fRetriggerDelay
- 104 -> m_fActivateDelay
- 100 -> m_lActivationCount
-  96 -> m_bReadyToTrigger
-  92 -> m_vecConditionals
-  72 -> m_coidLeftObject
-  64 -> m_coidRightObject
-  56 -> m_cLeftType
-  55 -> m_cRightType
-  54 -> m_bLoopLock
-  53 -> m_bApplyToAllColliders
-  52 -> m_lLastStepNumber
-  48 -> m_dwColor
-  44 -> m_dwLastCollided
-  40 -> m_dwTriggerID
-  36 -> m_vecRecentActivatedList
*/