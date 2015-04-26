using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    public class CVOGReactionText
    {
        public String Main;
        public Byte TargetType;
        public List<TextChoice> TextChoices = new List<TextChoice>();
        public List<TextParam> TextParams = new List<TextParam>();

        public Byte Type;

        public CVOGReactionText(BinaryReader br, UInt32 mapVersion)
        {
            Type = br.ReadByte();
            TargetType = br.ReadByte();
            Main = br.ReadLengthedString();

            uint numParams = br.ReadUInt32();
            for (uint i = 0U; i < numParams; ++i)
                TextParams.Add(TextParam.Read(br, mapVersion));

            uint numChoices = br.ReadUInt32();
            for (uint i = 0U; i < numChoices; ++i)
            {
                var tChoice = new TextChoice
                    {
                        TriggerCOID = br.ReadUInt64(),
                        Text = br.ReadLengthedString(),
                        TextParams = new List<TextParam>()
                    };

                uint numChoiceParams = br.ReadUInt32();
                for (uint j = 0U; j < numChoiceParams; ++j)
                    tChoice.TextParams.Add(TextParam.Read(br, mapVersion));
            }
        }
    }

    public struct TextParam
    {
        public Single CachedValue;
        public UInt32 Id;
        public Byte Type;

        public static TextParam Read(BinaryReader br, UInt32 mapVersion)
        {
            var tParam = new TextParam {Type = br.ReadByte()};

            br.ReadBytes(3);

            tParam.Id = br.ReadUInt32();
            tParam.CachedValue = mapVersion < 14 ? 0.0f : br.ReadSingle();

            return tParam;
        }
    }

    public struct TextChoice
    {
        public String Text;
        public List<TextParam> TextParams;
        public UInt64 TriggerCOID;
    }
}