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
            Add(ptr => AltNative.Vehicle.Vehicle_SetModKit(ptr, value));
            return this;
        }

        public IVehicleBuilder PrimaryColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetPrimaryColor(ptr, value));
            return this;
        }

        public IVehicleBuilder PrimaryColorRgb(Rgba value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetPrimaryColorRGB(ptr, value));
            return this;
        }

        public IVehicleBuilder SecondaryColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetSecondaryColor(ptr, value));
            return this;
        }

        public IVehicleBuilder SecondaryColorRgb(Rgba value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetSecondaryColorRGB(ptr, value));
            return this;
        }

        public IVehicleBuilder PearlColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetPearlColor(ptr, value));
            return this;
        }

        public IVehicleBuilder WheelColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetWheelColor(ptr, value));
            return this;
        }

        public IVehicleBuilder InteriorColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetInteriorColor(ptr, value));
            return this;
        }

        public IVehicleBuilder DashboardColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetDashboardColor(ptr, value));
            return this;
        }

        public IVehicleBuilder TireSmokeColor(Rgba value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetTireSmokeColor(ptr, value));
            return this;
        }

        public IVehicleBuilder CustomTires(bool value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetCustomTires(ptr, value));
            return this;
        }

        public IVehicleBuilder SpecialDarkness(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetSpecialDarkness(ptr, value));
            return this;
        }

        public IVehicleBuilder NumberplateIndex(uint value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetNumberplateIndex(ptr, value));
            return this;
        }

        public IVehicleBuilder NumberplateText(string value)
        {
            var valuePtr = StringToHGlobalUtf8(value);
            Add(ptr => AltNative.Vehicle.Vehicle_SetNumberplateText(ptr, valuePtr));
            return this;
        }

        public IVehicleBuilder WindowTint(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetWindowTint(ptr, value));
            return this;
        }

        public IVehicleBuilder DirtLevel(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetDirtLevel(ptr, value));
            return this;
        }

        public IVehicleBuilder NeonColor(Rgba value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetNeonColor(ptr, value));
            return this;
        }

        public IVehicleBuilder EngineOn(bool value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetEngineOn(ptr, value));
            return this;
        }

        public IVehicleBuilder HeadlightColor(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetHeadlightColor(ptr, value));
            return this;
        }

        public IVehicleBuilder SirenActive(bool value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetSirenActive(ptr, value));
            return this;
        }

        public IVehicleBuilder LockState(VehicleLockState value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetLockState(ptr, (byte) value));
            return this;
        }

        public IVehicleBuilder RoofState(byte value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetRoofState(ptr, value));
            return this;
        }

        public IVehicleBuilder State(string value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_LoadGameStateFromBase64(ptr, value));
            return this;
        }

        public IVehicleBuilder EngineHealth(int value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetEngineHealth(ptr, value));
            return this;
        }

        public IVehicleBuilder PetrolTankHealth(int value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetPetrolTankHealth(ptr, value));
            return this;
        }

        public IVehicleBuilder BodyHealth(uint value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetBodyHealth(ptr, value));
            return this;
        }

        public IVehicleBuilder BodyAdditionalHealth(uint value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_SetBodyAdditionalHealth(ptr, value));
            return this;
        }

        public IVehicleBuilder HealthData(string value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_LoadHealthDataFromBase64(ptr, value));
            return this;
        }

        public IVehicleBuilder DamageData(string value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_LoadDamageDataFromBase64(ptr, value));
            return this;
        }

        public IVehicleBuilder Appearance(string value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_LoadAppearanceDataFromBase64(ptr, value));
            return this;
        }

        public IVehicleBuilder ScriptData(string value)
        {
            Add(ptr => AltNative.Vehicle.Vehicle_LoadScriptDataFromBase64(ptr, value));
            return this;
        }

        public async Task<IVehicle> Build()
        {
            ushort id = default;
            var enumerator = functions.Values.GetEnumerator();
            var vehiclePtr = await AltAsync.AltVAsync.Schedule(() =>
            {
                var ptr = AltNative.Server.Server_CreateVehicle(((Server) Alt.Server).NativePointer, model,
                    position, rotation,
                    ref id);

                while (enumerator.MoveNext())
                {
                    enumerator.Current(ptr);
                }

                return ptr;
            });
            enumerator.Dispose();
            Dispose();
            Alt.Module.VehiclePool.Create(vehiclePtr, id, out var vehicle);
            return vehicle;
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