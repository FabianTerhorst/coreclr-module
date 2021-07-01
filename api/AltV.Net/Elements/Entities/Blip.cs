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
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Blip.Blip_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Blip.Blip_SetPosition(NativePointer, value);
            }
        }

        public override int Dimension
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Blip.Blip_GetDimension(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Blip.Blip_SetDimension(NativePointer, value);
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Blip.Blip_GetMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Blip.Blip_SetMetaData(NativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }
        
        public override bool HasMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Blip.Blip_HasMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public override void DeleteMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Blip.Blip_DeleteMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }

        public bool IsGlobal
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Blip.Blip_IsGlobal(NativePointer);
            }
        }

        public bool IsAttached
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Blip.Blip_IsAttached(NativePointer);
            }
        }

        public IEntity AttachedTo
        {
            get
            {
                CheckIfEntityExists();
                var entityType = BaseObjectType.Undefined;
                var entityPointer = AltNative.Blip.Blip_AttachedTo(NativePointer, ref entityType);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.BaseEntityPool.Get(entityPointer, entityType, out var entity) ? entity : null;
            }
        }

        public byte BlipType
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Blip.Blip_GetType(NativePointer);
            }
        }

        public ushort Sprite
        {
            set
            {
                CheckIfEntityExists();
                AltNative.Blip.Blip_SetSprite(NativePointer, value);
            }
        }

        public byte Color
        {
            set
            {
                CheckIfEntityExists();
                AltNative.Blip.Blip_SetColor(NativePointer, value);
            }
        }

        public bool Route
        {
            set
            {
                CheckIfEntityExists();
                AltNative.Blip.Blip_SetRoute(NativePointer, value);
            }
        }

        public byte RouteColor
        {
            set
            {
                CheckIfEntityExists();
                AltNative.Blip.Blip_SetRouteColor(NativePointer, value);
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
            AltNative.Blip.Blip_AddRef(NativePointer);
        }

        protected override void InternalRemoveRef()
        {
            AltNative.Blip.Blip_RemoveRef(NativePointer);
        }
    }
}