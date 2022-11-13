using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class HandlingData : IHandlingData
    {
        private readonly ICore core;
        private readonly uint modelHash;

        internal HandlingData(ICore core, uint modelHash)
        {
            this.core = core;
            this.modelHash = modelHash;
        }

        public uint HandlingNameHash
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetHandlingNameHash(modelHash);
                }
            }
        }

        public float Mass
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetMass(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetMass(modelHash, value);
                }
            }
        }

        public float InitialDragCoeff
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetInitialDragCoeff(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetInitialDragCoeff(modelHash, value);
                }
            }
        }

        public float DownforceModifier
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetDownforceModifier(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetDownforceModifier(modelHash, value);
                }
            }
        }

        public float unkFloat1
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetunkFloat1(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetunkFloat1(modelHash, value);
                }
            }
        }

        public float unkFloat2
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetunkFloat2(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetunkFloat2(modelHash, value);
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
                    core.Library.Client.Handling_GetCentreOfMassOffset(modelHash, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetCentreOfMassOffset(modelHash, value);
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
                    core.Library.Client.Handling_GetInertiaMultiplier(modelHash, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetInertiaMultiplier(modelHash, value);
                }
            }
        }

        public float PercentSubmerged
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetPercentSubmerged(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetPercentSubmerged(modelHash, value);
                }
            }
        }

        public float PercentSubmergedRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetPercentSubmergedRatio(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetPercentSubmergedRatio(modelHash, value);
                }
            }
        }

        public float DriveBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetDriveBiasFront(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetDriveBiasFront(modelHash, value);
                }
            }
        }

        public float Acceleration
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetAcceleration(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetAcceleration(modelHash, value);
                }
            }
        }

        public uint InitialDriveGears
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetInitialDriveGears(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetInitialDriveGears(modelHash, value);
                }
            }
        }

        public float DriveInertia
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetDriveInertia(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetDriveInertia(modelHash, value);
                }
            }
        }

        public float ClutchChangeRateScaleUpShift
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetClutchChangeRateScaleUpShift(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetClutchChangeRateScaleUpShift(modelHash, value);
                }
            }
        }

        public float ClutchChangeRateScaleDownShift
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetClutchChangeRateScaleDownShift(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetClutchChangeRateScaleDownShift(modelHash, value);
                }
            }
        }

        public float InitialDriveForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetInitialDriveForce(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetInitialDriveForce(modelHash, value);
                }
            }
        }

        public float DriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetDriveMaxFlatVel(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetDriveMaxFlatVel(modelHash, value);
                }
            }
        }

        public float InitialDriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetInitialDriveMaxFlatVel(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetInitialDriveMaxFlatVel(modelHash, value);
                }
            }
        }

        public float BrakeForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetBrakeForce(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetBrakeForce(modelHash, value);
                }
            }
        }

        public float unkFloat4
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetunkFloat4(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetunkFloat4(modelHash, value);
                }
            }
        }

        public float BrakeBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetBrakeBiasFront(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetBrakeBiasFront(modelHash, value);
                }
            }
        }

        public float BrakeBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetBrakeBiasRear(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetBrakeBiasRear(modelHash, value);
                }
            }
        }

        public float HandBrakeForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetHandBrakeForce(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetHandBrakeForce(modelHash, value);
                }
            }
        }

        public float SteeringLock
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSteeringLock(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSteeringLock(modelHash, value);
                }
            }
        }

        public float SteeringLockRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSteeringLockRatio(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSteeringLockRatio(modelHash, value);
                }
            }
        }

        public float TractionCurveMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionCurveMax(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionCurveMax(modelHash, value);
                }
            }
        }

        public float TractionCurveMaxRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionCurveMaxRatio(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionCurveMaxRatio(modelHash, value);
                }
            }
        }

        public float TractionCurveMin
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionCurveMin(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionCurveMin(modelHash, value);
                }
            }
        }

        public float TractionCurveMinRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionCurveMinRatio(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionCurveMinRatio(modelHash, value);
                }
            }
        }

        public float TractionCurveLateral
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionCurveLateral(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionCurveLateral(modelHash, value);
                }
            }
        }

        public float TractionCurveLateralRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionCurveLateralRatio(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionCurveLateralRatio(modelHash, value);
                }
            }
        }

        public float TractionSpringDeltaMax
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionSpringDeltaMax(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionSpringDeltaMax(modelHash, value);
                }
            }
        }

        public float TractionSpringDeltaMaxRatio
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionSpringDeltaMaxRatio(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionSpringDeltaMaxRatio(modelHash, value);
                }
            }
        }

        public float LowSpeedTractionLossMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetLowSpeedTractionLossMult(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetLowSpeedTractionLossMult(modelHash, value);
                }
            }
        }

        public float CamberStiffness
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetCamberStiffness(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetCamberStiffness(modelHash, value);
                }
            }
        }

        public float TractionBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionBiasFront(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionBiasFront(modelHash, value);
                }
            }
        }

        public float TractionBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionBiasRear(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionBiasRear(modelHash, value);
                }
            }
        }

        public float TractionLossMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetTractionLossMult(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetTractionLossMult(modelHash, value);
                }
            }
        }

        public float SuspensionForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionForce(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionForce(modelHash, value);
                }
            }
        }

        public float SuspensionCompDamp
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionCompDamp(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionCompDamp(modelHash, value);
                }
            }
        }

        public float SuspensionReboundDamp
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionReboundDamp(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionReboundDamp(modelHash, value);
                }
            }
        }

        public float SuspensionUpperLimit
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionUpperLimit(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionUpperLimit(modelHash, value);
                }
            }
        }

        public float SuspensionLowerLimit
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionLowerLimit(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionLowerLimit(modelHash, value);
                }
            }
        }

        public float SuspensionRaise
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionRaise(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionRaise(modelHash, value);
                }
            }
        }

        public float SuspensionBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionBiasFront(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionBiasFront(modelHash, value);
                }
            }
        }

        public float SuspensionBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSuspensionBiasRear(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSuspensionBiasRear(modelHash, value);
                }
            }
        }

        public float AntiRollBarForce
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetAntiRollBarForce(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetAntiRollBarForce(modelHash, value);
                }
            }
        }

        public float AntiRollBarBiasFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetAntiRollBarBiasFront(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetAntiRollBarBiasFront(modelHash, value);
                }
            }
        }

        public float AntiRollBarBiasRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetAntiRollBarBiasRear(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetAntiRollBarBiasRear(modelHash, value);
                }
            }
        }

        public float RollCentreHeightFront
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetRollCentreHeightFront(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetRollCentreHeightFront(modelHash, value);
                }
            }
        }

        public float RollCentreHeightRear
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetRollCentreHeightRear(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetRollCentreHeightRear(modelHash, value);
                }
            }
        }

        public float CollisionDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetCollisionDamageMult(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetCollisionDamageMult(modelHash, value);
                }
            }
        }

        public float WeaponDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetWeaponDamageMult(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetWeaponDamageMult(modelHash, value);
                }
            }
        }

        public float DeformationDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetDeformationDamageMult(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetDeformationDamageMult(modelHash, value);
                }
            }
        }

        public float EngineDamageMult
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetEngineDamageMult(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetEngineDamageMult(modelHash, value);
                }
            }
        }

        public float PetrolTankVolume
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetPetrolTankVolume(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetPetrolTankVolume(modelHash, value);
                }
            }
        }

        public float OilVolume
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetOilVolume(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetOilVolume(modelHash, value);
                }
            }
        }

        public float unkFloat5
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetunkFloat5(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetunkFloat5(modelHash, value);
                }
            }
        }

        public float SeatOffsetDistX
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSeatOffsetDistX(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSeatOffsetDistX(modelHash, value);
                }
            }
        }

        public float SeatOffsetDistY
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSeatOffsetDistY(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSeatOffsetDistY(modelHash, value);
                }
            }
        }

        public float SeatOffsetDistZ
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetSeatOffsetDistZ(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetSeatOffsetDistZ(modelHash, value);
                }
            }
        }

        public uint MonetaryValue
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetMonetaryValue(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetMonetaryValue(modelHash, value);
                }
            }
        }

        public uint ModelFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetModelFlags(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetModelFlags(modelHash, value);
                }
            }
        }

        public uint HandlingFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetHandlingFlags(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetHandlingFlags(modelHash, value);
                }
            }
        }

        public uint DamageFlags
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Handling_GetDamageFlags(modelHash);
                }
            }
            set
            {
                unsafe
                {
                    core.Library.Client.Handling_SetDamageFlags(modelHash, value);
                }
            }
        }
    }
}