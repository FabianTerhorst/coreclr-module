using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Async.Elements.Entities
{
    [Obsolete("Use Vehicle constructor instead")]
    public class VehicleBuilder : IVehicleBuilder
    {
        private readonly uint model;

        private readonly Position position;

        private readonly Rotation rotation;

        private readonly Dictionary<string, Action<IntPtr>> functions = new Dictionary<string, Action<IntPtr>>();

        private readonly List<IntPtr> memoryToFree = new List<IntPtr>();

        public VehicleBuilder(uint model, Position position, Rotation rotation)
        {
            this.model = model;
            this.position = position;
            this.rotation = rotation;
        }

        public IVehicleBuilder ModKit(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetModKit(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder PrimaryColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetPrimaryColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder PrimaryColorRgb(Rgba value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetPrimaryColorRGB(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder SecondaryColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetSecondaryColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder SecondaryColorRgb(Rgba value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetSecondaryColorRGB(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder PearlColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetPearlColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder WheelColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetWheelColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder InteriorColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetInteriorColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder DashboardColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetDashboardColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder TireSmokeColor(Rgba value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetTireSmokeColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder CustomTires(bool value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetCustomTires(ptr, value ? (byte) 1 : (byte) 0);
                }
            });
            return this;
        }

        public IVehicleBuilder SpecialDarkness(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetSpecialDarkness(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder NumberplateIndex(uint value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetNumberplateIndex(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder NumberplateText(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetNumberplateText(ptr, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            });
            return this;
        }

        public IVehicleBuilder WindowTint(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetWindowTint(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder DirtLevel(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetDirtLevel(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder NeonColor(Rgba value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetNeonColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder EngineOn(bool value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetEngineOn(ptr, value ? (byte) 1 : (byte) 0);
                }
            });
            return this;
        }

        public IVehicleBuilder HeadlightColor(byte value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetHeadlightColor(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder SirenActive(bool value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetSirenActive(ptr, value ? (byte) 1 : (byte) 0);
                }
            });
            return this;
        }

        public IVehicleBuilder LockState(VehicleLockState value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetLockState(ptr, (byte) value);
                }
            });
            return this;
        }

        public IVehicleBuilder IsRoofClosed(bool state)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetRoofState(ptr, state ? (byte)1: (byte)0);
                }
            });
            return this;
        }

        public IVehicleBuilder State(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_LoadGameStateFromBase64(ptr, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            });
            return this;
        }

        public IVehicleBuilder EngineHealth(int value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetEngineHealth(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder PetrolTankHealth(int value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetPetrolTankHealth(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder BodyHealth(uint value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetBodyHealth(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder BodyAdditionalHealth(uint value)
        {
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_SetBodyAdditionalHealth(ptr, value);
                }
            });
            return this;
        }

        public IVehicleBuilder HealthData(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_LoadHealthDataFromBase64(ptr, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            });
            return this;
        }

        public IVehicleBuilder DamageData(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_LoadDamageDataFromBase64(ptr, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            });
            return this;
        }

        public IVehicleBuilder Appearance(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_LoadAppearanceDataFromBase64(ptr, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            });
            return this;
        }

        public IVehicleBuilder ScriptData(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr =>
            {
                unsafe
                {
                    Alt.Core.Library.Server.Vehicle_LoadScriptDataFromBase64(ptr, valuePtr);
                    Marshal.FreeHGlobal(valuePtr);
                }
            });
            return this;
        }

        public async Task<IVehicle> Build()
        {
            var enumerator = functions.Values.GetEnumerator();
            var (vehiclePtr, vehicleId) = await AltAsync.AltVAsync.Schedule(() =>
            {
                unsafe
                {
                    uint id = default;
                    var ptr = Alt.Core.Library.Server.Core_CreateVehicle(((Core) Alt.Core).NativePointer, model,
                        position, rotation,
                        &id);

                    while (enumerator.MoveNext())
                    {
                        enumerator.Current(ptr);
                    }

                    return (ptr, id);
                }
            });
            enumerator.Dispose();
            Dispose();
            return Alt.Core.PoolManager.Vehicle.Create(Alt.Core, vehiclePtr, vehicleId);
        }

        // Call Dispose when you don't wanna continue building the vehicle anymore to cleanup memory
        public void Dispose()
        {
            foreach (var ptr in memoryToFree)
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private void Add(Action<IntPtr> action, [CallerMemberName] string memberName = "")
        {
            functions[memberName] = action;
        }

        private IntPtr StringToHGlobalUtf8(string str)
        {
            var strPtr = AltNative.StringUtils.StringToHGlobalUtf8(str);
            memoryToFree.Add(strPtr);
            return strPtr;
        }
    }
}