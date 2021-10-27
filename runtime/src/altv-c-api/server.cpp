#include "server.h"
#include "mvalue.h"

void Server_LogInfo(alt::ICore* server, const char* str) {
    server->LogInfo(str);
}

void Server_LogDebug(alt::ICore* server, const char* str) {
    server->LogDebug(str);
}

void Server_LogWarning(alt::ICore* server, const char* str) {
    server->LogWarning(str);
}

void Server_LogError(alt::ICore* server, const char* str) {
    server->LogError(str);
}

void Server_LogColored(alt::ICore* server, const char* str) {
    server->LogColored(str);
}

/*uint32_t Server_Hash(alt::ICore* server, const char* str) {
    return server->Hash(str);
}*/

void Server_SubscribeEvent(alt::ICore* server, alt::CEvent::Type ev, alt::EventCallback cb) {
    return server->SubscribeEvent(ev, cb);
}

void Server_SubscribeTick(alt::ICore* server, alt::TickCallback cb) {
    return server->SubscribeTick(cb);
}

uint8_t Server_SubscribeCommand(alt::ICore* server, const char* cmd, alt::CommandCallback cb) {
    return server->SubscribeCommand(cmd, cb);
}

uint8_t Server_FileExists(alt::ICore* server, const char* path) {
    return server->FileExists(path);
}

void Server_FileRead(alt::ICore* server, const char* path, const char*&text) {
    text = server->FileRead(path).CStr();
}

void Server_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueConst* args[], int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        mValues.Push(ToMValue(server, args[i]));
    }
    server->TriggerLocalEvent(ev, mValues);
}

void
Server_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, alt::MValueConst* args[],
                          int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        mValues.Push(ToMValue(server, args[i]));
    }
    server->TriggerClientEvent(target, ev, mValues);
}

void
Server_TriggerClientEventForAll(alt::ICore* server, const char* ev, alt::MValueConst* args[],
    int size) {
    alt::MValueArgs mValues = alt::MValueArgs(size);
    for (int i = 0; i < size; i++) {
        mValues.Push(ToMValue(server, args[i]));
    }
    server->TriggerClientEventForAll(ev, mValues);
}

void
Server_TriggerClientEventForSome(alt::ICore* server, alt::IPlayer* targets[], int targetsSize, const char* ev, alt::MValueConst* args[],
    int argsSize) {
    alt::Array<alt::Ref<alt::IPlayer>> clients(targetsSize);
    for (int i = 0; i < targetsSize; i++)
    {
        clients[i] = targets[i];
    }
    alt::MValueArgs mValues = alt::MValueArgs(argsSize);
    for (int i = 0; i < argsSize; i++) {
        mValues.Push(ToMValue(server, args[i]));
    }
    server->TriggerClientEvent(clients, ev, mValues);
}

alt::IVehicle*
Server_CreateVehicle(alt::ICore* server, uint32_t model, position_t pos, rotation_t rot, uint16_t &id) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    alt::Rotation rotation;
    rotation.roll = rot.roll;
    rotation.pitch = rot.pitch;
    rotation.yaw = rot.yaw;
    auto vehicle = server->CreateVehicle(model, position, rotation).Get();
    if (vehicle != nullptr) {
        id = vehicle->GetID();
    }
    return vehicle;
}

alt::ICheckpoint*
Server_CreateCheckpoint(alt::ICore* server, uint8_t type, position_t pos, float radius,
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
    return server->CreateCheckpoint(type, position, radius, height, rgba).Get();
}

alt::IBlip*
Server_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateBlip(target, (alt::IBlip::BlipType) type, position).Get();
}

alt::IBlip*
Server_CreateBlipAttached(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo) {
    return server->CreateBlip(target, (alt::IBlip::BlipType) type, attachTo).Get();
}

alt::IResource* Server_GetResource(alt::ICore* server, const char* resourceName) {
    return server->GetResource(resourceName);
}

alt::IVoiceChannel* Server_CreateVoiceChannel(alt::ICore* server, uint8_t spatial, float maxDistance) {
    return server->CreateVoiceChannel(spatial, maxDistance).Get();
}

alt::IColShape* Server_CreateColShapeCylinder(alt::ICore* server, position_t pos, float radius, float height) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateColShapeCylinder(position, radius, height).Get();
}

alt::IColShape* Server_CreateColShapeSphere(alt::ICore* server, position_t pos, float radius) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateColShapeSphere(position, radius).Get();
}

alt::IColShape* Server_CreateColShapeCircle(alt::ICore* server, position_t pos, float radius) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateColShapeCircle(position, radius).Get();
}

alt::IColShape* Server_CreateColShapeCube(alt::ICore* server, position_t pos, position_t pos2) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;

    alt::Position position2;
    position2.x = pos2.x;
    position2.y = pos2.y;
    position2.z = pos2.z;
    return server->CreateColShapeCube(position, position2).Get();
}

alt::IColShape* Server_CreateColShapeRectangle(alt::ICore* server, float x1, float y1, float x2, float y2, float z) {
    return server->CreateColShapeRectangle(x1, y1, x2, y2, z).Get();
}

/*void Server_DestroyBaseObject(alt::ICore* server, alt::IBaseObject* baseObject) {
    return server->DestroyBaseObject(baseObject);
}*/

void Server_DestroyVehicle(alt::ICore* server, alt::IVehicle* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyBlip(alt::ICore* server, alt::IBlip* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyCheckpoint(alt::ICore* server, alt::ICheckpoint* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyVoiceChannel(alt::ICore* server, alt::IVoiceChannel* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyColShape(alt::ICore* server, alt::IColShape* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

int32_t Server_GetNetTime(alt::ICore* server) {
    return server->GetNetTime();
}

void Server_GetRootDirectory(alt::ICore* server, const char*&text) {
    text = server->GetRootDirectory().CStr();
}

uint64_t Server_GetPlayerCount(alt::ICore* server) {
    return server->GetPlayers().GetSize();
}

void Server_GetPlayers(alt::ICore* server, alt::IPlayer* players[], uint64_t size) {
    auto playersArray = server->GetPlayers();
    if (playersArray.GetSize() < size) {
        size = playersArray.GetSize();
    }
    for (uint64_t i = 0; i < size; i++) {
        players[i] = playersArray[i].Get();
    }
}

uint64_t Server_GetVehicleCount(alt::ICore* server) {
    return server->GetVehicles().GetSize();
}

void Server_GetVehicles(alt::ICore* server, alt::IVehicle* vehicles[], uint64_t size) {
    auto vehiclesArray = server->GetVehicles();
    if (vehiclesArray.GetSize() < size) {
        size = vehiclesArray.GetSize();
    }
    for (uint64_t i = 0; i < size; i++) {
        vehicles[i] = vehiclesArray[i].Get();
    }
}

void* Server_GetEntityById(alt::ICore* core, uint16_t id, uint8_t& type) {
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

void Server_StartResource(alt::ICore* server, const char* text) {
    server->StartResource(text);
}

void Server_StopResource(alt::ICore* server, const char* text) {
    server->StopResource(text);
}

void Server_RestartResource(alt::ICore* server, const char* text) {
    server->RestartResource(text);
}

alt::MValueConst* Server_GetMetaData(alt::ICore* core, const char* key) {
    return new alt::MValueConst(core->GetMetaData(key));
}

void Server_SetMetaData(alt::ICore* core, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    core->SetMetaData(key, val->Get()->Clone());
}

uint8_t Server_HasMetaData(alt::ICore* core, const char* key) {
    return core->HasMetaData(key);
}

void Server_DeleteMetaData(alt::ICore* core, const char* key) {
    core->DeleteMetaData(key);
}

alt::MValueConst* Server_GetSyncedMetaData(alt::ICore* core, const char* key) {
    return new alt::MValueConst(core->GetSyncedMetaData(key));
}

void Server_SetSyncedMetaData(alt::ICore* core, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    core->SetSyncedMetaData(key, val->Get()->Clone());
}

uint8_t Server_HasSyncedMetaData(alt::ICore* core, const char* key) {
    return core->HasSyncedMetaData(key);
}

void Server_DeleteSyncedMetaData(alt::ICore* core, const char* key) {
    core->DeleteSyncedMetaData(key);
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

/*alt::MValueBaseObject* Core_CreateMValueBaseObject(alt::ICore* core, alt::Ref<alt::IBaseObject>* value) {
    auto mValue = core->CreateMValueBaseObject(*value);
    return new alt::Ref(mValue);
}*/

alt::MValueConst* Core_CreateMValueCheckpoint(alt::ICore* core, alt::ICheckpoint* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueBlip(alt::ICore* core, alt::IBlip* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueVoiceChannel(alt::ICore* core, alt::IVoiceChannel* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValuePlayer(alt::ICore* core, alt::IPlayer* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueVehicle(alt::ICore* core, alt::IVehicle* value) {
    alt::MValueConst mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value) {
    alt::MValueConst mValue = core->CreateMValueFunction(value);
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

uint8_t Core_IsDebug(alt::ICore* core) {
    return core->IsDebug();
}

void Core_GetVersion(alt::ICore* core, const char*&value, uint64_t &size) {
    auto version = core->GetVersion();
    value = version.GetData();
    size = version.GetSize();
}

void Core_GetBranch(alt::ICore* core, const char*&value, uint64_t &size) {
    auto version = core->GetBranch();
    value = version.GetData();
    size = version.GetSize();
}

void Core_SetPassword(alt::ICore* core, const char* value) {
    core->SetPassword(value);
}
