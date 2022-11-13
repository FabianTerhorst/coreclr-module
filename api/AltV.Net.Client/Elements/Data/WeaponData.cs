using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class WeaponData
    {
        private readonly ICore core;
        private readonly uint weaponHash;

        internal WeaponData(ICore core, uint weaponHash)
        {
            this.core = core;
            this.weaponHash = weaponHash;
        }

        public uint NameHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetNameHash(weaponHash);
                }
            }
        }

        public uint ModelHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetModelHash(weaponHash);
                }
            }
        }

        public float RecoilShakeAmplitude
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilShakeAmplitude(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilShakeAmplitude(weaponHash, value);
                }
            }
        }

        public float RecoilAccuracyMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilAccuracyMax(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilAccuracyMax(weaponHash, value);
                }
            }
        }

        public float RecoilAccuracyToAllowHeadshotPlayer
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer(weaponHash, value);
                }
            }
        }

        public float RecoilRecoveryRate
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilRecoveryRate(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilRecoveryRate(weaponHash, value);
                }
            }
        }

        public float AnimReloadRate
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetAnimReloadRate(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetAnimReloadRate(weaponHash, value);
                }
            }
        }

        public float VehicleReloadTime
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetVehicleReloadTime(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetVehicleReloadTime(weaponHash, value);
                }
            }
        }

        public float LockOnRange
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetLockOnRange(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetLockOnRange(weaponHash, value);
                }
            }
        }

        public float AccuracySpread
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetAccuracySpread(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetAccuracySpread(weaponHash, value);
                }
            }
        }

        public float Range
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRange(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRange(weaponHash, value);
                }
            }
        }

        public float Damage
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetDamage(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetDamage(weaponHash, value);
                }
            }
        }

        public uint ClipSize
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetClipSize(weaponHash);
                }
            }
        }

        public float TimeBetweenShots
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetTimeBetweenShots(weaponHash);
                }
            }
        }

        public float HeadshotDamageModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetHeadshotDamageModifier(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetHeadshotDamageModifier(weaponHash, value);
                }
            }
        }

        public float PlayerDamageModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetPlayerDamageModifier(weaponHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetPlayerDamageModifier(weaponHash, value);
                }
            }
        }
    }
}