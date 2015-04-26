using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DataLoader.WAD
{
    using Entities;
    using Prefixes;
    using Quests;
    using Skills;

    public class WADReader
    {
        private readonly String _fileName;

        public WADReader(String fName)
        {
            _fileName = fName;
        }

        public ContentHolder ReadFile()
        {
            var ch = new ContentHolder();

            using (var br = new BinaryReader(new FileStream(_fileName, FileMode.Open, FileAccess.Read)))
            {
                uint version = br.ReadUInt32();
                Debug.Assert(version == 27);

                uint objectCount = br.ReadUInt32();
                for (uint i = 0U; i < objectCount; ++i)
                {
                    uint type = br.ReadUInt32();

                    var eType = (ObjectType) type;

                    if (!ch.CloneObjects.ContainsKey(eType))
                        ch.CloneObjects.Add(eType, new List<CloneBaseObject>());

                    switch (eType)
                    {
                        case ObjectType.ObjectGraphics:
                        case ObjectType.ObjectGraphicsPhysics:
                        case ObjectType.QuestObject:
                        case ObjectType.Item:
                        case ObjectType.Store:
                        case ObjectType.EnterPoint:
                        case ObjectType.ExitPoint:
                        case ObjectType.ContinentObject:
                        case ObjectType.Convoy:
                        case ObjectType.SpawnPoint:
                        case ObjectType.Trigger:
                        case ObjectType.Reaction:
                        case ObjectType.MapModulePlacement:
                        case ObjectType.MapPath:
                        case ObjectType.Money:
                        case ObjectType.Outpost:
                            ch.CloneObjects[eType].Add(new CloneBaseObject(br));
                            break;

                        case ObjectType.Commodity:
                            ch.CloneObjects[eType].Add(new CloneBaseCommodity(br));
                            break;

                        case ObjectType.Character:
                            ch.CloneObjects[eType].Add(new CloneBaseCharacter(br));
                            break;

                        case ObjectType.Weapon:
                        case ObjectType.Bullet:
                            ch.CloneObjects[eType].Add(new CloneBaseWeapon(br));
                            break;

                        case ObjectType.Gadget:
                            ch.CloneObjects[eType].Add(new CloneBaseGadget(br));
                            break;

                        case ObjectType.TinkeringKit:
                            ch.CloneObjects[eType].Add(new CloneBaseTinkeringKit(br));
                            break;

                        case ObjectType.Vehicle:
                            ch.CloneObjects[eType].Add(new CloneBaseVehicle(br));
                            break;

                        case ObjectType.PowerPlant:
                            ch.CloneObjects[eType].Add(new CloneBasePowerPlant(br));
                            break;

                        case ObjectType.WheelSet:
                            ch.CloneObjects[eType].Add(new CloneBaseWheelSet(br));
                            break;

                        case ObjectType.Creature:
                            ch.CloneObjects[eType].Add(new CloneBaseCreature(br));
                            break;

                        case ObjectType.Armor:
                            ch.CloneObjects[eType].Add(new CloneBaseArmor(br));
                            break;

                        default:
                            throw new Exception("asd");
                    }
                }

                uint missionCount = br.ReadUInt32();
                for (uint i = 0U; i < missionCount; ++i)
                {
                    var q = br.ReadStruct<Quest>();
                    ch.Quests.Add(q.Id, q);
                }

                uint skillCount = br.ReadUInt32();
                for (uint i = 0U; i < skillCount; ++i)
                {
                    var s = br.ReadStruct<Skill>();
                    ch.Skills.Add(s.Id, s);
                }

                int armorPrefCount = br.ReadInt32();
                for (uint i = 0U; i < armorPrefCount; ++i)
                {
                    var ap = br.ReadStruct<ArmorPrefix>();
                    ch.ArmorPrefixes.Add(ap.BasePrefix.Id, ap);
                }

                int powerPlantPrefCount = br.ReadInt32();
                for (uint i = 0U; i < powerPlantPrefCount; ++i)
                {
                    var ppp = br.ReadStruct<PowerPlantPrefix>();
                    ch.PowerPlantPrefixes.Add(ppp.BasePrefix.Id, ppp);
                }

                int weaponPrefCount = br.ReadInt32();
                for (uint i = 0U; i < weaponPrefCount; ++i)
                {
                    var wp = br.ReadStruct<WeaponPrefix>();
                    ch.WeaponPrefixes.Add(wp.BasePrefix.Id, wp);
                }

                int vehiclePrefCount = br.ReadInt32();
                for (uint i = 0U; i < vehiclePrefCount; ++i)
                {
                    var vp = br.ReadStruct<VehiclePrefix>();
                    ch.VehiclePrefixes.Add(vp.BasePrefix.Id, vp);
                }

                int ornamentPrefCount = br.ReadInt32();
                for (uint i = 0U; i < ornamentPrefCount; ++i)
                {
                    var op = br.ReadStruct<OrnamentPrefix>();
                    ch.OrnamentPrefixes.Add(op.BasePrefix.Id, op);
                }

                int raceItemPrefCount = br.ReadInt32();
                for (uint i = 0U; i < raceItemPrefCount; ++i)
                {
                    var rip = br.ReadStruct<RaceItemPrefix>();
                    ch.RaceItemPrefixes.Add(rip.BasePrefix.Id, rip);
                }
            }

            return ch;
        }
    }

    public enum ObjectType
    {
        //Object                = 1,
        ObjectGraphics = 1,
        ObjectGraphicsPhysics = 3,
        QuestObject = 4,
        Item = 6,
        Gadget = 8,
        PowerPlant = 10,
        Weapon = 12,
        Vehicle = 14,
        WheelSet = 16,
        Creature = 18,
        Character = 20,
        Store = 22,
        Bullet = 24,
        Commodity = 26,
        Armor = 28,
        EnterPoint = 30,
        ExitPoint = 32,
        ContinentObject = 34,
        Town = 36,
        Encounter = 38,
        CharacterBody = 40,
        CharacterHead = 42,
        CharacterHair = 44,
        CharacterAccessory = 46,
        Convoy = 48,
        TinkeringKit = 50,
        Accessory = 52,
        SpawnPoint = 54,
        Trigger = 56,
        Reaction = 58,
        MapModulePlacement = 60,
        MapPath = 62,
        MissionObject = 64,
        Money = 66,
        Ornament = 68,
        RaceItem = 70,
        Outpost = 72
    }

    public class ContentHolder
    {
        public Dictionary<Int32, ArmorPrefix> ArmorPrefixes;
        public Dictionary<ObjectType, List<CloneBaseObject>> CloneObjects;
        public Dictionary<Int32, OrnamentPrefix> OrnamentPrefixes;
        public Dictionary<Int32, PowerPlantPrefix> PowerPlantPrefixes;
        public Dictionary<Int32, Quest> Quests;
        public Dictionary<Int32, RaceItemPrefix> RaceItemPrefixes;
        public Dictionary<Int32, Skill> Skills;

        public Dictionary<Int32, VehiclePrefix> VehiclePrefixes;
        public Dictionary<Int32, WeaponPrefix> WeaponPrefixes;

        public ContentHolder()
        {
            CloneObjects = new Dictionary<ObjectType, List<CloneBaseObject>>();

            Quests = new Dictionary<Int32, Quest>();

            Skills = new Dictionary<Int32, Skill>();

            ArmorPrefixes = new Dictionary<Int32, ArmorPrefix>();
            PowerPlantPrefixes = new Dictionary<Int32, PowerPlantPrefix>();
            WeaponPrefixes = new Dictionary<Int32, WeaponPrefix>();
            VehiclePrefixes = new Dictionary<Int32, VehiclePrefix>();
            OrnamentPrefixes = new Dictionary<Int32, OrnamentPrefix>();
            RaceItemPrefixes = new Dictionary<Int32, RaceItemPrefix>();
        }

        public String GetNameFromCBID(UInt32 cbid)
        {
            foreach (
                var obj in
                    from o in CloneObjects
                    from obj in o.Value
                    where obj.CloneBaseSpecific.CloneBaseId == cbid
                    select obj)
                return obj.CloneBaseSpecific.ShortDesc;

            return String.Empty;
        }

        public CloneBaseObject GetCloneBaseObjectForCBID(UInt32 cbid)
        {
            return
                (from o in CloneObjects from obj in o.Value where obj.CloneBaseSpecific.CloneBaseId == cbid select obj).
                    FirstOrDefault();
        }
    }
}