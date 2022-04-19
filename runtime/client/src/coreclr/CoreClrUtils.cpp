#include <filesystem>

#include "CoreCLR.h"

#ifdef WIN32
#define LIST_SEPARATOR ";"
#else
#define LIST_SEPARATOR ":"
#endif

std::string CoreClr::BuildTpaList(const std::string& runtimeDir) {
    std::string tpaList;

    static const std::vector<std::string> tpa_extensions = {
        ".ni.dll", // Probe for .ni.dll first so that it's preferred if ni and il coexist in the same dir
        ".dll",
        ".ni.exe",
        ".exe",
    };

    std::vector<std::string> addedAssemblies;

    for (const auto& ext : tpa_extensions) {
        for (auto& dirEntry : std::filesystem::recursive_directory_iterator(runtimeDir)) {
            if (!dirEntry.is_regular_file() || dirEntry.is_directory() || !utils::has_suffix(dirEntry.path().string(), ext)) continue;
            
            auto path = dirEntry.path();
            path = path.make_preferred();

            // If we have an assembly with multiple extensions present, we insert only one
            auto nameWithoutExt = path.filename().string().substr(0, path.filename().string().length() - ext.length());
            if (std::find(addedAssemblies.begin(), addedAssemblies.end(), nameWithoutExt) != addedAssemblies.end()) continue;
            
            addedAssemblies.push_back(nameWithoutExt);
            tpaList += path.string();
            tpaList += LIST_SEPARATOR;
        }
    }

    return tpaList;
}