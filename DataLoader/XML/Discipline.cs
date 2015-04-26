using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Discipline
    {
        [XmlElement("intCostToTrain")] public Int32 CostToTrain;
        [XmlElement("sinDisciplineType")] public Int32 DisciplineType;
        [XmlElement("IDDiscipline")] public UInt32 Id;

        [XmlElement("tinLevelPrereq")] public String LevelPrereq;
        [XmlElement("strName")] public String Name;

        [XmlElement("IDDisciplinePrereq1")] public Int32 Prereq1;

        [XmlElement("IDDisciplinePrereq2")] public Int32 Prereq2;

        [XmlElement("IDDisciplinePrereq3")] public Int32 Prereq3;

        [XmlElement("IDDisciplinePrereq4")] public Int32 Prereq4;

        [XmlElement("IDDisciplinePrereq5")] public Int32 Prereq5;

        [XmlElement("IDRace")] public SByte Race;

        [XmlElement("sinRanksPrereq1")] public Int32 RanksPrereq1;

        [XmlElement("sinRanksPrereq2")] public Int32 RanksPrereq2;

        [XmlElement("sinRanksPrereq3")] public Int32 RanksPrereq3;

        [XmlElement("sinRanksPrereq4")] public Int32 RanksPrereq4;

        [XmlElement("sinRanksPrereq5")] public Int32 RanksPrereq5;

        [XmlElement("strPrereq1")] public String StrPrereq1;

        [XmlElement("strPrereq2")] public String StrPrereq2;

        [XmlElement("strPrereq3")] public String StrPrereq3;

        [XmlElement("strPrereq4")] public String StrPrereq4;

        [XmlElement("strPrereq5")] public String StrPrereq5;

        [XmlElement("sinTier")] public Int32 Tier;
        [XmlElement("bitControlShop")] public String _controlShop;

        [XmlElement("bitFabricatedPlant")] public String _fabricatedPlant;

        [XmlElement("bitReactor")] public String _reactor;

        public Boolean IsFabricatedPlant
        {
            get { return _fabricatedPlant == "Tr"; }
        }

        public Boolean IsReactor
        {
            get { return _reactor == "Tr"; }
        }

        public Boolean IsControlShop
        {
            get { return _controlShop == "Tr"; }
        }

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Id, Name);
        }
    }
}