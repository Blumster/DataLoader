using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct WeaponGroupX
    {
        [XmlElement("CBIDWeapon")] public UInt32 WeaponCBID;
        [XmlElement("IDWeaponGroup")] public Byte GroupId;
    }
}
