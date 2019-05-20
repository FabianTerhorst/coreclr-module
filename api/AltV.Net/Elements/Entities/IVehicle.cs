using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltV.Net.Elements.Entities
{
    public interface IVehicle : IEntity
    {   
        /// <summary>
        /// Get the current driver of the vehicle.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        IPlayer Driver { get; }

        /// <summary>
        /// Get or set mod kit of the vehicle.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        byte ModKit { get; set; }

        byte ModKitsCount { get; }

        bool IsPrimaryColorRgb { get; }

        /// <summary>
        /// Get or set primary color of the vehicle.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        byte PrimaryColor { get; set; }

        Rgba PrimaryColorRgb { get; set; }

        bool IsSecondaryColorRgb { get; }

        byte SecondaryColor { get; set; }

        Rgba SecondaryColorRgb { get; set; }

        byte PearlColor { get; set; }

        byte WheelColor { get; set; }

        byte InteriorColor { get; set; }

        byte DashboardColor { get; set; }

        bool IsTireSmokeColorCustom { get; }

        Rgba TireSmokeColor { get; set; }

        byte WheelType { get; }

        byte WheelVariation { get; }

        bool CustomTires { get; set; }

        byte SpecialDarkness { get; set; }

        /// <summary>
        /// Get or set number plate index of the vehicle.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        uint NumberplateIndex { get; set; }

        /// <summary>
        /// Get or set number plate text of the vehicle.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        string NumberplateText { get; set; }

        byte WindowTint { get; set; }

        byte DirtLevel { get; set; }

        Rgba NeonColor { get; set; }
        
        string AppearanceData { get; set; }

        byte GetMod(byte category);

        byte GetModsCount(byte category);

        bool SetMod(byte category, byte id);

        void SetWheels(byte type, byte variation);

        bool IsExtraOn(byte extraId);

        void ToggleExtra(byte extraId, bool state);

        bool IsNeonActive { get; }

        void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back);

        void SetNeonActive(bool left, bool right, bool top, bool back);

        bool EngineOn { get; set; }

        bool IsHandbrakeActive { get; }

        byte HeadlightColor { get; set; }
        
        uint RadioStation { get; set; }

        bool SirenActive { get; set; }

        VehicleLockState LockState { get; set; }

        byte GetDoorState(byte doorId);

        void SetDoorState(byte doorId, byte state);

        bool IsWindowOpened(byte windowId);

        void SetWindowOpened(byte windowId, bool state);

        bool IsDaylightOn { get; }

        bool IsNightlightOn { get; }

        bool RoofOpened { get; set; }

        bool IsFlamethrowerActive { get; }

        string State { get; set; }

        int EngineHealth { get; set; }

        int PetrolTankHealth { get; set; }

        byte WheelsCount { get; }

        bool IsWheelBurst(byte wheelId);

        void SetWheelBurst(byte wheelId, bool state);

        bool DoesWheelHasTire(byte wheelId);

        void SetWheelHasTire(byte wheelId, bool state);

        float GetWheelHealth(byte wheelId);

        void SetWheelHealth(byte wheelId, float health);

        byte RepairsCount { get; }

        uint BodyHealth { get; set; }

        uint BodyAdditionalHealth { get; set; }

        string HealthData { get; set; }

        byte GetPartDamageLevel(byte partId);

        void SetPartDamageLevel(byte partId, byte damage);

        /// <summary>
        /// Get the amount of bullet holes for the current part id
        /// </summary>
        /// <param name="partId">The current part od between 0 and 5</param>
        /// <returns>The bullet holes count between 0 and 15</returns>
        byte GetPartBulletHoles(byte partId);

        /// <summary>
        /// Set the amount of bullet holes for the current part id
        /// </summary>
        /// <param name="partId">The current part id between 0 and 5</param>
        /// <param name="shootsCount">The bullet holes count between 0 and 15</param>
        void SetPartBulletHoles(byte partId, byte shootsCount);

        bool IsLightDamaged(byte lightId);

        void SetLightDamaged(byte lightId, bool isDamaged);

        bool IsWindowDamaged(byte windowId);

        void SetWindowDamaged(byte windowId, bool isDamaged);

        bool IsSpecialLightDamaged(byte specialLightId);

        void SetSpecialLightDamaged(byte specialLightId, bool isDamaged);

        bool HasArmoredWindows { get; }

        float GetArmoredWindowHealth(byte windowId);

        void SetArmoredWindowHealth(byte windowId, float health);

        byte GetArmoredWindowShootCount(byte windowId);

        void SetArmoredWindowShootCount(byte windowId, byte count);

        byte GetBumperDamageLevel(byte bumperId);

        void SetBumperDamageLevel(byte bumperId, byte damageLevel);

        string DamageData { get; set; }
        
        bool ManualEngineControl { get; set; }
        
        string ScriptData { get; set; }

        void Remove();

#if NETCOREAPP3_0
        byte GetMod(VehicleModType category) => GetMod((byte) category);
        
        byte GetModsCount(VehicleModType category) => GetModsCount((byte) category);
        
        bool SetMod(VehicleModType category, byte id) => SetMod((byte) category, id);
        
        void SetPartDamageLevel(VehiclePart part, byte damage) => SetPartDamageLevel((byte) part, byte damage);

        byte GetPartBulletHoles(VehiclePart part) => GetPartBulletHoles((byte) part);

        void SetPartBulletHoles(VehiclePart part, byte shootsCount) => SetPartBulletHoles((byte) part, byte shootsCount);
        
        VehicleBumperDamage GetBumperDamageLevel(VehicleBumper bumper) => (VehicleBumperDamage) GetBumperDamageLevel((byte) bumper); 
        
        void SetBumperDamageLevel(VehicleBumper bumper, VehicleBumperDamage damageLevel) => SetBumperDamageLevel((byte) bumper, (byte) damageLevel);

        VehiclePartDamage GetPartDamageLevel(VehiclePart part) => (VehiclePartDamage) GetPartDamageLevel((byte) part);

        void SetPartDamageLevel(VehiclePart part, VehiclePartDamage damage) =>  SetPartDamageLevel((byte) part, (byte) damage); 
        
        VehicleDoorState GetDoorState(VehicleDoor door) => (VehicleDoorState) GetDoorState((byte)door);

        void SetDoorState(VehicleDoor door, VehicleDoorState state) => SetDoorState((byte) door, (byte) state);
#endif
    }

    public static class VehicleEnumExtensions
    {
        public static byte GetMod(this IVehicle vehicle, VehicleModType category) => vehicle.GetMod((byte) category);

        public static byte GetModsCount(this IVehicle vehicle, VehicleModType category) =>
            vehicle.GetModsCount((byte) category);

        public static bool SetMod(this IVehicle vehicle, VehicleModType category, byte id) =>
            vehicle.SetMod((byte) category, id);

        public static void SetPartDamageLevel(this IVehicle vehicle, VehiclePart part, byte damage) =>
            vehicle.SetPartDamageLevel((byte) part, damage);

        public static byte GetPartBulletHoles(this IVehicle vehicle, VehiclePart part) =>
            vehicle.GetPartBulletHoles((byte) part);

        public static void SetPartBulletHoles(this IVehicle vehicle, VehiclePart part, byte shootsCount) =>
            vehicle.SetPartBulletHoles((byte) part, shootsCount);

        public static VehicleBumperDamage GetBumperDamageLevel(this IVehicle vehicle, VehicleBumper bumper) =>
            (VehicleBumperDamage) vehicle.GetBumperDamageLevel((byte) bumper);

        public static void SetBumperDamageLevel(this IVehicle vehicle, VehicleBumper bumper,
            VehicleBumperDamage damageLevel) => vehicle.SetBumperDamageLevel((byte) bumper, (byte) damageLevel);

        public static VehiclePartDamage GetPartDamageLevel(this IVehicle vehicle, VehiclePart part) =>
            (VehiclePartDamage) vehicle.GetPartDamageLevel((byte) part);

        public static void SetPartDamageLevel(this IVehicle vehicle, VehiclePart part, VehiclePartDamage damage) =>
            vehicle.SetPartDamageLevel((byte) part, (byte) damage);

        public static VehicleDoorState GetDoorState(this IVehicle vehicle, VehicleDoor door) =>
            (VehicleDoorState) vehicle.GetDoorState((byte) door);

        public static void SetDoorState(this IVehicle vehicle, VehicleDoor door, VehicleDoorState state) =>
            vehicle.SetDoorState((byte) door, (byte) state);
    }
}