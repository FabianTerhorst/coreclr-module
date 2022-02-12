#pragma once

#include <string>
#include "altv-cpp-api/ICore.h"

struct ClrVehicleModelInfo {
    char* title = nullptr;
    alt::VehicleModelInfo::Type modelType;
    uint8_t wheelsCount;
    uint8_t hasArmoredWindows;
    uint8_t primaryColor;
    uint8_t secondaryColor;
    uint8_t pearlColor;
    uint8_t wheelsColor;
    uint8_t interiorColor;
    uint8_t dashboardColor;

    uint16_t extras;
    uint16_t defaultExtras;
    bool modkits[2];

    ClrVehicleModelInfo() = default;

    ClrVehicleModelInfo(alt::VehicleModelInfo info) :
            modelType(info.modelType),
            wheelsCount(info.wheelsCount),
            hasArmoredWindows(info.hasArmoredWindows),
            primaryColor(info.primaryColor),
            secondaryColor(info.secondaryColor),
            pearlColor(info.pearlColor),
            wheelsColor(info.wheelsColor),
            interiorColor(info.interiorColor),
            dashboardColor(info.dashboardColor),
            extras(info.extras),
            defaultExtras(info.defaultExtras) {

        size_t modkitsSize = std::size(info.modkits);
        for(size_t i = 0; i < modkitsSize; i++)
        {
            modkits[i] = info.modkits[i] != 0xFFFF;
        }

        title = new char[info.title.length() + 1];
        strcpy(title, info.title.c_str());
    }

    ~ClrVehicleModelInfo() {
        delete[] title;
    }
};