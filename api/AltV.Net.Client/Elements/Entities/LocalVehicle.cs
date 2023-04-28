using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class LocalVehicle : WorldObject, ILocalVehicle
{
    public IntPtr LocalVehicleNativePointer { get; }
    public override IntPtr NativePointer => LocalVehicleNativePointer;

    private static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Shared.LocalVehicle_GetWorldObject(nativePointer);
        }
    }


    public LocalVehicle(ICore core, uint modelHash, int dimension, Position position, Rotation rotation, bool useStreaming, uint streamingDistance) :
        this(core, core.CreateLocalVehiclePtr(out var id, modelHash, dimension, position, rotation, useStreaming, streamingDistance), id)
    {
        core.PoolManager.LocalVehicle.Add(this);
    }

    public LocalVehicle(ICore core, IntPtr nativePointer, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.LocalVehicle, id)
    {
        LocalVehicleNativePointer = nativePointer;
    }

    public uint Model
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.LocalVehicle_GetModel(LocalVehicleNativePointer);
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
                Core.Library.Shared.LocalVehicle_GetRotation(LocalVehicleNativePointer, &directon);
                return directon;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.LocalVehicle_SetRotation(LocalVehicleNativePointer, value);
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
                return Core.Library.Shared.LocalVehicle_GetStreamingDistance(LocalVehicleNativePointer);
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
                return Core.Library.Shared.LocalVehicle_IsVisible(LocalVehicleNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.LocalVehicle_SetVisible(LocalVehicleNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }

    public bool IsRemote
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.LocalVehicle_IsRemote(LocalVehicleNativePointer) == 1;
            }
        }
    }

    public uint RemoteId
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.LocalVehicle_GetRemoteID(LocalVehicleNativePointer);
            }
        }
    }

    public bool IsStreamedIn
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.LocalVehicle_IsStreamedIn(LocalVehicleNativePointer) == 1;
            }
        }
    }
}