//
// Created by parallels on 1/29/19.
//

#include "CoreClr.h"
#include <semver.h>

/*int tail_cmp(char* lhs, char* rhs) {
    if (!strcmp(lhs, rhs)) return TAIL_CMP_EQ;

    char* dot = ".";
    char* l_last, * r_last;

    char* l_token = strtok_r(lhs, dot, &l_last);
    char* r_token = strtok_r(rhs, dot, &r_last);

    if (l_token && !r_token) return TAIL_CMP_LT;
    if (!l_token && r_token) return TAIL_CMP_GT;

    while (l_token || r_token) {
        if (l_token && r_token) {
            int l_numeric = isdigit(l_token[0]);
            int r_numeric = isdigit(r_token[0]);

            if (l_numeric && r_numeric) {
                int l_int = atoi(l_token);
                int r_int = atoi(r_token);

                if (l_int < r_int) return TAIL_CMP_LT;
                if (l_int > r_int) return TAIL_CMP_GT;
            } else if (l_numeric) {
                return TAIL_CMP_LT;
            } else if (r_numeric) {
                return TAIL_CMP_GT;
            } else {
                int cmp = strcmp(l_token, r_token);

                if (cmp) return cmp > 0 ? TAIL_CMP_GT : TAIL_CMP_LT;
            }
        } else if (l_token) {
            return TAIL_CMP_GT;
        } else if (r_token) {
            return TAIL_CMP_LT;
        }

        l_token = strtok_r(NULL, dot, &l_last);
        r_token = strtok_r(NULL, dot, &r_last);
    }

    return TAIL_CMP_KO;
}

int tail_lt(char* lhs, char* rhs) {
    return tail_cmp(lhs, rhs) == TAIL_CMP_LT;
}

int tail_eq(char* lhs, char* rhs) {
    return tail_cmp(lhs, rhs) == TAIL_CMP_EQ;
}

int tail_gt(char* lhs, char* rhs) {
    return tail_cmp(lhs, rhs) == TAIL_CMP_GT;
}*/


CoreClr::CoreClr(alt::IServer* server) {
    _initializeCoreCLR = nullptr;
    _shutdownCoreCLR = nullptr;
    _createDelegate = nullptr;
    _executeAssembly = nullptr;
#ifdef _WIN32
    char pf[MAX_PATH];
    SHGetSpecialFolderPath(
            nullptr,
            pf,
            CSIDL_PROGRAM_FILES,
            FALSE);

    const char *windowsProgramFilesPath = "/dotnet/shared/Microsoft.NETCore.App/";
    auto defaultPath = new char[strlen(windowsProgramFilesPath) + strlen(pf) + 1];
    strcpy(defaultPath, pf);
    strcat(defaultPath, windowsProgramFilesPath);
    GetPath(server, defaultPath);
    delete[] defaultPath;
#else
    GetPath(server, "/usr/share/dotnet/shared/Microsoft.NETCore.App/");
#endif
#ifdef _WIN32
    const char *fileName = "/coreclr.dll";

    auto fullPath = new char[strlen(fileName) + strlen(runtimeDirectory) + 1];
    strcpy(fullPath, runtimeDirectory);
    strcat(fullPath, fileName);

    _coreClrLib = LoadLibraryEx(fullPath, nullptr, 0);
    delete[] fullPath;
    if (_coreClrLib == nullptr) {
        server->LogInfo(alt::String("coreclr-module: Unable to find CoreCLR dll"));
        return;
    }

    _initializeCoreCLR = (coreclr_initialize_ptr) GetProcAddress(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr) GetProcAddress(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr) GetProcAddress(_coreClrLib, "coreclr_create_delegate");
    _executeAssembly = (coreclr_execute_assembly_ptr) GetProcAddress(_coreClrLib, "coreclr_execute_assembly");
#else
    const char* fileName = "/libcoreclr.so";
    char fullPath[strlen(fileName) + strlen(runtimeDirectory) + 1];
    strcpy(fullPath, runtimeDirectory);
    strcat(fullPath, fileName);
    _coreClrLib = dlopen(fullPath, RTLD_NOW | RTLD_LOCAL);
    if (_coreClrLib == nullptr) {
        server->LogInfo(alt::String("coreclr-module: Unable to find CoreCLR dll [") + fullPath + "]: " + dlerror());
        return;
    }
    _initializeCoreCLR = (coreclr_initialize_ptr) dlsym(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr) dlsym(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr) dlsym(_coreClrLib, "coreclr_create_delegate");
    _executeAssembly = (coreclr_execute_assembly_ptr) dlsym(_coreClrLib, "coreclr_execute_assembly");
#endif
    if (_initializeCoreCLR == nullptr || _shutdownCoreCLR == nullptr || _createDelegate == nullptr ||
        _executeAssembly == nullptr) {
        server->LogInfo(alt::String("coreclr-module: Unable to find CoreCLR dll methods"));
        return;
    }
    server->LogInfo(alt::String("coreclr-module: libcoreclr successfully loaded"));
}

CoreClr::~CoreClr() {
    free(runtimeDirectory);
}

bool CoreClr::GetDelegate(alt::IServer* server, void* runtimeHost, unsigned int domainId, const char* moduleName,
                          const char* classPath, const char* methodName, void** callback) {
    if (runtimeHost == nullptr || domainId == 0) {
        server->LogInfo(alt::String("coreclr-module: Core CLR host not loaded"));
        return false;
    }
    int result = _createDelegate(runtimeHost, domainId, moduleName, classPath, methodName, callback);
    if (result < 0) {
        if (this->PrintError(server, result)) {
            return false;
        }
        server->LogInfo(
                alt::String("coreclr-module: Unable to get ") + moduleName + ":" + classPath + "." + methodName +
                " domain:" +
                domainId);
        return false;
    }
    return true;
}

//TODO: don't include own dll or exe ect that is in the directory
alt::Array<alt::String> CoreClr::getTrustedAssemblies(alt::IServer* server, const char* appPath) {
    alt::Array<alt::String> assemblies;
    const char* const tpaExtensions[] = {".ni.dll", ".dll", ".ni.exe", ".exe", ".winmd"};

    const char* directories[] = {runtimeDirectory/*, appPath*/ };

    for (auto path : directories) {
        auto directory = opendir(path);
        if (directory == nullptr) {
            server->LogInfo(alt::String("coreclr-module: Runtime directory not found"));
            return assemblies;
        }
        server->LogInfo(alt::String("coreclr-module: Runtime directory found"));
        struct dirent* entry;
        struct stat sb{};
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
                        fullFilename.append(PATH_SEPARATOR);
                        fullFilename.append(entry->d_name);

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
                        alt::String(path) + PATH_SEPARATOR + entry->d_name);
            }
            // rewind directory to search for next extension
            rewinddir(directory);
        }
#ifndef _WIN32
        closedir(directory);
#endif
    }
    return assemblies;
}

void CoreClr::CreateAppDomain(alt::IServer* server, alt::IResource* resource, const char* appPath, void** runtimeHost,
                              unsigned int* domainId, bool executable, uint64_t resourceIndex, const char* domainName) {
    alt::String tpaList = "";

    //TODO: check if useless list separator at the end is fine
    for (auto &tpa : getTrustedAssemblies(server, appPath)) {
        tpaList = tpaList + tpa;
        tpaList = tpaList + LIST_SEPARATOR;
    }

    auto nativeDllPaths = alt::String(appPath) + LIST_SEPARATOR + runtimeDirectory;

    const char* propertyKeys[] = {
            "TRUSTED_PLATFORM_ASSEMBLIES",
            "APP_PATHS",
            "APP_NI_PATHS",
            "NATIVE_DLL_SEARCH_DIRECTORIES",
            "System.GC.Server",
            "System.Globalization.Invariant"};

    const char* propertyValues[] = {
            tpaList.CStr(),
            appPath,
            appPath,
            nativeDllPaths.CStr(),
            "true",
            "true"};

    int result = _initializeCoreCLR(
            appPath,
            domainName,
            sizeof(propertyKeys) / sizeof(char*),
            propertyKeys,
            propertyValues,
            runtimeHost,
            domainId);

    if (result < 0) {
        server->LogInfo(alt::String("coreclr-module: Unable to create app domain: 0x"));
        this->PrintError(server, result);
    } else {
        server->LogInfo(alt::String("coreclr-module: Created app domain: 0x") + appPath);
    }

    if (executable) {
        auto executablePath = alt::String(appPath) + PATH_SEPARATOR + resource->GetMain();

        server->LogInfo(alt::String("coreclr-module: Prepare for executing assembly:") + executablePath);
        int exitCode = -1;
        const char* args[1];
        char resourceIndexChar = resourceIndex + '0';
        char resourceIndexString[1];
        resourceIndexString[0] = resourceIndexChar;
        args[0] = resourceIndexString;
        result = _executeAssembly(
                *runtimeHost,
                *domainId,
                1,
                args,
                executablePath.CStr(),
                (unsigned int*) &exitCode
        );

        if (result < 0) {
            exitCode = -1;
            server->LogInfo(
                    alt::String("coreclr-module: Unable to execute assembly in app path:") + executablePath);
            this->PrintError(server, result);
        } else {
            server->LogInfo(alt::String("coreclr-module: Assembly executed"));
            /*char* x_str = new char[10];
            sprintf(x_str, "exit code: %d", exitCode);
            server->LogInfo(
                    alt::String(x_str));
            delete[] x_str;*/
        }
    }
}

void CoreClr::Shutdown(alt::IServer* server, void* runtimeHost,
                       unsigned int domainId) {
    int latchedExitCode = 0;
    int result = _shutdownCoreCLR(runtimeHost, domainId, &latchedExitCode);
    if (result < 0) {
        server->LogInfo(alt::String("coreclr-module: Unable to shutdown host"));
    } else {
        server->LogInfo(alt::String("coreclr-module: Host successfully shotted down"));
    }
}

void CoreClr::GetPath(alt::IServer* server, const char* defaultPath) {
    auto directory = opendir(defaultPath);
    if (directory == nullptr) {
        server->LogInfo(alt::String("coreclr-module: dotnet core sdk not found in ") + defaultPath);
        return;
    }
    struct dirent* entry;
    char* greatest = nullptr;
    semver_t greatest_version = {};
    semver_t compare_version = {};
    while ((entry = readdir(directory)) != nullptr) {
        if (entry->d_type == DT_DIR && memcmp(entry->d_name, ".", 1) != 0 && memcmp(entry->d_name, "..", 2) != 0) {
            server->LogInfo(alt::String("coreclr-module: version found: ") + entry->d_name);
            if (greatest == nullptr) {
                if (semver_parse(entry->d_name, &greatest_version)) {
                    server->LogInfo(alt::String("coreclr-module: invalid version found: ") + entry->d_name);
                    continue;
                }
                greatest = entry->d_name;
                continue;
            }
            if (semver_parse(entry->d_name, &compare_version)) {
                server->LogInfo(alt::String("coreclr-module: invalid version found: ") + entry->d_name);
                continue;
            }
            if (semver_compare(compare_version, greatest_version) > 0) {
                semver_free(&greatest_version);
                greatest_version = compare_version;
                greatest = entry->d_name;
            } else {
                semver_free(&compare_version);
            }
            /*auto compareCache = new char[strlen(entry->d_name)];
            strcpy(compareCache, entry->d_name);
            auto compareCache2 = new char[strlen(greatest)];
            strcpy(compareCache2, greatest);
            if (tail_lt(compareCache, compareCache2)) {
                greatest = entry->d_name;
            }
            delete[] compareCache;
            delete[] compareCache2;*/
        }
    }
    if (greatest == nullptr) {
        server->LogInfo(alt::String("coreclr-module: No dotnet sdk version found"));
        return;
    } else {
        semver_free(&greatest_version);
    }
    server->LogInfo(alt::String("coreclr-module: greatest version: ") + greatest);
    size_t size = strlen(defaultPath) + strlen(greatest) + 1;
    runtimeDirectory = (char*) malloc(size);
    memset(runtimeDirectory, '\0', size);
    strcpy(runtimeDirectory, defaultPath);
    strcat(runtimeDirectory, greatest);
}

//TODO: https://github.com/rashiph/DecompliedDotNetLibraries/blob/6056fc6ff7ae8fb3057c936d9ebf36da73f990a6/mscorlib/System/__HResults.cs
bool CoreClr::PrintError(alt::IServer* server, int errorCode) {
    if (errorCode == -2146234304) {
        server->LogInfo(
                alt::String(
                        "coreclr-module: Your server needs to be compiled and needs to target (<TargetFramework>netcoreappX.X</TargetFramework>) with the same .net core version that is installed on your workstation"));
        return true;
    } else if (errorCode == -2147024894) {
        server->LogInfo(
                alt::String(
                        "coreclr-module: You need to place the AltV.Net.dll in your resource directory. Use publish to generate all dlls."));
        return true;
    }
    server->LogInfo(alt::String(strerror(errno)));
    char* x_str = new char[10];
    sprintf(x_str, "%d", errorCode);
    server->LogInfo(
            alt::String(x_str));
    delete[] x_str;
    return false;
}