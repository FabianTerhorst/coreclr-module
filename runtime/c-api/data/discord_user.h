#pragma once


#include "../../cpp-sdk/IDiscordManager.h"

struct ClrDiscordUser {
    char* id = nullptr;
    char* username = nullptr;
    char* discriminator = nullptr;
    char* avatar = nullptr;

    ClrDiscordUser() = default;

    ClrDiscordUser(alt::IDiscordManager* discordManager) {
        auto idStr = discordManager->GetUserID();
        id = new char[idStr.length() + 1];
        strcpy(id, idStr.c_str());

        auto usernameStr = discordManager->GetUsername();
        username = new char[usernameStr.length() + 1];
        strcpy(username, usernameStr.c_str());

        auto discriminatorStr = discordManager->GetDiscriminator();
        discriminator = new char[discriminatorStr.length() + 1];
        strcpy(discriminator, discriminatorStr.c_str());

        auto avatarStr = discordManager->GetAvatar();
        avatar = new char[avatarStr.length() + 1];
        strcpy(avatar, avatarStr.c_str());
    }

    ~ClrDiscordUser() {
        delete[] id;
        delete[] username;
        delete[] discriminator;
        delete[] avatar;
    }
};