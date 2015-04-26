using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct RemovedObject
    {
        [XmlElement("IDCloneBaseOld")] public UInt32 CloneBaseOld;
        [XmlElement("IDCloneBaseNew")] public UInt32 CloneBaseNew;
    }
}
