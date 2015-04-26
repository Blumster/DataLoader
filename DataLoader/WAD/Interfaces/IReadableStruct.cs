using System;
using System.IO;

namespace DataLoader.WAD.Interfaces
{
    public interface IReadableStruct<out T> where T : struct
    {
        T Read(BinaryReader br);
        String ToString();
    }
}