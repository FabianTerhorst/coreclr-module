using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class LocalPed : WorldObject, ILocalPed
{
    public IntPtr LocalPedNativePointer { get; }
    public override IntPtr NativePointer => LocalPedNativePointer;

    private static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Shared.LocalPed_GetWorldObject(nativePointer);
        }
    }


    public LocalPed(ICore core, uint modelHash, int dimension, Position position, Rotation rotation, bool useStreaming, uint streamingDistance) :
        this(core, core.CreateLocalPedPtr(out var id, modelHash, dimension, position, rotation, useStreaming, streamingDistance), id)
    {
        core.PoolManager.LocalPed.Add(this);
    }

    public LocalPed(ICore core, IntPtr nativePointer, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.LocalVehicle, id)
    {
        LocalPedNativePointer = nativePointer;
    }

    public uint Model
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.LocalPed_GetModel(LocalPedNativePointer);
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
                Core.Library.Shared.LocalPed_GetRotation(LocalPedNativePointer, &directon);
                return directon;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.LocalPed_SetRotation(LocalPedNativePointer, value);
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
                return Core.Library.Shared.LocalPed_GetStreamingDistance(LocalPedNativePointer);
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
                return Core.Library.Shared.LocalPed_IsVisible(LocalPedNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.LocalPed_SetVisible(LocalPedNativePointer, value ? (byte)1:(byte)0);
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
                return Core.Library.Client.LocalPed_IsRemote(LocalPedNativePointer) == 1;
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
                return Core.Library.Client.LocalPed_GetRemoteID(LocalPedNativePointer);
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
                return Core.Library.Client.LocalPed_IsStreamedIn(LocalPedNativePointer) == 1;
            }
        }
    }
}