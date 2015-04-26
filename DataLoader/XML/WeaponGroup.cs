using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct WeaponGroup
    {
        [XmlElement("IDWeaponGroup")] public Byte GroupId;
        [XmlElement("strName")]       public String Name;
    }
}
