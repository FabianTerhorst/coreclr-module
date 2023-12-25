using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AltV.Net.Elements.Args;
using AltV.Net.Exceptions;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Elements.Entities
{
    public abstract class BaseObject : SharedBaseObject, IBaseObject, IInternalBaseObject
    {
        public override IntPtr BaseObjectNativePointer { get; protected set; }

        public override ICore Core { get; }

        public override uint Id { get; }

        public override BaseObjectType Type { get; }


        protected BaseObject(ICore core, IntPtr nativePointer, BaseObjectType type, uint id)
        {
            Core = core;
            BaseObjectNativePointer = nativePointer;
            Type = type;
            Id = id;

            if (nativePointer == IntPtr.Zero)
            {
                throw new BaseObjectRemovedException(this);
            }

            Exists = true;
        }


        public override void CheckIfEntityExists()
        {
            CheckIfCallIsValid();
            if (Exists)
            {
                return;
            }

            throw new BaseObjectRemovedException(this);
        }

        public override void CheckIfCallIsValid()
        {
        }

        public void SetSyncedMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Core.CreateMValue(out var mValue, value);
            SetSyncedMetaData(key, in mValue);
            mValue.Dispose();
        }

        public void SetSyncedMetaData(Dictionary<string, object> metaData)
        {
            unsafe
            {
                var dataTemp = new Dictionary<IntPtr, MValueConst>();

                var keys = new IntPtr[metaData.Count];
                var values = new IntPtr[metaData.Count];

                for (var i = 0; i < metaData.Count; i++)
                {
                    var stringPtr = MemoryUtils.StringToHGlobalUtf8(metaData.ElementAt(i).Key);
                    Core.CreateMValue(out var mValue, metaData.ElementAt(i).Value);
                    keys[i] = stringPtr;
                    values[i] = mValue.nativePointer;
                    dataTemp.Add(stringPtr, mValue);
                }

                Core.Library.Server.BaseObject_SetMultipleSyncedMetaData(NativePointer, keys, values, (uint)dataTemp.Count);

                foreach (var dataValue in dataTemp)
                {
                    dataValue.Value.Dispose();
                    Marshal.FreeHGlobal(dataValue.Key);
                }
            }
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.BaseObject_SetSyncedMetaData(BaseObjectNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.BaseObject_DeleteSyncedMetaData(BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
    }
}