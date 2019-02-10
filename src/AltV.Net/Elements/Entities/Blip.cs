using System;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Blip : Entity, IBlip
    {
        public bool IsGlobal => Exists && AltVNative.Blip.Blip_IsGlobal(NativePointer);
        public bool IsAttached => Exists && AltVNative.Blip.Blip_IsAttached(NativePointer);

        public IEntity AttachedTo
        {
            get
            {
                if (!Exists) return null;
                var entityPointer = AltVNative.Blip.Blip_AttachedTo(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, out var entity) ? entity : null;
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

        public Blip(IntPtr nativePointer) : base(nativePointer, EntityType.Blip)
        {
        }
    }
}