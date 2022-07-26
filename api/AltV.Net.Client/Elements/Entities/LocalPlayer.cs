﻿using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using WeaponData = AltV.Net.Client.Elements.Data.WeaponData;

namespace AltV.Net.Client.Elements.Entities
{
    public class LocalPlayer : Player, ILocalPlayer
    {
        private static IntPtr GetPlayerPointer(ICore core, IntPtr localPlayerPointer)
        {
            unsafe
            {
                return core.Library.Client.LocalPlayer_GetPlayer(localPlayerPointer);
            }
        }

        public LocalPlayer(ICore core, IntPtr localPlayerPointer, ushort id) : base(core, GetPlayerPointer(core, localPlayerPointer), id, BaseObjectType.LocalPlayer)
        {
            LocalPlayerNativePointer = localPlayerPointer;
        }

        public IntPtr LocalPlayerNativePointer { get; }

        public override bool IsLocal => true;

        public ushort CurrentAmmo
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.LocalPlayer_GetCurrentAmmo(LocalPlayerNativePointer);
                }
            }
        }

        public ushort GetWeaponAmmo(uint weaponHash)
        {
            unsafe
            {
                return Core.Library.Client.LocalPlayer_GetWeaponAmmo(LocalPlayerNativePointer, weaponHash);
            }
        }

        public WeaponData GetWeaponData()
        {
            unsafe
            {
                var pointer = Core.Library.Client.LocalPlayer_GetCurrentWeaponData(LocalPlayerNativePointer);
                return new WeaponData(Core, pointer);
            }
        }

        public bool HasWeapon(uint weaponHash)
        {
            unsafe
            {
                return Core.Library.Client.LocalPlayer_HasWeapon(LocalPlayerNativePointer, weaponHash) == 1;
            }
        }

        public uint[] Weapons()
        {
            unsafe
            {
                uint size = 0;
                var weaponsPtr = IntPtr.Zero;
                Core.Library.Client.LocalPlayer_GetWeapons(PlayerNativePointer, &weaponsPtr, &size);

                var uintArray = new UIntArray
                {
                    data = weaponsPtr,
                    size = size,
                    capacity = size
                };

                var result = uintArray.ToArray();
                
                Core.Library.Shared.FreeUInt32Array(weaponsPtr);
                return result;
            }
        }

        public uint[] WeaponComponents(uint weaponHash)
        {
            unsafe
            {
                uint size = 0;
                var weaponComponentsPtr = IntPtr.Zero;
                Core.Library.Client.LocalPlayer_GetWeaponComponents(PlayerNativePointer, weaponHash, &weaponComponentsPtr, &size);

                var uintArray = new UIntArray
                {
                    data = weaponComponentsPtr,
                    size = size,
                    capacity = size
                };

                var result = uintArray.ToArray();
                
                Core.Library.Shared.FreeUInt32Array(weaponComponentsPtr);
                return result;
            }
        }
    }
}