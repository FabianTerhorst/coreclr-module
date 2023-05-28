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

    private static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Shared.Marker_GetWorldObject(nativePointer);
        }
    }

    public static uint GetId(IntPtr nativePointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Marker_GetID(nativePointer);
        }
    }

    public Marker(ICore core, IntPtr nativePointer, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.Marker, id)
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
                return Core.PoolManager.Player.Get(targetPointer);
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
                return Core.Library.Shared.Marker_IsVisible(MarkerNativePointer) == 1;
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

    public uint StreamingDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.Marker_GetStreamingDistance(MarkerNativePointer);
            }
        }
    }

    public bool IsFaceCamera
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.Marker_IsFaceCamera(MarkerNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetFaceCamera(MarkerNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }

    public bool IsRotating
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.Marker_IsRotating(MarkerNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetRotating(MarkerNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }

    public bool IsBobUpDown
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.Marker_IsBobUpDown(MarkerNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Marker_SetBobUpDown(MarkerNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }
}