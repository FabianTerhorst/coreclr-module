using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Enums;

namespace AltV.Net.Elements.Entities;

public class Marker : WorldObject, IMarker
{
    public IntPtr MarkerNativePointer { get; }
    public override IntPtr NativePointer => MarkerNativePointer;

    private static IntPtr GetEntityPointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Shared.Marker_GetBaseObject(nativePointer);
        }
    }

    public static uint GetId(IntPtr nativePointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Marker_GetID(nativePointer);
        }
    }

    public Marker(ICore core, IPlayer player, byte type, Position pos, Rgba color) : this(core,
        core.CreateMarkerEntity(out var id, player, type, pos, color), id)
    {
    }

    public Marker(ICore core, IntPtr nativePointer, uint id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.Marker, id)
    {
        this.MarkerNativePointer = nativePointer;
    }

    public bool IsGlobal
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.Marker_IsGlobal(MarkerNativePointer) == 1;
            }
        }
    }

    public ISharedPlayer Target
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var targetPointer = Core.Library.Shared.Marker_GetTarget(MarkerNativePointer);
                if (targetPointer == IntPtr.Zero) return null;
                return (ISharedPlayer)Core.BaseBaseObjectPool.Get(targetPointer, BaseObjectType.Player);
            }
        }
    }
    public Rgba Color
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var color = Rgba.Zero;
                Core.Library.Shared.Marker_GetColor(MarkerNativePointer, &color);
                return color;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetColor(MarkerNativePointer, value);
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
                return Core.Library.Shared.Marker_GetVisible(MarkerNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetVisible(MarkerNativePointer, value ? (byte)1 : (byte)0);
            }
        }
    }

    public MarkerType MarkerType
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return (MarkerType)Core.Library.Shared.Marker_GetMarkerType(MarkerNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetMarkerType(MarkerNativePointer, (byte)value);
            }
        }
    }

    public Position Scale
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var scale = Vector3.Zero;
                Core.Library.Shared.Marker_GetScale(MarkerNativePointer, &scale);
                return scale;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetScale(MarkerNativePointer, value);
            }
        }
    }

    public Rotation Rotation
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var directon = Rotation.Zero;
                Core.Library.Shared.Marker_GetRotation(MarkerNativePointer, &directon);
                return directon;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetRotation(MarkerNativePointer, value);
            }
        }
    }
    public Position Direction
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var directon = Vector3.Zero;
                Core.Library.Shared.Marker_GetDirection(MarkerNativePointer, &directon);
                return directon;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetDirection(MarkerNativePointer, value);
            }
        }
    }
}