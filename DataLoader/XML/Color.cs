using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Color
    {
        [XmlElement("IDColor")] public UInt32 IDColor;

        [XmlElement("intRGBColor")] public Int32 RGBColor;
        [XmlElement("intWorth")] public Int32 Worth;

        [XmlElement("intWorthBiomek")] public Int32 WorthBiomek;
        [XmlElement("intWorthHuman")] public Int32 WorthHuman;
        [XmlElement("intWorthMutant")] public Int32 WorthMutant;

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", IDColor, RGBColor);
        }
    }
}