using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IVehicle : ISharedVehicle, IEntity
    {
        /// <summary>
        /// Get the current driver of the
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        IPlayer Driver { get; }

        /// <summary>
        /// Gets if the vehicle is destroyed.
        /// </summary>
        bool IsDestroyed { get; }

        /// <summary>
        /// Get or set mod kit of the
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        byte ModKit { get; set; }

        /// <summary>
        /// The amount of Modkits
        /// </summary>
        byte ModKitsCount { get; }

        /// <summary>
        /// If the primary color is RGBA
        /// </summary>
        bool IsPrimaryColorRgb { get; }

        /// <summary>
        /// Get or set primary color of the
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        byte PrimaryColor { get; set; }

        /// <summary>
        /// The primary color in RGBA
        /// </summary>
        Rgba PrimaryColorRgb { get; set; }

        /// <summary>
        /// If the secondary color is RGBA
        /// </summary>
        bool IsSecondaryColorRgb { get; }

        /// <summary>
        /// The secondary color
        /// </summary>
        byte SecondaryColor { get; set; }

        /// <summary>
        /// The secondary color in RGBA
        /// </summary>
        Rgba SecondaryColorRgb { get; set; }

        /// <summary>
        /// Pearl Color
        /// </summary>
        byte PearlColor { get; set; }

        /// <summary>
        /// Wheel Color
        /// </summary>
        byte WheelColor { get; set; }

        /// <summary>
        /// Interior Color
        /// </summary>
        byte InteriorColor { get; set; }

        /// <summary>
        /// Dashboard Color
        /// </summary>
        byte DashboardColor { get; set; }

        /// <summary>
        /// If the tyre smoke is RGBA
        /// </summary>
        bool IsTireSmokeColorCustom { get; }

        /// <summary>
        /// The RGBA of the tyre smoke
        /// </summary>
        Rgba TireSmokeColor { get; set; }

        /// <summary>
        /// The wheel type
        /// </summary>
        byte WheelType { get; }

        /// <summary>
        /// The wheel variation, for e.g. bikes only this getter works, RearWheel won't.
        /// For most other vehicles this is the FrontWheel variation getter.
        /// </summary>
        byte WheelVariation { get; }

        /// <summary>
        /// Rear wheel variation.
        /// </summary>
        byte RearWheel { get; set; }

        /// <summary>
        /// Sets custom tires on the vehicle
        /// </summary>
        bool CustomTires { get; set; }

        byte SpecialDarkness { get; set; }

        /// <summary>
        /// Get or set number plate index of the vehicle
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        uint NumberplateIndex { get; set; }

        /// <summary>
        /// Get or set number plate text of the vehicle
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        string NumberplateText { get; set; }

        /// <summary>
        /// The window tint level
        /// </summary>
        byte WindowTint { get; set; }

        /// <summary>
        /// The dirt level
        /// </summary>
        byte DirtLevel { get; set; }

        /// <summary>
        /// Neon Color in RGBA
        /// </summary>
        Rgba NeonColor { get; set; }

        /// <summary>
        /// The livery
        /// </summary>
        byte Livery { get; set; }

        byte LightState { get; set; }

        /// <summary>
        /// The roof livery
        /// </summary>
        byte RoofLivery { get; set; }

        string AppearanceData { get; set; }

        /// <summary>
        /// Gets the vehicle that is attached on this vehicle
        /// </summary>
        IVehicle Attached { get; }

        /// <summary>
        /// Gets the vehicle that this vehicle is attached to
        /// </summary>
        IVehicle AttachedTo { get; }

        /// <summary>
        /// Current mod in category
        /// </summary>
        /// <param name="category">Mod Category</param>
        /// <returns>Current mod</returns>
        byte GetMod(byte category);

        /// <summary>
        /// Mod count in Category
        /// </summary>
        /// <param name="category">Mod Category</param>
        /// <returns>Mod count</returns>
        byte GetModsCount(byte category);

        /// <summary>
        /// Set Mod
        /// </summary>
        /// <param name="category">The mod category (slot)</param>
        /// <param name="id">The mod id</param>
        /// <returns>True - Mod was set</returns>
        bool SetMod(byte category, byte id);

        /// <summary>
        /// Sets the wheels type and variation
        /// </summary>
        /// <param name="type">Wheel Type</param>
        /// <param name="variation">Wheel variation</param>
        void SetWheels(byte type, byte variation);

        /// <summary>
        /// If the vehicle extra is on
        /// </summary>
        /// <param name="extraId"></param>
        /// <returns></returns>
        bool IsExtraOn(byte extraId);

        /// <summary>
        /// Toggles the vehicle extra
        /// </summary>
        /// <param name="extraId">Extra Id</param>
        /// <param name="state">True - Enabled</param>
        void ToggleExtra(byte extraId, bool state);

        /// <summary>
        /// Is the neon active - True = Active
        /// </summary>
        bool IsNeonActive { get; }

        /// <summary>
        /// Gets the neon active for each area
        /// </summary>
        /// <param name="left">Left Side</param>
        /// <param name="right">Right Side</param>
        /// <param name="top">Front Side</param>
        /// <param name="back">Rear Side</param>
        void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back);

        /// <summary>
        /// Sets neon active by side
        /// </summary>
        /// <param name="left">Left side</param>
        /// <param name="right">Right Side</param>
        /// <param name="top">Top Side</param>
        /// <param name="back">Back Side</param>
        void SetNeonActive(bool left, bool right, bool top, bool back);

        /// <summary>
        /// Sets or Returns the status of the Engine
        /// </summary>
        bool EngineOn { get; set; }

        /// <summary>
        /// Returns the status of the handbrake
        /// </summary>
        bool IsHandbrakeActive { get; }

        /// <summary>
        /// The current headlight color
        /// </summary>
        byte HeadlightColor { get; set; }

        /// <summary>
        /// Sets or Gets the current radio station
        /// </summary>
        uint RadioStation { get; set; }

        IPlayer TimedExplosionCulprit { get; }

        uint TimedExplosionTime { get; }

        /// <summary>
        /// Sets or Gets if the siren is active. True = active
        /// </summary>
        bool SirenActive { get; set; }

        /// <summary>
        /// Returns or Sets the LockState of the vehicle
        /// </summary>
        VehicleLockState LockState { get; set; }

        /// <summary>
        /// Returns the state of the door
        /// </summary>
        /// <param name="doorId">Door Id</param>
        /// <returns>Door State</returns>
        byte GetDoorState(byte doorId);

        /// <summary>
        /// Sets the door state
        /// </summary>
        /// <param name="doorId">The Door</param>
        /// <param name="state">The state</param>
        void SetDoorState(byte doorId, byte state);

        /// <summary>
        /// Returns if the window is opened
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <returns>True = Open</returns>
        bool IsWindowOpened(byte windowId);

        /// <summary>
        /// Sets the window status
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <param name="state">True = Open</param>
        void SetWindowOpened(byte windowId, bool state);

        /// <summary>
        /// Is the day lights on
        /// </summary>
        bool IsDaylightOn { get; }

        /// <summary>
        /// Is the night light on
        /// </summary>
        bool IsNightlightOn { get; }

        /// <summary>
        /// Sets the Roof closed
        /// </summary>
        bool IsRoofClosed { get; set; }

        /// <summary>
        /// If the flamethrower is active
        /// </summary>
        bool IsFlamethrowerActive { get; }

        /// <summary>
        /// Multiplier for the lights
        /// </summary>
        float LightsMultiplier { get; set; }

        /// <summary>
        /// Vehicle state
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// Engine Health
        /// </summary>
        int EngineHealth { get; set; }

        /// <summary>
        /// Fuel Tank Health
        /// </summary>
        int PetrolTankHealth { get; set; }

        /// <summary>
        /// Is the type burst
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <returns>True = Burst</returns>
        bool IsWheelBurst(byte wheelId);

        /// <summary>
        /// Sets a wheels burst state
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <param name="state">True = Burst</param>
        void SetWheelBurst(byte wheelId, bool state);

        /// <summary>
        /// Returns if the wheel has a tyre
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <returns>True = Has tyre</returns>
        bool DoesWheelHasTire(byte wheelId);

        /// <summary>
        /// Sets if the wheel has a tyre
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <param name="state">True = Has tyre</param>
        void SetWheelHasTire(byte wheelId, bool state);

        /// <summary>
        /// Returns if the wheel is detached
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <returns>True if the wheel is detached</returns>
        bool IsWheelDetached(byte wheelId);

        /// <summary>
        /// Sets the detached state of the given wheel
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <param name="state">True when it should be detached, False when it should be attached</param>
        void SetWheelDetached(byte wheelId, bool state);

        /// <summary>
        /// Returns if the wheel is on fire
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <returns>True if the wheel is on fire</returns>
        bool IsWheelOnFire(byte wheelId);

        /// <summary>
        /// Sets the fire state of the given wheel
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <param name="state">True when it should be on fire, False when it should not be on fire</param>
        void SetWheelOnFire(byte wheelId, bool state);

        /// <summary>
        /// Gets the wheels health
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <returns>Wheel health</returns>
        float GetWheelHealth(byte wheelId);

        /// <summary>
        /// Sets the wheels healthy
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        /// <param name="health">Health</param>
        void SetWheelHealth(byte wheelId, float health);
        /// <summary>
        /// Fix the wheel
        /// </summary>
        /// <param name="wheelId">Wheel Id</param>
        void SetWheelFixed(byte wheelId);
        /// <summary>
        /// The amount of repairs
        /// </summary>
        byte RepairsCount { get; }

        /// <summary>
        /// The body health
        /// </summary>
        uint BodyHealth { get; set; }

        /// <summary>
        /// The additional body health
        /// </summary>
        uint BodyAdditionalHealth { get; set; }

        /// <summary>
        /// Health Data
        /// </summary>
        string HealthData { get; set; }

        /// <summary>
        /// Damage level by part
        /// </summary>
        /// <param name="partId">Part Id</param>
        /// <returns>Damage Level</returns>
        byte GetPartDamageLevel(byte partId);

        /// <summary>
        /// Sets the damage level of a part
        /// </summary>
        /// <param name="partId">Part Id</param>
        /// <param name="damage">Damage Level</param>
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

        /// <summary>
        /// Is the light damaged
        /// </summary>
        /// <param name="lightId">Light Id</param>
        /// <returns>True = Damaged</returns>
        bool IsLightDamaged(byte lightId);

        /// <summary>
        /// Sets the light damage state
        /// </summary>
        /// <param name="lightId">Light Id</param>
        /// <param name="isDamaged">True = Damaged</param>
        void SetLightDamaged(byte lightId, bool isDamaged);

        /// <summary>
        /// Returns if the window is damaged
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <returns>True = Damaged</returns>
        bool IsWindowDamaged(byte windowId);

        /// <summary>
        /// Sets the window damage state
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <param name="isDamaged">True = Damaged</param>
        void SetWindowDamaged(byte windowId, bool isDamaged);

        /// <summary>
        /// Returns if the special light is damaged
        /// </summary>
        /// <param name="specialLightId">Special light Id</param>
        /// <returns>True = Damaged</returns>
        bool IsSpecialLightDamaged(byte specialLightId);

        /// <summary>
        /// Sets the state of the special light damage
        /// </summary>
        /// <param name="specialLightId">Special Light</param>
        /// <param name="isDamaged">Damage</param>
        void SetSpecialLightDamaged(byte specialLightId, bool isDamaged);

        /// <summary>
        /// Returns true if has armored windows
        /// </summary>
        bool HasArmoredWindows { get; }

        bool TimedExplosion { get; }

        /// <summary>
        /// Returns health of an armored window
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <returns>Health level</returns>
        float GetArmoredWindowHealth(byte windowId);

        /// <summary>
        /// Sets the armored window health state
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <param name="health">State</param>
        void SetArmoredWindowHealth(byte windowId, float health);

        /// <summary>
        /// Gets the amount of bullets that has hit the window
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <returns>Bullet Count</returns>
        byte GetArmoredWindowShootCount(byte windowId);

        /// <summary>
        /// Sets the amount of bullets that has hit the window
        /// </summary>
        /// <param name="windowId">Window Id</param>
        /// <param name="count">Amount of bullets</param>
        void SetArmoredWindowShootCount(byte windowId, byte count);

        /// <summary>
        /// Gets the damage level for a bumper
        /// </summary>
        /// <param name="bumperId">0 - Front, 1 - Rear</param>
        /// <returns>0 - Not Damaged / 1 - Damaged / 2 - None</returns>
        byte GetBumperDamageLevel(byte bumperId);

        /// <summary>
        /// Sets the damage level of a bumper
        /// </summary>
        /// <param name="bumperId">0 - Front, 1 - Rear</param>
        /// <param name="damageLevel">0 - Not Damaged / 1 - Damaged / 2 - None</param>
        void SetBumperDamageLevel(byte bumperId, byte damageLevel);

        /// <summary>
        /// Returns the damage data
        /// </summary>
        string DamageData { get; set; }

        /// <summary>
        /// Enables or Disables automatic engine start when a player enters the drivers seat
        /// </summary>
        bool ManualEngineControl { get; set; }

        /// <summary>
        /// Script Data
        /// </summary>
        string ScriptData { get; set; }

        [Obsolete("Use Destroy() instead")]
        void Remove();

        /// <summary>
        /// Destroy the vehicle entity
        /// </summary>
        void Destroy();

        /// <summary>
        /// Repairs the vehicle
        /// </summary>
        void Repair();

        void SetTimedExplosion(bool state, IPlayer culprit, uint time);

        /// <summary>
        /// Returns the current mod of the vehicle in the category
        /// </summary>
        /// <param name="category">Mod category</param>
        /// <returns></returns>
        byte GetModExt(VehicleModType category) => GetMod((byte) category);

        /// <summary>
        /// Returns the amount of mods available in a category
        /// </summary>
        /// <param name="category">The mod type</param>
        /// <returns></returns>
        byte GetModsCountExt(VehicleModType category) =>
            GetModsCount((byte) category);

        /// <summary>
        /// Sets a vehicles mod into a category
        /// </summary>
        /// <param name="category">The mod category</param>
        /// <param name="id">The mod id</param>
        /// <returns></returns>
        bool SetModExt(VehicleModType category, byte id) =>
            SetMod((byte) category, id);

        /// <summary>
        /// Sets a vehicles part damage
        /// </summary>
        /// <param name="part">The vehicle part</param>
        /// <param name="damage">The damage</param>
        void SetPartDamageLevelExt(VehiclePart part, byte damage) =>
            SetPartDamageLevel((byte) part, damage);

        /// <summary>
        /// Gets the damage level of a vehicle part
        /// </summary>
        /// <param name="part">The part</param>
        /// <returns>The VehiclePart damage level</returns>
        VehiclePartDamage GetPartDamageLevelExt(VehiclePart part) =>
            (VehiclePartDamage) GetPartDamageLevel((byte) part);

        /// <summary>
        /// Get the amount of bullet holes in a part
        /// </summary>
        /// <param name="part">The vehicle part</param>
        /// <returns>Amount of bullet holes</returns>
        byte GetPartBulletHolesExt(VehiclePart part) =>
            GetPartBulletHoles((byte) part);

        /// <summary>
        /// Sets the amount of bullet holes in a vehicles part
        /// </summary>
        /// <param name="part">The part</param>
        /// <param name="shootsCount">The amount of bullets</param>
        void SetPartBulletHolesExt(VehiclePart part, byte shootsCount) =>
            SetPartBulletHoles((byte) part, shootsCount);

        /// <summary>
        /// Gets the vehicles bumper damage level
        /// </summary>
        /// <param name="bumper">The bumper</param>
        /// <returns>Enum of VehicleBumperDamage</returns>
        VehicleBumperDamage GetBumperDamageLevelExt(VehicleBumper bumper) =>
            (VehicleBumperDamage) GetBumperDamageLevel((byte) bumper);

        /// <summary>
        /// Sets the vehicles bumper damage level
        /// </summary>
        /// <param name="bumper">The bumper (Front/Rear)</param>
        /// <param name="damageLevel">The Bumper damage level</param>
        void SetBumperDamageLevelExt(VehicleBumper bumper,
            VehicleBumperDamage damageLevel) => SetBumperDamageLevel((byte) bumper, (byte) damageLevel);

        /// <summary>
        /// Sets the damage level of a vehicle part
        /// </summary>
        /// <param name="part">The vehicle part</param>
        /// <param name="damage">The damage level</param>
        void SetPartDamageLevelExt(VehiclePart part, VehiclePartDamage damage) =>
            SetPartDamageLevel((byte) part, (byte) damage);

        /// <summary>
        /// Returns the current door state of a vehicles door
        /// </summary>
        /// <param name="door">The door</param>
        /// <returns>The door state</returns>
        VehicleDoorState GetDoorStateExt(VehicleDoor door) =>
            (VehicleDoorState) GetDoorState((byte) door);

        /// <summary>
        /// Sets a vehicles door to a state
        /// </summary>
        /// <param name="door">The door</param>
        /// <param name="state">The state</param>
        void SetDoorStateExt(VehicleDoor door, VehicleDoorState state) =>
            SetDoorState((byte) door, (byte) state);

        /// <summary>
        /// Sets the current radio station
        /// </summary>
        /// <param name="radioStation">The radio station</param>
        void SetRadioStationExt(RadioStation radioStation) =>
            RadioStation = (uint) radioStation;

        /// <summary>
        /// Gets the current radio station
        /// </summary>
        /// <returns>The radio station</returns>
        RadioStation GetRadioStationExt() => (RadioStation) RadioStation;

        /// <summary>
        /// Sets the current window tint
        /// </summary>
        /// <param name="windowTint">The window tint</param>
        void SetWindowTintExt(WindowTint windowTint) =>
            WindowTint = (byte) windowTint;

        /// <summary>
        /// Gets the current window tint
        /// </summary>
        /// <returns>The window tint</returns>
        WindowTint GetWindowTintExt() => (WindowTint) WindowTint;

        /// <summary>
        /// Sets the current number plate style
        /// </summary>
        /// <param name="numberPlateStyle">The number plate style</param>
        void SetNumberPlateStyleExt(NumberPlateStyle numberPlateStyle) =>
            NumberplateIndex = (uint) numberPlateStyle;

        /// <summary>
        /// Gets the current number plate style
        /// </summary>
        /// <returns>The number plate style</returns>
        NumberPlateStyle GetNumberPlateStyleExt() =>
            (NumberPlateStyle) NumberplateIndex;

        /// <summary>
        /// Gets the vehicles velocity
        /// </summary>
        Position Velocity { get; }

        /// <summary>
        /// Get or set drift mode of the vehicle
        /// </summary>
        bool DriftMode { get; set; }

        /// <summary>
        /// Get or set boat anchor of the vehicle
        /// </summary>
        bool BoatAnchor { get; set; }

        /// <summary>
        /// Sets the searchlight to given entity
        /// </summary>
        bool SetSearchLight(bool state, IEntity spottedEntity);

        /// <summary>
        /// Gets or sets if the vehicle is a train
        /// </summary>
        bool IsMissionTrain { get; set; }

        /// <summary>
        /// Gets or sets the trains track id
        /// </summary>
        sbyte TrainTrackId { get; set; }

        /// <summary>
        /// Gets or sets the trains engine
        /// </summary>
        IVehicle TrainEngine { get; set; }



        /// <summary>
        /// Gets or sets the trains config index
        /// </summary>
        sbyte TrainConfigIndex { get; set; }

        /// <summary>
        /// Gets or sets the trains distance from the engine
        /// </summary>
        float TrainDistanceFromEngine { get; set; }

        /// <summary>
        /// Gets or sets if the vehicle is the trains engine
        /// </summary>
        bool IsTrainEngine { get; set; }

        /// <summary>
        /// Gets or sets if the vehicle is caboose
        /// </summary>
        bool IsTrainCaboose { get; set; }

        /// <summary>
        /// Gets or sets the trains direction
        /// </summary>
        bool TrainDirection { get; set; }

        /// <summary>
        /// Gets or sets if the train has passenger carriages
        /// </summary>
        bool TrainPassengerCarriages { get; set; }

        /// <summary>
        /// Gets or sets if the train should be rendered derailed
        /// </summary>
        bool TrainRenderDerailed { get; set; }

        /// <summary>
        /// Gets or sets if the trains doors should be forced open
        /// </summary>
        bool TrainForceDoorsOpen { get; set; }

        /// <summary>
        /// Gets or sets the trains cruise speed
        /// </summary>
        float TrainCruiseSpeed { get; set; }

        /// <summary>
        /// Gets or sets the trains carriage config index
        /// </summary>
        sbyte TrainCarriageConfigIndex { get; set; }

        /// <summary>
        /// Gets or sets the trains vehicle linked backward vehicle
        /// </summary>
        IVehicle TrainLinkedToBackward { get; set; }

        /// <summary>
        /// Gets or sets the trains vehicle linked forward vehicle
        /// </summary>
        IVehicle TrainLinkedToForward { get; set; }

        /// <summary>
        /// Gets or sets the vehicle counter measure count
        /// </summary>
        uint CounterMeasureCount { get; set; }

        /// <summary>
        /// Gets or sets the hybrid extra
        /// </summary>
        bool HybridExtraActive { get; set; }

        /// <summary>
        /// Gets or sets the hybrid extra state
        /// </summary>
        byte HybridExtraState { get; set; }

        /// <summary>
        /// Gets or sets the rocket refuel speed
        /// </summary>
        float RocketRefuelSpeed { get; set; }

        /// <summary>
        /// Gets or sets the script max speed
        /// </summary>
        float ScriptMaxSpeed { get; set; }

        /// <summary>
        /// Gets or sets to disable the towing
        /// </summary>
        bool IsTowingDisabled { get; set; }

        /// <summary>
        /// Sets the weapon capacity
        /// </summary>
        /// <param name="index">Index of weapon</param>
        /// <param name="capacity">Capacity to set</param>
        void SetWeaponCapacity(byte index, int capacity);

        /// <summary>
        /// Gets the weapon capacity
        /// </summary>
        /// <param name="index">Index of weapon</param>
        /// <returns></returns>
        int GetWeaponCapacity(byte index);

        Quaternion Quaternion { get; set; }
    }
}