//
// Created by parallels on 1/29/19.
//

#include "CoreClr.h"

char *
itoa (int value, char *result, int base)
{
    // check that the base if valid
    if (base < 2 || base > 36) { *result = '\0'; return result; }

    char* ptr = result, *ptr1 = result, tmp_char;
    int tmp_value;

    do {
        tmp_value = value;
        value /= base;
        *ptr++ = "zyxwvutsrqponmlkjihgfedcba9876543210123456789abcdefghijklmnopqrstuvwxyz" [35 + (tmp_value - value * base)];
    } while ( value );

    // Apply negative sign
    if (tmp_value < 0) *ptr++ = '-';
    *ptr-- = '\0';
    while (ptr1 < ptr) {
        tmp_char = *ptr;
        *ptr--= *ptr1;
        *ptr1++ = tmp_char;
    }
    return result;
}

CoreClr::CoreClr(alt::IServer *server) {
    const char *path = "/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1/libcoreclr.so";
    _coreClrLib = dlopen(path, RTLD_NOW | RTLD_LOCAL);
    if (_coreClrLib == nullptr) {
        server->LogInfo(alt::String("[.NET] Unable to find CoreCLR dll [") + path + "]: " + dlerror());
        return;
    }
    _initializeCoreCLR = (coreclr_initialize_ptr) dlsym(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr) dlsym(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr) dlsym(_coreClrLib, "coreclr_create_delegate");
    if (_initializeCoreCLR == nullptr || _shutdownCoreCLR == nullptr || _createDelegate == nullptr) {
        server->LogInfo(alt::String("[.NET] Unable to find CoreCLR dll methods"));
        return;
    }
    server->LogInfo(alt::String("[.NET] libcoreclr successfully loaded"));
}

bool CoreClr::GetDelegate(alt::IServer *server, void *runtimeHost, unsigned int domainId, const char *moduleName,
                          const char *classPath, const char *methodName, void **callback) {
    if (runtimeHost == nullptr || domainId == 0) {
        server->LogInfo(alt::String("[.NET] Core CLR host not loaded"));
        return false;
    }
    int result = _createDelegate(runtimeHost, domainId, moduleName, classPath, methodName, callback);
    if (result < 0) {
        server->LogInfo(alt::String(strerror(errno)));
        char * x_str = new char[10];
        sprintf(x_str, "%d", result);
        server->LogInfo(
                alt::String(x_str));
        delete[] x_str;
        server->LogInfo(
                alt::String("[.NET] Unable to get ") + moduleName + ":" + classPath + "." + methodName + " domain:" +
                domainId);
        return false;
    }
    return true;
}

alt::Array<alt::String> CoreClr::getTrustedAssemblies(alt::IServer *server) {
    alt::Array<alt::String> assemblies;
    const char *const tpaExtensions[] = {".ni.dll", ".dll", ".ni.exe", ".exe", ".winmd"};
    const char *path = "/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1";
    auto directory = opendir(path);
    if (directory == nullptr) {
        server->LogInfo(alt::String("[.NET] Runtime directory not found"));
        return assemblies;
    }
    server->LogInfo(alt::String("[.NET] Runtime directory found"));
    struct dirent *entry;
    for (auto ext : tpaExtensions) {
        size_t extLength = strlen(ext);
        while ((entry = readdir(directory)) != nullptr) {
            switch (entry->d_type) {
                case DT_REG:
                    break;

                    // Handle symlinks and file systems that do not support d_type
                case DT_LNK:
                case DT_UNKNOWN: {
                    std::string fullFilename;

                    fullFilename.append(path);
                    fullFilename.append("/");
                    fullFilename.append(entry->d_name);

                    struct stat sb;
                    if (stat(fullFilename.c_str(), &sb) == -1) {
                        continue;
                    }

                    if (!S_ISREG(sb.st_mode)) {
                        continue;
                    }
                }
                    break;

                default:
                    continue;
            }

            // Check if the extension matches the one we are looking for
            unsigned long extPos = strlen(entry->d_name) - extLength;
            //server->LogInfo(alt::String(ext) + "," + extLength + "," + entry->d_name);
            if (extPos <= 0 || memcmp(ext, entry->d_name + extPos, extLength) != 0) {
                continue;
            }

            //std::string filenameWithoutExt(filename.substr(0, extPos));

            // Ensure assemblies are unique in the list
            /*if (assemblies.find(filenameWithoutExt) != assemblies.end()) {//TODO: use alt::Set which doesnt exists
                continue;
            }*/

            assemblies.Push(alt::String("/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1") + "/" + entry->d_name);
        }
        // rewind directory to search for next extension
        rewinddir(directory);
    }
    closedir(directory);
    return assemblies;
}

void CoreClr::CreateAppDomain(alt::IServer *server, const char *appPath, const char *libraryPath, void **runtimeHost,
                              unsigned int *domainId) {
    alt::String tpaList = "";

    //TODO: check if useless list separator at the end is fine
    for (auto &tpa : getTrustedAssemblies(server)) {
        tpaList = tpaList + tpa;
        tpaList = tpaList + LIST_SEPARATOR;
    }

    auto nativeDllPaths = alt::String(appPath) + LIST_SEPARATOR + libraryPath;

    const char *propertyKeys[] = {
            "TRUSTED_PLATFORM_ASSEMBLIES",
            "APP_PATHS",
            "APP_NI_PATHS",
            "NATIVE_DLL_SEARCH_DIRECTORIES",
            "System.GC.Server",
            "System.Globalization.Invariant"
    };

    const char *propertyValues[] = {
            tpaList.CStr(),
            appPath,
            appPath,
            nativeDllPaths.CStr(),
            "true",
            "true"
    };

    int result = _initializeCoreCLR(
            appPath,
            "host",
            sizeof(propertyKeys) / sizeof(char*),
            propertyKeys,
            propertyValues,
            runtimeHost,
            domainId);

    if (result < 0) {
        server->LogInfo(alt::String("[.NET] Unable to create app domain: 0x"));
    } else {
        server->LogInfo(alt::String("[.NET] created app domain: 0x") + appPath);
    }
}
