using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DataLoader.GLM.Entities
{
    using CVOG;
    using WAD;

    public class SectorMap
    {
        #region Declarations

        public static Dictionary<String, List<SectorMap>> Terrains = new Dictionary<String, List<SectorMap>>();
        public UInt32 COID;
        public Catalog Catalog;
        public UInt64 CreatorLoadTrigger;

        public Single CullingStyle;
        public Single EntryW;
        public Single EntryX;
        public Single EntryY;
        public Single EntryZ;
        public Int32 FileLen;
        public String FileName;
        public UInt32 Flags;
        public Single GridSize;
        public UInt32 IterationVersion;
        public UInt64 LastTeamTrigger;
        public String MapFileName;
        public UInt32 MapVersion;
        public Dictionary<UInt32, MissionString> MissionStrings = new Dictionary<UInt32, MissionString>();
        public UInt16[] Music;
        public Int32 NumModulePlacements;
        public Int32 NumOfClientVOGOs;
        public UInt32 NumOfImports;
        public Int32 NumOfVOGOs;

        public Dictionary<ObjectType, List<CVOGClonedObjectBase>> ObjectBasesByType =
            new Dictionary<ObjectType, List<CVOGClonedObjectBase>>();

        public UInt64 OnKillTrigger;
        public UInt64 PerPlayerLoadTrigger;
        public SeaPlane SeaPlane;
        public Byte TileSet;
        public Boolean UseClouds;
        public Boolean UseRoad;
        public Boolean UseTimeOfDay;
        public Dictionary<UInt32, Variable> Variables = new Dictionary<UInt32, Variable>();
        public Dictionary<UInt32, VisualWaypoint> VisualWaypoints = new Dictionary<UInt32, VisualWaypoint>();
        public Dictionary<Byte, WeatherContainer> WeatherInfos = new Dictionary<Byte, WeatherContainer>();
        public String WeatherStrEffect;

        #endregion

        public static SectorMap Read(String name, BinaryReader br)
        {
            var t = new SectorMap { MapVersion = br.ReadUInt32(), MapFileName = name }; // 60 < MapVersion < 62

            #region Header

            if (t.MapVersion < 4 || t.MapVersion > 62)
                return null;

            if (t.MapVersion >= 27)
                t.IterationVersion = br.ReadUInt32();

            br.ReadBytes(8);

            t.GridSize = br.ReadSingle();
            t.TileSet = br.ReadByte();
            t.UseRoad = br.ReadBoolean();
            t.Music = new [] {br.ReadUInt16(), br.ReadUInt16(), br.ReadUInt16()};

            if (t.MapVersion >= 11)
            {
                t.UseClouds = br.ReadBoolean();
                t.UseTimeOfDay = br.ReadBoolean();

                t.FileLen = br.ReadInt32();

                if (t.FileLen > 0)
                    t.FileName = Encoding.UTF8.GetString(br.ReadBytes(t.FileLen));
            }

            if (t.MapVersion >= 36)
                t.CullingStyle = br.ReadSingle();

            if (t.MapVersion >= 45)
                t.NumOfImports = br.ReadUInt32();

            #endregion

            #region Common Data

            t.EntryX = br.ReadSingle();
            t.EntryY = br.ReadSingle();
            t.EntryZ = br.ReadSingle();
            t.EntryW = br.ReadSingle();

            using (var sw = new StreamWriter("coords.txt", true, Encoding.UTF8))
                sw.WriteLine("Id: {1,4} | X: {2,10} | Y: {3,10} | Z: {4,10} | Q1: 0 | Q2: 0 | Q3: 0 | Q4: 1 | Map Name: {0}", t.MapFileName, AssetManager.Instance.DataHolder.ContinentObjects.Where(c => t.MapFileName.StartsWith(c.MapFileName)).Select(c => c.ContinentObjectId).FirstOrDefault(), t.EntryX, t.EntryY, t.EntryZ);

            t.NumModulePlacements = br.ReadInt32();
            t.NumOfVOGOs = br.ReadInt32();
            t.NumOfClientVOGOs = br.ReadInt32();
            t.COID = br.ReadUInt32();
            t.PerPlayerLoadTrigger = br.ReadUInt64();
            t.CreatorLoadTrigger = br.ReadUInt64();

            if (t.MapVersion >= 33)
                t.OnKillTrigger = br.ReadUInt64();

            if (t.MapVersion >= 34)
                t.LastTeamTrigger = br.ReadUInt64();

            var missC = br.ReadUInt32();
            for (var i = 0U; i < missC; ++i)
            {
                var ms = MissionString.Read(br, t.MapVersion);
                t.MissionStrings.Add(ms.StringId, ms);
            }

            var wpC = br.ReadUInt32();
            for (var i = 0U; i < wpC; ++i)
            {
                var wp = VisualWaypoint.Read(br, t.MapVersion);
                t.VisualWaypoints.Add(wp.Id, wp);
            }

            var varC = br.ReadUInt32();
            for (var i = 0U; i < varC; ++i)
            {
                var v = Variable.Read(br, t.MapVersion);
                t.Variables.Add(v.Id, v);
            }

            #region UNUSED

            if (t.MapVersion >= 37 && t.MapVersion < 47)
            {
                Debug.Assert(false, "OLD VERSION FORMAT IS NOT IMPLEMENTED! >= 37 && < 47");
                /*var count = br.ReadUInt32();
                for (var i = 0U; i < count; ++i)
                {
                    var pct = br.ReadSingle();
                    var specEvent = br.ReadUInt32();
                    var minTimeToLive = br.ReadUInt32();
                    var eventTimesPerMinute = br.ReadUInt32();
                    var maxTimeToLive = br.ReadByte();
                    var currentTimeToLive = br.ReadUInt32();
                    var currentChance = br.ReadSingle();
                    var str = Encoding.UTF8.GetString(br.ReadBytes(br.ReadInt32()));
                }

                var count2 = br.ReadUInt32();
                for (var i = 0U; i < count2; ++i)
                    t.WeatherUnks.Add(br.ReadUInt32());*/
            }

            if (t.MapVersion >= 38 && t.MapVersion < 47)
            {
                Debug.Assert(false, "OLD VERSION FORMAT IS NOT IMPLEMENTED! >= 38 && < 47");
                /*var strLen = br.ReadInt32();
                if (strLen > 0)
                {
                    var strEffect = Encoding.UTF8.GetString(br.ReadBytes(strLen));
                }

                var count = br.ReadUInt32();
                for (var i = 0U; i < count; ++i)
                {
                    var strLen2 = br.ReadInt32();
                    if (strLen2 > 0)
                    {
                        var strEffect = Encoding.UTF8.GetString(br.ReadBytes(strLen2));
                    }

                }*/
            }

            #endregion

            if (t.MapVersion >= 47)
            {
                t.WeatherStrEffect = br.ReadLengthedString();

                var regionCount = br.ReadUInt32();
                for (var i = 0U; i < regionCount; ++i)
                {
                    var regionId = br.ReadByte();

                    if (!t.WeatherInfos.ContainsKey(regionId))
                        t.WeatherInfos.Add(regionId, new WeatherContainer());

                    var weatherCount = br.ReadUInt32();
                    for (var j = 0U; j < weatherCount; ++j)
                    {
                        t.WeatherInfos[regionId].Weathers.Add(new WeatherInfo
                        {
                            SpecialType = br.ReadUInt32(),
                            Type = br.ReadUInt32(),
                            PercentChance = br.ReadSingle(),
                            SpecialEventSkill = br.ReadInt32(),
                            EventTimesPerMinute = br.ReadByte(),
                            MinTimeToLive = br.ReadUInt32(),
                            MaxTimeToLive = br.ReadUInt32(),
                            LayerBits = t.MapVersion >= 54 ? br.ReadUInt32() : 1,
                            FxName = br.ReadLengthedString()
                        });
                    }

                    t.WeatherInfos[regionId].Effect = br.ReadLengthedString();

                    for (var j = 0; j < 4; ++j)
                        t.WeatherInfos[regionId].Environments.Add(br.ReadLengthedString());
                }
            }

            if (t.MapVersion >= 38)
            {
                // Sea Plane Data
                if (t.MapVersion >= 35)
                {
                    if (br.ReadByte() != 0)
                    {
                        var planeCount = br.ReadInt32();

                        t.SeaPlane.Coords = Vector4.Read(br);
                        t.SeaPlane.CoordsList = new List<Vector4>(planeCount);

                        for (var i = 0; i < planeCount; ++i)
                            t.SeaPlane.CoordsList.Add(Vector4.Read(br));
                    }
                }
            }

            #endregion

            #region ModulePlacements

            for (var i = 0; i < t.NumModulePlacements; ++i)
            {
                Debug.Assert(false, "Unreachable code reached!");
                /*if (t.MapVersion > 5)
                {
                    var layer = br.ReadByte();
                }

                var cbid = br.ReadUInt32();
                var cbidstr = AssetManager.Instance.ContentHolder.GetNameFromCBID(cbid);

                var numBytes = br.ReadUInt32();*/
            }

            #endregion

            #region VOGOs

            for (var i = 0; i < t.NumOfClientVOGOs + t.NumOfVOGOs; ++i)
            {
                Console.Title = String.Format("({3}) {0}: {1}/{2}", name, i + 1, t.NumOfClientVOGOs + t.NumOfVOGOs, Terrains.Count);

                Byte layer = 0;
                if (t.MapVersion > 5)
                    layer = br.ReadByte();

                var cbid = br.ReadUInt32();
                var coid = br.ReadUInt32();

                var skipBytes = br.ReadInt32(); // skip this many bytes, if client already loaded this clone base object

                var obj = CVOGClonedObjectBase.AllocateNewObjectFromCBID(cbid);
                if (obj == null)
                {
                    br.BaseStream.Seek(skipBytes, SeekOrigin.Current);
                    continue;
                }

                obj.InitializeFromCBID(cbid, t);
                obj.Layer = layer;
                obj.SetCOID(coid);

                var pos = br.BaseStream.Position;

                try
                {
                    obj.Unserialize(br, t.MapVersion);
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("EOS?!?!");
                }
                

                if (!t.ObjectBasesByType.ContainsKey(obj.CloneBaseObject.Type))
                    t.ObjectBasesByType.Add(obj.CloneBaseObject.Type, new List<CVOGClonedObjectBase>());

                t.ObjectBasesByType[obj.CloneBaseObject.Type].Add(obj);

                if (pos + skipBytes == br.BaseStream.Position)
                    continue;

                Console.WriteLine("COID: {0} ({1}) | {2} reading | Read size: {3} | Total size: {4} | Diff: {5}", coid,  obj.CloneBaseObject.Type, (pos + skipBytes > br.BaseStream.Position ? "under" : "over"), Math.Abs(br.BaseStream.Position - pos), skipBytes, skipBytes - Math.Abs(br.BaseStream.Position - pos));
                br.BaseStream.Position = pos + skipBytes;
            }

            #endregion

            #region End

            if (t.MapVersion >= 43)
                t.Flags = br.ReadUInt32();

            var numRoads = br.ReadUInt32();
            for (var i = 0U; i < numRoads; ++i)
            {
                var unk = br.ReadUInt32();
                var type = br.ReadByte();

                CVOGRoadNodeBase roadNodeBase;

                switch (type)
                {
                    case 0:
                        roadNodeBase = new CVOGRoadNode();
                        break;

                    case 1:
                        roadNodeBase = new CVOGRoadJunction();
                        break;

                    case 2:
                        roadNodeBase = new CVOGRiverNode();
                        break;

                    default:
                        throw new InvalidDataException("Invalid road node base type!");
                }

                roadNodeBase.UnSerialize(br, t.MapVersion);
            }

            /*if (t.MapVersion < 38)
            {
                if (t.MapVersion >= 35)
                {
                    if (br.ReadByte() != 0)
                    {
                        var planeCount = br.ReadInt32();

                        t.SeaPlane.Coords = Vector4.Read(br);
                        t.SeaPlane.CoordsList = new List<Vector4>(planeCount);

                        for (var i = 0; i < planeCount; ++i)
                            t.SeaPlane.CoordsList.Add(Vector4.Read(br));
                    }
                }
            }*/

            if (t.MapVersion >= 42)
            {
                var numMusicRegion = br.ReadUInt32();
                for (var i = 0U; i < numMusicRegion; ++i)
                {
                    var unk = br.ReadUInt32();
                    if (t.MapVersion < 42)
                        continue;

                    var musicName = br.ReadLengthedString();
                    var looping = br.ReadBoolean();
                    var silenceatmaxradius = br.ReadBoolean();
                    var durationForRepeat = br.ReadSingle();
                    var fadeintime = br.ReadSingle();
                    var fadeouttime = br.ReadSingle();
                    var maxradius = br.ReadSingle();
                    var x = br.ReadSingle();
                    var y = br.ReadSingle();
                    var z = br.ReadSingle();
                    var musicType = br.ReadUInt32();
                }
            }

            if (t.MapVersion >= 30)
            {
                var streamVer = br.ReadUInt32();
                var width = br.ReadInt32();
                var height = br.ReadInt32();
                var maxobjcountperglomsector = br.ReadInt32();

                var objectcount = br.ReadInt32();
                for (var i = 0; i < objectcount; ++i)
                {
                    var streamVer2 = br.ReadUInt32();
                    var cbidVisual = br.ReadInt32();
                    var drawSizeMin = br.ReadSingle();
                    var drawSizeVariance = br.ReadSingle();
                    var thresholdMin = br.ReadByte();
                    var thresholdMax = br.ReadByte();
                    var layerMask = br.ReadByte();
                    var placeWithGroundNormal = br.ReadByte();
                }

                var inlineDensityMap = br.ReadBoolean();
                Debug.Assert(!inlineDensityMap, "I HOPE THIS IS UNREACHABLE!");
            }

            t.Catalog = Catalog.Read(br, t);

            #endregion

            if (!Terrains.ContainsKey(name))
                Terrains.Add(name, new List<SectorMap>());

            Terrains[name].Add(t);

            return t;
        }
    }

    public struct MissionString
    {
        public UInt32 OwnerId;
        public UInt32 StringId;
        public String Text;
        public Byte Type;

        public static MissionString Read(BinaryReader br, UInt32 mapVersion)
        {
            return new MissionString
                {
                    StringId = br.ReadUInt32(),
                    OwnerId = br.ReadUInt32(),
                    Type = mapVersion >= 18 ? br.ReadByte() : (Byte) 0,
                    Text = Encoding.UTF8.GetString(br.ReadBytes(br.ReadInt32()))
                };
        }
    }

    public struct VisualWaypoint
    {
        public UInt32 Id;
        public UInt64 ObjectCOID;
        public UInt32 ObjectiveCount;
        public List<UInt32> Objectives;
        public UInt64 ReactionCOID;
        public Byte Type;
        public Single X;
        public Single Y;
        public Single Z;

        public static VisualWaypoint Read(BinaryReader br, UInt32 mapVersion)
        {
            var wp = new VisualWaypoint {Objectives = new List<UInt32>()};

            if (mapVersion <= 24)
            {
                if (mapVersion > 22)
                {
                    wp.Id = br.ReadUInt32();
                    wp.Type = br.ReadByte();
                    br.ReadBytes(3);
                    wp.ObjectCOID = br.ReadUInt64();
                    wp.X = br.ReadSingle();
                    wp.Y = br.ReadSingle();
                    wp.Z = br.ReadSingle();
                    br.ReadBytes(4);
                    wp.ReactionCOID = br.ReadUInt64();
                    wp.ObjectiveCount = br.ReadUInt32();

                    for (uint i = 0U; i < 4; ++i)
                        wp.Objectives.Add(br.ReadUInt32());

                    br.ReadBytes(4);
                }
                else if (mapVersion <= 12)
                {
                    wp.Id = br.ReadUInt32();
                    wp.Type = br.ReadByte();
                    br.ReadBytes(3);
                    wp.ObjectCOID = br.ReadUInt64();
                    wp.X = br.ReadSingle();
                    wp.Y = br.ReadSingle();
                    wp.Z = br.ReadSingle();
                    br.ReadBytes(4);
                }
                else
                {
                    wp.Id = br.ReadUInt32();
                    wp.Type = br.ReadByte();
                    br.ReadBytes(3);
                    wp.ObjectCOID = br.ReadUInt64();
                    wp.X = br.ReadSingle();
                    wp.Y = br.ReadSingle();
                    wp.Z = br.ReadSingle();
                    br.ReadBytes(4);
                    wp.ReactionCOID = br.ReadUInt64();
                }
            }
            else
            {
                /*var version = */
                br.ReadUInt32(); // Stream version

                wp.Id = br.ReadUInt32();
                wp.Type = br.ReadByte();
                wp.X = br.ReadSingle();
                wp.Y = br.ReadSingle();
                wp.Z = br.ReadSingle();
                wp.ObjectCOID = br.ReadUInt64();
                wp.ReactionCOID = br.ReadUInt64();
                wp.ObjectiveCount = br.ReadUInt32();

                for (uint i = 0U; i < wp.ObjectiveCount; ++i)
                    wp.Objectives.Add(br.ReadUInt32());
            }
            return wp;
        }
    }

    public struct Variable
    {
        public UInt32 Id;
        public Single InitialValue;
        public List<UInt64> Triggers;
        public Byte Type;
        public Boolean UniqueForImport;
        public Single Value;

        public static Variable Read(BinaryReader br, UInt32 mapVersion)
        {
            return new Variable
                {
                    Id = br.ReadUInt32(),
                    Type = br.ReadByte(),
                    Value = br.ReadSingle(),
                    InitialValue = br.ReadSingle(),
                    UniqueForImport = mapVersion >= 46 && br.ReadBoolean(),
                    Triggers = new List<UInt64>(br.Read<UInt64>(8))
                };
        }
    }

    public struct WeatherInfo
    {
        public Byte EventTimesPerMinute;
        public String FxName;
        public UInt32 LayerBits;
        public UInt32 MaxTimeToLive;
        public UInt32 MinTimeToLive;
        public Single PercentChance;
        public Int32 SpecialEventSkill;
        public UInt32 SpecialType;
        public UInt32 Type;
    }

    public class WeatherContainer
    {
        public String Effect;
        public List<String> Environments = new List<String>();
        public List<WeatherInfo> Weathers = new List<WeatherInfo>();
    }

    public struct Vector4
    {
        public Single W;
        public Single X, Y, Z;

        public static Vector4 Read(BinaryReader br)
        {
            return new Vector4
                {
                    X = br.ReadSingle(),
                    Y = br.ReadSingle(),
                    Z = br.ReadSingle(),
                    W = br.ReadSingle()
                };
        }

        public override String ToString()
        {
            return String.Format("X: {0} | Y: {1} | Z: {2} | W: {3}", X, Y, Z, W);
        }
    }

    public struct SeaPlane
    {
        public Vector4 Coords;
        public List<Vector4> CoordsList;
    }
}