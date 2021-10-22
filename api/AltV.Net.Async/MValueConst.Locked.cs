using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static class MValueConstLocked
    {
        public static void CreateLocked(IPlayer player, IAsyncRefContext asyncRefContext, out MValueConst mValue)
        {
            if (!asyncRefContext.CreateRef(player))
            {
                mValue = MValueConst.Nil;
                return;
            }

            Alt.Server.CreateMValuePlayer(out mValue, player);
        }

        public static void CreateLocked(IVehicle vehicle, IAsyncRefContext asyncRefContext, out MValueConst mValue)
        {
            if (!asyncRefContext.CreateRef(vehicle))
            {
                mValue = MValueConst.Nil;
                return;
            }

            Alt.Server.CreateMValueVehicle(out mValue, vehicle);
        }

        public static void CreateLocked(IBlip blip, IAsyncRefContext asyncRefContext, out MValueConst mValue)
        {
            if (!asyncRefContext.CreateRef(blip))
            {
                mValue = MValueConst.Nil;
                return;
            }

            Alt.Server.CreateMValueBlip(out mValue, blip);
        }

        public static void CreateLocked(ICheckpoint checkpoint, IAsyncRefContext asyncRefContext, out MValueConst mValue)
        {
            if (!asyncRefContext.CreateRef(checkpoint))
            {
                mValue = MValueConst.Nil;
                return;
            }

            Alt.Server.CreateMValueCheckpoint(out mValue, checkpoint);
        }

        public static void CreateFromObjectLocked(object obj, IAsyncRefContext asyncRefContext, out MValueConst mValue)
        {
            if (obj == null)
            {
                mValue = MValueConst.Nil;
                return;
            }

            int i;

            string[] dictKeys;
            MValueConst[] dictValues;
            MValueWriter2 writer;

            switch (obj)
            {
                case IPlayer player:
                    CreateLocked(player, asyncRefContext, out mValue);
                    return;
                case IVehicle vehicle:
                    CreateLocked(vehicle, asyncRefContext, out mValue);
                    return;
                case IBlip blip:
                    CreateLocked(blip, asyncRefContext, out mValue);
                    return;
                case ICheckpoint checkpoint:
                    CreateLocked(checkpoint, asyncRefContext, out mValue);
                    return;
                case bool value:
                    Alt.Server.CreateMValueBool(out mValue, value);
                    return;
                case int value:
                    Alt.Server.CreateMValueInt(out mValue, value);
                    return;
                case uint value:
                    Alt.Server.CreateMValueUInt(out mValue, value);
                    return;
                case long value:
                    Alt.Server.CreateMValueInt(out mValue, value);
                    return;
                case ulong value:
                    Alt.Server.CreateMValueUInt(out mValue, value);
                    return;
                case double value:
                    Alt.Server.CreateMValueDouble(out mValue, value);
                    return;
                case float value:
                    Alt.Server.CreateMValueDouble(out mValue, value);
                    return;
                case string value:
                    Alt.Server.CreateMValueString(out mValue, value);
                    return;
                case MValueConst value:
                    mValue = value;
                    return;
                case MValueConst[] value:
                    Alt.Server.CreateMValueList(out mValue, value, (ulong) value.Length);
                    return;
                case Invoker value:
                    Alt.Server.CreateMValueFunction(out mValue, value.NativePointer);
                    return;
                case MValueFunctionCallback value:
                    Alt.Server.CreateMValueFunction(out mValue, Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(value));
                    return;
                case Net.Function function:
                    Alt.Server.CreateMValueFunction(out mValue,
                        Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(function.Call));
                    return;
                case byte[] byteArray:
                    Alt.Server.CreateMValueByteArray(out mValue, byteArray);
                    break;
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            mValue = MValueConst.Nil;
                            return;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        Alt.Server.CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }
                    
                    Alt.Server.CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }
                    return;
                case ICollection collection:
                    var length = (ulong) collection.Count;
                    var listValues = new MValueConst[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        Alt.Server.CreateMValue(out var elementMValue, value);
                        listValues[i++] = elementMValue;
                    }
                    
                    Alt.Server.CreateMValueList(out mValue, listValues, length);
                    for (ulong j = 0; j < length; j++)
                    {
                        listValues[j].Dispose();
                    }
                    return;
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        Alt.Server.CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }
                    
                    Alt.Server.CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictValues.Length; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }
                    return;
                case IWritable writable:
                    writer = new MValueWriter2();
                    writable.OnWrite(writer);
                    writer.ToMValue(out mValue);
                    return;
                case IMValueConvertible convertible:
                    writer = new MValueWriter2();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    writer.ToMValue(out mValue);
                    return;
                case Position position:
                    Alt.Server.CreateMValueVector3(out mValue, position);
                    return;
                case Rotation rotation:
                    Alt.Server.CreateMValueVector3(out mValue, rotation);
                    return;
                case Rgba rgba:
                    Alt.Server.CreateMValueRgba(out mValue, rgba);
                    return;
                case short value:
                    Alt.Server.CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    Alt.Server.CreateMValueUInt(out mValue, value);
                    return;
                case Vector3 position:
                    Alt.Server.CreateMValueVector3(out mValue, position);
                    return;
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    mValue = MValueConst.Nil;
                    return;
            }
        }

        internal static void CreateFromObjectsLocked(object[] objects, MValueConst[] mValues, IAsyncRefContext asyncRefContext)
        {
            var length = objects.Length;
            for (var i = 0; i < length; i++)
            {
                CreateFromObjectLocked(objects[i], asyncRefContext, out var mValueElement);
                mValues[i] = mValueElement;
            }
        }
    }
}