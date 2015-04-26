using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Arena
    {
        [XmlElement("sinArenaType")] public Byte ArenaType;
        [XmlElement("IDArena")] public UInt32 IDArena;

        [XmlElement("IDContinentObject")] public UInt32 IDContinentObject;

        [XmlElement("intLayer")] public Int32 Layer;

        [XmlElement("sinMaxNumTeams")] public Byte MaxNumTeams;

        [XmlElement("sinMaxPlayersPerTeam")] public Byte MaxPlayersPerTeam;
        [XmlElement("sinMinNumTeams")] public Byte MinNumTeams;
        [XmlElement("sinMinPlayersPerTeam")] public Byte MinPlayersPerTeam;

        [XmlElement("bitUseForLadder")] public String _useForLadder;

        public Boolean UseForLadder
        {
            get { return _useForLadder == "Tr"; }
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | {1}", IDArena, IDContinentObject);
        }
    }
}