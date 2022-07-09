using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class WeaponData : IDisposable
    {
        private readonly ICore core;
        private readonly IntPtr nativePointer;

        internal WeaponData(ICore core, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
        }

        public uint NameHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetNameHash(nativePointer);
                }
            }
        }

        public uint ModelHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetModelHash(nativePointer);
                }
            }
        }

        public float RecoilShakeAmplitude
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilShakeAmplitude(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilShakeAmplitude(nativePointer, value);
                }
            }
        }
        
        public float RecoilAccuracyMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilAccuracyMax(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilAccuracyMax(nativePointer, value);
                }
            }
        }
        
        public float RecoilAccuracyToAllowHeadshotPlayer
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer(nativePointer, value);
                }
            }
        }
        
        public float RecoilRecoveryRate
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRecoilRecoveryRate(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRecoilRecoveryRate(nativePointer, value);
                }
            }
        }
        
        public float AnimReloadRate
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetAnimReloadRate(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetAnimReloadRate(nativePointer, value);
                }
            }
        }
        
        public float VehicleReloadTime
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetVehicleReloadTime(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetVehicleReloadTime(nativePointer, value);
                }
            }
        }
        
        public float LockOnRange
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetLockOnRange(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetLockOnRange(nativePointer, value);
                }
            }
        }
        
        public float AccuracySpread
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetAccuracySpread(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetAccuracySpread(nativePointer, value);
                }
            }
        }
        
        public float Range
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetRange(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetRange(nativePointer, value);
                }
            }
        }
        
        public float Damage
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetDamage(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetDamage(nativePointer, value);
                }
            }
        }
        
        public uint ClipSize
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetClipSize(nativePointer);
                }
            }
        }
        
        public float TimeBetweenShots
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetTimeBetweenShots(nativePointer);
                }
            }
        }
        
        public float HeadshotDamageModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetHeadshotDamageModifier(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetHeadshotDamageModifier(nativePointer, value);
                }
            }
        }
        
        public float PlayerDamageModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.WeaponData_GetPlayerDamageModifier(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.WeaponData_SetPlayerDamageModifier(nativePointer, value);
                }
            }
        }

        public void Dispose()
        {
            unsafe
            {
                core.Library.Client.WeaponData_Dispose(nativePointer);
            }
        }
    }
}