#include "voice_channel.h"

alt::MValueConst* VoiceChannel_GetMetaData(alt::IVoiceChannel* voiceChannel, const char* key) {
    return new alt::ConstRef(voiceChannel->GetMetaData(key));
}

void VoiceChannel_SetMetaData(alt::IVoiceChannel* channel, const char* key, alt::MValue* val) {
    channel->SetMetaData(key, *val);
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

bool VoiceChannel_IsPlayerConnected(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    return channel->IsPlayerConnected(player);
}

bool VoiceChannel_IsPlayerMuted(alt::IVoiceChannel* channel, alt::IPlayer* player) {
    return channel->IsPlayerMuted(player);
}

bool VoiceChannel_IsSpatial(alt::IVoiceChannel* channel) {
    return channel->IsSpatial();
}

float VoiceChannel_GetMaxDistance(alt::IVoiceChannel* channel) {
    return channel->GetMaxDistance();
}
