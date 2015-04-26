using System;
using System.IO;

namespace DataLoader.WAD.Specifics
{
    public struct WheelSetSpecific
    {
        public Int16[] Friction;
        public Byte[] NumWheelsAxle;
        public String Wheel0Name;
        public String Wheel1Name;
        public Byte WheelSetType;
        private Byte _skip;

        public static WheelSetSpecific Read(BinaryReader br)
        {
            return new WheelSetSpecific
            {
                Friction = br.Read<Int16>(6),
                NumWheelsAxle = br.ReadBytes(2),
                WheelSetType = br.ReadByte(),
                _skip = br.ReadByte(),
                Wheel0Name = br.ReadUnicodeString(65),
                Wheel1Name = br.ReadUnicodeString(65)
            };
        }
    }
}