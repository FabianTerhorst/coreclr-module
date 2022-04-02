#include "core.h"
#include "mvalue.h"
#include "utils/strings.h"
#include "Log.h"
#include <vector>

void Core_LogInfo(alt::ICore* core, const char* str) {
    core->LogInfo(str);
}

void Core_LogDebug(alt::ICore* core, const char* str) {
    core->LogDebug(str);
}

void Core_LogWarning(alt::ICore* core, const char* str) {
    core->LogWarning(str);
}

void Core_LogError(alt::ICore* core, const char* str) {
    core->LogError(str);
}

void Core_LogColored(alt::ICore* core, const char* str) {
    core->LogColored(str);
}

alt::MValueConst* Core_CreateMValueNil(alt::ICore* core) {
    auto mValue = core->CreateMValueNil();
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueBool(alt::ICore* core, uint8_t value) {
    auto mValue = core->CreateMValueBool(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueInt(alt::ICore* core, int64_t value) {
    auto mValue = core->CreateMValueInt(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueUInt(alt::ICore* core, uint64_t value) {
    auto mValue = core->CreateMValueUInt(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueDouble(alt::ICore* core, double value) {
    auto mValue = core->CreateMValueDouble(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueString(alt::ICore* core, const char* value) {
    auto mValue = core->CreateMValueString(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueList(alt::ICore* core, alt::MValueConst* val[], uint64_t size) {
    auto mValueConst = core->CreateMValueList(size);
    auto mValue = mValueConst.Get();
    for (uint64_t i = 0; i < size; i++) {
        auto mValueElement = val[i];
        if (mValueElement == nullptr || mValueElement->Get() == nullptr) {
            mValue->Set(i, core->CreateMValueNil());
        } else {
            mValue->SetConst(i, *val[i]);
        }
    }
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueDict(alt::ICore* core, const char* keys[], alt::MValueConst* val[], uint64_t size) {
    auto mValueConst = core->CreateMValueDict();
    auto mValue = mValueConst.Get();
    for (uint64_t i = 0; i < size; i++) {
        auto mValueElement = val[i];
        if (mValueElement == nullptr || mValueElement->Get() == nullptr) {
            mValue->Set(keys[i], core->CreateMValueNil());
        } else {
            mValue->SetConst(keys[i], *val[i]);
        }
    }
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueBaseObject(alt::ICore* core, alt::IBaseObject* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueVector3(alt::ICore* core, position_t value) {
    alt::Vector3f vector3F;
    vector3F[0] = value.x;
    vector3F[1] = value.y;
    vector3F[2] = value.z;
    alt::MValueConst mValue = core->CreateMValueVector3(vector3F);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueVector2(alt::ICore* core, vector2_t value) {
    alt::Vector2f vector2F;
    vector2F[0] = value.x;
    vector2F[1] = value.y;
    alt::MValueConst mValue = core->CreateMValueVector2(vector2F);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueByteArray(alt::ICore* core, uint64_t size, const void* data) {
    auto byteArray = (const uint8_t*) data;
    alt::MValueConst mValue = core->CreateMValueByteArray(byteArray, size);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueRgba(alt::ICore* core, rgba_t value) {
    alt::RGBA rgba;
    rgba.r = value.r;
    rgba.g = value.g;
    rgba.b = value.b;
    rgba.a = value.a;
    alt::MValueConst mValue = core->CreateMValueRGBA(rgba);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value) {
    alt::MValueConst mValue = core->CreateMValueFunction(value);
    return new alt::MValueConst(mValue);
}


uint64_t Core_GetPlayerCount(alt::ICore* core) {
    return core->GetPlayers().GetSize();
}

void Core_GetPlayers(alt::ICore* core, alt::IPlayer* players[], uint64_t size) {
    auto playersArray = core->GetPlayers();
    if (playersArray.GetSize() < size) {
        size = playersArray.GetSize();
    }
    for (uint64_t i = 0; i < size; i++) {
        players[i] = playersArray[i].Get();
    }
}

uint64_t Core_GetVehicleCount(alt::ICore* core) {
    return core->GetVehicles().GetSize();
}

void Core_GetVehicles(alt::ICore* core, alt::IVehicle* vehicles[], uint64_t size) {
    auto vehiclesArray = core->GetVehicles();
    if (vehiclesArray.GetSize() < size) {
        size = vehiclesArray.GetSize();
    }
    for (uint64_t i = 0; i < size; i++) {
        vehicles[i] = vehiclesArray[i].Get();
    }
}

void* Core_GetEntityById(alt::ICore* core, uint16_t id, uint8_t& type) {
    auto entityRef = core->GetEntityByID(id);
    auto entity = entityRef.Get();
    if (entity == nullptr) return nullptr;
    type = (uint8_t) entity->GetType();
    switch (entity->GetType()) {
        case alt::IBaseObject::Type::PLAYER:
            return dynamic_cast<alt::IPlayer*>(entity);
        case alt::IBaseObject::Type::VEHICLE:
            return dynamic_cast<alt::IVehicle*>(entity);
    }
    return nullptr;
}


uint8_t Core_IsDebug(alt::ICore* core) {
    return core->IsDebug();
}

const char* Core_GetVersion(alt::ICore* core, int32_t &size) {
    return AllocateString(core->GetVersion(), size);
}

const char* Core_GetBranch(alt::ICore* core, int32_t &size) {
    return AllocateString(core->GetBranch(), size);
}


void Core_DestroyBaseObject(alt::ICore* core, alt::IBaseObject* baseObject) {
    return core->DestroyBaseObject(baseObject);
}

alt::MValueConst* Core_GetMetaData(alt::ICore* core, const char* key) {
    return new alt::MValueConst(core->GetMetaData(key));
}

void Core_SetMetaData(alt::ICore* core, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    core->SetMetaData(key, val->Get()->Clone());
}

uint8_t Core_HasMetaData(alt::ICore* core, const char* key) {
    return core->HasMetaData(key);
}

void Core_DeleteMetaData(alt::ICore* core, const char* key) {
    core->DeleteMetaData(key);
}

alt::MValueConst* Core_GetSyncedMetaData(alt::ICore* core, const char* key) {
    return new alt::MValueConst(core->GetSyncedMetaData(key));
}

uint8_t Core_HasSyncedMetaData(alt::ICore* core, const char* key) {
    return core->HasSyncedMetaData(key);
}


#ifdef ALT_SERVER_API
uint8_t Core_SubscribeCommand(alt::ICore* core, const char* cmd, alt::CommandCallback cb) {
    return core->SubscribeCommand(cmd, cb);
}

uint8_t Core_FileExists(alt::ICore* core, const char* path) {
    return core->FileExists(path);
}

//TODO: needs migration to std::string in cpp-sdk
void Core_FileRead(alt::ICore* core, const char* path, const char*&text) {
    text = core->FileRead(path).CStr();
}

void Core_TriggerServerEvent(alt::ICore* core, const char* ev, alt::MValueConst* args[], int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        ToMValueArg(mValues, core, args[i], i);
    }
    core->TriggerLocalEvent(ev, mValues);
}

void
Core_TriggerClientEvent(alt::ICore* core, alt::IPlayer* target, const char* ev, alt::MValueConst* args[],
                          int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        ToMValueArg(mValues, core, args[i], i);
    }
    core->TriggerClientEvent(target, ev, mValues);
}

void
Core_TriggerClientEventForAll(alt::ICore* core, const char* ev, alt::MValueConst* args[],
    int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        ToMValueArg(mValues, core, args[i], i);
    }
    core->TriggerClientEventForAll(ev, mValues);
}

void
Core_TriggerClientEventForSome(alt::ICore* core, alt::IPlayer* targets[], int targetsSize, const char* ev, alt::MValueConst* args[],
    int argsSize) {
    alt::Array<alt::Ref<alt::IPlayer>> clients(targetsSize);
    for (int i = 0; i < targetsSize; i++)
    {
        clients[i] = targets[i];
    }
    alt::MValueArgs mValues = alt::MValueArgs(argsSize);
    for (int i = 0; i < argsSize; i++) {
        ToMValueArg(mValues, core, args[i], i);
    }
    core->TriggerClientEvent(clients, ev, mValues);
}

alt::IVehicle*
Core_CreateVehicle(alt::ICore* core, uint32_t model, position_t pos, rotation_t rot, uint16_t &id) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    alt::Rotation rotation;
    rotation.roll = rot.roll;
    rotation.pitch = rot.pitch;
    rotation.yaw = rot.yaw;
    auto vehicle = core->CreateVehicle(model, position, rotation).Get();
    if (vehicle != nullptr) {
        id = vehicle->GetID();
    }
    return vehicle;
}

alt::ICheckpoint*
Core_CreateCheckpoint(alt::ICore* core, uint8_t type, position_t pos, float radius,
                        float height, rgba_t color) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    alt::RGBA rgba;
    rgba.r = color.r;
    rgba.g = color.g;
    rgba.b = color.b;
    rgba.a = color.a;
    return core->CreateCheckpoint(type, position, radius, height, rgba).Get();
}

alt::IBlip*
Core_CreateBlip(alt::ICore* core, alt::IPlayer* target, uint8_t type, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return core->CreateBlip(target, (alt::IBlip::BlipType) type, position).Get();
}

alt::IBlip* Core_CreateBlipAttached(alt::ICore* core, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo) {
    return core->CreateBlip(target, (alt::IBlip::BlipType) type, attachTo).Get();
}

alt::IResource* Core_GetResource(alt::ICore* core, const char* resourceName) {
    return core->GetResource(resourceName);
}

ClrVehicleModelInfo* Core_GetVehicleModelInfo(alt::ICore* core, uint32_t hash) {
    return new ClrVehicleModelInfo(core->GetVehicleModelByHash(hash));
}

void Core_DeallocVehicleModelInfo(ClrVehicleModelInfo* modelInfo) {
    delete modelInfo;
}

alt::IVoiceChannel* Core_CreateVoiceChannel(alt::ICore* core, uint8_t spatial, float maxDistance) {
    return core->CreateVoiceChannel(spatial, maxDistance).Get();
}

alt::IColShape* Core_CreateColShapeCylinder(alt::ICore* core, position_t pos, float radius, float height) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return core->CreateColShapeCylinder(position, radius, height).Get();
}

alt::IColShape* Core_CreateColShapeSphere(alt::ICore* core, position_t pos, float radius) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return core->CreateColShapeSphere(position, radius).Get();
}

alt::IColShape* Core_CreateColShapeCircle(alt::ICore* core, position_t pos, float radius) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return core->CreateColShapeCircle(position, radius).Get();
}

alt::IColShape* Core_CreateColShapeCube(alt::ICore* core, position_t pos, position_t pos2) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;

    alt::Position position2;
    position2.x = pos2.x;
    position2.y = pos2.y;
    position2.z = pos2.z;
    return core->CreateColShapeCube(position, position2).Get();
}

alt::IColShape* Core_CreateColShapeRectangle(alt::ICore* core, float x1, float y1, float x2, float y2, float z) {
    return core->CreateColShapeRectangle(x1, y1, x2, y2, z).Get();
}

alt::IColShape* Core_CreateColShapePolygon(alt::ICore* core, float minZ, float maxZ, vector2_t points[], int pointSize) {
    std::vector<alt::Vector2f> convertedPoints(pointSize);
    for (int i = 0; i < pointSize; i++)
    {
       alt::Vector2f point;
       point[0] = points[i].x;
       point[1] = points[i].y;
       convertedPoints[i] = point;
    }

    return core->CreateColShapePolygon(minZ, maxZ, convertedPoints).Get();
}

/*void Core_DestroyBaseObject(alt::ICore* core, alt::IBaseObject* baseObject) {
    return core->DestroyBaseObject(baseObject);
}*/

void Core_DestroyVehicle(alt::ICore* core, alt::IVehicle* baseObject) {
    return core->DestroyBaseObject(baseObject);
}

void Core_DestroyCheckpoint(alt::ICore* core, alt::ICheckpoint* baseObject) {
    return core->DestroyBaseObject(baseObject);
}

void Core_DestroyVoiceChannel(alt::ICore* core, alt::IVoiceChannel* baseObject) {
    return core->DestroyBaseObject(baseObject);
}

void Core_DestroyColShape(alt::ICore* core, alt::IColShape* baseObject) {
    return core->DestroyBaseObject(baseObject);
}

int32_t Core_GetNetTime(alt::ICore* core) {
    return core->GetNetTime();
}

void Core_GetRootDirectory(alt::ICore* core, const char*&text) {
    text = core->GetRootDirectory().CStr();
}

void Core_StartResource(alt::ICore* core, const char* text) {
    core->StartResource(text);
}

void Core_StopResource(alt::ICore* core, const char* text) {
    core->StopResource(text);
}

void Core_RestartResource(alt::ICore* core, const char* text) {
    core->RestartResource(text);
}

void Core_SetSyncedMetaData(alt::ICore* core, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    core->SetSyncedMetaData(key, val->Get()->Clone());
}

void Core_DeleteSyncedMetaData(alt::ICore* core, const char* key) {
    core->DeleteSyncedMetaData(key);
}

uint64_t Core_HashPassword(alt::ICore* core, const char* password) {
    return core->HashServerPassword(password);
}

void Core_SetPassword(alt::ICore* core, const char* value) {
    core->SetPassword(value);
}

void Core_StopServer(alt::ICore* core) {
    core->StopServer();
}
#endif

#ifdef ALT_CLIENT_API
alt::IBlip* Core_Client_CreatePointBlip(alt::ICore* core, vector3_t position) {
    alt::Position pos;
    pos.x = position.x;
    pos.y = position.y;
    pos.z = position.z;
    auto blip = core->CreateBlip(alt::IBlip::BlipType::DESTINATION, pos);
    if (blip.IsEmpty()) return nullptr;
    return blip.Get();
}

alt::IBlip* Core_Client_CreateRadiusBlip(alt::ICore* core, vector3_t position, float radius) {
    alt::Position pos;
    pos.x = position.x;
    pos.y = position.y;
    pos.z = position.z;
    auto blip = core->CreateBlip(pos, radius);
    if (blip.IsEmpty()) return nullptr;
    return blip.Get();
}

alt::IBlip* Core_Client_CreateAreaBlip(alt::ICore* core, vector3_t position, float width, float height) {
    alt::Position pos;
    pos.x = position.x;
    pos.y = position.y;
    pos.z = position.z;
    auto blip = core->CreateBlip(pos, width, height);
    if (blip.IsEmpty()) return nullptr;
    return blip.Get();
}

alt::IWebView* Core_CreateWebView(alt::ICore* core, alt::IResource* resource, const char* url, vector2_t pos, vector2_t size, uint8_t isOverlay) {
    auto webView = core->CreateWebView(resource, url, { pos.x, pos.y }, { size.x, size.y }, true, isOverlay);
    if (webView.IsEmpty()) return nullptr;
    return webView.Get();
}

alt::IWebView* Core_CreateWebView3D(alt::ICore* core, alt::IResource* resource, const char* url, uint32_t hash, const char* targetTexture) {
    auto webView = core->CreateWebView(resource, url, hash, targetTexture);
    if (webView.IsEmpty()) return nullptr;
    return webView.Get();
}

void Core_TriggerWebViewEvent(alt::ICore* core, alt::IWebView* webview, const char* event, alt::MValueConst* args[], int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        ToMValueArg(mValues, core, args[i], i);
    }
    webview->Trigger(event, mValues);
}


ClrDiscordUser* Core_GetDiscordUser(alt::ICore* core) {
    auto manager = core->GetDiscordManager();
    if (!manager->IsUserDataReady()) return nullptr;
    return new ClrDiscordUser(manager);
}

void Core_DeallocDiscordUser(ClrDiscordUser* user) {
    delete user;
}

void Core_ShowCursor(alt::ICore* core, alt::IResource* resource, bool state) {
    if(!resource->ToggleCursor(state))
    {
        Log::Warning << "Cursor state can't go < 0" << Log::Endl;
    }
}

void Core_TriggerServerEvent(alt::ICore* core, const char* event, alt::MValueConst* args[], int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        ToMValueArg(mValues, core, args[i], i);
    }
    core->TriggerServerEvent(event, mValues);
}

#endif