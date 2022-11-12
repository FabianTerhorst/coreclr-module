﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Exceptions;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities
{
    public class BaseObject : SharedBaseObject, IBaseObject
    {
        public override IntPtr BaseObjectNativePointer { get; }
        public override IntPtr NativePointer => BaseObjectNativePointer;
        public override ICore Core { get; }
        public override BaseObjectType Type { get; }

        public BaseObject(ICore core, IntPtr baseObjectPointer, BaseObjectType type)
        {
            Core = core;
            BaseObjectNativePointer = baseObjectPointer;
            Type = type;

            if (baseObjectPointer == IntPtr.Zero)
            {
                throw new BaseObjectRemovedException(this);
            }

            exists = true;
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
            if (Alt.CoreImpl.IsMainThread()) return;
            if (Monitor.IsEntered(this)) return;
            throw new IllegalThreadException(this);
        }
    }
}