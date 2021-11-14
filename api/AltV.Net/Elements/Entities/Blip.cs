using System;
using System.Numerics;
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
                return result == 1;
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
                    return Server.Library.Blip_IsGlobal(NativePointer) == 1;
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
                    return Server.Library.Blip_IsAttached(NativePointer) == 1;
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
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_GetSprite(NativePointer);
                }
            }
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
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_GetColor(NativePointer);
                }
            }
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
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Blip_GetRoute(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetRoute(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    Server.Library.Blip_GetRouteColor(NativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetRouteColor(NativePointer, value);
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
                    Server.Library.Blip_GetScaleXY(NativePointer, &v2);
                    return v2;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetScaleXY(NativePointer, value);
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
                    return Server.Library.Blip_GetDisplay(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetDisplay(NativePointer, value);
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
                    Server.Library.Blip_GetSecondaryColor(NativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetSecondaryColor(NativePointer, value);
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
                    return Server.Library.Blip_GetAlpha(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetAlpha(NativePointer, value);
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
                    return Server.Library.Blip_GetFlashTimer(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetFlashTimer(NativePointer, value);
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
                    return Server.Library.Blip_GetFlashInterval(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetFlashInterval(NativePointer, value);
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
                    return Server.Library.Blip_GetAsFriendly(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetAsFriendly(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetBright(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetBright(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetNumber(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetNumber(NativePointer, value);
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
                    return Server.Library.Blip_GetShowCone(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetShowCone(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetFlashes(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetFlashes(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetFlashesAlternate(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetFlashesAlternate(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetAsShortRange(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetAsShortRange(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetPriority(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetPriority(NativePointer, value);
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
                    return Server.Library.Blip_GetRotation(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                 CheckIfEntityExists();
                 Server.Library.Blip_SetRotation(NativePointer, value);
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
                    Server.Library.Blip_GetGxtName(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Server.Library.Blip_SetGxtName(NativePointer, stringPtr);
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
                    Server.Library.Blip_GetName(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Server.Library.Blip_SetName(NativePointer, stringPtr);
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
                    return Server.Library.Blip_GetPulse(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetPulse(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetAsMissionCreator(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetAsMissionCreator(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetTickVisible(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetTickVisible(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetHeadingIndicatorVisible(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetHeadingIndicatorVisible(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetOutlineIndicatorVisible(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetOutlineIndicatorVisible(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetCrewIndicatorVisible(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetCrewIndicatorVisible(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetCategory(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetCategory(NativePointer, value);
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
                    return Server.Library.Blip_GetAsHighDetail(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetAsHighDetail(NativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Server.Library.Blip_GetShrinked(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Blip_SetShrinked(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public Blip(IServer server, IntPtr nativePointer) : base(server, nativePointer, BaseObjectType.Blip)
        {
        }

        public void Fade(uint opacity, uint duration)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Blip_Fade(NativePointer, opacity, duration);
            }
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