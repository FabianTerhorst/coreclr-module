using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionStringParsers
    {
        public static object ParseObject(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return value;
        }

        public static object ParseFunction(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseBool(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!bool.TryParse(value, out var boolValue)) return null;
            return boolValue;
        }

        public static object ParseSByte(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!sbyte.TryParse(value, out var sbyteValue)) return null;
            return sbyteValue;
        }

        public static object ParseShort(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!short.TryParse(value, out var shortValue)) return null;
            return shortValue;
        }

        public static object ParseInt(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!int.TryParse(value, out var intValue)) return null;
            return intValue;
        }

        public static object ParseLong(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!long.TryParse(value, out var longValue)) return null;
            return longValue;
        }

        public static object ParseByte(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!byte.TryParse(value, out var byteValue)) return null;
            return byteValue;
        }

        public static object ParseUShort(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!ushort.TryParse(value, out var ushortValue)) return null;
            return ushortValue;
        }

        public static object ParseUInt(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!uint.TryParse(value, out var uintValue)) return null;
            return uintValue;
        }

        public static object ParseULong(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!ulong.TryParse(value, out var ulongValue)) return null;
            return ulongValue;
        }

        public static object ParseFloat(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!float.TryParse(value, out var floatValue)) return null;
            return floatValue;
        }

        public static object ParseDouble(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!double.TryParse(value, out var doubleValue)) return null;
            return doubleValue;
        }

        public static object ParseString(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return value;
        }

        public static object ParseEntity(string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (typeInfo.IsPlayer)
            {
                foreach (var player in Alt.Server.GetPlayers())
                {
                    if (!player.Exists) continue;
                    if (player.Name.Equals(value))
                    {
                        return player;
                    }
                }

                if (!ushort.TryParse(value, out var playerId)) return null;
                var entity = Alt.Server.GetEntityById(playerId);
                if (entity is IPlayer playerEntity)
                {
                    return playerEntity;
                }
            }
            else if (typeInfo.IsVehicle)
            {
                if (!ushort.TryParse(value, out var vehicleId)) return null;
                var entity = Alt.Server.GetEntityById(vehicleId);
                if (entity is IVehicle vehicleEntity)
                {
                    return vehicleEntity;
                }
            }

            return null;
        }

        public static object ParseArray(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseDictionary(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseConvertible(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParsePosition(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }
        
        public static object ParseRotation(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }
        
        public static object ParseVector3(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }
        
        public static object ParseRgba(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }
        
        public static object ParseByteArray(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseEnum(string value, Type type, FunctionTypeInfo typeInfo)
        {
            return !Enum.TryParse(type, value, true, out var enumObject) ? null : enumObject;
        }
    }

    internal delegate object FunctionStringParser(string value, Type type, FunctionTypeInfo typeInfo);
}