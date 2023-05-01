using System.Numerics;
using AltV.Net.Client.Elements.Data;
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
            return core.Library.Client.LocalVehicle_GetWorldObject(nativePointer);
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
                return Core.Library.Client.LocalVehicle_GetModel(LocalVehicleNativePointer);
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
                Core.Library.Client.LocalVehicle_GetRotation(LocalVehicleNativePointer, &directon);
                return directon;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalVehicle_SetRotation(LocalVehicleNativePointer, value);
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

        public ushort Gear
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetCurrentGear(LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetCurrentGear(LocalVehicleNativePointer, value);
                }
            }
        }

        public byte IndicatorLights
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetLightsIndicator (LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetLightsIndicator(LocalVehicleNativePointer, value);
                }
            }
        }

        public ushort MaxGear
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetMaxGear(LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetMaxGear(LocalVehicleNativePointer, value);
                }
            }
        }

        public float Rpm
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetCurrentRPM(LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetCurrentRPM(LocalVehicleNativePointer, value);
                }
            }
        }

        public float OilLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetOilLevel(LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetOilLevel(LocalVehicleNativePointer, value);
                }
            }
        }

        public float EngineTemperature
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetEngineTemperature(LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetEngineTemperature(LocalVehicleNativePointer, value);
                }
            }
        }

        public float FuelLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetFuelLevel(LocalVehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_SetFuelLevel(LocalVehicleNativePointer, value);
                }
            }
        }

        public byte SeatCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetSeatCount(LocalVehicleNativePointer);
                }
            }
        }

        public byte OccupiedSeatsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetOccupiedSeatsCount(LocalVehicleNativePointer);
                }
            }
        }

        public float WheelSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_GetWheelSpeed(LocalVehicleNativePointer);
                }
            }
        }

        public Vector3 SpeedVector
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var position = Vector3.Zero;
                    Core.Library.Client.LocalVehicle_GetSpeedVector(LocalVehicleNativePointer, &position);
                    return position;
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Vehicle_GetWheelsCount(LocalVehicleNativePointer);
                }
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Vehicle_GetPetrolTankHealth(LocalVehicleNativePointer);
                }
            }
        }

        public bool IsTaxiLightOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.LocalVehicle_IsTaxiLightOn(LocalVehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.LocalVehicle_ToggleTaxiLight(LocalVehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public Handling GetHandling()
        {
            return new Handling(Core, LocalVehicleNativePointer, true);
        }

        public uint GetWheelSurfaceMaterial(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelSurfaceMaterial(LocalVehicleNativePointer, wheel);
            }
        }

        public float GetWheelCamber(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelCamber(LocalVehicleNativePointer, wheel);
            }
        }

        public void SetWheelCamber(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.LocalVehicle_SetWheelCamber(LocalVehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelTrackWidth(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelTrackWidth(LocalVehicleNativePointer, wheel);
            }
        }

        public void SetWheelTrackWidth(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.LocalVehicle_SetWheelTrackWidth(LocalVehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelHeight(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelHeight(LocalVehicleNativePointer, wheel);
            }
        }

        public void SetWheelHeight(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.LocalVehicle_SetWheelHeight(LocalVehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelTyreRadius(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelTyreRadius(LocalVehicleNativePointer, wheel);
            }
        }

        public void SetWheelTyreRadius(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.LocalVehicle_SetWheelTyreRadius(LocalVehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelRimRadius(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelRimRadius(LocalVehicleNativePointer, wheel);
            }
        }

        public void SetWheelRimRadius(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.LocalVehicle_SetWheelRimRadius(LocalVehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelTyreWidth(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.LocalVehicle_GetWheelTyreWidth(LocalVehicleNativePointer, wheel);
            }
        }

        public void SetWheelTyreWidth(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.LocalVehicle_SetWheelTyreWidth(LocalVehicleNativePointer, wheel, value);
            }
        }
}