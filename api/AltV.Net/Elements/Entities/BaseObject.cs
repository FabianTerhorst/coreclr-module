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

namespace AltV.Net.Elements.Entities
{
    public abstract class BaseObject : SharedBaseObject, IBaseObject, IInternalBaseObject
    {
        public override IntPtr BaseObjectNativePointer { get; protected set; }

        public override ICore Core { get; }

        public uint Id { get; }

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

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.BaseObject_SetSyncedMetaData(BaseObjectNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.BaseObject_DeleteSyncedMetaData(BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
    }
}