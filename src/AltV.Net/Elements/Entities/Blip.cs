using System;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Blip : Entity, IBlip
    {
        public new static ushort GetId(IntPtr blipPointer) => AltVNative.Blip.Blip_GetID(blipPointer);

        public override Position Position
        {
            get
            {
                var position = Position.Zero;
                if (Exists)
                {
                    AltVNative.Blip.Blip_GetPosition(NativePointer, ref position);
                }
                return position;
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetPosition(NativePointer, value);
                }
            }
        }

        public override Rotation Rotation
        {
            get
            {
                var rotation = Rotation.Zero;
                if (Exists)
                {
                    AltVNative.Blip.Blip_GetRotation(NativePointer, ref rotation);
                }
                return rotation;
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetRotation(NativePointer, value);
                }
            }
        }

        public override ushort Dimension
        {
            get => !Exists ? default : AltVNative.Blip.Blip_GetDimension(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetDimension(NativePointer, value);
                }
            }
        }

        public override void SetMetaData(string key, object value)
        {
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Blip.Blip_SetMetaData(NativePointer, key, ref mValue);
            }
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }

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

        public override void SetSyncedMetaData(string key, object value)
        {
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Blip.Blip_SetSyncedMetaData(NativePointer, key, ref mValue);
            }
        }

        public override bool GetSyncedMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }

            var mValue = MValue.Nil;
            AltVNative.Blip.Blip_GetSyncedMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public bool IsGlobal => Exists && AltVNative.Blip.Blip_IsGlobal(NativePointer);
        public bool IsAttached => Exists && AltVNative.Blip.Blip_IsAttached(NativePointer);

        public IEntity AttachedTo
        {
            get
            {
                if (!Exists) return null;
                var entityType = EntityType.Undefined;
                var entityPointer = AltVNative.Blip.Blip_AttachedTo(NativePointer, ref entityType);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity) ? entity : null;
            }
        }

        public byte BlipType => !Exists ? default : AltVNative.Blip.Blip_GetType(NativePointer);

        public ushort Sprite
        {
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetSprite(NativePointer, value);
                }
            }
        }

        public byte Color
        {
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetColor(NativePointer, value);
                }
            }
        }

        public bool Route
        {
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetRoute(NativePointer, value);
                }
            }
        }

        public byte RouteColor
        {
            set
            {
                if (Exists)
                {
                    AltVNative.Blip.Blip_SetRouteColor(NativePointer, value);
                }
            }
        }

        public Blip(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Blip, id)
        {
        }
    }
}