using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class HandlingData
    {
        private ICore _core;
        private IntPtr _nativePointer;

        internal HandlingData(ICore core, IntPtr nativePointer)
        {
            _core = core;
            _nativePointer = nativePointer;
        }

        public uint HandlingNameHash
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetHandlingNameHash(_nativePointer);
                }
            }
        }

        public float Mass
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetMass(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetMass(_nativePointer, value);
                }
            }
        }

        public float InitialDragCoeff
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetInitialDragCoeff(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetInitialDragCoeff(_nativePointer, value);
                }
            }
        }

        public float DownforceModifier
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetDownforceModifier(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetDownforceModifier(_nativePointer, value);
                }
            }
        }

        public float unkFloat1
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetunkFloat1(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetunkFloat1(_nativePointer, value);
                }
            }
        }

        public float unkFloat2
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetunkFloat2(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetunkFloat2(_nativePointer, value);
                }
            }
        }

        public Vector3 CentreOfMassOffset
        {
            get
            {
                unsafe
                {
                    var vector = Vector3.Zero;
                    BeforeModified();
                    _core.Library.Vehicle_Handling_GetCentreOfMassOffset(_nativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetCentreOfMassOffset(_nativePointer, value);
                }
            }
        }

        public Vector3 InertiaMultiplier
        {
            get
            {
                unsafe
                {
                    var vector = Vector3.Zero;
                    BeforeModified();
                    _core.Library.Vehicle_Handling_GetInertiaMultiplier(_nativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetInertiaMultiplier(_nativePointer, value);
                }
            }
        }

        public float PercentSubmerged
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetPercentSubmerged(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetPercentSubmerged(_nativePointer, value);
                }
            }
        }

        public float PercentSubmergedRatio
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetPercentSubmergedRatio(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetPercentSubmergedRatio(_nativePointer, value);
                }
            }
        }

        public float DriveBiasFront
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetDriveBiasFront(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetDriveBiasFront(_nativePointer, value);
                }
            }
        }

        public float Acceleration
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetAcceleration(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetAcceleration(_nativePointer, value);
                }
            }
        }

        public uint InitialDriveGears
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetInitialDriveGears(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetInitialDriveGears(_nativePointer, value);
                }
            }
        }

        public float DriveInertia
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetDriveInertia(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetDriveInertia(_nativePointer, value);
                }
            }
        }

        public float ClutchChangeRateScaleUpShift
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetClutchChangeRateScaleUpShift(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetClutchChangeRateScaleUpShift(_nativePointer, value);
                }
            }
        }

        public float ClutchChangeRateScaleDownShift
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetClutchChangeRateScaleDownShift(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetClutchChangeRateScaleDownShift(_nativePointer, value);
                }
            }
        }

        public float InitialDriveForce
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetInitialDriveForce(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetInitialDriveForce(_nativePointer, value);
                }
            }
        }

        public float DriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetDriveMaxFlatVel(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetDriveMaxFlatVel(_nativePointer, value);
                }
            }
        }

        public float InitialDriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetInitialDriveMaxFlatVel(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetInitialDriveMaxFlatVel(_nativePointer, value);
                }
            }
        }

        public float BrakeForce
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetBrakeForce(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetBrakeForce(_nativePointer, value);
                }
            }
        }

        public float unkFloat4
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetunkFloat4(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetunkFloat4(_nativePointer, value);
                }
            }
        }

        public float BrakeBiasFront
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetBrakeBiasFront(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetBrakeBiasFront(_nativePointer, value);
                }
            }
        }

        public float BrakeBiasRear
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetBrakeBiasRear(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetBrakeBiasRear(_nativePointer, value);
                }
            }
        }

        public float HandBrakeForce
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetHandBrakeForce(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetHandBrakeForce(_nativePointer, value);
                }
            }
        }

        public float SteeringLock
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSteeringLock(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSteeringLock(_nativePointer, value);
                }
            }
        }

        public float SteeringLockRatio
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSteeringLockRatio(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSteeringLockRatio(_nativePointer, value);
                }
            }
        }

        public float TractionCurveMax
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionCurveMax(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionCurveMax(_nativePointer, value);
                }
            }
        }

        public float TractionCurveMaxRatio
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionCurveMaxRatio(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionCurveMaxRatio(_nativePointer, value);
                }
            }
        }

        public float TractionCurveMin
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionCurveMin(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionCurveMin(_nativePointer, value);
                }
            }
        }

        public float TractionCurveMinRatio
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionCurveMinRatio(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionCurveMinRatio(_nativePointer, value);
                }
            }
        }

        public float TractionCurveLateral
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionCurveLateral(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionCurveLateral(_nativePointer, value);
                }
            }
        }

        public float TractionCurveLateralRatio
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionCurveLateralRatio(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionCurveLateralRatio(_nativePointer, value);
                }
            }
        }

        public float TractionSpringDeltaMax
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionSpringDeltaMax(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionSpringDeltaMax(_nativePointer, value);
                }
            }
        }

        public float TractionSpringDeltaMaxRatio
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionSpringDeltaMaxRatio(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionSpringDeltaMaxRatio(_nativePointer, value);
                }
            }
        }

        public float LowSpeedTractionLossMult
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetLowSpeedTractionLossMult(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetLowSpeedTractionLossMult(_nativePointer, value);
                }
            }
        }

        public float CamberStiffness
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetCamberStiffness(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetCamberStiffness(_nativePointer, value);
                }
            }
        }

        public float TractionBiasFront
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionBiasFront(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionBiasFront(_nativePointer, value);
                }
            }
        }

        public float TractionBiasRear
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionBiasRear(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionBiasRear(_nativePointer, value);
                }
            }
        }

        public float TractionLossMult
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetTractionLossMult(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetTractionLossMult(_nativePointer, value);
                }
            }
        }

        public float SuspensionForce
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionForce(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionForce(_nativePointer, value);
                }
            }
        }

        public float SuspensionCompDamp
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionCompDamp(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionCompDamp(_nativePointer, value);
                }
            }
        }

        public float SuspensionReboundDamp
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionReboundDamp(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionReboundDamp(_nativePointer, value);
                }
            }
        }

        public float SuspensionUpperLimit
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionUpperLimit(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionUpperLimit(_nativePointer, value);
                }
            }
        }

        public float SuspensionLowerLimit
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionLowerLimit(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionLowerLimit(_nativePointer, value);
                }
            }
        }

        public float SuspensionRaise
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionRaise(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionRaise(_nativePointer, value);
                }
            }
        }

        public float SuspensionBiasFront
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionBiasFront(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionBiasFront(_nativePointer, value);
                }
            }
        }

        public float SuspensionBiasRear
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSuspensionBiasRear(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSuspensionBiasRear(_nativePointer, value);
                }
            }
        }

        public float AntiRollBarForce
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetAntiRollBarForce(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetAntiRollBarForce(_nativePointer, value);
                }
            }
        }

        public float AntiRollBarBiasFront
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetAntiRollBarBiasFront(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetAntiRollBarBiasFront(_nativePointer, value);
                }
            }
        }

        public float AntiRollBarBiasRear
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetAntiRollBarBiasRear(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetAntiRollBarBiasRear(_nativePointer, value);
                }
            }
        }

        public float RollCentreHeightFront
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetRollCentreHeightFront(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetRollCentreHeightFront(_nativePointer, value);
                }
            }
        }

        public float RollCentreHeightRear
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetRollCentreHeightRear(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetRollCentreHeightRear(_nativePointer, value);
                }
            }
        }

        public float CollisionDamageMult
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetCollisionDamageMult(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetCollisionDamageMult(_nativePointer, value);
                }
            }
        }

        public float WeaponDamageMult
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetWeaponDamageMult(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetWeaponDamageMult(_nativePointer, value);
                }
            }
        }

        public float DeformationDamageMult
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetDeformationDamageMult(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetDeformationDamageMult(_nativePointer, value);
                }
            }
        }

        public float EngineDamageMult
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetEngineDamageMult(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetEngineDamageMult(_nativePointer, value);
                }
            }
        }

        public float PetrolTankVolume
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetPetrolTankVolume(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetPetrolTankVolume(_nativePointer, value);
                }
            }
        }

        public float OilVolume
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetOilVolume(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetOilVolume(_nativePointer, value);
                }
            }
        }

        public float unkFloat5
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetunkFloat5(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetunkFloat5(_nativePointer, value);
                }
            }
        }

        public float SeatOffsetDistX
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSeatOffsetDistX(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSeatOffsetDistX(_nativePointer, value);
                }
            }
        }

        public float SeatOffsetDistY
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSeatOffsetDistY(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSeatOffsetDistY(_nativePointer, value);
                }
            }
        }

        public float SeatOffsetDistZ
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetSeatOffsetDistZ(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetSeatOffsetDistZ(_nativePointer, value);
                }
            }
        }

        public uint MonetaryValue
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetMonetaryValue(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetMonetaryValue(_nativePointer, value);
                }
            }
        }

        public uint ModelFlags
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetModelFlags(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetModelFlags(_nativePointer, value);
                }
            }
        }

        public uint HandlingFlags
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetHandlingFlags(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetHandlingFlags(_nativePointer, value);
                }
            }
        }

        public uint DamageFlags
        {
            get
            {
                unsafe
                {
                    return _core.Library.Vehicle_Handling_GetDamageFlags(_nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    _core.Library.Vehicle_Handling_SetDamageFlags(_nativePointer, value);
                }
            }
        }

        protected virtual void BeforeModified()
        {
        }
    }
}