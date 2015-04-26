using System;
using System.Xml.Serialization;

namespace DataLoader.XML
{
    public struct ItemTemplate
    {
        [XmlElement("intBaseCBID")] public UInt32 CloneBaseId;
        [XmlElement("strDescription")] public String Description;

        [XmlElement("IDGadget1")] public Int32 GadgetId1;

        [XmlElement("IDGadget2")] public Int32 GadgetId2;

        [XmlElement("IDGadget3")] public Int32 GadgetId3;

        [XmlElement("IDGadget4")] public Int32 GadgetId4;

        [XmlElement("IDGadget5")] public Int32 GadgetId5;
        [XmlElement("IDTemplate")] public UInt32 Id;

        [XmlElement("strItemName")] public String ItemName;
        [XmlElement("IDOnUseSkillCast")] public Int32 OnUseSkillCast;

        [XmlElement("IDPrefix1")] public Int32 PrefixId1;

        [XmlElement("IDPrefix2")] public Int32 PrefixId2;

        [XmlElement("IDPrefix3")] public Int32 PrefixId3;

        [XmlElement("IDPrefix4")] public Int32 PrefixId4;

        [XmlElement("IDPrefix5")] public Int32 PrefixId5;
        [XmlElement("intRarity")] public Int32 Rarity;
        [XmlElement("rlVarianceScaler")] public Single VarianceScaler;

        [XmlElement("bitIsReverseEngineerable")] public String _isReverseEngineerable;

        public Boolean IsReverseEngineerable
        {
            get { return _isReverseEngineerable == "Tr"; }
        }
    }
}