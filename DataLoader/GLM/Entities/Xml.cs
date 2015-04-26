using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader.GLM.Entities
{
    public class Xml
    {
        public static Dictionary<String, List<Xml>> Xmls = new Dictionary<String, List<Xml>>();

        public String Content;

        public static Xml Read(String name, BinaryReader br)
        {
            var x = new Xml {Content = Encoding.UTF8.GetString(br.ReadBytes((Int32) br.BaseStream.Length))};

            if (!Xmls.ContainsKey(name))
                Xmls.Add(name, new List<Xml>());

            Xmls[name].Add(x);

            return x;
        }
    }
}