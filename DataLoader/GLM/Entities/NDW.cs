using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DataLoader.GLM.Entities
{
    public class NDW
    {
        public static Dictionary<String, List<NDW>> Entires = new Dictionary<String, List<NDW>>();

        public List<String> Lines = new List<String>();

        public static NDW Read(String fileName, BinaryReader br)
        {
            var ndw = new NDW();

            var mode = br.ReadByte();
            Debug.Assert(mode == 84 || mode == 116); // No binary mode in NDW files

            String str;

            while ((str = br.ReadLineOn(2098)) != null)
                if (str.Length > 1)
                    ndw.Lines.Add(str.Substring(0, str.Length - 1));

            if (!Entires.ContainsKey(fileName))
                Entires.Add(fileName, new List<NDW>());

            Entires[fileName].Add(ndw);
            return ndw;
        }
    }
}