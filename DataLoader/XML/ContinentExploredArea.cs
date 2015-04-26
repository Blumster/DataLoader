using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct ContinentExploredArea
    {
        [XmlElement("IDContinentObject")] public UInt32 ContinentObject;

        [XmlElement("IDExploredArea")] public Byte ExploredArea;

        [XmlElement("strExploredAreaName")] public String ExploredAreaName;

        [XmlElement("intXPLevel")] public Int32 XPLevel;

        public override String ToString()
        {
            return String.Format("ID: {0}-{2} | {1}", ContinentObject, ExploredAreaName, ExploredArea);
        }
    }
}