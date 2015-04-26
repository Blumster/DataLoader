using System;

namespace DataLoader
{
    public class Program
    {
        private static void Main()
        {
            AssetManager.Instance.ReadXML(@"C:\AA\wad.xml");
            AssetManager.Instance.ReadWAD(@"C:\AA\clonebase.wad");
            AssetManager.Instance.ReadEntries(@"C:\AA\", true);

            Console.WriteLine("The Program has read all the data!");
            Console.ReadLine();
        }
    }
}