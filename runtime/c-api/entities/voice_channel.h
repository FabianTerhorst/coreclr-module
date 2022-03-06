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

EXPORT_SERVER alt::IBaseObject* VoiceChannel_GetBaseObject(alt::IVoiceChannel* voiceChannel);

EXPORT_SERVER alt::MValueConst* VoiceChannel_GetMetaData(alt::IVoiceChannel* voiceChannel, const char* key);
EXPORT_SERVER void VoiceChannel_SetMetaData(alt::IVoiceChannel* channel, const char* key, alt::MValueConst* val);
EXPORT_SERVER uint8_t VoiceChannel_HasMetaData(alt::IVoiceChannel* voiceChannel, const char* key);
EXPORT_SERVER void VoiceChannel_DeleteMetaData(alt::IVoiceChannel* voiceChannel, const char* key);
EXPORT_SERVER void VoiceChannel_AddRef(alt::IVoiceChannel* voiceChannel);
EXPORT_SERVER void VoiceChannel_RemoveRef(alt::IVoiceChannel* voiceChannel);

EXPORT_SERVER void VoiceChannel_AddPlayer(alt::IVoiceChannel* channel, alt::IPlayer* player);
EXPORT_SERVER void VoiceChannel_RemovePlayer(alt::IVoiceChannel* channel, alt::IPlayer* player);
EXPORT_SERVER void VoiceChannel_MutePlayer(alt::IVoiceChannel* channel, alt::IPlayer* player);
EXPORT_SERVER void VoiceChannel_UnmutePlayer(alt::IVoiceChannel* channel, alt::IPlayer* player);
EXPORT_SERVER uint8_t VoiceChannel_HasPlayer(alt::IVoiceChannel* channel, alt::IPlayer* player);
EXPORT_SERVER uint8_t VoiceChannel_IsPlayerMuted(alt::IVoiceChannel* channel, alt::IPlayer* player);
EXPORT_SERVER uint8_t VoiceChannel_IsSpatial(alt::IVoiceChannel* channel);
EXPORT_SERVER float VoiceChannel_GetMaxDistance(alt::IVoiceChannel* channel);

#ifdef __cplusplus
}
#endif
