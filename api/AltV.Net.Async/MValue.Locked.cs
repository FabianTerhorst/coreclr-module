using System.Collections;
using System.Collections.Generic;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static class MValueLocked
    {
        public static MValue CreateLocked(IPlayer player)
        {
            var mValue = MValue.Nil;
            lock (player)
            {
                if (!player.Exists)
                {
                    return MValue.Nil;
                }

                AltNative.MValueCreate.MValue_CreatePlayer(player.NativePointer, ref mValue);
                return mValue;
            }
        }

        public static MValue CreateLocked(IVehicle vehicle)
        {
            var mValue = MValue.Nil;
            lock (vehicle)
            {
                if (!vehicle.Exists)
                {
                    return MValue.Nil;
                }

                AltNative.MValueCreate.MValue_CreateVehicle(vehicle.NativePointer, ref mValue);
                return mValue;
            }
        }

        public static MValue CreateLocked(IBlip blip)
        {
            var mValue = MValue.Nil;
            lock (blip)
            {
                if (!blip.Exists)
                {
                    return MValue.Nil;
                }

                AltNative.MValueCreate.MValue_CreateBlip(blip.NativePointer, ref mValue);
                return mValue;
            }
        }

        public static MValue CreateLocked(ICheckpoint checkpoint)
        {
            var mValue = MValue.Nil;
            lock (checkpoint)
            {
                if (!checkpoint.Exists)
                {
                    return MValue.Nil;
                }

                AltNative.MValueCreate.MValue_CreateCheckpoint(checkpoint.NativePointer, ref mValue);
                return mValue;
            }
        }

        public static MValue CreateFromObjectLocked(object obj)
        {
            if (obj == null)
            {
                return MValue.Nil;
            }

            int i;

            string[] dictKeys;
            MValue[] dictValues;
            MValueWriter writer;

            switch (obj)
            {
                case IPlayer player:
                    return CreateLocked(player);
                case IVehicle vehicle:
                    return CreateLocked(vehicle);
                case IBlip blip:
                    return CreateLocked(blip);
                case ICheckpoint checkpoint:
                    return CreateLocked(checkpoint);
                case bool value:
                    return MValue.Create(value);
                case int value:
                    return MValue.Create(value);
                case uint value:
                    return MValue.Create(value);
                case long value:
                    return MValue.Create(value);
                case ulong value:
                    return MValue.Create(value);
                case double value:
                    return MValue.Create(value);
                case float value:
                    return MValue.Create(value);
                case string value:
                    return MValue.Create(value);
                case MValue value:
                    return value;
                case MValue[] value:
                    return MValue.Create(value);
                case Invoker value:
                    return MValue.Create(value);
                case MValue.Function value:
                    return MValue.Create(value);
                case Function function:
                    return MValue.Create(function.call);
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValue[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            return MValue.Nil;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        dictValues[i++] = CreateFromObjectLocked(value);
                    }

                    return MValue.Create(dictValues, dictKeys);
                case ICollection collection:
                    var length = collection.Count;
                    var listValues = new MValue[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        listValues[i++] = CreateFromObjectLocked(value);
                    }

                    return MValue.Create(listValues);
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValue[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        dictValues[i++] = CreateFromObjectLocked(value);
                    }

                    return MValue.Create(dictValues, dictKeys);
                case IWritable writable:
                    writer = new MValueWriter();
                    writable.OnWrite(writer);
                    return writer.ToMValue();
                case IMValueConvertible convertible:
                    writer = new MValueWriter();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    return writer.ToMValue();
                case short value:
                    return MValue.Create(value);
                case ushort value:
                    return MValue.Create(value);
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    return MValue.Nil;
            }
        }

        internal static MValue[] CreateFromObjectsLocked(object[] objects)
        {
            var length = objects.Length;
            var mValues = new MValue[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = CreateFromObjectLocked(objects[i]);
            }

            return mValues;
        }
    }
}