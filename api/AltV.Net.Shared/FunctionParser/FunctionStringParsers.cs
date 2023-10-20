using System;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionStringParsers
    {
        public static object ParseObject(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return value;
        }

        public static object ParseFunction(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseBool(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!bool.TryParse(value, out var boolValue)) return null;
            return boolValue;
        }

        public static object ParseSByte(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!sbyte.TryParse(value, out var sbyteValue)) return null;
            return sbyteValue;
        }

        public static object ParseShort(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!short.TryParse(value, out var shortValue)) return null;
            return shortValue;
        }

        public static object ParseInt(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!int.TryParse(value, out var intValue)) return null;
            return intValue;
        }

        public static object ParseLong(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!long.TryParse(value, out var longValue)) return null;
            return longValue;
        }

        public static object ParseByte(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!byte.TryParse(value, out var byteValue)) return null;
            return byteValue;
        }

        public static object ParseUShort(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!ushort.TryParse(value, out var ushortValue)) return null;
            return ushortValue;
        }

        public static object ParseUInt(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!uint.TryParse(value, out var uintValue)) return null;
            return uintValue;
        }

        public static object ParseULong(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!ulong.TryParse(value, out var ulongValue)) return null;
            return ulongValue;
        }

        public static object ParseFloat(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!float.TryParse(value, out var floatValue)) return null;
            return floatValue;
        }

        public static object ParseDouble(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!double.TryParse(value, out var doubleValue)) return null;
            return doubleValue;
        }

        public static object ParseString(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return value;
        }

        public static object ParseBaseObject(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            if (typeInfo.IsPlayer)
            {
                foreach (var player in core.PoolManager.Player.GetAllEntities())
                {
                    if (!player.Exists) continue;
                    if (player.Name.Equals(value))
                    {
                        return player;
                    }
                }

                if (!ushort.TryParse(value, out var playerId)) return null;
                var entity = core.GetBaseObjectById(BaseObjectType.Player, playerId);
                if (entity is ISharedPlayer playerEntity)
                {
                    return playerEntity;
                }
            }
            else if (typeInfo.IsVehicle)
            {
                if (!ushort.TryParse(value, out var vehicleId)) return null;
                var entity = core.GetBaseObjectById(BaseObjectType.Vehicle, vehicleId);
                if (entity is ISharedVehicle vehicleEntity)
                {
                    return vehicleEntity;
                }
            }

            return null;
        }

        public static object ParseArray(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseDictionary(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseConvertible(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParsePosition(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseRotation(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseVector3(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseRgba(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseByteArray(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return null;
        }

        public static object ParseEnum(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo)
        {
            return !Enum.TryParse(type, value, true, out var enumObject) ? null : enumObject;
        }
    }

    internal delegate object FunctionStringParser(ISharedCore core, string value, Type type, FunctionTypeInfo typeInfo);
}