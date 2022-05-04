using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class HandlingData
    {
        private readonly ICore core;
        private readonly IntPtr nativePointer;

        internal HandlingData(ICore core, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
        }

        public uint HandlingNameHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetHandlingNameHash(nativePointer);
                }
            }
        }

        public float Mass
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetMass(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetMass(nativePointer, value);
                }
            }
        }

        public float InitialDragCoeff
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDragCoeff(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetInitialDragCoeff(nativePointer, value);
                }
            }
        }

        public float DownforceModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDownforceModifier(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetDownforceModifier(nativePointer, value);
                }
            }
        }

        public float unkFloat1
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat1(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetunkFloat1(nativePointer, value);
                }
            }
        }

        public float unkFloat2
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat2(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetunkFloat2(nativePointer, value);
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
                    core.Library.Client.Vehicle_Handling_GetCentreOfMassOffset(nativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetCentreOfMassOffset(nativePointer, value);
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
                    core.Library.Client.Vehicle_Handling_GetInertiaMultiplier(nativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetInertiaMultiplier(nativePointer, value);
                }
            }
        }

        public float PercentSubmerged
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetPercentSubmerged(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetPercentSubmerged(nativePointer, value);
                }
            }
        }

        public float PercentSubmergedRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetPercentSubmergedRatio(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetPercentSubmergedRatio(nativePointer, value);
                }
            }
        }

        public float DriveBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDriveBiasFront(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetDriveBiasFront(nativePointer, value);
                }
            }
        }

        public float Acceleration
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAcceleration(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetAcceleration(nativePointer, value);
                }
            }
        }

        public uint InitialDriveGears
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDriveGears(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetInitialDriveGears(nativePointer, value);
                }
            }
        }

        public float DriveInertia
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDriveInertia(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetDriveInertia(nativePointer, value);
                }
            }
        }

        public float ClutchChangeRateScaleUpShift
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetClutchChangeRateScaleUpShift(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetClutchChangeRateScaleUpShift(nativePointer, value);
                }
            }
        }

        public float ClutchChangeRateScaleDownShift
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetClutchChangeRateScaleDownShift(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetClutchChangeRateScaleDownShift(nativePointer, value);
                }
            }
        }

        public float InitialDriveForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDriveForce(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetInitialDriveForce(nativePointer, value);
                }
            }
        }

        public float DriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDriveMaxFlatVel(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetDriveMaxFlatVel(nativePointer, value);
                }
            }
        }

        public float InitialDriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDriveMaxFlatVel(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetInitialDriveMaxFlatVel(nativePointer, value);
                }
            }
        }

        public float BrakeForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetBrakeForce(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetBrakeForce(nativePointer, value);
                }
            }
        }

        public float unkFloat4
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat4(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetunkFloat4(nativePointer, value);
                }
            }
        }

        public float BrakeBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetBrakeBiasFront(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetBrakeBiasFront(nativePointer, value);
                }
            }
        }

        public float BrakeBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetBrakeBiasRear(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetBrakeBiasRear(nativePointer, value);
                }
            }
        }

        public float HandBrakeForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetHandBrakeForce(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetHandBrakeForce(nativePointer, value);
                }
            }
        }

        public float SteeringLock
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSteeringLock(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSteeringLock(nativePointer, value);
                }
            }
        }

        public float SteeringLockRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSteeringLockRatio(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSteeringLockRatio(nativePointer, value);
                }
            }
        }

        public float TractionCurveMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMax(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMax(nativePointer, value);
                }
            }
        }

        public float TractionCurveMaxRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMaxRatio(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMaxRatio(nativePointer, value);
                }
            }
        }

        public float TractionCurveMin
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMin(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMin(nativePointer, value);
                }
            }
        }

        public float TractionCurveMinRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMinRatio(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMinRatio(nativePointer, value);
                }
            }
        }

        public float TractionCurveLateral
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveLateral(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionCurveLateral(nativePointer, value);
                }
            }
        }

        public float TractionCurveLateralRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveLateralRatio(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionCurveLateralRatio(nativePointer, value);
                }
            }
        }

        public float TractionSpringDeltaMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionSpringDeltaMax(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionSpringDeltaMax(nativePointer, value);
                }
            }
        }

        public float TractionSpringDeltaMaxRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionSpringDeltaMaxRatio(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionSpringDeltaMaxRatio(nativePointer, value);
                }
            }
        }

        public float LowSpeedTractionLossMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetLowSpeedTractionLossMult(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetLowSpeedTractionLossMult(nativePointer, value);
                }
            }
        }

        public float CamberStiffness
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetCamberStiffness(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetCamberStiffness(nativePointer, value);
                }
            }
        }

        public float TractionBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionBiasFront(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionBiasFront(nativePointer, value);
                }
            }
        }

        public float TractionBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionBiasRear(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionBiasRear(nativePointer, value);
                }
            }
        }

        public float TractionLossMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionLossMult(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetTractionLossMult(nativePointer, value);
                }
            }
        }

        public float SuspensionForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionForce(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionForce(nativePointer, value);
                }
            }
        }

        public float SuspensionCompDamp
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionCompDamp(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionCompDamp(nativePointer, value);
                }
            }
        }

        public float SuspensionReboundDamp
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionReboundDamp(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionReboundDamp(nativePointer, value);
                }
            }
        }

        public float SuspensionUpperLimit
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionUpperLimit(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionUpperLimit(nativePointer, value);
                }
            }
        }

        public float SuspensionLowerLimit
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionLowerLimit(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionLowerLimit(nativePointer, value);
                }
            }
        }

        public float SuspensionRaise
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionRaise(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionRaise(nativePointer, value);
                }
            }
        }

        public float SuspensionBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionBiasFront(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionBiasFront(nativePointer, value);
                }
            }
        }

        public float SuspensionBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionBiasRear(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSuspensionBiasRear(nativePointer, value);
                }
            }
        }

        public float AntiRollBarForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAntiRollBarForce(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetAntiRollBarForce(nativePointer, value);
                }
            }
        }

        public float AntiRollBarBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAntiRollBarBiasFront(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetAntiRollBarBiasFront(nativePointer, value);
                }
            }
        }

        public float AntiRollBarBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAntiRollBarBiasRear(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetAntiRollBarBiasRear(nativePointer, value);
                }
            }
        }

        public float RollCentreHeightFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetRollCentreHeightFront(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetRollCentreHeightFront(nativePointer, value);
                }
            }
        }

        public float RollCentreHeightRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetRollCentreHeightRear(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetRollCentreHeightRear(nativePointer, value);
                }
            }
        }

        public float CollisionDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetCollisionDamageMult(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetCollisionDamageMult(nativePointer, value);
                }
            }
        }

        public float WeaponDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetWeaponDamageMult(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetWeaponDamageMult(nativePointer, value);
                }
            }
        }

        public float DeformationDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDeformationDamageMult(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetDeformationDamageMult(nativePointer, value);
                }
            }
        }

        public float EngineDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetEngineDamageMult(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetEngineDamageMult(nativePointer, value);
                }
            }
        }

        public float PetrolTankVolume
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetPetrolTankVolume(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetPetrolTankVolume(nativePointer, value);
                }
            }
        }

        public float OilVolume
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetOilVolume(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetOilVolume(nativePointer, value);
                }
            }
        }

        public float unkFloat5
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat5(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetunkFloat5(nativePointer, value);
                }
            }
        }

        public float SeatOffsetDistX
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistX(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSeatOffsetDistX(nativePointer, value);
                }
            }
        }

        public float SeatOffsetDistY
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistY(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSeatOffsetDistY(nativePointer, value);
                }
            }
        }

        public float SeatOffsetDistZ
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistZ(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetSeatOffsetDistZ(nativePointer, value);
                }
            }
        }

        public uint MonetaryValue
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetMonetaryValue(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetMonetaryValue(nativePointer, value);
                }
            }
        }

        public uint ModelFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetModelFlags(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetModelFlags(nativePointer, value);
                }
            }
        }

        public uint HandlingFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetHandlingFlags(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetHandlingFlags(nativePointer, value);
                }
            }
        }

        public uint DamageFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDamageFlags(nativePointer);
                }
            }
            set
            {
                unsafe
                {
                    BeforeModified();
                    core.Library.Client.Vehicle_Handling_SetDamageFlags(nativePointer, value);
                }
            }
        }

        protected virtual void BeforeModified()
        {
        }
    }
}