#include "mvalue.h"
#include "utils/strings.h"

void ToMValueDict(alt::MValueDict& mValues, std::string& key, alt::ICore *core, alt::MValueConst *val);
void ToMValueList(alt::MValueList& mValues, alt::ICore *core, alt::MValueConst *val, alt::Size i);

void ToMValueArg(alt::MValueArgs& mValues, alt::ICore *core, alt::MValueConst *val, alt::Size i) {
    if (val == nullptr) {
        mValues[i] = core->CreateMValueNil();
        return;
    }
    auto mValue = val->Get();
    switch (mValue->GetType()) {
        case alt::IMValue::Type::NONE:
            mValues[i] = core->CreateMValueNone();
            return;
        case alt::IMValue::Type::NIL:
            mValues[i] = core->CreateMValueNil();
            return;
        case alt::IMValue::Type::BOOL:
            mValues[i] = core->CreateMValueBool(dynamic_cast<const alt::IMValueBool*>(mValue)->Value());
            return;
        case alt::IMValue::Type::INT:
            mValues[i] = core->CreateMValueInt(dynamic_cast<const alt::IMValueInt*>(mValue)->Value());
            return;
        case alt::IMValue::Type::UINT:
            mValues[i] = core->CreateMValueUInt(dynamic_cast<const alt::IMValueUInt*>(mValue)->Value());
            return;
        case alt::IMValue::Type::DOUBLE:
            mValues[i] = core->CreateMValueDouble(dynamic_cast<const alt::IMValueDouble*>(mValue)->Value());
            return;
        case alt::IMValue::Type::STRING:
            mValues[i] = core->CreateMValueString(dynamic_cast<const alt::IMValueString*>(mValue)->Value());
            return;
        case alt::IMValue::Type::LIST: {
            auto cVal = dynamic_cast<const alt::IMValueList*>(mValue);
            auto length = cVal->GetSize();
            alt::MValueList list = core->CreateMValueList(length);

            alt::MValueConst innerVal;
            for (uint32_t j = 0; j < length; ++j) {
                innerVal = cVal->Get(j);
                ToMValueList(list, core, &innerVal, j);
            }

            mValues[i] = list;
            return;
        }
        case alt::IMValue::Type::DICT: {
            auto cVal = dynamic_cast<const alt::IMValueDict*>(mValue);
            alt::MValueDict dict = core->CreateMValueDict();

            alt::MValueConst innerVal;
            alt::IMValueDict::Iterator *it = cVal->Begin();
            std::string key;
            while (it != nullptr) {
                innerVal = it->GetValue();
                key = it->GetKey();
                ToMValueDict(dict, key, core, &innerVal);
                it = cVal->Next();
            }
            mValues[i] = dict;
            return;
        }
        case alt::IMValue::Type::BASE_OBJECT:
            mValues[i] = core->CreateMValueBaseObject(dynamic_cast<const alt::IMValueBaseObject*>(mValue)->Value());
            return;
        case alt::IMValue::Type::FUNCTION:
            mValues[i] = mValue;
            return; //TODO: fix //core->CreateMValueNone();//core->CreateMValueFunction(dynamic_cast<const alt::IMValueFunction*>(mValue)->Call);
        case alt::IMValue::Type::VECTOR3:
            mValues[i] = core->CreateMValueVector3(dynamic_cast<const alt::IMValueVector3*>(mValue)->Value());
            return;
        case alt::IMValue::Type::RGBA:
            mValues[i] = core->CreateMValueRGBA(dynamic_cast<const alt::IMValueRGBA*>(mValue)->Value());
            return;
        case alt::IMValue::Type::BYTE_ARRAY: {
            auto cVal = dynamic_cast<const alt::IMValueByteArray *>(mValue);
            mValues[i] = core->CreateMValueByteArray(cVal->GetData(), cVal->GetSize());
            return;
        }
        case alt::IMValue::Type::VECTOR2:
            mValues[i] = core->CreateMValueVector2(dynamic_cast<const alt::IMValueVector2*>(mValue)->Value());
            return;
        default:
            mValues[i] = core->CreateMValueNone();
            return;
    }
}

void ToMValueList(alt::MValueList& mValues, alt::ICore *core, alt::MValueConst *val, alt::Size i) {
    if (val == nullptr) {
        mValues->SetConst(i, core->CreateMValueNil());
        return;
    }
    auto mValue = val->Get();
    switch (mValue->GetType()) {
        case alt::IMValue::Type::NONE:
            mValues->SetConst(i, core->CreateMValueNone());
            return;
        case alt::IMValue::Type::NIL:
            mValues->SetConst(i, core->CreateMValueNil());
            return;
        case alt::IMValue::Type::BOOL:
            mValues->SetConst(i, core->CreateMValueBool(dynamic_cast<const alt::IMValueBool*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::INT:
            mValues->SetConst(i, core->CreateMValueInt(dynamic_cast<const alt::IMValueInt*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::UINT:
            mValues->SetConst(i, core->CreateMValueUInt(dynamic_cast<const alt::IMValueUInt*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::DOUBLE:
            mValues->SetConst(i, core->CreateMValueDouble(dynamic_cast<const alt::IMValueDouble*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::STRING:
            mValues->SetConst(i, core->CreateMValueString(dynamic_cast<const alt::IMValueString*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::LIST: {
            auto cVal = dynamic_cast<const alt::IMValueList*>(mValue);
            auto length = cVal->GetSize();
            alt::MValueList list = core->CreateMValueList(length);

            alt::MValueConst innerVal;
            for (uint32_t j = 0; j < length; ++j) {
                innerVal = cVal->Get(j);
                ToMValueList(list, core, &innerVal, j);
            }

            mValues->SetConst(i, list);
            return;
        }
        case alt::IMValue::Type::DICT: {
            auto cVal = dynamic_cast<const alt::IMValueDict*>(mValue);
            alt::MValueDict dict = core->CreateMValueDict();

            alt::MValueConst innerVal;
            alt::IMValueDict::Iterator *it = cVal->Begin();
            std::string key;
            while (it != nullptr) {
                innerVal = it->GetValue();
                key = it->GetKey();
                ToMValueDict(dict, key, core, &innerVal);
                it = cVal->Next();
            }
            mValues->SetConst(i, dict);
            return;
        }
        case alt::IMValue::Type::BASE_OBJECT:
            mValues->SetConst(i, core->CreateMValueBaseObject(dynamic_cast<const alt::IMValueBaseObject*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::FUNCTION:
            mValues->SetConst(i, mValue);
            return; //TODO: fix //core->CreateMValueNone();//core->CreateMValueFunction(dynamic_cast<const alt::IMValueFunction*>(mValue)->Call);
        case alt::IMValue::Type::VECTOR3:
            mValues->SetConst(i, core->CreateMValueVector3(dynamic_cast<const alt::IMValueVector3*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::RGBA:
            mValues->SetConst(i, core->CreateMValueRGBA(dynamic_cast<const alt::IMValueRGBA*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::BYTE_ARRAY: {
            auto cVal = dynamic_cast<const alt::IMValueByteArray *>(mValue);
            mValues->SetConst(i, core->CreateMValueByteArray(cVal->GetData(), cVal->GetSize()));
            return;
        }
        case alt::IMValue::Type::VECTOR2:
            mValues->SetConst(i, core->CreateMValueVector2(dynamic_cast<const alt::IMValueVector2*>(mValue)->Value()));
            return;
        default:
            mValues->SetConst(i, core->CreateMValueNone());
            return;
    }
}

void ToMValueDict(alt::MValueDict& mValues, std::string& key, alt::ICore *core, alt::MValueConst *val) {
    if (val == nullptr) {
        mValues->SetConst(key, core->CreateMValueNil());
        return;
    }
    auto mValue = val->Get();
    switch (mValue->GetType()) {
        case alt::IMValue::Type::NONE:
            mValues->SetConst(key, core->CreateMValueNone());
            return;
        case alt::IMValue::Type::NIL:
            mValues->SetConst(key, core->CreateMValueNil());
            return;
        case alt::IMValue::Type::BOOL:
            mValues->SetConst(key, core->CreateMValueBool(dynamic_cast<const alt::IMValueBool*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::INT:
            mValues->SetConst(key, core->CreateMValueInt(dynamic_cast<const alt::IMValueInt*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::UINT:
            mValues->SetConst(key, core->CreateMValueUInt(dynamic_cast<const alt::IMValueUInt*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::DOUBLE:
            mValues->SetConst(key, core->CreateMValueDouble(dynamic_cast<const alt::IMValueDouble*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::STRING:
            mValues->SetConst(key, core->CreateMValueString(dynamic_cast<const alt::IMValueString*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::LIST: {
            auto cVal = dynamic_cast<const alt::IMValueList*>(mValue);
            auto length = cVal->GetSize();
            alt::MValueList list = core->CreateMValueList(length);

            alt::MValueConst innerVal;
            for (uint32_t i = 0; i < length; ++i) {
                innerVal = cVal->Get(i);
                ToMValueList(list, core, &innerVal, i);
            }

            mValues->SetConst(key, list);
            return;
        }
        case alt::IMValue::Type::DICT: {
            auto cVal = dynamic_cast<const alt::IMValueDict*>(mValue);
            alt::MValueDict dict = core->CreateMValueDict();

            alt::MValueConst innerVal;
            alt::IMValueDict::Iterator *it = cVal->Begin();
            std::string innerKey;
            while (it != nullptr) {
                innerVal = it->GetValue();
                innerKey = it->GetKey();
                ToMValueDict(dict, innerKey, core, &innerVal);
                it = cVal->Next();
            }
            mValues->SetConst(key, dict);
            return;
        }
        case alt::IMValue::Type::BASE_OBJECT:
            mValues->SetConst(key, core->CreateMValueBaseObject(dynamic_cast<const alt::IMValueBaseObject*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::FUNCTION:
            mValues->SetConst(key, mValue);
            return; //TODO: fix //core->CreateMValueNone();//core->CreateMValueFunction(dynamic_cast<const alt::IMValueFunction*>(mValue)->Call);
        case alt::IMValue::Type::VECTOR3:
            mValues->SetConst(key, core->CreateMValueVector3(dynamic_cast<const alt::IMValueVector3*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::RGBA:
            mValues->SetConst(key, core->CreateMValueRGBA(dynamic_cast<const alt::IMValueRGBA*>(mValue)->Value()));
            return;
        case alt::IMValue::Type::BYTE_ARRAY: {
            auto cVal = dynamic_cast<const alt::IMValueByteArray *>(mValue);
            mValues->SetConst(key, core->CreateMValueByteArray(cVal->GetData(), cVal->GetSize()));
            return;
        }
        case alt::IMValue::Type::VECTOR2:
            mValues->SetConst(key, core->CreateMValueVector2(dynamic_cast<const alt::IMValueVector2*>(mValue)->Value()));
            return;
        default:
            mValues->SetConst(key, core->CreateMValueNone());
            return;
    }
}

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

const char* MValueConst_GetString(alt::MValueConst *mValueConst, int32_t &size) {
    auto mValue = mValueConst->Get();
    if (mValue != nullptr && mValue->GetType() == alt::IMValue::Type::STRING) {
        auto string = dynamic_cast<const alt::IMValueString *>(mValue)->Value();
        return AllocateString(string, size);
    }
    return nullptr;
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
            auto keySize = key.size();
            auto keyArray = new char[keySize + 1];
            memcpy(keyArray, key.c_str(), keySize);
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

alt::MValueConst *
MValueConst_CallFunction(alt::ICore *core, alt::MValueConst *mValueConst, alt::MValueConst *val[], uint64_t size) {
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

void MValueConst_GetVector3(alt::MValueConst *mValueConst, position_t &position) {
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


/*void MValue_Dispose(alt::MValue* mValue) {
    mValue->Free();
}*/

void MValueConst_Delete(alt::MValueConst *mValueConst) {
    delete mValueConst;
}

uint8_t MValueConst_GetType(alt::MValueConst *mValueConst) {
    auto mValue = mValueConst->Get();
    if (mValue == nullptr) return (uint8_t) alt::IMValue::Type::NIL;
    return (uint8_t) mValue->GetType();
}

CustomInvoker *Invoker_Create(CSharpResourceImpl *resource, MValueFunctionCallback val) {
    auto invoker = new CustomInvoker(val);
    resource->invokers->Push(invoker);
    return invoker;
}

void Invoker_Destroy(CSharpResourceImpl *resource, CustomInvoker *val) {
    auto newInvokers = new alt::Array<CustomInvoker *>();
    for (alt::Size i = 0, length = resource->invokers->GetSize(); i < length; i++) {
        auto invoker = (*resource->invokers)[i];
        if (invoker != val) {
            newInvokers->Push(invoker);
        }
    }
    alt::Array<CustomInvoker *> *oldInvokers = resource->invokers;
    resource->invokers = newInvokers;
    delete val;
    delete oldInvokers;
}