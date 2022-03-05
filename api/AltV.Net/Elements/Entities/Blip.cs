using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Blip : WorldObject, IBlip
    {
        public IntPtr BlipNativePointer { get; }
        public override IntPtr NativePointer => BlipNativePointer;
        
        private static IntPtr GetWorldObjectPointer(IServer server, IntPtr nativePointer)
        {
            unsafe
            {
                return server.Library.Server.Blip_GetWorldObject(nativePointer);
            }
        }
        
        public bool IsGlobal
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_IsGlobal(BlipNativePointer) == 1;
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
                    return Server.Library.Server.Blip_IsAttached(BlipNativePointer) == 1;
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
                    var entityPointer = Server.Library.Server.Blip_AttachedTo(BlipNativePointer, &entityType);
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
                    return Server.Library.Server.Blip_GetType(BlipNativePointer);
                }
            }
        }

        public ushort Sprite
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetSprite(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetSprite(BlipNativePointer, value);
                }
            }
        }

        public byte Color
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetColor(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetColor(BlipNativePointer, value);
                }
            }
        }

        public bool Route
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetRoute(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetRoute(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public Rgba RouteColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rgba = Rgba.Zero;
                    Server.Library.Server.Blip_GetRouteColor(BlipNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetRouteColor(BlipNativePointer, value);
                }
            }
        }

        public Vector2 ScaleXY
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var v2 = Vector2.Zero;
                    Server.Library.Server.Blip_GetScaleXY(BlipNativePointer, &v2);
                    return v2;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetScaleXY(BlipNativePointer, value);
                }
            }
        }

        public short Display
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetDisplay(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetDisplay(BlipNativePointer, value);
                }
            }
        }

        public Rgba SecondaryColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rgba = Rgba.Zero;
                    Server.Library.Server.Blip_GetSecondaryColor(BlipNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetSecondaryColor(BlipNativePointer, value);
                }
            }
        }

        public byte Alpha
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetAlpha(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetAlpha(BlipNativePointer, value);
                }
            }
        }

        public ushort FlashTimer
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetFlashTimer(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetFlashTimer(BlipNativePointer, value);
                }
            }
        }

        public ushort FlashInterval
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetFlashInterval(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetFlashInterval(BlipNativePointer, value);
                }
            }
        }

        public bool Friendly
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetAsFriendly(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetAsFriendly(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool Bright
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetBright(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetBright(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public ushort Number
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetNumber(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetNumber(BlipNativePointer, value);
                }
            }
        }
        
        public bool ShowCone 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetShowCone(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetShowCone(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool Flashes 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetFlashes(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetFlashes(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool FlashesAlternate 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetFlashesAlternate(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetFlashesAlternate(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool ShortRange 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetAsShortRange(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetAsShortRange(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public ushort Priority
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetPriority(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetPriority(BlipNativePointer, value);
                }
            }
        }

        public float Rotation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetRotation(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                 CheckIfEntityExists();
                 Server.Library.Server.Blip_SetRotation(BlipNativePointer, value);
                }
            }
        }
        
        public string GxtName 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var ptr = IntPtr.Zero;
                    Server.Library.Server.Blip_GetGxtName(BlipNativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Server.Library.Server.Blip_SetGxtName(BlipNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public string Name 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var ptr = IntPtr.Zero;
                    Server.Library.Server.Blip_GetName(BlipNativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Server.Library.Server.Blip_SetName(BlipNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }
        
        public bool Pulse 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetPulse(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetPulse(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool MissionCreator 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetAsMissionCreator(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetAsMissionCreator(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool TickVisible 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetTickVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetTickVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool HeadingIndicatorVisible 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetHeadingIndicatorVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetHeadingIndicatorVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool OutlineIndicatorVisible
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetOutlineIndicatorVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetOutlineIndicatorVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool CrewIndicatorVisible 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetCrewIndicatorVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetCrewIndicatorVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public ushort Category
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetCategory(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetCategory(BlipNativePointer, value);
                }
            }
        }
        
        public bool HighDetail 
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetAsHighDetail(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetAsHighDetail(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool Shrinked
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.Blip_GetShrinked(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.Blip_SetShrinked(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public Blip(IServer server, IntPtr nativePointer) : base(server, GetWorldObjectPointer(server, nativePointer), BaseObjectType.Blip)
        {
            BlipNativePointer = nativePointer;
        }

        public void Fade(uint opacity, uint duration)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Server.Blip_Fade(BlipNativePointer, opacity, duration);
            }
        }

        public void Remove()
        {
            Alt.RemoveBlip(this);
        }
    }
}