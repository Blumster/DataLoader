using System;
using System.IO;
using System.Text;

namespace DataLoader
{
    using WAD.Interfaces;

    public static class Extensions
    {
        public delegate T ReadFunction<out T>();

        public static String ReadLengthedString(this BinaryReader br)
        {
            var size = br.ReadInt32();
            return size > 0 ? br.ReadStringOn(size) : String.Empty;
        }

        public static String ReadUnicodeString(this BinaryReader br, Int32 size)
        {
            if (size > 0)
            {
                var buff = br.ReadBytes(size*2);

                for (var i = 0; i < buff.Length; i += 2)
                    if (buff[i] == 0 && buff[i + 1] == 0)
                        return Encoding.Unicode.GetString(buff, 0, i);

                return Encoding.Unicode.GetString(buff);
            }

            return String.Empty;
        }

        public static String ReadLineOn(this BinaryReader br, Int32 size)
        {
            if (size <= 0)
                return null;

            try
            {
                var i = 0;
                Char ch;
                var sb = new StringBuilder();
                while (i++ < size && (ch = br.ReadChar()) != '\n')
                    sb.Append(ch);

                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static String ReadStringOn(this BinaryReader br, Int32 size)
        {
            if (size > 0)
            {
                var buff = br.ReadBytes(size);

                for (var i = 0; i < size; ++i)
                    if (buff[i] == 0)
                        return Encoding.UTF8.GetString(buff, 0, i);

                return Encoding.UTF8.GetString(buff);
            }

            return String.Empty;
        }

        public static String ReadStringNull(this BinaryReader br)
        {
            Char c;
            var sb = new StringBuilder();

            while (br.BaseStream.Position + 1 < br.BaseStream.Length && (c = br.ReadChar()) != '\0')
                sb.Append(c);

            return sb.ToString();
        }

        public static T ReadStruct<T>(this BinaryReader br) where T : struct, IReadableStruct<T>
        {
            return new T().Read(br);
        }

        public static T[] ReadStruct<T>(this BinaryReader br, Int32 count) where T : struct, IReadableStruct<T>
        {
            var arr = new T[count];

            for (var i = 0; i < count; ++i)
                arr[i] = ReadStruct<T>(br);

            return arr;
        }

        public static T[] Read<T>(this BinaryReader br, Int32 count)
        {
            var arr = new T[count];

            ReadFunction<T> func;

            switch (typeof (T).Name)
            {
                case "Single":
                    func = () => (T) (Object) br.ReadSingle();
                    break;

                case "Double":
                    func = () => (T) (Object) br.ReadDouble();
                    break;

                case "Byte":
                    func = () => (T) (Object) br.ReadByte();
                    break;

                case "UInt16":
                    func = () => (T) (Object) br.ReadUInt16();
                    break;

                case "UInt32":
                    func = () => (T) (Object) br.ReadUInt32();
                    break;

                case "UInt64":
                    func = () => (T) (Object) br.ReadUInt64();
                    break;

                case "SByte":
                    func = () => (T) (Object) br.ReadSByte();
                    break;

                case "Int16":
                    func = () => (T) (Object) br.ReadInt16();
                    break;

                case "Int32":
                    func = () => (T) (Object) br.ReadInt32();
                    break;

                case "Int64":
                    func = () => (T) (Object) br.ReadInt64();
                    break;

                case "String":
                    func = () => (T) (Object) br.ReadString();
                    break;

                case "Decimal":
                    func = () => (T) (Object) br.ReadDecimal();
                    break;

                case "Boolean":
                    func = () => (T) (Object) br.ReadBoolean();
                    break;

                default:
                    func = () => default(T);
                    break;
            }

            for (var i = 0; i < count; ++i)
                arr[i] = func();

            return arr;
        }
    }
}