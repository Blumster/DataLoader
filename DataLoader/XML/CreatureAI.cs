using System;
using System.Globalization;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct CreatureAI
    {
        [XmlElement("AICode")] public UInt32 Code;

        [XmlElement("strDescInternal")] public String Description;
        [XmlElement("AIID")] public UInt32 Id;

        [XmlElement("val1")] public String _val1;

        [XmlElement("val10")] public String _val10;

        [XmlElement("val11")] public String _val11;

        [XmlElement("val12")] public String _val12;

        [XmlElement("val13")] public String _val13;

        [XmlElement("val14")] public String _val14;

        [XmlElement("val15")] public String _val15;

        [XmlElement("val16")] public String _val16;

        [XmlElement("val17")] public String _val17;

        [XmlElement("val18")] public String _val18;

        [XmlElement("val19")] public String _val19;
        [XmlElement("val2")] public String _val2;

        [XmlElement("val20")] public String _val20;
        [XmlElement("val3")] public String _val3;

        [XmlElement("val4")] public String _val4;

        [XmlElement("val5")] public String _val5;

        [XmlElement("val6")] public String _val6;

        [XmlElement("val7")] public String _val7;

        [XmlElement("val8")] public String _val8;

        [XmlElement("val9")] public String _val9;

        public Double Val1
        {
            get { return _val1.Length == 0 ? 0.0f : Double.Parse(_val1, CultureInfo.InvariantCulture); }
        }

        public Double Val2
        {
            get { return _val2.Length == 0 ? 0.0f : Double.Parse(_val2, CultureInfo.InvariantCulture); }
        }

        public Double Val3
        {
            get { return _val3.Length == 0 ? 0.0f : Double.Parse(_val3, CultureInfo.InvariantCulture); }
        }

        public Double Val4
        {
            get { return _val4.Length == 0 ? 0.0f : Double.Parse(_val4, CultureInfo.InvariantCulture); }
        }

        public Double Val5
        {
            get { return _val5.Length == 0 ? 0.0f : Double.Parse(_val5, CultureInfo.InvariantCulture); }
        }

        public Double Val6
        {
            get { return _val6.Length == 0 ? 0.0f : Double.Parse(_val6, CultureInfo.InvariantCulture); }
        }

        public Double Val7
        {
            get { return _val7.Length == 0 ? 0.0f : Double.Parse(_val7, CultureInfo.InvariantCulture); }
        }

        public Double Val8
        {
            get { return _val8.Length == 0 ? 0.0f : Double.Parse(_val8, CultureInfo.InvariantCulture); }
        }

        public Double Val9
        {
            get { return _val9.Length == 0 ? 0.0f : Double.Parse(_val9, CultureInfo.InvariantCulture); }
        }

        public Double Val10
        {
            get { return _val10.Length == 0 ? 0.0f : Double.Parse(_val10, CultureInfo.InvariantCulture); }
        }

        public Double Val11
        {
            get { return _val11.Length == 0 ? 0.0f : Double.Parse(_val11, CultureInfo.InvariantCulture); }
        }

        public Double Val12
        {
            get { return _val12.Length == 0 ? 0.0f : Double.Parse(_val12, CultureInfo.InvariantCulture); }
        }

        public Double Val13
        {
            get { return _val13.Length == 0 ? 0.0f : Double.Parse(_val13, CultureInfo.InvariantCulture); }
        }

        public Double Val14
        {
            get { return _val14.Length == 0 ? 0.0f : Double.Parse(_val14, CultureInfo.InvariantCulture); }
        }

        public Double Val15
        {
            get { return _val15.Length == 0 ? 0.0f : Double.Parse(_val15, CultureInfo.InvariantCulture); }
        }

        public Double Val16
        {
            get { return _val16.Length == 0 ? 0.0f : Double.Parse(_val16, CultureInfo.InvariantCulture); }
        }

        public Double Val17
        {
            get { return _val17.Length == 0 ? 0.0f : Double.Parse(_val17, CultureInfo.InvariantCulture); }
        }

        public Double Val18
        {
            get { return _val18.Length == 0 ? 0.0f : Double.Parse(_val18, CultureInfo.InvariantCulture); }
        }

        public Double Val19
        {
            get { return _val19.Length == 0 ? 0.0f : Double.Parse(_val19, CultureInfo.InvariantCulture); }
        }

        public Double Val20
        {
            get { return _val20.Length == 0 ? 0.0f : Double.Parse(_val20, CultureInfo.InvariantCulture); }
        }

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Id, Description);
        }
    }
}