#include "voice_channel.h"
#include "../utils/strings.h"

#ifdef ALT_CLIENT_API
alt::IBaseObject* Audio_GetBaseObject(alt::IAudio* audio) {
    return dynamic_cast<alt::IBaseObject*>(audio);
}


uint32_t Audio_GetCategory(alt::IAudio* audio) {
    return audio->GetCategory();
}

void Audio_SetCategory(alt::IAudio* audio, uint32_t value) {
    audio->SetCategory(value);
}

double Audio_GetCurrentTime(alt::IAudio* audio) {
    return audio->GetCurrentTime();
}

uint8_t Audio_IsFrontendPlay(alt::IAudio* audio) {
    return audio->IsFrontendPlay();
}

uint8_t Audio_GetLooped(alt::IAudio* audio) {
    return audio->IsLoop();
}

void Audio_SetLooped(alt::IAudio* audio, uint8_t value) {
    return audio->SetLoop(value);
}

double Audio_GetMaxTime(alt::IAudio* audio) {
    return audio->GetMaxTime();
}

uint8_t Audio_IsPlaying(alt::IAudio* audio) {
    return audio->IsPlaying();
}

const char* Audio_GetSource(alt::IAudio* audio, int32_t& size) {
    return AllocateString(audio->GetSource(), size);
}

float Audio_GetVolume(alt::IAudio* audio) {
    return audio->GetVolume();
}

void Audio_SetVolume(alt::IAudio* audio, float value) {
    audio->SetVolume(value);
}


void Audio_AddOutput_ScriptId(alt::IAudio* audio, uint32_t value) {
    audio->AddOutput(value);
}

void Audio_AddOutput_Entity(alt::IAudio* audio, alt::IEntity* value) {
    audio->AddOutput(value);
}

void Audio_RemoveOutput_ScriptId(alt::IAudio* audio, uint32_t value) {
    audio->RemoveOutput(value);
}

void Audio_RemoveOutput_Entity(alt::IAudio* audio, alt::IEntity* value) {
    audio->RemoveOutput(value);
}

alt::MValueConst** Audio_GetOutputs(alt::IAudio* audio, uint32_t& size) {
    auto outputs = audio->GetOutputs();
    size = outputs->GetSize();
    auto arr = new alt::MValueConst*[size];

    for (auto i = 0; i < size; i++) arr[i] = (alt::MValueConst *) outputs->Get(i).Get();
    return arr;
}

void Audio_Pause(alt::IAudio* audio) {
    audio->Pause();
}

void Audio_Play(alt::IAudio* audio) {
    audio->Play();
}

void Audio_Reset(alt::IAudio* audio) {
    audio->Reset();
}

void Audio_Seek(alt::IAudio* audio, double time) {
    audio->Seek(time);
}
#endif