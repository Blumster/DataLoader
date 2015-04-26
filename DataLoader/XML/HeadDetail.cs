using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct HeadDetail
    {
        [XmlElement("IDCloneBase")] public Int32 CloneBase;

        [XmlElement("strFilename")] public String FileName;
        [XmlElement("IDHeadBody")] public UInt32 HeadBodyId;
        [XmlElement("IDHeadDetail")] public UInt32 Id;

        [XmlElement("intNumTextures")] public Int32 NumTextures;
        [XmlElement("strOldName")] public String OldName;
        [XmlElement("tinType")] public Byte Type;

        [XmlElement("bitDisableHair")] public String _isDisableHair;

        public Boolean IsBody
        {
            get { return _isDisableHair == "Tr"; }
        }
    }
}