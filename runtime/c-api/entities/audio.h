#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_CLIENT alt::IBaseObject* Audio_GetBaseObject(alt::IAudio* audio);

EXPORT_CLIENT uint32_t Audio_GetCategory(alt::IAudio* audio);
EXPORT_CLIENT void Audio_SetCategory(alt::IAudio* audio, uint32_t value);
EXPORT_CLIENT double Audio_GetCurrentTime(alt::IAudio* audio);
EXPORT_CLIENT uint8_t Audio_IsFrontendPlay(alt::IAudio* audio);
EXPORT_CLIENT uint8_t Audio_GetLooped(alt::IAudio* audio);
EXPORT_CLIENT void Audio_SetLooped(alt::IAudio* audio, uint8_t value);
EXPORT_CLIENT double Audio_GetMaxTime(alt::IAudio* audio);
EXPORT_CLIENT uint8_t Audio_IsPlaying(alt::IAudio* audio);
EXPORT_CLIENT const char* Audio_GetSource(alt::IAudio* audio, int32_t& size);
EXPORT_CLIENT void Audio_SetSource(alt::IAudio* audio, const char* source);
EXPORT_CLIENT float Audio_GetVolume(alt::IAudio* audio);
EXPORT_CLIENT void Audio_SetVolume(alt::IAudio* audio, float value);

EXPORT_CLIENT void Audio_AddOutput_ScriptId(alt::IAudio* audio, uint32_t value);
EXPORT_CLIENT void Audio_AddOutput_Entity(alt::IAudio* audio, alt::IEntity* value);
EXPORT_CLIENT void Audio_RemoveOutput_ScriptId(alt::IAudio* audio, uint32_t value);
EXPORT_CLIENT void Audio_RemoveOutput_Entity(alt::IAudio* audio, alt::IEntity* value);
EXPORT_CLIENT void Audio_GetOutputs(alt::IAudio* audio, void**& entityArray, uint8_t*& entityTypesArray, uint32_t*& scriptIdArray, uint32_t& size);
EXPORT_CLIENT void Audio_Pause(alt::IAudio* audio);
EXPORT_CLIENT void Audio_Play(alt::IAudio* audio);
EXPORT_CLIENT void Audio_Reset(alt::IAudio* audio);
EXPORT_CLIENT void Audio_Seek(alt::IAudio* audio, double time);

#ifdef __cplusplus
}
#endif
