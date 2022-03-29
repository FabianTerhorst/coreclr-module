#include "../../../cpp-sdk/SDK.h"
#include <Log.h>
#include "mvalue.h"

using namespace alt;

void MValueConst_AddRef(alt::MValueConst *mValueConst) {
    (*mValueConst)->AddRef();
}

void MValueConst_RemoveRef(alt::MValueConst *mValueConst) {
    (*mValueConst)->RemoveRef();
}

uint8_t MValueConst_GetBool(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BOOL) {
        return dynamic_cast<const alt::IMValueBool *>(mValue)->Value();
    }
    return false;
}

int64_t MValueConst_GetInt(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::INT) {
        return dynamic_cast<const alt::IMValueInt *>(mValue)->Value();
    }
    return 0;
}

uint64_t MValueConst_GetUInt(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::UINT) {
        return dynamic_cast<const alt::IMValueUInt *>(mValue)->Value();
    }
    return 0;
}

double MValueConst_GetDouble(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DOUBLE) {
        return dynamic_cast<const alt::IMValueDouble *>(mValue)->Value();
    }
    return 0.0;
}

uint8_t MValueConst_GetString(alt::MValueConst *mValueConst, const char *&value, uint64_t &size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::STRING) {
        auto stringView = dynamic_cast<const alt::IMValueString *>(mValue)->Value();
        value = stringView.CStr();
        size = stringView.GetSize();
        return true;
    }
    return false;
}

uint64_t MValueConst_GetListSize(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::LIST) {
        auto list = dynamic_cast<const alt::IMValueList *>(mValue);
        if (list == nullptr) return 0;
        return list->GetSize();
    }
    return 0;
}

uint8_t MValueConst_GetList(alt::MValueConst *mValueConst, alt::MValueConst *values[]) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::LIST) {
        auto list = dynamic_cast<const alt::IMValueList *>(mValue);
        for (uint64_t i = 0, length = list->GetSize(); i < length; i++) {
            alt::MValueConst mValueElement = list->Get(i);
            values[i] = new alt::MValueConst(mValueElement);
        }
        return true;
    }
    return false;
}

uint64_t MValueConst_GetDictSize(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DICT) {
        auto dict = dynamic_cast<const alt::IMValueDict *>(mValue);
        if (dict == nullptr) return 0;
        return dict->GetSize();
    }
    return 0;
}

uint8_t MValueConst_GetDict(alt::MValueConst *mValueConst, const char *keys[],
                            alt::MValueConst *values[]) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DICT) {
        auto dict = dynamic_cast<const alt::IMValueDict *>(mValue);
        auto next = dict->Begin();
        if (next == nullptr) return true;
        uint64_t i = 0;
        do {
            auto key = next->GetKey();
            auto keySize = key.GetSize();
            auto keyArray = new char[keySize + 1];
            memcpy(keyArray, key.CStr(), keySize);
            keyArray[keySize] = '\0';
            keys[i] = keyArray;
            alt::MValueConst mValueElement = next->GetValue();
            values[i] = new alt::MValueConst(mValueElement);
            i++;
        } while ((next = dict->Next()) != nullptr);
        return true;
    }
    return false;
}

void *MValueConst_GetEntity(alt::MValueConst *mValueConst, alt::IBaseObject::Type &type) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BASE_OBJECT) {
        auto entityPointer = dynamic_cast<const alt::IMValueBaseObject *>(mValue)->Value().Get();
        if (entityPointer != nullptr) {
            type = entityPointer->GetType();
            switch (type) {
                case alt::IBaseObject::Type::PLAYER:
                    return dynamic_cast<alt::IPlayer *>(entityPointer);
                case alt::IBaseObject::Type::VEHICLE:
                    return dynamic_cast<alt::IVehicle *>(entityPointer);
                case alt::IBaseObject::Type::BLIP:
                    return dynamic_cast<alt::IBlip *>(entityPointer);
                case alt::IBaseObject::Type::VOICE_CHANNEL:
                    return dynamic_cast<alt::IVoiceChannel *>(entityPointer);
                case alt::IBaseObject::Type::COLSHAPE:
                    return dynamic_cast<alt::IColShape *>(entityPointer);
                case alt::IBaseObject::Type::CHECKPOINT:
                    return dynamic_cast<alt::ICheckpoint *>(entityPointer);
                default:
                    return nullptr;
            }
        }
    }
    return nullptr;
}

alt::MValueConst* MValueConst_CallFunction(alt::ICore *core, alt::MValueConst *mValueConst, alt::MValueConst *val[], uint64_t size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::FUNCTION) {
        alt::MValueArgs value = alt::Array<alt::MValueConst>(size);
        for (uint64_t i = 0; i < size; i++) {
            if (val == nullptr) {
                value[i] = core->CreateMValueNil();
            } else {
                value[i] = *val[i];
            }
        }
        auto mValueFunction = dynamic_cast<const alt::IMValueFunction *>(mValue);
        auto result = new alt::MValueConst(mValueFunction->Call(value));
        return result;
    }
    return nullptr;
}

void MValueConst_GetVector3(alt::MValueConst *mValueConst, vector3_t &position) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::VECTOR3) {
        auto vector = dynamic_cast<const alt::IMValueVector3 *>(mValue)->Value();
        position.x = vector[0];
        position.y = vector[1];
        position.z = vector[2];
    }
}

void MValueConst_GetRGBA(alt::MValueConst *mValueConst, rgba_t &rgba) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::RGBA) {
        auto rgbaValue = dynamic_cast<const alt::IMValueRGBA *>(mValue)->Value();
        rgba.r = rgbaValue.r;
        rgba.g = rgbaValue.g;
        rgba.b = rgbaValue.b;
        rgba.a = rgbaValue.a;
    }
}

void MValueConst_GetByteArray(alt::MValueConst *mValueConst, uint64_t size, void *data) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::RGBA) {
        auto byteArrayMValue = dynamic_cast<const alt::IMValueByteArray *>(mValue);
        auto byteArraySize = byteArrayMValue->GetSize();
        if (byteArraySize < size) {
            size = byteArraySize;
        }
        auto byteArray = byteArrayMValue->GetData();
        memcpy(data, byteArray, size);
    }
}

uint64_t MValueConst_GetByteArraySize(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BYTE_ARRAY) {
        return dynamic_cast<const alt::IMValueByteArray *>(mValue)->GetSize();
    }
    return 0;
}

void MValueConst_Delete(alt::MValueConst *mValueConst) {
    delete mValueConst;
}

uint8_t MValueConst_GetType(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue == nullptr) return (uint8_t) alt::IMValue::Type::NIL;
    return (uint8_t) mValue->GetType();
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

//alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value) {
//    alt::MValueConst mValue = core->CreateMValueFunction(value);
//    return new alt::MValueConst(mValue);
//}

alt::MValueConst* Core_CreateMValueVector3(alt::ICore* core, vector3_t value) {
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