using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltV.Net.Elements.Entities
{
    public interface IVehicle : IEntity
    {
        /// <summary>
        /// Get the current driver of the vehicle
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IPlayer Driver { get; }

        /// <summary>
        /// Get or set mod kit of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        byte ModKit { get; set; }

        byte ModKitsCount { get; }

        bool IsPrimaryColorRgb { get; }

        /// <summary>
        /// Get or set primary color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
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
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint NumberPlateIndex { get; set; }

        /// <summary>
        /// Get or set number plate text of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string NumberPlateText { get; set; }

        byte WindowTint { get; set; }

        byte DirtLevel { get; set; }

        Rgba NeonColor { get; set; }

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

        byte GetPartBulletHoles(byte partId);

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

        void Remove();
    }
}