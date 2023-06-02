using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Client.Elements.Entities
{
    public class Blip : WorldObject, IBlip
    {
        public IntPtr BlipNativePointer { get; }
        public override IntPtr NativePointer => BlipNativePointer;

        private static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Blip_GetWorldObject(nativePointer);
            }
        }

        public bool IsGlobal
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Blip_IsGlobal(BlipNativePointer) == 1;
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
                    return Core.Library.Shared.Blip_GetType(BlipNativePointer);
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
                    return Core.Library.Shared.Blip_GetSprite(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetSprite(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetColor(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetColor(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetRoute(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetRoute(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    Core.Library.Shared.Blip_GetRouteColor(BlipNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetRouteColor(BlipNativePointer, value);
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
                    Core.Library.Shared.Blip_GetScaleXY(BlipNativePointer, &v2);
                    return v2;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetScaleXY(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetDisplay(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetDisplay(BlipNativePointer, value);
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
                    Core.Library.Shared.Blip_GetSecondaryColor(BlipNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetSecondaryColor(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetAlpha(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetAlpha(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetFlashTimer(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetFlashTimer(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetFlashInterval(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetFlashInterval(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetAsFriendly(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetAsFriendly(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetBright(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetBright(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetNumber(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetNumber(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetShowCone(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetShowCone(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetFlashes(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetFlashes(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetFlashesAlternate(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetFlashesAlternate(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetAsShortRange(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetAsShortRange(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetPriority(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetPriority(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetRotation(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetRotation(BlipNativePointer, value);
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
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Shared.Blip_GetGxtName(BlipNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Core.Library.Shared.Blip_SetGxtName(BlipNativePointer, stringPtr);
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
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Shared.Blip_GetName(BlipNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Core.Library.Shared.Blip_SetName(BlipNativePointer, stringPtr);
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
                    return Core.Library.Shared.Blip_GetPulse(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetPulse(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetAsMissionCreator(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetAsMissionCreator(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetTickVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetTickVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetHeadingIndicatorVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetHeadingIndicatorVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetOutlineIndicatorVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetOutlineIndicatorVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetCrewIndicatorVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetCrewIndicatorVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetCategory(BlipNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetCategory(BlipNativePointer, value);
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
                    return Core.Library.Shared.Blip_GetAsHighDetail(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetAsHighDetail(BlipNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return Core.Library.Shared.Blip_GetShrinked(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Blip_SetShrinked(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public uint GameId
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Blip_GetGameID(BlipNativePointer);
                }
            }
        }

        public bool Visible
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Blip_IsVisible(BlipNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Blip_SetVisible(BlipNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public Blip(ICore core, IntPtr nativePointer, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.Blip, id)
        {
            BlipNativePointer = nativePointer;
        }

        [Obsolete("Use Alt.CreatePointBlip instead")]
        public Blip(ICore core, Position position) : this(core, core.CreatePointBlipPtr(out var id, position), id)
        {
            core.PoolManager.Blip.Add(this);
        }

        [Obsolete("Use Alt.CreateRadiusBlip instead")]
        public Blip(ICore core, Position position, float radius) : this(core, core.CreateRadiusBlipPtr(out var id, position, radius), id)
        {
            core.PoolManager.Blip.Add(this);
        }

        [Obsolete("Use Alt.CreateAreaBlip instead")]
        public Blip(ICore core, Position position, int width, int height) : this(core, core.CreateAreaBlipPtr(out var id, position, width, height), id)
        {
            core.PoolManager.Blip.Add(this);
        }

        public void Fade(uint opacity, uint duration)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Blip_Fade(BlipNativePointer, opacity, duration);
            }
        }
    }
}