using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct HeadBody
    {
        [XmlElement("IDCloneBase")] public Int32 CloneBase;

        [XmlElement("strFilename")] public String FileName;
        [XmlElement("IDHeadBody")] public Int32 Id;
        [XmlElement("intNumTextures")] public Int32 NumTextures;

        [XmlElement("bitIsBody")] public String _isBody;
        [XmlElement("bitIsHead")] public String _isHead;

        public Boolean IsHead
        {
            get { return _isHead == "Tr"; }
        }

        public Boolean IsBody
        {
            get { return _isBody == "Tr"; }
        }

        public override String ToString()
        {
            return String.Format("ID: {0} | {1}", Id, FileName);
        }
    }
}