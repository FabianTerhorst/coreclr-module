using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionTypes
    {
        public static readonly Type Void = typeof(void);

        public static readonly Type Bool = typeof(bool);

        public static readonly Type SByte = typeof(sbyte);

        public static readonly Type Short = typeof(short);

        public static readonly Type Int = typeof(int);

        public static readonly Type Long = typeof(long);

        public static readonly Type Byte = typeof(byte);

        public static readonly Type UShort = typeof(ushort);

        public static readonly Type UInt = typeof(uint);

        public static readonly Type ULong = typeof(ulong);

        public static readonly Type Float = typeof(float);

        public static readonly Type Double = typeof(double);

        public static readonly Type String = typeof(string);

        public static readonly Type Player = typeof(IPlayer);

        public static readonly Type Vehicle = typeof(IVehicle);

        public static readonly Type ColShape = typeof(IColShape);

        public static readonly Type Checkpoint = typeof(ICheckpoint);

        public static readonly Type Array = typeof(Array);

        public static readonly Type Entity = typeof(IEntity);

        public static readonly Type Blip = typeof(IBlip);

        public static readonly Type Obj = typeof(object);

        public static readonly Type Position = typeof(Position);
        
        public static readonly Type Rotation = typeof(Rotation);
        
        public static readonly Type Rgba = typeof(Rgba);
        
        public static readonly Type Vector3 = typeof(Vector3);

        public static readonly Type ByteArray = typeof(byte[]);

        public static readonly Type FunctionType = typeof(Function.Func);

        public static readonly Type MValueConvertible = typeof(IMValueConvertible);
    }
}