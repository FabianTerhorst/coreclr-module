using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IHandlingData
    {
        double Acceleration { get; set; }
        
        double AntiRollBarBiasFront { get; set; }
        
        double AntiRollBarBiasRear { get; set; }
        
        double AntiRollBarForce { get; set; }
        
        double BrakeBiasFront { get; set; }
        
        double BrakeBiasRear { get; set; }
        
        double BreakForce { get; set; }
        
        double CamberStiffness { get; set; }
        
        Vector3 CentreOfMassOffset { get; set; }
        
        double ClutchChangeRateScaleDownShift { get; set; }
        
        double ClutchChangeRateScaleUpShift { get; set; }
        
        double CollisionDamageMult { get; set; }
        
        int DamageFlags { get; set; }
        
        double DeformationDamageMult { get; set; }
        
        double DownforceModifier { get; set; }
        
        double DriveBiasFront { get; set; }
        
        double DriveInertia { get; set; }
        
        double DriveMaxFlatVel { get; set; }
        
        double EngineDamageMult { get; set; }
        
        double HandBrakeForce { get; set; }
        
        int HandlingFlags { get; set; }
        
        int HandlingNameHash { get; }
        
        Vector3 InertiaMultiplier { get; set; }
        
        double InitalDragCoeff { get; set; }
        
        double InitialDriveForce { get; set; }
        
        int InitialDriveGears { get; set; }
        
        double InitialDriveMaxFlatVel { get; set; }
        
        double LowSpeedTractionLossMult { get; set; }
        
        int Mass { get; set; }
        
        int ModelFlags { get; set; }
        
        int MonetaryValue { get; set; }
        
        int OilVolume { get; set; }
        
        int PercentSubmerged { get; set; }

        double PercentSubmergedRatio { get; set; }
        
        int PetrolTankVolume { get; set; }
        
        double RollCentreHeightFront { get; set; }
        
        double RollCentreHeightRear { get; set; }
        
        double SeatOffsetDistX { get; set; }
        
        double SeatOffsetDistY { get; set; }
        
        double SeatOffsetDistZ { get; set; }
        
        double SteeringLock { get; set; }
        
        double SteeringLockRatio { get; set; }
        
        double SuspensionBiasFront { get; set; }
        
        double SuspensionBiasRear { get; set; }
        
        double SuspensionCompDamp { get; set; }
        
        double SuspensionForce { get; set; }
        
        double SuspensionLowerLimit { get; set; }
        
        double SuspensionRaise { get; set; }
        
        double SuspensionReboundDamp { get; set; }
        
        double SuspensionUpperLimit { get; set; }
        
        double TractionBiasFront { get; set; }
        
        double TractionBiasRear { get; set; }
        
        double TractionCurveLateral { get; set; }
        
        double TractionCurveLateralRatio { get; set; }
        
        double TractionCurveMax { get; set; }
        
        double TractionCurveMaxRatio { get; set; }
        
        double TractionCurveMin { get; set; }
        
        double TractionCurveMinRatio { get; set; }
        
        double TractionLossMult { get; set; }
        
        double TractionSpringDeltaMax { get; set; }
        
        double TractionSpringDeltaMaxRatio { get; set; }
        
        double UnkFloat1 { get; set; }
        
        double UnkFloat2 { get; set; }
        
        double UnkFloat3 { get; set; }
        
        double UnkFloat4 { get; set; }
        
        double UnkFloat5 { get; set; }
        
        double WeaponDamageMult { get; set; }
    }
}