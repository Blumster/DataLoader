using System;
using System.IO;

namespace DataLoader.GLM.CVOG
{
    public class CVOGGraphicsBase
    {
        public String FxCreateExtraName;
        public String ToolTip;
        public UInt32 Unk;
        public Byte UnkFlagByte;

        public void UnserializeCreateEffect(BinaryReader br, UInt32 mapVersion)
        {
            if (mapVersion >= 21)
                FxCreateExtraName = br.ReadLengthedString();

            if (mapVersion >= 48)
                UnkFlagByte = br.ReadByte();

            if (mapVersion >= 62)
                Unk = br.ReadUInt32();
        }

        public void UnserializeTooltip(BinaryReader br, UInt32 mapVersion)
        {
            if (mapVersion >= 22)
                ToolTip = br.ReadLengthedString();
        }
    }
}