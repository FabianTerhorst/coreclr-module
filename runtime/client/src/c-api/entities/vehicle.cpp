#include "vehicle.h"
#include "../../../../cpp-sdk/SDK.h"
#include <Log.h>

using namespace alt;

uint16_t Vehicle_GetID(alt::IVehicle* vehicle) {
    return vehicle->GetID();
}

alt::IEntity* Vehicle_GetEntity(alt::IVehicle* vehicle) {
    return dynamic_cast<alt::IEntity*>(vehicle);
}


uint16_t Vehicle_GetGear(alt::IVehicle* vehicle)
{
    return vehicle->GetCurrentGear();
}

void Vehicle_SetGear(alt::IVehicle* vehicle, uint16_t value) {
    vehicle->SetCurrentGear(value);
}

uint8_t Vehicle_GetIndicatorLights(alt::IVehicle* vehicle) {
    return vehicle->GetLightsIndicator();
}

void Vehicle_SetIndicatorLights(alt::IVehicle* vehicle, uint8_t value) {
    vehicle->SetLightsIndicator(value);
}

uint16_t Vehicle_GetMaxGear(alt::IVehicle* vehicle) {
    return vehicle->GetMaxGear();
}

void Vehicle_SetMaxGear(alt::IVehicle* vehicle, uint16_t value) {
    vehicle->SetMaxGear(value);
}

float Vehicle_GetRPM(alt::IVehicle* vehicle) {
    return vehicle->GetCurrentRPM();
}

uint8_t Vehicle_GetSeatCount(alt::IVehicle* vehicle) {
    return vehicle->GetSeatCount();
}

float Vehicle_GetWheelSpeed(alt::IVehicle* vehicle) {
    return vehicle->GetWheelSpeed();
}

void Vehicle_GetSpeedVector(alt::IVehicle* vehicle, vector3_t& vector) {
    auto speed = vehicle->GetSpeedVector();
    vector.x = speed[0];
    vector.y = speed[1];
    vector.z = speed[2];
}

uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle) {
    return vehicle->GetWheelsCount();
}

void Vehicle_GetHandling(alt::IVehicle* vehicle, alt::IHandlingData*& handling) {
    handling = vehicle->GetHandling().Get();
}

void Vehicle_ReplaceHandling(alt::IVehicle* vehicle) {
    vehicle->ReplaceHandling();
}

void Vehicle_ResetHandling(alt::IVehicle* vehicle) {
    vehicle->ReplaceHandling();
}

uint8_t Vehicle_IsHandlingModified(alt::IVehicle* vehicle) {
    return vehicle->IsHandlingModified();
}

uint8_t Vehicle_Handling_GetByModelHash(alt::ICore* core, uint32_t modelHash, alt::IHandlingData*& handling) {
    Log::Info << "Model hash is " << modelHash << Log::Endl;
    auto data = core->GetHandlingData(modelHash);
    Log::Info << "Empty was " << data.IsEmpty() << Log::Endl;
    if (data.IsEmpty()) return false;
    handling = data.Get();
    return true;
}

uint32_t Vehicle_Handling_GetHandlingNameHash(alt::IHandlingData* handling) {
    return handling->GetHandlingNameHash();
}
float Vehicle_Handling_GetMass(alt::IHandlingData* handling) {
    return handling->GetMass();
}
void Vehicle_Handling_SetMass(alt::IHandlingData* handling, float value) {
    handling->SetMass(value);
}
float Vehicle_Handling_GetInitialDragCoeff(alt::IHandlingData* handling) {
    return handling->GetInitialDragCoeff();
}
void Vehicle_Handling_SetInitialDragCoeff(alt::IHandlingData* handling, float value) {
    handling->SetInitialDragCoeff(value);
}
float Vehicle_Handling_GetDownforceModifier(alt::IHandlingData* handling) {
    return handling->GetDownforceModifier();
}
void Vehicle_Handling_SetDownforceModifier(alt::IHandlingData* handling, float value) {
    handling->SetDownforceModifier(value);
}
float Vehicle_Handling_GetunkFloat1(alt::IHandlingData* handling) {
    return handling->GetunkFloat1();
}
void Vehicle_Handling_SetunkFloat1(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat1(value);
}
float Vehicle_Handling_GetunkFloat2(alt::IHandlingData* handling) {
    return handling->GetunkFloat2();
}
void Vehicle_Handling_SetunkFloat2(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat2(value);
}
void Vehicle_Handling_GetCentreOfMassOffset(alt::IHandlingData* handling, vector3_t& offset) {
    auto vector = handling->GetCentreOfMassOffset();
    offset.x = vector[0];
    offset.y = vector[1];
    offset.z = vector[2];
}
void Vehicle_Handling_SetCentreOfMassOffset(alt::IHandlingData* handling, vector3_t value) {
    handling->SetCentreOfMassOffset(alt::Vector3f(value.x, value.y, value.z));
}
void Vehicle_Handling_GetInertiaMultiplier(alt::IHandlingData* handling, vector3_t& offset) {
    auto vector = handling->GetInertiaMultiplier();
    offset.x = vector[0];
    offset.y = vector[1];
    offset.z = vector[2];
}
void Vehicle_Handling_SetInertiaMultiplier(alt::IHandlingData* handling, vector3_t value) {
    handling->SetInertiaMultiplier(alt::Vector3f(value.x, value.y, value.z));
}
float Vehicle_Handling_GetPercentSubmerged(alt::IHandlingData* handling) {
    return handling->GetPercentSubmerged();
}
void Vehicle_Handling_SetPercentSubmerged(alt::IHandlingData* handling, float value) {
    handling->SetPercentSubmerged(value);
}
float Vehicle_Handling_GetPercentSubmergedRatio(alt::IHandlingData* handling) {
    return handling->GetPercentSubmergedRatio();
}
void Vehicle_Handling_SetPercentSubmergedRatio(alt::IHandlingData* handling, float value) {
    handling->SetPercentSubmergedRatio(value);
}
float Vehicle_Handling_GetDriveBiasFront(alt::IHandlingData* handling) {
    return handling->GetDriveBiasFront();
}
void Vehicle_Handling_SetDriveBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetDriveBiasFront(value);
}
float Vehicle_Handling_GetAcceleration(alt::IHandlingData* handling) {
    return handling->GetAcceleration();
}
void Vehicle_Handling_SetAcceleration(alt::IHandlingData* handling, float value) {
    handling->SetAcceleration(value);
}
uint32_t Vehicle_Handling_GetInitialDriveGears(alt::IHandlingData* handling) {
    return handling->GetInitialDriveGears();
}
void Vehicle_Handling_SetInitialDriveGears(alt::IHandlingData* handling, uint32_t value) {
    handling->SetInitialDriveGears(value);
}
float Vehicle_Handling_GetDriveInertia(alt::IHandlingData* handling) {
    return handling->GetDriveInertia();
}
void Vehicle_Handling_SetDriveInertia(alt::IHandlingData* handling, float value) {
    handling->SetDriveInertia(value);
}
float Vehicle_Handling_GetClutchChangeRateScaleUpShift(alt::IHandlingData* handling) {
    return handling->GetClutchChangeRateScaleUpShift();
}
void Vehicle_Handling_SetClutchChangeRateScaleUpShift(alt::IHandlingData* handling, float value) {
    handling->SetClutchChangeRateScaleUpShift(value);
}
float Vehicle_Handling_GetClutchChangeRateScaleDownShift(alt::IHandlingData* handling) {
    return handling->GetClutchChangeRateScaleDownShift();
}
void Vehicle_Handling_SetClutchChangeRateScaleDownShift(alt::IHandlingData* handling, float value) {
    handling->SetClutchChangeRateScaleDownShift(value);
}
float Vehicle_Handling_GetInitialDriveForce(alt::IHandlingData* handling) {
    return handling->GetInitialDriveForce();
}
void Vehicle_Handling_SetInitialDriveForce(alt::IHandlingData* handling, float value) {
    handling->SetInitialDriveForce(value);
}
float Vehicle_Handling_GetDriveMaxFlatVel(alt::IHandlingData* handling) {
    return handling->GetDriveMaxFlatVel();
}
void Vehicle_Handling_SetDriveMaxFlatVel(alt::IHandlingData* handling, float value) {
    handling->SetDriveMaxFlatVel(value);
}
float Vehicle_Handling_GetInitialDriveMaxFlatVel(alt::IHandlingData* handling) {
    return handling->GetInitialDriveMaxFlatVel();
}
void Vehicle_Handling_SetInitialDriveMaxFlatVel(alt::IHandlingData* handling, float value) {
    handling->SetInitialDriveMaxFlatVel(value);
}
float Vehicle_Handling_GetBrakeForce(alt::IHandlingData* handling) {
    return handling->GetBrakeForce();
}
void Vehicle_Handling_SetBrakeForce(alt::IHandlingData* handling, float value) {
    handling->SetBrakeForce(value);
}
float Vehicle_Handling_GetunkFloat4(alt::IHandlingData* handling) {
    return handling->GetunkFloat4();
}
void Vehicle_Handling_SetunkFloat4(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat4(value);
}
float Vehicle_Handling_GetBrakeBiasFront(alt::IHandlingData* handling) {
    return handling->GetBrakeBiasFront();
}
void Vehicle_Handling_SetBrakeBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetBrakeBiasFront(value);
}
float Vehicle_Handling_GetBrakeBiasRear(alt::IHandlingData* handling) {
    return handling->GetBrakeBiasRear();
}
void Vehicle_Handling_SetBrakeBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetBrakeBiasRear(value);
}
float Vehicle_Handling_GetHandBrakeForce(alt::IHandlingData* handling) {
    return handling->GetHandBrakeForce();
}
void Vehicle_Handling_SetHandBrakeForce(alt::IHandlingData* handling, float value) {
    handling->SetHandBrakeForce(value);
}
float Vehicle_Handling_GetSteeringLock(alt::IHandlingData* handling) {
    return handling->GetSteeringLock();
}
void Vehicle_Handling_SetSteeringLock(alt::IHandlingData* handling, float value) {
    handling->SetSteeringLock(value);
}
float Vehicle_Handling_GetSteeringLockRatio(alt::IHandlingData* handling) {
    return handling->GetSteeringLockRatio();
}
void Vehicle_Handling_SetSteeringLockRatio(alt::IHandlingData* handling, float value) {
    handling->SetSteeringLockRatio(value);
}
float Vehicle_Handling_GetTractionCurveMax(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMax();
}
void Vehicle_Handling_SetTractionCurveMax(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMax(value);
}
float Vehicle_Handling_GetTractionCurveMaxRatio(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMaxRatio();
}
void Vehicle_Handling_SetTractionCurveMaxRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMaxRatio(value);
}
float Vehicle_Handling_GetTractionCurveMin(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMin();
}
void Vehicle_Handling_SetTractionCurveMin(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMin(value);
}
float Vehicle_Handling_GetTractionCurveMinRatio(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMinRatio();
}
void Vehicle_Handling_SetTractionCurveMinRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMinRatio(value);
}
float Vehicle_Handling_GetTractionCurveLateral(alt::IHandlingData* handling) {
    return handling->GetTractionCurveLateral();
}
void Vehicle_Handling_SetTractionCurveLateral(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveLateral(value);
}
float Vehicle_Handling_GetTractionCurveLateralRatio(alt::IHandlingData* handling) {
    return handling->GetTractionCurveLateralRatio();
}
void Vehicle_Handling_SetTractionCurveLateralRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveLateralRatio(value);
}
float Vehicle_Handling_GetTractionSpringDeltaMax(alt::IHandlingData* handling) {
    return handling->GetTractionSpringDeltaMax();
}
void Vehicle_Handling_SetTractionSpringDeltaMax(alt::IHandlingData* handling, float value) {
    handling->SetTractionSpringDeltaMax(value);
}
float Vehicle_Handling_GetTractionSpringDeltaMaxRatio(alt::IHandlingData* handling) {
    return handling->GetTractionSpringDeltaMaxRatio();
}
void Vehicle_Handling_SetTractionSpringDeltaMaxRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionSpringDeltaMaxRatio(value);
}
float Vehicle_Handling_GetLowSpeedTractionLossMult(alt::IHandlingData* handling) {
    return handling->GetLowSpeedTractionLossMult();
}
void Vehicle_Handling_SetLowSpeedTractionLossMult(alt::IHandlingData* handling, float value) {
    handling->SetLowSpeedTractionLossMult(value);
}
float Vehicle_Handling_GetCamberStiffness(alt::IHandlingData* handling) {
    return handling->GetCamberStiffness();
}
void Vehicle_Handling_SetCamberStiffness(alt::IHandlingData* handling, float value) {
    handling->SetCamberStiffness(value);
}
float Vehicle_Handling_GetTractionBiasFront(alt::IHandlingData* handling) {
    return handling->GetTractionBiasFront();
}
void Vehicle_Handling_SetTractionBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetTractionBiasFront(value);
}
float Vehicle_Handling_GetTractionBiasRear(alt::IHandlingData* handling) {
    return handling->GetTractionBiasRear();
}
void Vehicle_Handling_SetTractionBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetTractionBiasRear(value);
}
float Vehicle_Handling_GetTractionLossMult(alt::IHandlingData* handling) {
    return handling->GetTractionLossMult();
}
void Vehicle_Handling_SetTractionLossMult(alt::IHandlingData* handling, float value) {
    handling->SetTractionLossMult(value);
}
float Vehicle_Handling_GetSuspensionForce(alt::IHandlingData* handling) {
    return handling->GetSuspensionForce();
}
void Vehicle_Handling_SetSuspensionForce(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionForce(value);
}
float Vehicle_Handling_GetSuspensionCompDamp(alt::IHandlingData* handling) {
    return handling->GetSuspensionCompDamp();
}
void Vehicle_Handling_SetSuspensionCompDamp(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionCompDamp(value);
}
float Vehicle_Handling_GetSuspensionReboundDamp(alt::IHandlingData* handling) {
    return handling->GetSuspensionReboundDamp();
}
void Vehicle_Handling_SetSuspensionReboundDamp(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionReboundDamp(value);
}
float Vehicle_Handling_GetSuspensionUpperLimit(alt::IHandlingData* handling) {
    return handling->GetSuspensionUpperLimit();
}
void Vehicle_Handling_SetSuspensionUpperLimit(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionUpperLimit(value);
}
float Vehicle_Handling_GetSuspensionLowerLimit(alt::IHandlingData* handling) {
    return handling->GetSuspensionLowerLimit();
}
void Vehicle_Handling_SetSuspensionLowerLimit(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionLowerLimit(value);
}
float Vehicle_Handling_GetSuspensionRaise(alt::IHandlingData* handling) {
    return handling->GetSuspensionRaise();
}
void Vehicle_Handling_SetSuspensionRaise(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionRaise(value);
}
float Vehicle_Handling_GetSuspensionBiasFront(alt::IHandlingData* handling) {
    return handling->GetSuspensionBiasFront();
}
void Vehicle_Handling_SetSuspensionBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionBiasFront(value);
}
float Vehicle_Handling_GetSuspensionBiasRear(alt::IHandlingData* handling) {
    return handling->GetSuspensionBiasRear();
}
void Vehicle_Handling_SetSuspensionBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionBiasRear(value);
}
float Vehicle_Handling_GetAntiRollBarForce(alt::IHandlingData* handling) {
    return handling->GetAntiRollBarForce();
}
void Vehicle_Handling_SetAntiRollBarForce(alt::IHandlingData* handling, float value) {
    handling->SetAntiRollBarForce(value);
}
float Vehicle_Handling_GetAntiRollBarBiasFront(alt::IHandlingData* handling) {
    return handling->GetAntiRollBarBiasFront();
}
void Vehicle_Handling_SetAntiRollBarBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetAntiRollBarBiasFront(value);
}
float Vehicle_Handling_GetAntiRollBarBiasRear(alt::IHandlingData* handling) {
    return handling->GetAntiRollBarBiasRear();
}
void Vehicle_Handling_SetAntiRollBarBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetAntiRollBarBiasRear(value);
}
float Vehicle_Handling_GetRollCentreHeightFront(alt::IHandlingData* handling) {
    return handling->GetRollCentreHeightFront();
}
void Vehicle_Handling_SetRollCentreHeightFront(alt::IHandlingData* handling, float value) {
    handling->SetRollCentreHeightFront(value);
}
float Vehicle_Handling_GetRollCentreHeightRear(alt::IHandlingData* handling) {
    return handling->GetRollCentreHeightRear();
}
void Vehicle_Handling_SetRollCentreHeightRear(alt::IHandlingData* handling, float value) {
    handling->SetRollCentreHeightRear(value);
}
float Vehicle_Handling_GetCollisionDamageMult(alt::IHandlingData* handling) {
    return handling->GetCollisionDamageMult();
}
void Vehicle_Handling_SetCollisionDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetCollisionDamageMult(value);
}
float Vehicle_Handling_GetWeaponDamageMult(alt::IHandlingData* handling) {
    return handling->GetWeaponDamageMult();
}
void Vehicle_Handling_SetWeaponDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetWeaponDamageMult(value);
}
float Vehicle_Handling_GetDeformationDamageMult(alt::IHandlingData* handling) {
    return handling->GetDeformationDamageMult();
}
void Vehicle_Handling_SetDeformationDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetDeformationDamageMult(value);
}
float Vehicle_Handling_GetEngineDamageMult(alt::IHandlingData* handling) {
    return handling->GetEngineDamageMult();
}
void Vehicle_Handling_SetEngineDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetEngineDamageMult(value);
}
float Vehicle_Handling_GetPetrolTankVolume(alt::IHandlingData* handling) {
    return handling->GetPetrolTankVolume();
}
void Vehicle_Handling_SetPetrolTankVolume(alt::IHandlingData* handling, float value) {
    handling->SetPetrolTankVolume(value);
}
float Vehicle_Handling_GetOilVolume(alt::IHandlingData* handling) {
    return handling->GetOilVolume();
}
void Vehicle_Handling_SetOilVolume(alt::IHandlingData* handling, float value) {
    handling->SetOilVolume(value);
}
float Vehicle_Handling_GetunkFloat5(alt::IHandlingData* handling) {
    return handling->GetunkFloat5();
}
void Vehicle_Handling_SetunkFloat5(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat5(value);
}
float Vehicle_Handling_GetSeatOffsetDistX(alt::IHandlingData* handling) {
    return handling->GetSeatOffsetDistX();
}
void Vehicle_Handling_SetSeatOffsetDistX(alt::IHandlingData* handling, float value) {
    handling->SetSeatOffsetDistX(value);
}
float Vehicle_Handling_GetSeatOffsetDistY(alt::IHandlingData* handling) {
    return handling->GetSeatOffsetDistY();
}
void Vehicle_Handling_SetSeatOffsetDistY(alt::IHandlingData* handling, float value) {
    handling->SetSeatOffsetDistY(value);
}
float Vehicle_Handling_GetSeatOffsetDistZ(alt::IHandlingData* handling) {
    return handling->GetSeatOffsetDistZ();
}
void Vehicle_Handling_SetSeatOffsetDistZ(alt::IHandlingData* handling, float value) {
    handling->SetSeatOffsetDistZ(value);
}
uint32_t Vehicle_Handling_GetMonetaryValue(alt::IHandlingData* handling) {
    return handling->GetMonetaryValue();
}
void Vehicle_Handling_SetMonetaryValue(alt::IHandlingData* handling, uint32_t value) {
    handling->SetMonetaryValue(value);
}
uint32_t Vehicle_Handling_GetModelFlags(alt::IHandlingData* handling) {
    return handling->GetModelFlags();
}
void Vehicle_Handling_SetModelFlags(alt::IHandlingData* handling, uint32_t value) {
    handling->SetModelFlags(value);
}
uint32_t Vehicle_Handling_GetHandlingFlags(alt::IHandlingData* handling) {
    return handling->GetHandlingFlags();
}
void Vehicle_Handling_SetHandlingFlags(alt::IHandlingData* handling, uint32_t value) {
    handling->SetHandlingFlags(value);
}
uint32_t Vehicle_Handling_GetDamageFlags(alt::IHandlingData* handling) {
    return handling->GetDamageFlags();
}
void Vehicle_Handling_SetDamageFlags(alt::IHandlingData* handling, uint32_t value) {
    handling->SetDamageFlags(value);
}