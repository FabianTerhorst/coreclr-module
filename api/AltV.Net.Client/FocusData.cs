using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client
{
    public class FocusData
    {
        private readonly ICore core;

        public FocusData(ICore core)
        {
            this.core = core;
        }

        public bool IsFocusOverriden
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Core_IsFocusOverriden(core.NativePointer) == 1;
                }
            }
        }

        public Vector3 FocusOverridePosition
        {
            get
            {
                unsafe
                {
                    var vec = Vector3.Zero;
                    core.Library.Client.Core_GetFocusOverridePos(core.NativePointer, &vec);
                    return vec;
                }
            }
        }

        public Vector3 FocusOverrideOffset
        {
            get
            {
                unsafe
                {
                    var vec = Vector3.Zero;
                    core.Library.Client.Core_GetFocusOverrideOffset(core.NativePointer, &vec);
                    return vec;
                }
            }
        }

        public void OverrideFocusPosition(Vector3 pos, Vector3 offset)
        {
            unsafe
            {
                core.Library.Client.Core_OverrideFocusPosition(core.NativePointer, pos, offset);
            }
        }

        public IEntity FocusOverrideEntity
        {
            get
            {
                unsafe
                {
                    var type = (byte) BaseObjectType.Undefined;
                    if (!core.BaseEntityPool.Get(core.Library.Client.Core_GetFocusOverrideEntity(core.NativePointer, &type), (BaseObjectType) type, out var entity))
                        return null;
                    return entity;
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.Core_OverrideFocusEntity(core.NativePointer, value.EntityNativePointer);
                }
            }
        }

        public void ClearFocusOverride()
        {
            unsafe
            {
                core.Library.Client.Core_ClearFocusOverride(core.NativePointer);
            }
        }
    }
}