using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class LocalVehicle : Vehicle, ILocalVehicle
{
    public IntPtr LocalVehicleNativePointer { get; }
    public override IntPtr NativePointer => LocalVehicleNativePointer;

    private static IntPtr GetVehiclePointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Client.LocalVehicle_GetVehicle(nativePointer);
        }
    }

    public LocalVehicle(ICore core, uint modelHash, int dimension, Position position, Rotation rotation, bool useStreaming, uint streamingDistance) :
        this(core, core.CreateLocalVehiclePtr(out var id, modelHash, dimension, position, rotation, useStreaming, streamingDistance), id)
    {
        core.PoolManager.LocalVehicle.Add(this);
    }

    public LocalVehicle(ICore core, IntPtr nativePointer, uint id) : base(core, GetVehiclePointer(core, nativePointer), BaseObjectType.LocalVehicle, id)
    {
        LocalVehicleNativePointer = nativePointer;
    }

    public uint Model
    {
        get
        {
            return base.Model;
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalVehicle_SetModel(LocalVehicleNativePointer, value);
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
                return Core.Library.Client.LocalVehicle_GetStreamingDistance(LocalVehicleNativePointer);
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
                return Core.Library.Client.LocalVehicle_IsVisible(LocalVehicleNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalVehicle_SetVisible(LocalVehicleNativePointer, value ? (byte)1:(byte)0);
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