using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Blip : WorldObject, IBlip
    {
        public override Position Position
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Blip_GetPosition(NativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetPosition(NativePointer, value);
                }
            }
        }

        public override int Dimension
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_GetDimension(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetDimension(NativePointer, value);
                }
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Blip_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Blip_SetMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public override bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Blip_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result;
            }
        }

        public override void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Blip_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool IsGlobal
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_IsGlobal(NativePointer);
                }
            }
        }

        public bool IsAttached
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_IsAttached(NativePointer);
                }
            }
        }

        public IEntity AttachedTo
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = Server.Library.Blip_AttachedTo(NativePointer, &entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.BaseEntityPool.Get(entityPointer, entityType, out var entity) ? entity : null;
                }
            }
        }

        public byte BlipType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_GetType(NativePointer);
                }
            }
        }

        public ushort Sprite
        {
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetSprite(NativePointer, value);
                }
            }
        }

        public byte Color
        {
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetColor(NativePointer, value);
                }
            }
        }

        public bool Route
        {
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetRoute(NativePointer, value);
                }
            }
        }

        public byte RouteColor
        {
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetRouteColor(NativePointer, value);
                }
            }
        }

        public Blip(IServer server, IntPtr nativePointer) : base(server, nativePointer, BaseObjectType.Blip)
        {
        }
        
        public void Remove()
        {
            Alt.RemoveBlip(this);
        }
        
        protected override void InternalAddRef()
        {
            unsafe
            {
                Server.Library.Blip_AddRef(NativePointer);
            }
        }

        protected override void InternalRemoveRef()
        {
            unsafe
            {
                Server.Library.Blip_RemoveRef(NativePointer);
            }
        }
    }
}