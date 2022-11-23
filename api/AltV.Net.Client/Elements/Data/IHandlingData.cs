using System.Numerics;

namespace AltV.Net.Client.Elements.Data;

public interface IHandlingData
{
    uint HandlingNameHash { get; }
    float Mass { get; set; }
    float InitialDragCoeff { get; set; }
    float DownforceModifier { get; set; }
    float unkFloat1 { get; set; }
    float unkFloat2 { get; set; }
    Vector3 CentreOfMassOffset { get; set; }
    Vector3 InertiaMultiplier { get; set; }
    float PercentSubmerged { get; set; }
    float PercentSubmergedRatio { get; set; }
    float DriveBiasFront { get; set; }
    float Acceleration { get; set; }
    uint InitialDriveGears { get; set; }
    float DriveInertia { get; set; }
    float ClutchChangeRateScaleUpShift { get; set; }
    float ClutchChangeRateScaleDownShift { get; set; }
    float InitialDriveForce { get; set; }
    float DriveMaxFlatVel { get; set; }
    float InitialDriveMaxFlatVel { get; set; }
    float BrakeForce { get; set; }
    float unkFloat4 { get; set; }
    float BrakeBiasFront { get; set; }
    float BrakeBiasRear { get; set; }
    float HandBrakeForce { get; set; }
    float SteeringLock { get; set; }
    float SteeringLockRatio { get; set; }
    float TractionCurveMax { get; set; }
    float TractionCurveMaxRatio { get; set; }
    float TractionCurveMin { get; set; }
    float TractionCurveMinRatio { get; set; }
    float TractionCurveLateral { get; set; }
    float TractionCurveLateralRatio { get; set; }
    float TractionSpringDeltaMax { get; set; }
    float TractionSpringDeltaMaxRatio { get; set; }
    float LowSpeedTractionLossMult { get; set; }
    float CamberStiffness { get; set; }
    float TractionBiasFront { get; set; }
    float TractionBiasRear { get; set; }
    float TractionLossMult { get; set; }
    float SuspensionForce { get; set; }
    float SuspensionCompDamp { get; set; }
    float SuspensionReboundDamp { get; set; }
    float SuspensionUpperLimit { get; set; }
    float SuspensionLowerLimit { get; set; }
    float SuspensionRaise { get; set; }
    float SuspensionBiasFront { get; set; }
    float SuspensionBiasRear { get; set; }
    float AntiRollBarForce { get; set; }
    float AntiRollBarBiasFront { get; set; }
    float AntiRollBarBiasRear { get; set; }
    float RollCentreHeightFront { get; set; }
    float RollCentreHeightRear { get; set; }
    float CollisionDamageMult { get; set; }
    float WeaponDamageMult { get; set; }
    float DeformationDamageMult { get; set; }
    float EngineDamageMult { get; set; }
    float PetrolTankVolume { get; set; }
    float OilVolume { get; set; }
    float unkFloat5 { get; set; }
    float SeatOffsetDistX { get; set; }
    float SeatOffsetDistY { get; set; }
    float SeatOffsetDistZ { get; set; }
    uint MonetaryValue { get; set; }
    uint ModelFlags { get; set; }
    uint HandlingFlags { get; set; }
    uint DamageFlags { get; set; }
}