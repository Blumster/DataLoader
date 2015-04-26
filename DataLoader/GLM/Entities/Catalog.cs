using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DataLoader.GLM.Entities
{
    public struct Catalog
    {
        public static Catalog Read(BinaryReader br, SectorMap t)
        {
            var c = new Catalog();

            if (t.MapVersion >= 49)
            {
                if (t.MapVersion >= 52)
                {
                    var readerr = AssetManager.Instance.GetBinaryReaderByName(String.Format("{0}.cat", Path.GetFileNameWithoutExtension(t.MapFileName)));
                    if (readerr == null)
                        return c;

                    using (var reader = readerr)
                        c.UnSerialize(reader, t.MapVersion);
                }
            }

            return c;
        }

        public void UnSerialize(BinaryReader br, UInt32 mapversion)
        {
            // stoChunkFileReader header
            var strHeader = Encoding.UTF8.GetString(br.ReadBytes(4));
            Debug.Assert(strHeader == "CHNK");

            var opts = br.ReadBytes(4);
            Debug.Assert(opts[0] == 66); // No support for text reading yet!
            Debug.Assert(opts[1] == 76); // As in client

            // stoChunkFrameReader header
            var name = br.ReadUInt32();
            var size = br.ReadInt32();
            var version = br.ReadUInt32();
            var reserved = br.ReadInt32();

            Debug.Assert(name == 0x43544C47);
            if (version == 1)
            {
                Debug.Assert(false, "I HOPE ITS UNREACHABLE!");
                var unkCount = br.ReadUInt32();
                for (var i = 0U; i < unkCount; ++i)
                {
                }
            }
            else if (version == 2)
            {
                // Stringtable
                var numStrings = br.ReadUInt32();

                for (var i = 0U; i < numStrings; ++i)
                {
                    var str = br.ReadStringNull();
                }

                // Dependency Info
                /*var numEntries = br.ReadUInt32();
                for (var i = 0; i < numEntries; ++i)
                {
                    var numKeyValues = br.ReadInt32();
                    var keyIndex = br.ReadUInt32();

                    if (numKeyValues - 1 > 0)
                    {
                        for (var j = 0; j < numKeyValues - 1; ++j)
                        {
                            var valueIndex = br.ReadInt32();
                        }
                    }
                }*/
            }
        }
    }
}