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
        public override IntPtr BaseObjectNativePointer { get; }
        
        public override ICore Core { get; }

        [Obsolete("Use Core instead")]
        public ICore Server
        {
            get
            {
                Alt.LogWarning("baseObject.Server is deprecated, use baseObject.Core instead");
                return Core;
            }
        }
        public override BaseObjectType Type { get; }

        
        protected BaseObject(ICore core, IntPtr nativePointer, BaseObjectType type)
        {
            Core = core;
            BaseObjectNativePointer = nativePointer;
            Type = type;
            
            if (nativePointer == IntPtr.Zero)
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
        }
    }
}