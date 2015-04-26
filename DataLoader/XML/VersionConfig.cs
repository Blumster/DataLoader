using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct VersionConfig
    {
        [XmlElement("IDVersion")] public Byte VersionId;
        [XmlElement("strGameVersion")] public String GameVersion;
        [XmlElement("strVersionNote")] public String VersionNote;
        [XmlElement("dtCreated")] public String Created;
    }
}
