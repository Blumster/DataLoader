using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct RaceSpecificItem
    {
        [XmlElement("IDCloneBase")] public UInt32 CloneBase;
        [XmlElement("intType")] public Byte Type;
        [XmlElement("IDCategory")] public Int32 Category;
        [XmlElement("strUniqueName")] public String UniqueName;
        [XmlElement("strShortDesc")] public String ShortDesc;
        [XmlElement("strLongDesc")] public String LongDesc;
        [XmlElement("strFXFileName")] public String FXFileName;
        [XmlElement("bitIsGeneratable")] public String _isGenerateable;
        [XmlElement("bitTerrainAlpine")] public String _isTerrainAlpine;
        [XmlElement("bitTerrainDirtArena")] public String _isTerrainDirtArena;
        [XmlElement("bitTerrainDesert")] public String _isTerrainDesert;
        [XmlElement("bitTerrainMutantTown")] public String _isTerrainMutantTown;
        [XmlElement("bitTerrainJungle")] public String _isTerrainJungle;
        [XmlElement("bitTerrainSwamp")] public String _isTerrainSwamp;
        [XmlElement("bitTerrainPlains")] public String _isTerrainPlains;
        [XmlElement("bitTerrainIceCap")] public String _isTerrainIceCap;
        [XmlElement("bitTerrainVolcanic")] public String _isTerrainVolcanic;
        [XmlElement("bitTerrainAlien")] public String _isTerrainAlien;
        [XmlElement("bitTerrainSubterranean")] public String _isTerrainSubterranean;
        [XmlElement("bitTerrainArena")] public String _isTerrainArena;
        [XmlElement("bitTerrainUniversal")] public String _isTerrainUniversal;
        [XmlElement("bitIsTargetable")] public String _isTargetable;
        [XmlElement("dteCreated")] public String Created;
        [XmlElement("dteModified")] public String Modified;
        [XmlElement("bitIsDeleted")] public String _isDeleted;
        [XmlElement("tinRenderType")] public Byte RenderType;
        [XmlElement("rlMass")] public Single Mass;
        [XmlElement("rlAlpha")] public Single Alpha;
        [XmlElement("strPhysicsName")] public String PhysicsName;
        [XmlElement("sinMinHitPoints")] public Int32 MinHitPoints;
        [XmlElement("sinMaxHitPoints")] public Int32 MaxHitPoints;
        [XmlElement("bitCollidable")] public String _isCollidable;
        [XmlElement("bitFixed")] public String _isFixed;
        [XmlElement("bitHasAnimation")] public String _hasAnimation;
        [XmlElement("bitAlphaTest")] public String _isAlphaTest;
        [XmlElement("bitCustomColors")] public String _isCustomColors;
        [XmlElement("bitInvisibleObject")] public String _isInvisibleObject;
        [XmlElement("bitIsStackable")] public String _isStackable;
        [XmlElement("bitIsUsable")] public String _isUsable;
        [XmlElement("bitHasGeo")] public String _hasGeo;
        [XmlElement("bitIsInvincible")] public String _isInvincible;
        [XmlElement("bitIsLootable")] public String _isLootable;
        [XmlElement("IDArmor")] public Int32 ArmorCBID;
        [XmlElement("tinInventorySizeX")] public Byte InvSizeX;
        [XmlElement("tinInventorySizeY")] public Byte InvSizeY;
        [XmlElement("IDFaction")] public Int32 FactionId;
        [XmlElement("sinSubType")] public Byte SubType;
        [XmlElement("IDSkill_1")] public Int32 Skill1;
        [XmlElement("IDSkill_2")] public Int32 Skill2;
        [XmlElement("IDSkill_3")] public Int32 Skill3;
        [XmlElement("intCustomColor")] public Int32 CustomColor;
        [XmlElement("rlViewerScale")] public Single ViewerScale;
        [XmlElement("bitHasDialog")] public String _hasDialog;
        [XmlElement("bitIsUnique")] public String _isUnique;
        [XmlElement("sinRaceRegenRate")] public Int32 RaceRegenRate;
        [XmlElement("sinRaceShieldFactor")] public Int32 RaceShieldFactor;
    }
}
