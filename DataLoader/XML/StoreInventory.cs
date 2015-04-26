using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct StoreInventory
    {
        [XmlElement("CBIDStore")]   public UInt32 StoreCBID;
        [XmlElement("CBIDItem")]    public UInt32 ItemCBID;
        [XmlElement("sinQuantity")] public Byte Quantity;
    }
}
