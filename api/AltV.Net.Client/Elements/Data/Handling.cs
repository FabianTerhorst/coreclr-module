using System.Numerics;

namespace AltV.Net.Client.Elements.Data
{
    public class Handling : IHandlingData
    {
        private readonly ICore core;
        private readonly IntPtr vehiclePointer;
        private readonly bool isLocalVehicle;

        internal Handling(ICore core, IntPtr vehiclePointer, bool isLocalVehicle = false)
        {
            this.core = core;
            this.vehiclePointer = vehiclePointer;
            this.isLocalVehicle = isLocalVehicle;
        }

        public void ResetHandling()
        {
            unsafe
            {
                if (isLocalVehicle)
                {
                    core.Library.Client.LocalVehicle_ResetHandling(vehiclePointer);
                }
                else
                {
                    core.Library.Client.Vehicle_ResetHandling(vehiclePointer);
                }
            }
        }

        public bool IsHandlingModified
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_IsHandlingModified(vehiclePointer) == 1;
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_IsHandlingModified(vehiclePointer) == 1;
                    }
                }
            }
        }


        public uint HandlingNameHash
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetHandlingNameHash(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetHandlingNameHash(vehiclePointer);
                    }
                }
            }
        }

        public float Mass
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetMass(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetMass(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetMass(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetMass(vehiclePointer, value);
                    }
                }
            }
        }

        public float InitialDragCoeff
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetInitialDragCoeff(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetInitialDragCoeff(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetInitialDragCoeff(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetInitialDragCoeff(vehiclePointer, value);
                    }
                }
            }
        }

        public float DownforceModifier
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetDownforceModifier(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetDownforceModifier(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetDownforceModifier(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetDownforceModifier(vehiclePointer, value);
                    }
                }
            }
        }

        public float unkFloat1
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetunkFloat1(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetunkFloat1(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetunkFloat1(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetunkFloat1(vehiclePointer, value);
                    }
                }
            }
        }

        public float unkFloat2
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetunkFloat2(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetunkFloat2(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetunkFloat2(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetunkFloat2(vehiclePointer, value);
                    }
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
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_GetCentreOfMassOffset(vehiclePointer, &vector);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_GetCentreOfMassOffset(vehiclePointer, &vector);
                    }

                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetCentreOfMassOffset(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetCentreOfMassOffset(vehiclePointer, value);
                    }
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
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_GetInertiaMultiplier(vehiclePointer, &vector);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_GetInertiaMultiplier(vehiclePointer, &vector);
                    }

                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetInertiaMultiplier(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetInertiaMultiplier(vehiclePointer, value);
                    }
                }
            }
        }

        public float PercentSubmerged
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetPercentSubmerged(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetPercentSubmerged(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetPercentSubmerged(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetPercentSubmerged(vehiclePointer, value);
                    }
                }
            }
        }

        public float PercentSubmergedRatio
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetPercentSubmergedRatio(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetPercentSubmergedRatio(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetPercentSubmergedRatio(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetPercentSubmergedRatio(vehiclePointer, value);
                    }
                }
            }
        }

        public float DriveBiasFront
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetDriveBiasFront(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetDriveBiasFront(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetDriveBiasFront(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetDriveBiasFront(vehiclePointer, value);
                    }
                }
            }
        }

        public float Acceleration
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetAcceleration(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetAcceleration(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetAcceleration(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetAcceleration(vehiclePointer, value);
                    }
                }
            }
        }

        public uint InitialDriveGears
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetInitialDriveGears(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetInitialDriveGears(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetInitialDriveGears(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetInitialDriveGears(vehiclePointer, value);
                    }
                }
            }
        }

        public float DriveInertia
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetDriveInertia(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetDriveInertia(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetDriveInertia(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetDriveInertia(vehiclePointer, value);
                    }
                }
            }
        }

        public float ClutchChangeRateScaleUpShift
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client
                            .LocalVehicle_Handling_GetClutchChangeRateScaleUpShift(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetClutchChangeRateScaleUpShift(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client
                            .LocalVehicle_Handling_SetClutchChangeRateScaleUpShift(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetClutchChangeRateScaleUpShift(vehiclePointer, value);
                    }
                }
            }
        }

        public float ClutchChangeRateScaleDownShift
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetClutchChangeRateScaleDownShift(
                            vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetClutchChangeRateScaleDownShift(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetClutchChangeRateScaleDownShift(vehiclePointer,
                            value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetClutchChangeRateScaleDownShift(vehiclePointer, value);
                    }
                }
            }
        }

        public float InitialDriveForce
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetInitialDriveForce(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetInitialDriveForce(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetInitialDriveForce(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetInitialDriveForce(vehiclePointer, value);
                    }
                }
            }
        }

        public float DriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetDriveMaxFlatVel(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetDriveMaxFlatVel(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetDriveMaxFlatVel(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetDriveMaxFlatVel(vehiclePointer, value);
                    }
                }
            }
        }

        public float InitialDriveMaxFlatVel
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetInitialDriveMaxFlatVel(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetInitialDriveMaxFlatVel(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetInitialDriveMaxFlatVel(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetInitialDriveMaxFlatVel(vehiclePointer, value);
                    }
                }
            }
        }

        public float BrakeForce
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetBrakeForce(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetBrakeForce(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetBrakeForce(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetBrakeForce(vehiclePointer, value);
                    }
                }
            }
        }

        public float unkFloat4
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetunkFloat4(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetunkFloat4(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetunkFloat4(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetunkFloat4(vehiclePointer, value);
                    }
                }
            }
        }

        public float BrakeBiasFront
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetBrakeBiasFront(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetBrakeBiasFront(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetBrakeBiasFront(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetBrakeBiasFront(vehiclePointer, value);
                    }
                }
            }
        }

        public float BrakeBiasRear
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetBrakeBiasRear(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetBrakeBiasRear(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetBrakeBiasRear(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetBrakeBiasRear(vehiclePointer, value);
                    }
                }
            }
        }

        public float HandBrakeForce
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetHandBrakeForce(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetHandBrakeForce(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetHandBrakeForce(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetHandBrakeForce(vehiclePointer, value);
                    }
                }
            }
        }

        public float SteeringLock
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSteeringLock(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSteeringLock(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSteeringLock(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSteeringLock(vehiclePointer, value);
                    }
                }
            }
        }

        public float SteeringLockRatio
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSteeringLockRatio(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSteeringLockRatio(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSteeringLockRatio(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSteeringLockRatio(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionCurveMax
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionCurveMax(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionCurveMax(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionCurveMax(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionCurveMax(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionCurveMaxRatio
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionCurveMaxRatio(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionCurveMaxRatio(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionCurveMaxRatio(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionCurveMaxRatio(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionCurveMin
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionCurveMin(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionCurveMin(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionCurveMin(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionCurveMin(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionCurveMinRatio
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionCurveMinRatio(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionCurveMinRatio(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionCurveMinRatio(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionCurveMinRatio(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionCurveLateral
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionCurveLateral(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionCurveLateral(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionCurveLateral(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionCurveLateral(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionCurveLateralRatio
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionCurveLateralRatio(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionCurveLateralRatio(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionCurveLateralRatio(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionCurveLateralRatio(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionSpringDeltaMax
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionSpringDeltaMax(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionSpringDeltaMax(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionSpringDeltaMax(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionSpringDeltaMax(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionSpringDeltaMaxRatio
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionSpringDeltaMaxRatio(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionSpringDeltaMaxRatio(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionSpringDeltaMaxRatio(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionSpringDeltaMaxRatio(vehiclePointer, value);
                    }
                }
            }
        }

        public float LowSpeedTractionLossMult
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetLowSpeedTractionLossMult(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetLowSpeedTractionLossMult(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetLowSpeedTractionLossMult(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetLowSpeedTractionLossMult(vehiclePointer, value);
                    }
                }
            }
        }

        public float CamberStiffness
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetCamberStiffness(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetCamberStiffness(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetCamberStiffness(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetCamberStiffness(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionBiasFront
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionBiasFront(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionBiasFront(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionBiasFront(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionBiasFront(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionBiasRear
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionBiasRear(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionBiasRear(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionBiasRear(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionBiasRear(vehiclePointer, value);
                    }
                }
            }
        }

        public float TractionLossMult
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetTractionLossMult(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetTractionLossMult(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetTractionLossMult(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetTractionLossMult(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionForce
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionForce(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionForce(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionForce(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionForce(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionCompDamp
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionCompDamp(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionCompDamp(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionCompDamp(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionCompDamp(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionReboundDamp
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionReboundDamp(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionReboundDamp(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionReboundDamp(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionReboundDamp(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionUpperLimit
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionUpperLimit(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionUpperLimit(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionUpperLimit(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionUpperLimit(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionLowerLimit
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionLowerLimit(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionLowerLimit(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionLowerLimit(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionLowerLimit(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionRaise
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionRaise(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionRaise(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionRaise(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionRaise(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionBiasFront
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionBiasFront(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionBiasFront(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionBiasFront(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionBiasFront(vehiclePointer, value);
                    }
                }
            }
        }

        public float SuspensionBiasRear
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSuspensionBiasRear(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSuspensionBiasRear(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSuspensionBiasRear(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSuspensionBiasRear(vehiclePointer, value);
                    }
                }
            }
        }

        public float AntiRollBarForce
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetAntiRollBarForce(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetAntiRollBarForce(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetAntiRollBarForce(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetAntiRollBarForce(vehiclePointer, value);
                    }
                }
            }
        }

        public float AntiRollBarBiasFront
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetAntiRollBarBiasFront(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetAntiRollBarBiasFront(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetAntiRollBarBiasFront(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetAntiRollBarBiasFront(vehiclePointer, value);
                    }
                }
            }
        }

        public float AntiRollBarBiasRear
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetAntiRollBarBiasRear(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetAntiRollBarBiasRear(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetAntiRollBarBiasRear(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetAntiRollBarBiasRear(vehiclePointer, value);
                    }
                }
            }
        }

        public float RollCentreHeightFront
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetRollCentreHeightFront(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetRollCentreHeightFront(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetRollCentreHeightFront(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetRollCentreHeightFront(vehiclePointer, value);
                    }
                }
            }
        }

        public float RollCentreHeightRear
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetRollCentreHeightRear(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetRollCentreHeightRear(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetRollCentreHeightRear(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetRollCentreHeightRear(vehiclePointer, value);
                    }
                }
            }
        }

        public float CollisionDamageMult
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetCollisionDamageMult(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetCollisionDamageMult(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetCollisionDamageMult(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetCollisionDamageMult(vehiclePointer, value);
                    }
                }
            }
        }

        public float WeaponDamageMult
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetWeaponDamageMult(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetWeaponDamageMult(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetWeaponDamageMult(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetWeaponDamageMult(vehiclePointer, value);
                    }
                }
            }
        }

        public float DeformationDamageMult
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetDeformationDamageMult(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetDeformationDamageMult(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetDeformationDamageMult(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetDeformationDamageMult(vehiclePointer, value);
                    }
                }
            }
        }

        public float EngineDamageMult
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetEngineDamageMult(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetEngineDamageMult(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetEngineDamageMult(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetEngineDamageMult(vehiclePointer, value);
                    }
                }
            }
        }

        public float PetrolTankVolume
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetPetrolTankVolume(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetPetrolTankVolume(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetPetrolTankVolume(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetPetrolTankVolume(vehiclePointer, value);
                    }
                }
            }
        }

        public float OilVolume
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetOilVolume(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetOilVolume(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetOilVolume(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetOilVolume(vehiclePointer, value);
                    }
                }
            }
        }

        public float unkFloat5
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetunkFloat5(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetunkFloat5(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetunkFloat5(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetunkFloat5(vehiclePointer, value);
                    }
                }
            }
        }

        public float SeatOffsetDistX
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSeatOffsetDistX(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistX(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSeatOffsetDistX(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSeatOffsetDistX(vehiclePointer, value);
                    }
                }
            }
        }

        public float SeatOffsetDistY
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSeatOffsetDistY(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistY(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSeatOffsetDistY(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSeatOffsetDistY(vehiclePointer, value);
                    }
                }
            }
        }

        public float SeatOffsetDistZ
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetSeatOffsetDistZ(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetSeatOffsetDistZ(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetSeatOffsetDistZ(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetSeatOffsetDistZ(vehiclePointer, value);
                    }
                }
            }
        }

        public uint MonetaryValue
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetMonetaryValue(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetMonetaryValue(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetMonetaryValue(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetMonetaryValue(vehiclePointer, value);
                    }
                }
            }
        }

        public uint ModelFlags
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetModelFlags(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetModelFlags(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetModelFlags(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetModelFlags(vehiclePointer, value);
                    }
                }
            }
        }

        public uint HandlingFlags
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetHandlingFlags(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetHandlingFlags(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetHandlingFlags(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetHandlingFlags(vehiclePointer, value);
                    }
                }
            }
        }

        public uint DamageFlags
        {
            get
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        return core.Library.Client.LocalVehicle_Handling_GetDamageFlags(vehiclePointer);
                    }
                    else
                    {
                        return core.Library.Client.Vehicle_Handling_GetDamageFlags(vehiclePointer);
                    }
                }
            }
            set
            {
                unsafe
                {
                    if (isLocalVehicle)
                    {
                        core.Library.Client.LocalVehicle_Handling_SetDamageFlags(vehiclePointer, value);
                    }
                    else
                    {
                        core.Library.Client.Vehicle_Handling_SetDamageFlags(vehiclePointer, value);
                    }
                }
            }
        }
    }
}