using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct Outpost
    {
        [XmlElement("bIsOutpost")]               public String _isOutpost;
        [XmlElement("lPulseIndex")]              public UInt32 PulseIndex;
        [XmlElement("lMilliSecondsToNextPulse")] public UInt32 MilliSecondsToNextPulse;
        [XmlElement("fPercentLevelXP")]          public Single PercentLevelXP;
        [XmlElement("lNumTokens")]               public UInt32 NumTokens;

        public Boolean IsOutpost
        {
            get { return _isOutpost == "Tr"; }
        }
    }
}
