using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncPlayer : AsyncEntity, IPlayer, IAsyncConvertible<IPlayer>
    {
        protected readonly IPlayer Player;
        public IntPtr PlayerNativePointer => Player.PlayerNativePointer;

        public new uint Model
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Model;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.Model = value;
                }
            }
        }

        public bool IsConnected
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsConnected;
                }
            }
        }

        public string Name
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Name;
                }
            }
        }

        public ulong SocialClubId
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.SocialClubId;
                }
            }
        }

        public ulong HardwareIdHash
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.HardwareIdHash;
                }
            }
        }

        public ulong HardwareIdExHash
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.HardwareIdExHash;
                }
            }
        }

        public string AuthToken
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.AuthToken;
                }
            }
        }

        public long DiscordId
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.DiscordId;
                }
            }
        }

        public ushort Health
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Health;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.Health = value;
                }
            }
        }

        public ushort MaxHealth
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.MaxHealth;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.MaxHealth = value;
                }
            }
        }

        public bool IsDead
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsDead;
                }
            }
        }

        public bool IsJumping
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsJumping;
                }
            }
        }

        public bool IsInRagdoll
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsInRagdoll;
                }
            }
        }

        public bool IsAiming
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsAiming;
                }
            }
        }

        public bool IsShooting
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsShooting;
                }
            }
        }

        public bool IsReloading
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsReloading;
                }
            }
        }

        public bool IsEnteringVehicle
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsEnteringVehicle;
                }
            }
        }

        public bool IsLeavingVehicle
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsLeavingVehicle;
                }
            }
        }

        public bool IsOnLadder
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsOnLadder;
                }
            }
        }

        public bool IsInMelee
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsInMelee;
                }
            }
        }

        public bool IsInCover
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsInCover;
                }
            }
        }

        public ushort Armor
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Armor;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.Armor = value;
                }
            }
        }

        public ushort MaxArmor
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.MaxArmor;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.MaxArmor = value;
                }
            }
        }

        public float MoveSpeed
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.MoveSpeed;
                }
            }
        }

        public float ForwardSpeed
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.ForwardSpeed;
                }
            }
        }

        public float StrafeSpeed
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.StrafeSpeed;
                }
            }
        }

        public Position AimPosition
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.AimPosition;
                }
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.HeadRotation;
                }
            }
        }

        public bool IsInVehicle
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsInVehicle;
                }
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return null;
                    return Player.Vehicle;
                }
            }
        }
        ISharedVehicle ISharedPlayer.Vehicle => Vehicle;

        public uint CurrentWeapon
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.CurrentWeapon;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.CurrentWeapon = value;
                }
            }
        }

        public IEntity EntityAimingAt
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return null;
                    return Player.EntityAimingAt;
                }
            }
        }

        public uint InteriorLocation
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.InteriorLocation;
                }
            }
        }

        ISharedEntity ISharedPlayer.EntityAimingAt => EntityAimingAt;

        public Position EntityAimOffset
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.EntityAimOffset;
                }
            }
        }

        public bool IsFlashlightActive
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsFlashlightActive;
                }
            }
        }

        public byte Seat
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Seat;
                }
            }
        }

        public uint Ping
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Ping;
                }
            }
        }

        public string Ip
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Ip;
                }
            }
        }

        public bool IsSpawned
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsSpawned;
                }
            }
        }

        public uint CurrentAnimationDict
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.CurrentAnimationDict;
                }
            }
        }

        public uint CurrentAnimationName
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.CurrentAnimationName;
                }
            }
        }

        public AsyncPlayer(IPlayer player, IAsyncContext asyncContext) : base(player, asyncContext)
        {
            Player = player;
        }

        public AsyncPlayer(ICore core, IntPtr nativePointer, uint id) : this(new Player(core, nativePointer, id), null)
        {
        }

        public void Spawn(Position position, uint delayMs = 0)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.Spawn(position, delayMs);
            }
        }

        public void Despawn()
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.Despawn();
            }
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetDateTime(day, month, year, hour, minute, second);
            }
        }

        public void SetWeather(uint weather)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetWeather(weather);
            }
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.GiveWeapon(weapon, ammo, selectWeapon);
            }
        }

        public bool RemoveWeapon(uint weapon)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return false;
                return Player.RemoveWeapon(weapon);
            }
        }

        public void RemoveAllWeapons()
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.RemoveAllWeapons();
            }
        }

        public void Kick(string reason)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.Kick(reason);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            MValueConstLockedNoRefs.CreateFromObjectsLocked(args, mValues);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            lock (Player)
            {
                if (Player.Exists)
                {
                    Alt.Core.TriggerClientEvent(Player, eventNamePtr, mValues);
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void EmitUnreliable(string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            MValueConstLockedNoRefs.CreateFromObjectsLocked(args, mValues);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            lock (Player)
            {
                if (Player.Exists)
                {
                    Alt.Core.TriggerClientEventUnreliable(Player, eventNamePtr, mValues);
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void AddWeaponComponent(uint weapon, uint weaponComponent)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.AddWeaponComponent(weapon, weaponComponent);
            }
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.RemoveWeaponComponent(weapon, weaponComponent);
            }
        }

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return false;
                return Player.HasWeaponComponent(weapon, weaponComponent);
            }
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player))
                {
                    weaponComponents = Array.Empty<uint>();
                    return;
                }

                Player.GetCurrentWeaponComponents(out weaponComponents);
            }
        }

        public void SetWeaponTintIndex(uint weapon, byte tintIndex)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetWeaponTintIndex(weapon, tintIndex);
            }
        }

        public byte GetWeaponTintIndex(uint weapon)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.GetWeaponTintIndex(weapon);
            }
        }

        public byte GetCurrentWeaponTintIndex()
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.GetCurrentWeaponTintIndex();
            }
        }

        public WeaponData[] GetWeapons()
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.GetWeapons();
            }
        }

        public void ClearBloodDamage()
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.ClearBloodDamage();
            }
        }

        public Cloth GetClothes(byte component)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                return Player.GetClothes(component);
            }
        }

        public void GetClothes(byte component, ref Cloth cloth)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return;
                Player.GetClothes(component, ref cloth);
            }
        }

        public bool SetClothes(byte component, ushort drawable, byte texture, byte palette)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetClothes(component, drawable, texture, palette);
            }
        }

        public DlcCloth GetDlcClothes(byte component)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                return Player.GetDlcClothes(component);
            }
        }

        public void GetDlcClothes(byte component, ref DlcCloth cloth)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return;
                Player.GetDlcClothes(component, ref cloth);
            }
        }

        public bool SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetDlcClothes(component, drawable, texture, palette, dlc);
            }
        }

        public Prop GetProps(byte component)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                return Player.GetProps(component);
            }
        }

        public void GetProps(byte component, ref Prop prop)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return;
                Player.GetProps(component, ref prop);
            }
        }

        public bool SetProps(byte component, ushort drawable, byte texture)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetProps(component, drawable, texture);
            }
        }

        public DlcProp GetDlcProps(byte component)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                return Player.GetDlcProps(component);
            }
        }

        public void GetDlcProps(byte component, ref DlcProp prop)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return;
                Player.GetDlcProps(component, ref prop);
            }
        }

        public bool SetDlcProps(byte component, ushort drawable, byte texture, uint dlc)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetDlcProps(component, drawable, texture, dlc);
            }
        }

        public void ClearProps(byte component)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.ClearProps(component);
            }
        }

        public bool IsEntityInStreamingRange(IEntity entity)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.IsEntityInStreamingRange(entity);
            }
        }

        public bool Invincible
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.Invincible;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.Invincible = value;
                }
            }
        }

        public uint LastDamagedBodyPart
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.LastDamagedBodyPart;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.LastDamagedBodyPart = value;
                }
            }
        }

        public void SetIntoVehicle(IVehicle vehicle, byte seat)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetIntoVehicle(vehicle, seat);
            }
        }

        public bool IsSuperJumpEnabled
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsSuperJumpEnabled;
                }
            }
        }

        public bool IsCrouching
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsCrouching;
                }
            }
        }

        public bool IsStealthy
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.IsStealthy;
                }
            }
        }

        public void PlayAmbientSpeech(string speechName, string speechParam, uint speechHash)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.PlayAmbientSpeech(speechName, speechParam, speechHash);
            }
        }

        public HeadBlendData HeadBlendData
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.HeadBlendData;
                }
            }
        }

        public ushort EyeColor
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.EyeColor;
                }
            }
        }

        public byte HairColor
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.HairColor;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.HairColor = value;
                }
            }
        }

        public byte HairHighlightColor
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.HairHighlightColor;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.HairHighlightColor = value;
                }
            }
        }

        public bool SetHeadOverlay(byte overlayId, byte index, float opacity)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetHeadOverlay(overlayId, index, opacity);
            }
        }

        public bool RemoveHeadOverlay(byte overlayId)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.RemoveHeadOverlay(overlayId);
            }
        }


        public bool SetHeadOverlayColor(byte overlayId, byte colorType, byte colorIndex, byte secondColorIndex)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetHeadOverlayColor(overlayId, colorType, colorIndex, secondColorIndex);
            }
        }

        public HeadOverlay GetHeadOverlay(byte overlayID)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                return Player.GetHeadOverlay(overlayID);
            }
        }

        public bool SetFaceFeature(byte index, float scale)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetFaceFeature(index, scale);
            }
        }

        public float GetFaceFeatureScale(byte index)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                return Player.GetFaceFeatureScale(index);
            }
        }

        public bool RemoveFaceFeature(byte index)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.RemoveFaceFeature(index);
            }
        }

        public bool SetHeadBlendPaletteColor(byte id, Rgba rgba)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetHeadBlendPaletteColor(id, rgba);
            }
        }

        public Rgba GetHeadBlendPaletteColor(byte id)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.GetHeadBlendPaletteColor(id);
            }
        }

        public void SetHeadBlendData(uint shapeFirstID, uint shapeSecondID, uint shapeThirdID, uint skinFirstID,
            uint skinSecondID, uint skinThirdID, float shapeMix, float skinMix, float thirdMix)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetHeadBlendData(shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID,
                    skinThirdID, shapeMix, skinMix, thirdMix);
            }
        }

        public bool SetEyeColor(ushort eyeColor)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.SetEyeColor(eyeColor);
            }
        }

        public void GetLocalMetaData(string key, out MValueConst value)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player))
                {
                    value = default;
                    return;
                }
                Player.GetLocalMetaData(key, out value);
            }
        }

        public void SetLocalMetaData(string key, in MValueConst value)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player))
                {
                    return;
                }
                Player.SetLocalMetaData(key, in value);
            }
        }

        public bool HasLocalMetaData(string key)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return false;
                return Player.HasLocalMetaData(key);
            }
        }

        public void DeleteLocalMetaData(string key)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.DeleteLocalMetaData(key);
            }
        }

        public bool SendNames
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.SendNames;
                }
            }
            set
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                    Player.SendNames = value;
                }
            }
        }

        public void PlayAnimation(string animDict, string animName, float blendInSpeed, float blendOutSpeed, int duration, int flags,
            float playbackRate, bool lockX, bool lockY, bool lockZ)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.PlayAnimation( animDict, animName, blendInSpeed, blendOutSpeed, duration, flags, playbackRate, lockX, lockY, lockZ);
            }
        }

        public void ClearTasks()
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.ClearTasks();
            }
        }

        public string SocialClubName
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.SocialClubName;
                }
            }
        }

        public string CloudAuthHash
        {
            get
            {
                lock (Player)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Player)) return default;
                    return Player.CloudAuthHash;
                }
            }
        }

        public void SetAmmo(uint ammoHash, ushort ammo)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetAmmo(ammoHash, ammo);
            }
        }

        public ushort GetAmmo(uint ammoHash)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.GetAmmo(ammoHash);
            }
        }

        public void SetWeaponAmmo(uint weaponHash, ushort ammo)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return;
                Player.SetWeaponAmmo(weaponHash, ammo);
            }
        }

        public ushort GetWeaponAmmo(uint weaponHash)
        {
            lock (Player)
            {
                if (!AsyncContext.CheckIfExistsNullable(Player)) return default;
                return Player.GetWeaponAmmo(weaponHash);
            }
        }

        [Obsolete("Use new async API instead")]
        public IPlayer ToAsync(IAsyncContext asyncContext)
        {
            return this;
        }
    }
}