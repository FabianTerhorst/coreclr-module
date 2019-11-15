#include "mvalue.h"

CustomInvoker* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val) {
    auto invoker = new CustomInvoker(val);
    resource->invokers->Push(invoker);
    return invoker;
}

void Invoker_Destroy(CSharpResourceImpl* resource, CustomInvoker* val) {
    auto newInvokers = new alt::Array<CustomInvoker*>();
    for (alt::Size i = 0, length = resource->invokers->GetSize(); i < length; i++) {
        auto invoker = (*resource->invokers)[i];
        if (invoker != val) {
            newInvokers->Push(invoker);
        }
    }
    delete val;
    delete resource->invokers;
    resource->invokers = newInvokers;
}

/*bool MValue_GetBool(alt::MValueBool &mValue) {
    return mValue.Get()->Value();
}*/

bool MValueConst_GetBool(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BOOL) {
        return dynamic_cast<const alt::IMValueBool*>(mValue)->Value();
    }
    return false;
}

bool MValue_GetBool(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BOOL) {
        return dynamic_cast<alt::IMValueBool*>(mValue)->Value();
    }
    return false;
}

/*int64_t MValue_GetInt(alt::MValueInt &mValue) {
    return mValue.Get()->Value();
}*/

int64_t MValueConst_GetInt(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::INT) {
        return dynamic_cast<const alt::IMValueInt*>(mValue)->Value();
    }
    return 0;
}

int64_t MValue_GetInt(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::INT) {
        return dynamic_cast<alt::IMValueInt*>(mValue)->Value();
    }
    return 0;
}

/*uint64_t MValue_GetUInt(alt::MValueUInt &mValue) {
    return mValue.Get()->Value();
}*/

uint64_t MValueConst_GetUInt(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::UINT) {
        return dynamic_cast<const alt::IMValueUInt*>(mValue)->Value();
    }
    return 0;
}

uint64_t MValue_GetUInt(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::UINT) {
        return dynamic_cast<alt::IMValueUInt*>(mValue)->Value();
    }
    return 0;
}

/*double MValue_GetDouble(alt::MValueDouble &mValue) {
    return mValue.Get()->Value();
}*/

double MValueConst_GetDouble(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DOUBLE) {
        return dynamic_cast<const alt::IMValueDouble*>(mValue)->Value();
    }
    return 0.0;
}

double MValue_GetDouble(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DOUBLE) {
        return dynamic_cast<alt::IMValueDouble*>(mValue)->Value();
    }
    return 0.0;
}

/*void MValue_GetString(alt::MValueString &mValue, const char*&value, uint64_t &size) {
    auto stringView = mValue.Get()->Value();
    value = stringView.CStr();
    size = stringView.GetSize();
}*/

bool MValueConst_GetString(alt::MValueConst* mValueConst, const char*&value, uint64_t &size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::STRING) {
        auto stringView = dynamic_cast<const alt::IMValueString*>(mValue)->Value();
        value = stringView.CStr();
        size = stringView.GetSize();
        return true;
    }
    return false;
}

bool MValue_GetString(alt::MValue* mValueConst, const char*&value, uint64_t &size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::STRING) {
        auto stringView = dynamic_cast<alt::IMValueString*>(mValue)->Value();
        value = stringView.CStr();
        size = stringView.GetSize();
        return true;
    }
    return false;
}

/*void MValue_GetList(alt::MValueList &mValue, alt::Array<alt::MValue> &value) {
    auto list = mValue.Get();
    auto size = list->GetSize();
    value = alt::Array<alt::MValue>(size);
    for (uint64_t i = 0;i < size;i++) {
        value.Push(list->Get(i));
    }
}*/

uint64_t MValueConst_GetListSize(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::LIST) {
        auto list = dynamic_cast<const alt::IMValueList*>(mValue);
        if (list == nullptr) return 0;
        return list->GetSize();
    }
    return 0;
}

uint64_t MValue_GetListSize(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::LIST) {
        auto list = dynamic_cast<alt::IMValueList*>(mValue);
        if (list == nullptr) return 0;
        return list->GetSize();
    }
    return 0;
}

bool MValueConst_GetList(alt::MValueConst* mValueConst, alt::MValueConst* values[]) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::LIST) {
        auto list = dynamic_cast<const alt::IMValueList*>(mValue);
        for (uint64_t i = 0, length = list->GetSize(); i < length; i++) {
            alt::MValueConst mValueElement = list->Get(i);
            values[i] = new alt::MValueConst(mValueElement);
        }
        return true;
    }
    return false;
}

bool MValue_GetList(alt::MValue* mValueConst, alt::MValue* values[]) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::LIST) {
        auto list = dynamic_cast<alt::IMValueList*>(mValue);
        for (uint64_t i = 0, length = list->GetSize(); i < length; i++) {
            alt::MValue mValueElement = list->Get(i);
            values[i] = &mValueElement;
        }
        return true;
    }
    return false;
}

/*void MValue_GetDict(alt::MValueDict &mValue, alt::Array<alt::String> &keys, alt::Array<alt::MValueConst> &values) {
    auto dict = mValue.Get();
    auto next = dict->Begin();
    keys = alt::Array<alt::String>(dict->GetSize());
    values = alt::Array<alt::MValueConst>(dict->GetSize());
    do {
        keys.Push(next->GetKey());
        values.Push(next->GetValue());
    } while((next = dict->Next()) != nullptr);
}*/

uint64_t MValueConst_GetDictSize(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DICT) {
        auto dict = dynamic_cast<const alt::IMValueDict*>(mValue);
        if (dict == nullptr) return 0;
        return dict->GetSize();
    }
    return 0;
}

uint64_t MValue_GetDictSize(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DICT) {
        auto dict = dynamic_cast<alt::IMValueDict*>(mValue);
        if (dict == nullptr) return 0;
        return dict->GetSize();
    }
    return 0;
}

bool MValueConst_GetDict(alt::MValueConst* mValueConst, const char* keys[],
                         alt::MValueConst* values[]) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DICT) {
        auto dict = dynamic_cast<const alt::IMValueDict*>(mValue);
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

bool MValue_GetDict(alt::MValue* mValueConst, const char* keys[],
                         alt::MValueConst* values[]) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::DICT) {
        auto dict = dynamic_cast<alt::IMValueDict*>(mValue);
        auto next = dict->Begin();
        if (next == nullptr) return true;
        uint64_t i = 0;
        do {
            keys[i] = next->GetKey().CStr();
            alt::MValueConst mValueElement = next->GetValue();
            values[i] = &mValueElement;
            i++;
        } while ((next = dict->Next()) != nullptr);
        return true;
    }
    return false;
}

/*void* MValue_GetEntity(alt::MValueBaseObject &mValue, alt::IBaseObject::Type &type) {
    auto entityPointer = mValue.Get()->Value().Get();
    if (entityPointer != nullptr) {
        type = entityPointer->GetType();
        switch (type) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(entityPointer);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(entityPointer);
            case alt::IBaseObject::Type::BLIP:
                return dynamic_cast<alt::IBlip*>(entityPointer);
            case alt::IBaseObject::Type::CHECKPOINT:
                return dynamic_cast<alt::ICheckpoint*>(entityPointer);
            default:
                return nullptr;
        }
    }
    return nullptr;
}*/

void* MValueConst_GetEntity(alt::MValueConst* mValueConst, alt::IBaseObject::Type &type) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BASE_OBJECT) {
        auto entityPointer = dynamic_cast<const alt::IMValueBaseObject*>(mValue)->Value().Get();
        if (entityPointer != nullptr) {
            type = entityPointer->GetType();
            switch (type) {
                case alt::IBaseObject::Type::PLAYER:
                    return dynamic_cast<alt::IPlayer*>(entityPointer);
                case alt::IBaseObject::Type::VEHICLE:
                    return dynamic_cast<alt::IVehicle*>(entityPointer);
                case alt::IBaseObject::Type::BLIP:
                    return dynamic_cast<alt::IBlip*>(entityPointer);
                case alt::IBaseObject::Type::VOICE_CHANNEL:
                    return dynamic_cast<alt::IVoiceChannel*>(entityPointer);
                case alt::IBaseObject::Type::COLSHAPE:
                    if (auto checkpoint = dynamic_cast<alt::ICheckpoint*>(entityPointer)) {
                        return checkpoint;
                    } else {
                        auto colShape = dynamic_cast<alt::IColShape*>(entityPointer);
                        return colShape;
                    }
                default:
                    return nullptr;
            }
        }
    }
    return nullptr;
}

void* MValue_GetEntity(alt::MValue* mValueConst, alt::IBaseObject::Type &type) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::BASE_OBJECT) {
        auto entityPointer = dynamic_cast<alt::IMValueBaseObject*>(mValue)->Value().Get();
        if (entityPointer != nullptr) {
            type = entityPointer->GetType();
            switch (type) {
                case alt::IBaseObject::Type::PLAYER:
                    return dynamic_cast<alt::IPlayer*>(entityPointer);
                case alt::IBaseObject::Type::VEHICLE:
                    return dynamic_cast<alt::IVehicle*>(entityPointer);
                case alt::IBaseObject::Type::BLIP:
                    return dynamic_cast<alt::IBlip*>(entityPointer);
                case alt::IBaseObject::Type::COLSHAPE:
                    if (auto checkpoint = dynamic_cast<alt::ICheckpoint*>(entityPointer)) {
                        return checkpoint;
                    } else {
                        auto colShape = dynamic_cast<alt::IColShape*>(entityPointer);
                        return colShape;
                    }
                default:
                    return nullptr;
            }
        }
    }
    return nullptr;
}

/*void MValue_CallFunction(alt::MValueFunction& mValue, alt::MValue val[], int32_t size, alt::MValue &result) {
    alt::MValueArgs value = alt::Array<alt::MValueConst>(size);
    for (int i = 0; i < size; i++) {
        value.Push(val[i]);
    }
    mValue.Get()->Call(value);
}*/

alt::MValueConst* MValueConst_CallFunction(alt::MValueConst* mValueConst, alt::MValueConst* val[], uint64_t size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::FUNCTION) {
        alt::MValueArgs value = alt::Array<alt::MValueConst>(size);
        for (uint64_t i = 0; i < size; i++) {
            value.Push(*val[i]);
        }
        auto mValueFunction = dynamic_cast<const alt::IMValueFunction*>(mValue);
        return new alt::MValueConst(mValueFunction->Call(value));
    }
    return nullptr;
}

alt::MValue* MValue_CallFunction(alt::MValue* mValueConst, alt::MValue* val[], uint64_t size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::FUNCTION) {
        alt::MValueArgs value = alt::Array<alt::MValueConst>(size);
        for (uint64_t i = 0; i < size; i++) {
            value.Push(*val[i]);
        }
        auto mValueFunction = dynamic_cast<alt::IMValueFunction*>(mValue);
        return new alt::Ref(mValueFunction->Call(value));
    }
    return nullptr;
}

/*void MValue_Dispose(alt::MValue* mValue) {
    mValue->Free();
}*/

void MValueConst_Delete(alt::MValueConst* mValueConst) {
    delete mValueConst;
}

void MValue_Delete(alt::MValue* mValue) {
    delete mValue;
}

uint8_t MValueConst_GetType(alt::MValueConst* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue == nullptr) return (uint8_t) alt::IMValue::Type::NIL;
    return (uint8_t) mValue->GetType();
}

uint8_t MValue_GetType(alt::MValue* mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue == nullptr) return (uint8_t) alt::IMValue::Type::NIL;
    return (uint8_t) mValue->GetType();
}