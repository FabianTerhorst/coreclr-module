using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class Handling : IHandlingData
    {
        private readonly ICore core;
        private readonly IntPtr vehiclePointer;

        internal Handling(ICore core, IntPtr vehiclePointer)
        {
            this.core = core;
            this.vehiclePointer = vehiclePointer;
        }

        public void ResetHandling()
        {
            unsafe
            {
                core.Library.Client.Vehicle_ResetHandling(vehiclePointer);
            }
        }

        public bool IsHandlingModified
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_IsHandlingModified(vehiclePointer) == 1;
                }
            }
        }


        public uint HandlingNameHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetHandlingNameHash(vehiclePointer);
                }
            }
        }

        public float Mass
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetMass(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetMass(vehiclePointer, value);
                }
            }
        }

        public float InitialDragCoeff
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDragCoeff(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetInitialDragCoeff(vehiclePointer, value);
                }
            }
        }

        public float DownforceModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDownforceModifier(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetDownforceModifier(vehiclePointer, value);
                }
            }
        }

        public float unkFloat1
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat1(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetunkFloat1(vehiclePointer, value);
                }
            }
        }

        public float unkFloat2
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat2(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetunkFloat2(vehiclePointer, value);
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
                    core.Library.Client.Vehicle_Handling_GetCentreOfMassOffset(vehiclePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetCentreOfMassOffset(vehiclePointer, value);
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
                    core.Library.Client.Vehicle_Handling_GetInertiaMultiplier(vehiclePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetInertiaMultiplier(vehiclePointer, value);
                }
            }
        }

        public float PercentSubmerged
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetPercentSubmerged(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetPercentSubmerged(vehiclePointer, value);
                }
            }
        }

        public float PercentSubmergedRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetPercentSubmergedRatio(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetPercentSubmergedRatio(vehiclePointer, value);
                }
            }
        }

        public float DriveBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDriveBiasFront(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetDriveBiasFront(vehiclePointer, value);
                }
            }
        }

        public float Acceleration
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAcceleration(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetAcceleration(vehiclePointer, value);
                }
            }
        }

        public uint InitialDriveGears
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDriveGears(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetInitialDriveGears(vehiclePointer, value);
                }
            }
        }

        public float DriveInertia
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDriveInertia(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetDriveInertia(vehiclePointer, value);
                }
            }
        }

        public float ClutchChangeRateScaleUpShift
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetClutchChangeRateScaleUpShift(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetClutchChangeRateScaleUpShift(vehiclePointer, value);
                }
            }
        }

        public float ClutchChangeRateScaleDownShift
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetClutchChangeRateScaleDownShift(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetClutchChangeRateScaleDownShift(vehiclePointer, value);
                }
            }
        }

        public float InitialDriveForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDriveForce(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetInitialDriveForce(vehiclePointer, value);
                }
            }
        }

        public float DriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDriveMaxFlatVel(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetDriveMaxFlatVel(vehiclePointer, value);
                }
            }
        }

        public float InitialDriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetInitialDriveMaxFlatVel(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetInitialDriveMaxFlatVel(vehiclePointer, value);
                }
            }
        }

        public float BrakeForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetBrakeForce(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetBrakeForce(vehiclePointer, value);
                }
            }
        }

        public float unkFloat4
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat4(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetunkFloat4(vehiclePointer, value);
                }
            }
        }

        public float BrakeBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetBrakeBiasFront(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetBrakeBiasFront(vehiclePointer, value);
                }
            }
        }

        public float BrakeBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetBrakeBiasRear(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetBrakeBiasRear(vehiclePointer, value);
                }
            }
        }

        public float HandBrakeForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetHandBrakeForce(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetHandBrakeForce(vehiclePointer, value);
                }
            }
        }

        public float SteeringLock
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSteeringLock(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSteeringLock(vehiclePointer, value);
                }
            }
        }

        public float SteeringLockRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSteeringLockRatio(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSteeringLockRatio(vehiclePointer, value);
                }
            }
        }

        public float TractionCurveMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMax(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMax(vehiclePointer, value);
                }
            }
        }

        public float TractionCurveMaxRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMaxRatio(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMaxRatio(vehiclePointer, value);
                }
            }
        }

        public float TractionCurveMin
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMin(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMin(vehiclePointer, value);
                }
            }
        }

        public float TractionCurveMinRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveMinRatio(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionCurveMinRatio(vehiclePointer, value);
                }
            }
        }

        public float TractionCurveLateral
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveLateral(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionCurveLateral(vehiclePointer, value);
                }
            }
        }

        public float TractionCurveLateralRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionCurveLateralRatio(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionCurveLateralRatio(vehiclePointer, value);
                }
            }
        }

        public float TractionSpringDeltaMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionSpringDeltaMax(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionSpringDeltaMax(vehiclePointer, value);
                }
            }
        }

        public float TractionSpringDeltaMaxRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionSpringDeltaMaxRatio(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionSpringDeltaMaxRatio(vehiclePointer, value);
                }
            }
        }

        public float LowSpeedTractionLossMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetLowSpeedTractionLossMult(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetLowSpeedTractionLossMult(vehiclePointer, value);
                }
            }
        }

        public float CamberStiffness
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetCamberStiffness(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetCamberStiffness(vehiclePointer, value);
                }
            }
        }

        public float TractionBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionBiasFront(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionBiasFront(vehiclePointer, value);
                }
            }
        }

        public float TractionBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionBiasRear(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionBiasRear(vehiclePointer, value);
                }
            }
        }

        public float TractionLossMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetTractionLossMult(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetTractionLossMult(vehiclePointer, value);
                }
            }
        }

        public float SuspensionForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionForce(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionForce(vehiclePointer, value);
                }
            }
        }

        public float SuspensionCompDamp
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionCompDamp(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionCompDamp(vehiclePointer, value);
                }
            }
        }

        public float SuspensionReboundDamp
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionReboundDamp(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionReboundDamp(vehiclePointer, value);
                }
            }
        }

        public float SuspensionUpperLimit
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionUpperLimit(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionUpperLimit(vehiclePointer, value);
                }
            }
        }

        public float SuspensionLowerLimit
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionLowerLimit(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionLowerLimit(vehiclePointer, value);
                }
            }
        }

        public float SuspensionRaise
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionRaise(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionRaise(vehiclePointer, value);
                }
            }
        }

        public float SuspensionBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionBiasFront(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionBiasFront(vehiclePointer, value);
                }
            }
        }

        public float SuspensionBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSuspensionBiasRear(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSuspensionBiasRear(vehiclePointer, value);
                }
            }
        }

        public float AntiRollBarForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAntiRollBarForce(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetAntiRollBarForce(vehiclePointer, value);
                }
            }
        }

        public float AntiRollBarBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAntiRollBarBiasFront(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetAntiRollBarBiasFront(vehiclePointer, value);
                }
            }
        }

        public float AntiRollBarBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetAntiRollBarBiasRear(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetAntiRollBarBiasRear(vehiclePointer, value);
                }
            }
        }

        public float RollCentreHeightFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetRollCentreHeightFront(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetRollCentreHeightFront(vehiclePointer, value);
                }
            }
        }

        public float RollCentreHeightRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetRollCentreHeightRear(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetRollCentreHeightRear(vehiclePointer, value);
                }
            }
        }

        public float CollisionDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetCollisionDamageMult(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetCollisionDamageMult(vehiclePointer, value);
                }
            }
        }

        public float WeaponDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetWeaponDamageMult(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetWeaponDamageMult(vehiclePointer, value);
                }
            }
        }

        public float DeformationDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDeformationDamageMult(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetDeformationDamageMult(vehiclePointer, value);
                }
            }
        }

        public float EngineDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetEngineDamageMult(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetEngineDamageMult(vehiclePointer, value);
                }
            }
        }

        public float PetrolTankVolume
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetPetrolTankVolume(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetPetrolTankVolume(vehiclePointer, value);
                }
            }
        }

        public float OilVolume
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetOilVolume(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetOilVolume(vehiclePointer, value);
                }
            }
        }

        public float unkFloat5
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetunkFloat5(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetunkFloat5(vehiclePointer, value);
                }
            }
        }

        public float SeatOffsetDistX
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistX(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSeatOffsetDistX(vehiclePointer, value);
                }
            }
        }

        public float SeatOffsetDistY
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistY(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSeatOffsetDistY(vehiclePointer, value);
                }
            }
        }

        public float SeatOffsetDistZ
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistZ(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetSeatOffsetDistZ(vehiclePointer, value);
                }
            }
        }

        public uint MonetaryValue
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetMonetaryValue(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetMonetaryValue(vehiclePointer, value);
                }
            }
        }

        public uint ModelFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetModelFlags(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetModelFlags(vehiclePointer, value);
                }
            }
        }

        public uint HandlingFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetHandlingFlags(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetHandlingFlags(vehiclePointer, value);
                }
            }
        }

        public uint DamageFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_Handling_GetDamageFlags(vehiclePointer);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Vehicle_Handling_SetDamageFlags(vehiclePointer, value);
                }
            }
        }
    }
}