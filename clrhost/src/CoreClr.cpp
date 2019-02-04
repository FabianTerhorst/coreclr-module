//
// Created by parallels on 1/29/19.
//

#include "CoreClr.h"

CoreClr::CoreClr(alt::IServer *server) {
#ifdef _WIN32
    char pf[MAX_PATH];
    SHGetSpecialFolderPath(
            nullptr,
            pf,
            CSIDL_PROGRAM_FILES,
            FALSE);

    const char *windowsProgramFilesPath = "/dotnet/shared/Microsoft.NETCore.App/2.2.0";

    runtimeDirectory = (char *) malloc(strlen(pf) + strlen(windowsProgramFilesPath) + 1);
    strcpy(runtimeDirectory, pf);
    strcat(runtimeDirectory, windowsProgramFilesPath);
#else
    const char* linuxDefaultPath = "/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1";
    runtimeDirectory = (char *) malloc(strlen(linuxDefaultPath) + 1);
    strcpy(runtimeDirectory, linuxDefaultPath);
#endif
#ifdef _WIN32
    const char *fileName = "/coreclr.dll";

    char fullPath[strlen(fileName) + strlen(runtimeDirectory) + 1];
    strcpy(fullPath, runtimeDirectory);
    strcat(fullPath, fileName);

    _coreClrLib = LoadLibraryEx(fullPath, nullptr, 0);
    if (_coreClrLib == nullptr) {
        server->LogInfo(alt::String("[.NET] Unable to find CoreCLR dll"));
        return;
    }

    _initializeCoreCLR = (coreclr_initialize_ptr) GetProcAddress(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr) GetProcAddress(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr) GetProcAddress(_coreClrLib, "coreclr_create_delegate");
#else
    const char *fileName = "/libcoreclr.so";
    char fullPath[strlen(fileName) + strlen(runtimeDirectory) + 1];
    strcpy(fullPath, runtimeDirectory);
    strcat(fullPath, fileName);
    _coreClrLib = dlopen(fullPath, RTLD_NOW | RTLD_LOCAL);
    if (_coreClrLib == nullptr) {
        server->LogInfo(alt::String("[.NET] Unable to find CoreCLR dll [") + fullPath + "]: " + dlerror());
        return;
    }
    _initializeCoreCLR = (coreclr_initialize_ptr) dlsym(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr) dlsym(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr) dlsym(_coreClrLib, "coreclr_create_delegate");
#endif
    if (_initializeCoreCLR == nullptr || _shutdownCoreCLR == nullptr || _createDelegate == nullptr) {
        server->LogInfo(alt::String("[.NET] Unable to find CoreCLR dll methods"));
        return;
    }
    server->LogInfo(alt::String("[.NET] libcoreclr successfully loaded"));
}

CoreClr::~CoreClr() {
    //TODO: check what else needs to be freed
    delete runtimeDirectory;
}

bool CoreClr::GetDelegate(alt::IServer *server, void *runtimeHost, unsigned int domainId, const char *moduleName,
                          const char *classPath, const char *methodName, void **callback) {
    if (runtimeHost == nullptr || domainId == 0) {
        server->LogInfo(alt::String("[.NET] Core CLR host not loaded"));
        return false;
    }
    int result = _createDelegate(runtimeHost, domainId, moduleName, classPath, methodName, callback);
    if (result < 0) {
        //TODO: https://github.com/rashiph/DecompliedDotNetLibraries/blob/6056fc6ff7ae8fb3057c936d9ebf36da73f990a6/mscorlib/System/__HResults.cs
        if (result == -2146234304) {
            server->LogInfo(
                    alt::String(
                            "[.NET] Your server needs to be compiled and needs to target (<TargetFramework>netcoreappX.X</TargetFramework>) with the same .net core version that is installed on your workstation"));
            return false;
        }
        server->LogInfo(alt::String(strerror(errno)));
        char *x_str = new char[10];
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

//TODO: don't include own dll or exe ect that is in the directory
alt::Array<alt::String> CoreClr::getTrustedAssemblies(alt::IServer *server, const char *appPath) {
    alt::Array<alt::String> assemblies;
    const char *const tpaExtensions[] = {".ni.dll", ".dll", ".ni.exe", ".exe", ".winmd"};

    const char *directories[] = {runtimeDirectory/*, appPath*/ };

    for (auto path : directories) {
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
#ifndef _WIN32
                    case DT_LNK:
#endif
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
                size_t extPos = strlen(entry->d_name) - extLength;
                //server->LogInfo(alt::String(ext) + "," + extLength + "," + entry->d_name);
                if (extPos <= 0 || memcmp(ext, entry->d_name + extPos, extLength) != 0) {
                    continue;
                }

                //std::string filenameWithoutExt(filename.substr(0, extPos));

                // Ensure assemblies are unique in the list
                /*if (assemblies.find(filenameWithoutExt) != assemblies.end()) {//TODO: use alt::Set which doesnt exists
                    continue;
                }*/

                if (strcmp(entry->d_name, "AltV.Net.dll") == 0) {
                    continue;
                }
                assemblies.Push(
                        alt::String(path) + "/" + entry->d_name);
            }
            // rewind directory to search for next extension
            rewinddir(directory);
        }
#ifndef _WIN32
        closedir(directory);
#endif
    }
    delete runtimeDirectory;
    return assemblies;
}

void CoreClr::CreateAppDomain(alt::IServer *server, const char *appPath, const char *libraryPath, void **runtimeHost,
                              unsigned int *domainId) {
    alt::String tpaList = "";

    //TODO: check if useless list separator at the end is fine
    for (auto &tpa : getTrustedAssemblies(server, appPath)) {
        tpaList = tpaList + tpa;
        tpaList = tpaList + LIST_SEPARATOR;
    }

    server->LogInfo(tpaList);

    auto nativeDllPaths = alt::String(appPath) + LIST_SEPARATOR + libraryPath;

    const char *propertyKeys[] = {
            "TRUSTED_PLATFORM_ASSEMBLIES",
            "APP_PATHS",
            "APP_NI_PATHS",
            "NATIVE_DLL_SEARCH_DIRECTORIES",
            "System.GC.Server",
            "System.Globalization.Invariant"};

    const char *propertyValues[] = {
            tpaList.CStr(),
            appPath,
            appPath,
            nativeDllPaths.CStr(),
            "true",
            "true"};

    int result = _initializeCoreCLR(
            appPath,
            "host",
            sizeof(propertyKeys) / sizeof(char *),
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

void CoreClr::Shutdown(alt::IServer *server, void *runtimeHost,
                       unsigned int domainId) {
    int latchedExitCode = 0;
    int result = _shutdownCoreCLR(runtimeHost, domainId, &latchedExitCode);
    if (result < 0) {
        server->LogInfo(alt::String("[.NET] Unable to shutdown host"));
    } else {
        server->LogInfo(alt::String("[.NET] Host successfully shotted down"));
    }
}
