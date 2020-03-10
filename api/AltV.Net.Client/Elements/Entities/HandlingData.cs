using System;
using System.Numerics;
using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class HandlingData : IHandlingData
    {

        public static IHandlingData GetForModel(uint modelHash)
        {
            return new HandlingData(Alt.HandlingData.GetForModel(modelHash));
        }

        private readonly JSObject jsObject;
        
        private HandlingData(JSObject jsObject)
        {
            this.jsObject = jsObject;
        }
        
        public double Acceleration
        {
            get
            {
                var val = jsObject.GetObjectProperty("acceleration");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("acceleration", value);
        }

        public double AntiRollBarBiasFront
        {
            get
            {
                var val = jsObject.GetObjectProperty("antiRollBarBiasFront");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("antiRollBarBiasFront", value);
        }

        public double AntiRollBarBiasRear
        {
            get
            {
                var val = jsObject.GetObjectProperty("antiRollBarBiasRear");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("antiRollBarBiasRear", value);
        }

        public double AntiRollBarForce
        {
            get
            {
                var val = jsObject.GetObjectProperty("antiRollBarForce");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("antiRollBarForce", value);
        }

        public double BrakeBiasFront
        {
            get
            {
                var val = jsObject.GetObjectProperty("brakeBiasFront");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("brakeBiasFront", value);
        }

        public double BrakeBiasRear
        {
            get
            {
                var val = jsObject.GetObjectProperty("brakeBiasRear");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("brakeBiasRear", value);
        }

        public double BreakForce
        {
            get
            {
                var val = jsObject.GetObjectProperty("breakForce");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("breakForce", value);
        }

        public double CamberStiffness
        {
            //Typo in JS
            get
            {
                var val = jsObject.GetObjectProperty("camberStiffnesss");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("camberStiffnesss", value);
        }

        public Vector3 CentreOfMassOffset
        {
            get
            {
                var data = (JSObject) jsObject.GetObjectProperty("centreOfMassOffset");
                var x = data.GetObjectProperty("x");
                var y = data.GetObjectProperty("y");
                var z = data.GetObjectProperty("z");
                return new Vector3(Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(z));
            }
            set
            {
                var vectorObj = Runtime.NewJSObject();
                vectorObj.SetObjectProperty("x", value.X);
                vectorObj.SetObjectProperty("y", value.Y);
                vectorObj.SetObjectProperty("z", value.Z);
                jsObject.SetObjectProperty("centreOfMassOffset", vectorObj);
            }
        }

        public double ClutchChangeRateScaleDownShift
        {
            get
            {
                var val = jsObject.GetObjectProperty("clutchChangeRateScaleDownShift");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("clutchChangeRateScaleUpShift", value);
        }

        public double ClutchChangeRateScaleUpShift
        {
            get
            {
                var val = jsObject.GetObjectProperty("clutchChangeRateScaleUpShift");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("clutchChangeRateScaleUpShift", value);
        }

        public double CollisionDamageMult
        {
            get
            {
                var val = jsObject.GetObjectProperty("collisionDamageMult");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("collisionDamageMult", value);
        }

        public int DamageFlags
        {
            get => (int) jsObject.GetObjectProperty("damageFlags");
            set => jsObject.SetObjectProperty("damageFlags", value);
        }

        public double DeformationDamageMult
        {
            get
            {
                var val = jsObject.GetObjectProperty("deformationDamageMult");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("deformationDamageMult", value);
        }

        public double DownforceModifier
        {
            get
            {
                var val = jsObject.GetObjectProperty("downforceModifier");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("downforceModifier", value);
        }

        public double DriveBiasFront
        {
            get
            {
                var val = jsObject.GetObjectProperty("driveBiasFront");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("driveBiasFront", value);
        }

        public double DriveInertia
        {
            get
            {
                var val = jsObject.GetObjectProperty("driveInertia");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("driveInertia", value);
        }

        public double DriveMaxFlatVel
        {
            get => (double) jsObject.GetObjectProperty("driveMaxFlatVel");
            set => jsObject.SetObjectProperty("driveMaxFlatVel", value);
        }

        public double EngineDamageMult
        {
            get => (double) jsObject.GetObjectProperty("engineDamageMult");
            set => jsObject.SetObjectProperty("engineDamageMult", value);
        }

        public double HandBrakeForce
        {
            get => (double) jsObject.GetObjectProperty("handBrakeForce");
            set => jsObject.SetObjectProperty("handBrakeForce", value);
        }

        public int HandlingFlags
        {
            get => (int) jsObject.GetObjectProperty("handlingFlags");
            set => jsObject.SetObjectProperty("handlingFlags", value);
        }

        public int HandlingNameHash => (int)jsObject.GetObjectProperty("handlingNameHash");

        public Vector3 InertiaMultiplier
        {
            get
            {
                var vector3Obj = (JSObject) jsObject.GetObjectProperty("inertiaMultiplier");
                var x = vector3Obj.GetObjectProperty("x");
                var y = vector3Obj.GetObjectProperty("y");
                var z = vector3Obj.GetObjectProperty("z");
                return new Vector3(Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(z));
            }
            set
            {
                var vector3Obj = Runtime.NewJSObject();
                vector3Obj.SetObjectProperty("x", value.X);
                vector3Obj.SetObjectProperty("y", value.Y);
                vector3Obj.SetObjectProperty("z", value.Z);
                jsObject.SetObjectProperty("inertiaMultiplier", vector3Obj);
            }
        }

        public double InitalDragCoeff
        {
            get
            {
                var val = jsObject.GetObjectProperty("initialDragCoeff");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("initialDragCoeff", value);
        }

        public double InitialDriveForce
        {
            get => (double) jsObject.GetObjectProperty("initialDriveForce");
            set => jsObject.SetObjectProperty("initialDriveForce", value);
        }

        public int InitialDriveGears
        {
            get => (int) jsObject.GetObjectProperty("initialDriveGears");
            set => jsObject.SetObjectProperty("initialDriveGears", value);
        }

        public double InitialDriveMaxFlatVel
        {
            get
            {
                var val = jsObject.GetObjectProperty("initialDriveMaxFlatVel");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("initialDriveMaxFlatVel", value);
        }

        public double LowSpeedTractionLossMult
        {
            get
            {
                var val = jsObject.GetObjectProperty("lowSpeedTractionLossMult");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("lowSpeedTractionLossMult", value);
        }

        public int Mass
        {
            get => (int) jsObject.GetObjectProperty("mass");
            set => jsObject.SetObjectProperty("mass", value);
        }

        public int ModelFlags
        {
            get => (int) jsObject.GetObjectProperty("modelFlags");
            set => jsObject.SetObjectProperty("modelFlags", value);
        }

        public int MonetaryValue
        {
            get => (int) jsObject.GetObjectProperty("monetaryValue");
            set => jsObject.SetObjectProperty("monetaryValue", value);
        }

        public int OilVolume
        {
            get => (int) jsObject.GetObjectProperty("oilVolume");
            set => jsObject.SetObjectProperty("oilVolume", value);
        }

        public int PercentSubmerged
        {
            get => (int) jsObject.GetObjectProperty("percentSubmerged");
            set => jsObject.SetObjectProperty("percentSubmerged", value);
        }

        public double PercentSubmergedRatio
        {
            get => (double) jsObject.GetObjectProperty("percentSubmergedRatio");
            set => jsObject.SetObjectProperty("percentSubmergedRatio", value);
        }

        public int PetrolTankVolume
        {
            get => (int) jsObject.GetObjectProperty("petrolTankVolume");
            set => jsObject.SetObjectProperty("petrolTankVolume", value);
        }

        public double RollCentreHeightFront
        {
            get => (double) jsObject.GetObjectProperty("rollCentreHeightFront");
            set => jsObject.SetObjectProperty("rollCentreHeightFront", value);
        }

        public double RollCentreHeightRear
        {
            get => (double) jsObject.GetObjectProperty("rollCentreHeightRear");
            set => jsObject.SetObjectProperty("rollCentreHeightRear", value);
        }

        public double SeatOffsetDistX
        {
            get
            {
                var val = jsObject.GetObjectProperty("seatOffsetDistX");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("seatOffsetDistX", value);
        }

        public double SeatOffsetDistY
        {
            get
            {
                var val = jsObject.GetObjectProperty("seatOffsetDistY");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("seatOffsetDistY", value);
        }

        public double SeatOffsetDistZ
        {
            get
            {
                var val = jsObject.GetObjectProperty("seatOffsetDistZ");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("seatOffsetDistZ", value);
        }

        public double SteeringLock
        {
            get => (double) jsObject.GetObjectProperty("steeringLock");
            set => jsObject.SetObjectProperty("steeringLock", value);
        }

        public double SteeringLockRatio
        {
            get => (double) jsObject.GetObjectProperty("steeringLockRatio");
            set => jsObject.SetObjectProperty("steeringLockRatio", value);
        }

        public double SuspensionBiasFront
        {
            get
            {
                var val = jsObject.GetObjectProperty("suspensionBiasFront");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("suspensionBiasFront", value);
        }

        public double SuspensionBiasRear
        {
            get
            {
                var val = jsObject.GetObjectProperty("suspensionBiasRear");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("suspensionBiasRear", value);
        }

        public double SuspensionCompDamp
        {
            get => (double) jsObject.GetObjectProperty("suspensionCompDamp");
            set => jsObject.SetObjectProperty("suspensionCompDamp", value);
        }

        public double SuspensionForce
        {
            get => (double) jsObject.GetObjectProperty("suspensionForce");
            set => jsObject.SetObjectProperty("suspensionForce", value);
        }

        public double SuspensionLowerLimit
        {
            get => (double) jsObject.GetObjectProperty("suspensionLowerLimit");
            set => jsObject.SetObjectProperty("suspensionLowerLimit", value);
        }

        public double SuspensionRaise
        {
            get
            {
                var val = jsObject.GetObjectProperty("suspensionRaise");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("suspensionRaise", value);
        }

        public double SuspensionReboundDamp
        {
            get => (double) jsObject.GetObjectProperty("suspensionReboundDamp");
            set => jsObject.SetObjectProperty("suspensionReboundDamp", value);
        }

        public double SuspensionUpperLimit
        {
            get => (double) jsObject.GetObjectProperty("suspensionUpperLimit");
            set => jsObject.SetObjectProperty("suspensionUpperLimit", value);
        }

        public double TractionBiasFront
        {
            get
            {
                var val = jsObject.GetObjectProperty("tractionBiasFront");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("tractionBiasFront", value);
        }

        public double TractionBiasRear
        {
            get
            {
                var val = jsObject.GetObjectProperty("tractionBiasRear");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("tractionBiasRear", value);
        }

        public double TractionCurveLateral
        {
            get => (double) jsObject.GetObjectProperty("tractionCurveLateral");
            set => jsObject.SetObjectProperty("tractionCurveLateral", value);
        }

        public double TractionCurveLateralRatio
        {
            get => (double) jsObject.GetObjectProperty("tractionCurveLateralRatio");
            set => jsObject.SetObjectProperty("tractionCurveLateralRatio", value);
        }

        public double TractionCurveMax
        {
            get => (double) jsObject.GetObjectProperty("tractionCurveMax");
            set => jsObject.SetObjectProperty("tractionCurveMax", value);
        }

        public double TractionCurveMaxRatio
        {
            get => (double) jsObject.GetObjectProperty("tractionCurveMaxRatio");
            set => jsObject.SetObjectProperty("tractionCurveMaxRatio", value);
        }

        public double TractionCurveMin
        {
            get => (double) jsObject.GetObjectProperty("tractionCurveMin");
            set => jsObject.SetObjectProperty("tractionCurveMin", value);
        }

        public double TractionCurveMinRatio
        {
            get => (double) jsObject.GetObjectProperty("tractionCurveMinRatio");
            set => jsObject.SetObjectProperty("tractionCurveMinRatio", value);
        }

        public double TractionLossMult
        {
            get
            {
                var val = jsObject.GetObjectProperty("tractionLossMult");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("tractionLossMult", value);
        }

        public double TractionSpringDeltaMax
        {
            get => (double) jsObject.GetObjectProperty("tractionSpringDeltaMax");
            set => jsObject.SetObjectProperty("tractionSpringDeltaMax", value);
        }

        public double TractionSpringDeltaMaxRatio
        {
            get => (double) jsObject.GetObjectProperty("tractionSpringDeltaMaxRatio");
            set => jsObject.SetObjectProperty("tractionSpringDeltaMaxRatio", value);
        }

        public double UnkFloat1
        {
            get
            {
                var val = jsObject.GetObjectProperty("unkFloat1");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("unkFloat1", value);
        }

        public double UnkFloat2
        {
            get
            {
                var val = jsObject.GetObjectProperty("unkFloat2");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("unkFloat2", value);
        }

        public double UnkFloat3
        {
            get
            {
                var val = jsObject.GetObjectProperty("unkFloat3");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("unkFloat3", value);
        }

        public double UnkFloat4
        {
            get
            {
                var val = jsObject.GetObjectProperty("unkFloat4");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("unkFloat4", value);
        }

        public double UnkFloat5
        {
            get
            {
                var val = jsObject.GetObjectProperty("unkFloat5");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("unkFloat5", value);
        }

        public double WeaponDamageMult
        {
            get
            {
                var val = jsObject.GetObjectProperty("weaponDamageMult");
                return Convert.ToDouble(val);
            }
            set => jsObject.SetObjectProperty("weaponDamageMult", value);
        }
    }
}