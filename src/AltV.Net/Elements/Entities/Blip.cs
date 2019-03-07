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
                CheckExistence();
                var position = Position.Zero;
                AltVNative.Blip.Blip_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckExistence();
                AltVNative.Blip.Blip_SetPosition(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckExistence();
                return AltVNative.Blip.Blip_GetDimension(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Blip.Blip_SetDimension(NativePointer, value);
            }
        }

        public override void SetMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Blip.Blip_SetMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Blip.Blip_GetMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public bool IsGlobal
        {
            get
            {
                CheckExistence();
                return AltVNative.Blip.Blip_IsGlobal(NativePointer);
            }
        }

        public bool IsAttached
        {
            get
            {
                CheckExistence();
                return AltVNative.Blip.Blip_IsAttached(NativePointer);
            }
        }

        public IEntity AttachedTo
        {
            get
            {
                CheckExistence();
                var entityType = BaseObjectType.Undefined;
                var entityPointer = AltVNative.Blip.Blip_AttachedTo(NativePointer, ref entityType);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity) ? entity : null;
            }
        }

        public byte BlipType
        {
            get
            {
                CheckExistence();
                return AltVNative.Blip.Blip_GetType(NativePointer);
            }
        }

        public ushort Sprite
        {
            set
            {
                CheckExistence();
                AltVNative.Blip.Blip_SetSprite(NativePointer, value);
            }
        }

        public byte Color
        {
            set
            {
                CheckExistence();
                AltVNative.Blip.Blip_SetColor(NativePointer, value);
            }
        }

        public bool Route
        {
            set
            {
                CheckExistence();
                AltVNative.Blip.Blip_SetRoute(NativePointer, value);
            }
        }

        public byte RouteColor
        {
            set
            {
                CheckExistence();
                AltVNative.Blip.Blip_SetRouteColor(NativePointer, value);
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