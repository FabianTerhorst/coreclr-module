using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Enums;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : ISharedPlayer, IEntity
    {
        /// <summary>
        /// Returns the current vehicle. Null if not in a vehicle
        /// </summary>
        new IVehicle Vehicle { get; }

        /// <summary>
        /// The players model / skin
        /// </summary>
        new uint Model { get; set; }

        /// <summary>
        /// Returns true if player is connected - false if not connected
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Returns the players Social Club ID
        /// </summary>
        ulong SocialClubId { get; }

        /// <summary>
        /// Returns the players Hardware ID Hash
        /// </summary>
        ulong HardwareIdHash { get; }

        ulong HardwareIdExHash { get; }

        string AuthToken { get; }

        long DiscordId { get; }

        /// <summary>
        /// Gets and Sets the players health
        /// </summary>
        new ushort Health { get; set; }

        /// <summary>
        /// Gets and Sets the players max health
        /// </summary>
        new ushort MaxHealth { get; set; }

        /// <summary>
        /// Returns if the player is jumping. True = player jumping
        /// </summary>
        bool IsJumping { get; }

        /// <summary>
        /// Returns if the player is firing.
        /// </summary>
        bool IsShooting { get; }

        /// <summary>
        /// Sets and returns the players current armor
        /// </summary>
        new ushort Armor { get; set; }

        /// <summary>
        /// Sets and returns the max armor for the player
        /// </summary>
        new ushort MaxArmor { get; set; }

        /// <summary>
        /// Returns the current weapon the player has equipped
        /// </summary>
        new uint CurrentWeapon { get; set; }

        /// <summary>
        /// Returns the IEntity object if the player is aiming at
        /// </summary>
        new IEntity EntityAimingAt { get; }

        /// <summary>
        /// Returns the current ping of the player
        /// </summary>
        uint Ping { get; }

        /// <summary>
        /// Returns the IP of the player
        /// </summary>
        string Ip { get; }

        uint InteriorLocation { get; }

        /// <summary>
        /// Spawns a player at the designated position with a optional delay in milliseconds
        /// </summary>
        /// <param name="position">position</param>
        /// <param name="delayMs">delay in milliseconds until player is spawned</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void Spawn(Position position, uint delayMs = 0);

        /// <summary>
        /// Despawns a player
        /// </summary>
        void Despawn();

        /// <summary>
        /// Sets the current date and time for a player
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        void SetDateTime(int day, int month, int year, int hour,
            int minute, int second);

        void SetDateTime(DateTime dateTime);

        /// <summary>
        /// Sets the current weather for the player
        /// </summary>
        /// <param name="weather"></param>
        void SetWeather(uint weather);

        void SetWeather(WeatherType weatherType);

        /// <summary>
        /// Gives the player a weapon, ammo and if it is active
        /// </summary>
        /// <param name="weapon">weapon hash</param>
        /// <param name="ammo">ammo count</param>
        /// <param name="selectWeapon">True - Places into hand</param>
        void GiveWeapon(uint weapon, int ammo, bool selectWeapon);

        void GiveWeapon(WeaponModel weaponModel, int ammo, bool selectWeapon);


        /// <summary>
        /// Removes the weapon by hash
        /// </summary>
        /// <param name="weapon"></param>
        bool RemoveWeapon(uint weapon);

        bool RemoveWeapon(WeaponModel weaponModel);

        /// <summary>
        /// Removes all player weapons
        /// </summary>
        void RemoveAllWeapons(bool removeAllAmmo);

        bool HasWeapon(uint weapon);
        bool HasWeapon(WeaponModel weapon);

        /// <summary>
        /// Kicks the player with reason
        /// </summary>
        /// <param name="reason">Reason why the player is kicked</param>
        void Kick(string reason);

        /// <summary>
        /// Triggers client side event for a player
        /// </summary>
        /// <param name="eventName">Event Trigger</param>
        /// <param name="args">Parameters</param>
        void Emit(string eventName, params object[] args);

        ushort EmitRPC(string name, params object[] args);

        void EmitRPCAnswer(ushort answerId, object answer, string error);

        /// <summary>
        /// Triggers client side event for a player
        /// </summary>
        /// <param name="eventName">Event Trigger</param>
        /// <param name="args">Parameters</param>
        void EmitUnreliable(string eventName, params object[] args);

        /// <summary>
        /// Adds a weapon component to a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="weaponComponent">Weapon Component hash</param>
        void AddWeaponComponent(uint weapon, uint weaponComponent);

        void AddWeaponComponent(WeaponModel weaponModel, uint weaponComponent);

        /// <summary>
        /// Removes a weapon component from a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="weaponComponent">Weapon Component hash</param>
        void RemoveWeaponComponent(uint weapon, uint weaponComponent);

        void RemoveWeaponComponent(WeaponModel weaponModel, uint weaponComponent);

        /// <summary>
        /// Checks if a weapon has a component
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="weaponComponent">Weapon Component hash</param>
        /// <returns></returns>
        bool HasWeaponComponent(uint weapon, uint weaponComponent);
        bool HasWeaponComponent(WeaponModel weapon, uint weaponComponent);

        /// <summary>
        /// Sets the weapon tint to a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="tintIndex">tintIndex</param>
        void SetWeaponTintIndex(uint weapon, byte tintIndex);

        void SetWeaponTintIndex(WeaponModel weaponModel, byte tintIndex);

        /// <summary>
        /// Gets the weapon tint of a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        byte GetWeaponTintIndex(uint weapon);
        byte GetWeaponTintIndex(WeaponModel weapon);

        /// <summary>
        /// Returns weapon tint of current weapon
        /// </summary>
        /// <returns></returns>
        byte GetCurrentWeaponTintIndex();

        /// <summary>
        /// Returns player weapons
        /// </summary>
        /// <returns></returns>
        WeaponData[] GetWeapons();

        /// <summary>
        /// Clears the blood damage of the player
        /// </summary>
        void ClearBloodDamage();

        /// <summary>
        /// Gets the player clothes
        /// </summary>
        Cloth GetClothes(byte component);

        /// <summary>
        /// Gets the player clothes
        /// </summary>
        void GetClothes(byte component, ref Cloth cloth);

        /// <summary>
        /// Sets the player clothes
        /// </summary>
        bool SetClothes(byte component, ushort drawable, byte texture, byte palette);

        /// <summary>
        /// Gets the player dlc clothes
        /// </summary>
        DlcCloth GetDlcClothes(byte component);

        /// <summary>
        /// Gets the player dlc clothes
        /// </summary>
        void GetDlcClothes(byte component, ref DlcCloth cloth);

        /// <summary>
        /// Sets the player dlc clothes
        /// </summary>
        /// <param name="component">Id of the component</param>
        /// <param name="drawable">Drawable id of the component. Can't be higher then 127</param>
        /// <param name="texture">Texture id of the component</param>
        /// <param name="palette">Palette id of the component</param>
        /// <param name="dlc">Hash of the components dlc pack</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if drawable id is higher then 127</exception>
        bool SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc);

        bool ClearClothes(byte component);

        /// <summary>
        /// Gets the player props
        /// </summary>
        Prop GetProps(byte component);

        /// <summary>
        /// Gets the player props
        /// </summary>
        void GetProps(byte component, ref Prop prop);

        /// <summary>
        /// Sets the player props
        /// </summary>
        bool SetProps(byte component, ushort drawable, byte texture);

        /// <summary>
        /// Gets the player dlc props
        /// </summary>
        DlcProp GetDlcProps(byte component);

        /// <summary>
        /// Gets the player dlc props
        /// </summary>
        void GetDlcProps(byte component, ref DlcProp prop);

        /// <summary>
        /// Sets the player dlc props
        /// </summary>
        bool SetDlcProps(byte component, ushort drawable, byte texture, uint dlc);

        /// <summary>
        /// Clear the player props
        /// </summary>
        void ClearProps(byte component);

        /// <summary>
        /// Returns if the entity is in the streaming range of the player
        /// </summary>
        bool IsEntityInStreamingRange(IEntity entity);

        /// <summary>
        /// Get or set if the player is invincible.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool Invincible { get; set; }

        uint LastDamagedBodyPart { get; set; }

        void SetIntoVehicle(IVehicle vehicle, byte seat);

        /// <summary>
        /// Gets if the player has super jump enabled.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsSuperJumpEnabled { get; }

        /// <summary>
        /// Gets if the player is crouching.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsCrouching { get; }

        /// <summary>
        /// Gets if the player is stealthy.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsStealthy { get; }

        /// <summary>
        /// Plays ambient speech
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void PlayAmbientSpeech(string speechName, string speechParam, uint speechHash);

        /// <summary>
        /// Get Head Blend Data
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        HeadBlendData HeadBlendData { get; }

        /// <summary>
        /// Get Eye Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        ushort EyeColor { get; }

        /// <summary>
        /// Get/Set Hair Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        byte HairColor { get; set; }

        /// <summary>
        /// Get/Set Hair Highlight Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        byte HairHighlightColor { get; set; }

        /// <summary>
        /// Set Head Overlay
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool SetHeadOverlay(byte overlayId, byte index, float opacity);

        /// <summary>
        /// Remove Head Overlay
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool RemoveHeadOverlay(byte overlayId);

        /// <summary>
        /// Set Head Overlay Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool SetHeadOverlayColor(byte overlayId, byte colorType, byte colorIndex, byte secondColorIndex);

        /// <summary>
        /// Get Head Overlay
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        HeadOverlay GetHeadOverlay(byte overlayID);

        /// <summary>
        /// Set Face Feature
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool SetFaceFeature(byte index, float scale);

        /// <summary>
        /// Get Face Feature Scale
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        float GetFaceFeatureScale(byte index);

        /// <summary>
        /// Remove Face Feature
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool RemoveFaceFeature(byte index);

        /// <summary>
        /// Set Head Blend Palette Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool SetHeadBlendPaletteColor(byte id, Rgba rgba);

        /// <summary>
        /// Get Head Blend Palette Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        Rgba GetHeadBlendPaletteColor(byte id);

        void RemoveHeadBlendPaletteColor();

        /// <summary>
        /// Set Head Blend Data
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetHeadBlendData(uint shapeFirstID, uint shapeSecondID, uint shapeThirdID, uint skinFirstID, uint skinSecondID, uint skinThirdID, float shapeMix, float skinMix, float thirdMix);

        void RemoveHeadBlendData();

        /// <summary>
        /// Set Eye Color
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool SetEyeColor(ushort eyeColor);

        void GetLocalMetaData(string key, out MValueConst value);
        bool GetLocalMetaData<T>(string key, out T result);
        void SetLocalMetaData(string key, object value);
        void SetLocalMetaData(string key, in MValueConst value);

        bool HasLocalMetaData(string key);

        void DeleteLocalMetaData(string key);

        bool SendNames { get; set; }

        void PlayAnimation(string animDict, string animName, float blendInSpeed, float blendOutSpeed, int duration,
            int flags, float playbackRate, bool lockX, bool lockY, bool lockZ);

        void ClearTasks();

        string SocialClubName { get; }
        void SetAmmo(uint ammoHash, ushort ammo);
        ushort GetAmmo(uint ammoHash);
        void SetWeaponAmmo(uint weaponHash, ushort ammo);
        ushort GetWeaponAmmo(uint weaponHash);

        void SetAmmoSpecialType(uint ammoHash, AmmoSpecialType ammoSpecialType);
        AmmoSpecialType GetAmmoSpecialType(uint ammoHash);

        void SetAmmoFlags(uint ammoHash, AmmoFlags ammoFlags);

        AmmoFlags GetAmmoFlags(uint ammoHash);

        void SetAmmoMax(uint ammoHash, int ammoMax);
        int GetAmmoMax(uint ammoHash);
        void SetAmmoMax50(uint ammoHash, int ammoMax);
        int GetAmmoMax50(uint ammoHash);
        void SetAmmoMax100(uint ammoHash, int ammoMax);
        int GetAmmoMax100(uint ammoHash);

        void AddDecoration(uint collection, uint overlay, byte count = 1);
        void RemoveDecoration(uint collection, uint overlay);
        void ClearDecorations();
        Decoration[] GetDecorations();
        void PlayScenario(string name);
        string CloudId { get; }

        CloudAuthResult CloudAuthResult { get; }

        string BloodDamage { get; set; }

        Vector3 GetForwardVector();
    }
}