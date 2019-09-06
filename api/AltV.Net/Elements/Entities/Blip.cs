using System;
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

        public override short Dimension
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

        public override void GetMetaData(string key, ref MValue value) =>
            AltNative.Blip.Blip_GetMetaData(NativePointer, key, ref value);

        public override void SetMetaData(string key, ref MValue value) =>
            AltNative.Blip.Blip_SetMetaData(NativePointer, key, ref value);

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
                return Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity) ? entity : null;
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

        public Blip(IntPtr nativePointer) : base(nativePointer, BaseObjectType.Blip)
        {
        }
        
        public void Remove()
        {
            Alt.RemoveBlip(this);
        }
    }
}