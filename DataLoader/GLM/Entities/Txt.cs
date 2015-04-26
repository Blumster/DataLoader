using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader.GLM.Entities
{
    public class Txt
    {
        public static Dictionary<String, Txt> Xmls = new Dictionary<String, Txt>();

        public String Content;

        public static Txt Read(String name, BinaryReader br)
        {
            var x = new Txt {Content = Encoding.UTF8.GetString(br.ReadBytes((Int32) br.BaseStream.Length))};

            Xmls.Add(name, x);

            return x;
        }
    }
}