#include "voice_channel.h"

#ifdef ALT_SERVER_API
alt::IBaseObject* VoiceChannel_GetBaseObject(alt::IVoiceChannel* channel) {
    return dynamic_cast<alt::IBaseObject*>(channel);
}

alt::MValueConst* VoiceChannel_GetMetaData(alt::IVoiceChannel* voiceChannel, const char* key) {
    return new alt::MValueConst(voiceChannel->GetMetaData(key));
}

void VoiceChannel_SetMetaData(alt::IVoiceChannel* channel, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    channel->SetMetaData(key, val->Get()->Clone());
}

uint8_t VoiceChannel_HasMetaData(alt::IVoiceChannel* voiceChannel, const char* key) {
    return voiceChannel->HasMetaData(key);
}

void VoiceChannel_DeleteMetaData(alt::IVoiceChannel* voiceChannel, const char* key) {
    voiceChannel->DeleteMetaData(key);
}

void VoiceChannel_AddRef(alt::IVoiceChannel* voiceChannel) {
    voiceChannel->AddRef();
}

void VoiceChannel_RemoveRef(alt::IVoiceChannel* voiceChannel) {
    voiceChannel->RemoveRef();
}

void VoiceChannel_AddPlayer(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    channel->AddPlayer(player);
}

void VoiceChannel_RemovePlayer(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    channel->RemovePlayer(player);
}

void VoiceChannel_MutePlayer(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    channel->MutePlayer(player);
}

void VoiceChannel_UnmutePlayer(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    channel->UnmutePlayer(player);
}

uint8_t VoiceChannel_IsPlayerConnected(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    return channel->HasPlayer(player);
}

uint8_t VoiceChannel_HasPlayer(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    return channel->HasPlayer(player);
}

uint8_t VoiceChannel_IsPlayerMuted(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    return channel->IsPlayerMuted(player);
}

uint8_t VoiceChannel_IsSpatial(alt::IVoiceChannel* channel) {
    return channel->IsSpatial();
}

float VoiceChannel_GetMaxDistance(alt::IVoiceChannel* channel) {
    return channel->GetMaxDistance();
}
#endif