#include <json.hpp>
#include <Log.h>
#include <sha1.hpp>
#include <sha512.hpp>
#include <iomanip>
#include <zip_file.hpp>

#include "CoreClr.h"
#include "../../cpp-sdk/SDK.h"

using namespace alt;
namespace fs = std::filesystem;

std::string CoreClr::GetBaseCdnUrl() const {
    static auto branch = _core->GetBranch();
    return "https://cdn.altv.mp/coreclr-client-module/" + branch + "/x64_win32/";
}

inline const std::string host_dll_name = "AltV.Net.Client.Host.dll";

bool CoreClr::ValidateRuntime(nlohmann::basic_json<> updateJson, Ref<alt::IHttpClient> httpClient) const {
    auto const runtimeDirectoryPath = GetRuntimeDirectoryPath();
    if (!fs::exists(runtimeDirectoryPath)) return false;
    
    const auto hashList = updateJson["hashList"];
    
    for (auto it = hashList.begin(); it != hashList.end(); ++it) {
        if (!utils::has_prefix(it.key(), "runtime/")) continue;
        auto path = GetDataDirectoryPath();
        path.append(it.key());
        if (!fs::exists(path)) {
            Log::Warning << "File " << path.string() << " does not exist" << Log::Endl;
            return false;
        }
        SHA1 checksum;
        auto stream = std::ifstream(path, std::ios::binary);
        checksum.update(stream);
        const std::string hash = checksum.final();
        if (hash != it.value()) {
            Log::Warning << "File " << path << " has invalid hash" << Log::Endl;
            Log::Warning << "Current " << hash << " Needed " << it.value() << Log::Endl;
            return false;
        }
    }
    
    for (auto& entry : fs::recursive_directory_iterator(runtimeDirectoryPath)) {
        if (entry.is_directory() || !entry.is_regular_file()) continue;
        auto relativePath = "runtime/" + fs::relative( entry.path(), runtimeDirectoryPath ).generic_string();
        if (!hashList.contains(relativePath)) {
            Log::Warning << "File " << entry.path() << " is not in update.json" << Log::Endl;
            if (!fs::remove(entry.path())) {
                throw std::runtime_error("Failed to remove file " + entry.path().string());
            }
        }
    }

    return true;
}

void CoreClr::DownloadRuntime(Ref<alt::IHttpClient> httpClient) const {
    auto attempt = 0;
    
    while (true) {
        if (attempt++ >= 6) throw std::runtime_error("Failed to download CoreCLR after " + std::to_string(attempt) + " attempts");
        
        Log::Info << "Downloading CoreCLR (attempt " << attempt << ")" << Log::Endl;

        static auto url = GetBaseCdnUrl() + "runtime.zip";
        const auto response = utils::download_file_sync(httpClient, url);
        Log::Info << "Download finished" << Log::Endl;

        static auto runtimeDirectoryPath = GetRuntimeDirectoryPath();
        if (!fs::exists(runtimeDirectoryPath)) fs::create_directories(runtimeDirectoryPath);
            
        std::istringstream is(response.body, std::ios::binary);
        Log::Info << "Extracting zip" << Log::Endl;
            
        try {
            miniz_cpp::zip_file zip(is);
            zip.extractall(runtimeDirectoryPath.string());
            Log::Info << "Extract finished" << Log::Endl;
            return;
        } catch (std::runtime_error& e) {
            Log::Error << "Failed to extract zip: " << e.what() << Log::Endl;
        }
    }
}

bool CoreClr::ValidateHost(nlohmann::basic_json<> updateJson) const {
    Log::Info << "Validating Host" << Log::Endl;
    
    static auto hostPath = GetDataDirectoryPath().append(host_dll_name);
    
    if (!fs::exists(hostPath)) {
        Log::Warning << "Host file does not exist" << Log::Endl;
        return false;
    }
    
    SHA1 checksum;
    auto stream = std::ifstream(hostPath, std::ios::binary);
    checksum.update(stream);
    const std::string hash = checksum.final();
    
    const auto hashList = updateJson["hashList"];
    
    if (hashList[host_dll_name] != hash) {
        Log::Warning << "Host has invalid hash" << Log::Endl;
        return false;
    }

    return true;
}

void CoreClr::DownloadHost(Ref<alt::IHttpClient> httpClient) const {
    static auto url = GetBaseCdnUrl() + host_dll_name;
    auto attempt = 0;
    
    while (true) {
        if (attempt++ >= 6) throw std::runtime_error("Failed to download Host after " + std::to_string(attempt) + " attempts");
        
        Log::Info << "Downloading Host (attempt " << attempt << ")" << Log::Endl;

        const auto response = utils::download_file_sync(httpClient, url);
        if (response.statusCode != 200) {
            Log::Error << "Failed to download Host: " << response.statusCode << Log::Endl;
            continue;
        }
        

        static auto path = GetDataDirectoryPath().append(host_dll_name);
        std::ofstream file(path, std::ios::binary);
        file.write(response.body.data(), response.body.size());
        file.close();
        return;
    }
}

std::string CoreClr::GetLatestNugetVersion(alt::Ref<alt::IHttpClient> httpClient, const std::string& packageName) {
    if (!_nuget) _nuget.emplace(httpClient);
    const auto branch = _core->GetBranch();
    const auto versions = _nuget->GetPackageVersions(packageName);
    for (auto it = versions.rbegin(); it != versions.rend(); ++it) {
        if (branch == "release") {
            if (it->find("-") == std::string::npos) return *it;
        } else {
            if (utils::has_suffix(*it, "-" + branch)) return *it;
        }
    }

    throw std::runtime_error("Failed to find latest version of " + packageName + " for branch " + branch);
}

bool CoreClr::ValidateNuGet(alt::Ref<alt::IHttpClient> httpClient, const std::string& package, const std::string& version, nlohmann::json::basic_json<> json) {
    if (!_nuget) _nuget.emplace(httpClient);
    Log::Info << "Validating NuGet package " << package << " " << version << Log::Endl;
    
    if (json == nullptr) json = _nuget->GetCatalog(package, version);
    auto librariesDirectoryPath = GetLibrariesDirectoryPath();
    auto nupkgPath = librariesDirectoryPath.append(package + ".nupkg");
    if (!fs::exists(nupkgPath)) {
        Log::Info << "Nuget file does not exist" << Log::Endl;
        return false;
    }
    auto stream = std::ifstream(nupkgPath, std::ios::binary);
    const auto hashAlgorithm = json["packageHashAlgorithm"].get<std::string>();
    
    std::string fileHash;
    if (hashAlgorithm == "SHA512") {
        fileHash = sw::sha512::calculate(stream);
    } else if (hashAlgorithm == "SHA256") {
        std::string content((std::istreambuf_iterator<char>(stream)), std::istreambuf_iterator<char>());
        fileHash = _core->StringToSHA256(content);
    } else {
        throw std::runtime_error("Unsupported hash algorithm " + json["packageHashAlgorithm"].get<std::string>());   
    }
    
    const auto neededHashBase64 = json["packageHash"].get<std::string>();
    std::stringstream neededHash;
    for (const auto &item : utils::base64_decode(neededHashBase64)) {
        neededHash << std::hex << std::setw(2) << std::setfill('0') << (int) item;
    }

    Log::Info << "Needed hash was " << neededHash.str() << " actual hash was " << fileHash << Log::Endl;

    return neededHash.str() == fileHash;
}


bool CoreClr::ValidateNuGets(alt::Ref<alt::IHttpClient> httpClient) {
    if (!_nuget) _nuget.emplace(httpClient);
    const auto librariesDirectoryPath = GetLibrariesDirectoryPath();
    if (!fs::exists(librariesDirectoryPath)) return false;
    
    const auto version = GetLatestNugetVersion(httpClient, "altv.net.client");
    const auto catalog = _nuget->GetCatalog("altv.net.client", version);
    if (!ValidateNuGet(httpClient, "altv.net.client", version, catalog)) {
        Log::Error << "Failed to validate NuGet altv.net.client " << version << Log::Endl;
        return false;
    }
    const auto dependencyGroup = catalog["dependencyGroups"][0];
    if (!dependencyGroup.contains("dependencies")) return true;
    
    const auto dependencies = dependencyGroup["dependencies"];
    for (auto it = dependencies.begin(); it != dependencies.end(); ++it) {
        auto id = it.value()["id"].get<std::string>();
        utils::to_lower(id);
        
        if (!utils::has_prefix(id, "altv.")) continue;
        if (!ValidateNuGet(httpClient, id, version)) {
            Log::Error << "Failed to validate NuGet " << id << " " << version << Log::Endl;
            return false;
        }
    }

    return true;
}

void CoreClr::DownloadNuGet(alt::Ref<alt::IHttpClient> httpClient, const std::string& packageName, const std::string& version) {
    if (!_nuget) _nuget.emplace(httpClient);
    Log::Info << "Downloading NuGet package " << packageName << " " << version << Log::Endl;
    
    auto librariesDirectoryPath = GetLibrariesDirectoryPath();
    if (!fs::exists(librariesDirectoryPath)) fs::create_directories(librariesDirectoryPath);
    const auto nupkgPath = librariesDirectoryPath.append(packageName + ".nupkg");
    const auto content = _nuget->DownloadPackage(packageName, version);
    std::ofstream file(nupkgPath, std::ios::binary);
    file.write(content.data(), content.size());
    file.close();
}

void CoreClr::DownloadNuGets(alt::Ref<alt::IHttpClient> httpClient) {
    if (!_nuget) _nuget.emplace(httpClient);
    
    const auto librariesDirectoryPath = GetLibrariesDirectoryPath();
    if (!fs::exists(librariesDirectoryPath)) fs::create_directories(librariesDirectoryPath);
    
    const auto version = GetLatestNugetVersion(httpClient, "altv.net.client");
    const auto catalog = _nuget->GetCatalog("altv.net.client", version);
    DownloadNuGet(httpClient, "altv.net.client", version);
    
    const auto dependencyGroup = catalog["dependencyGroups"][0];
    if (!dependencyGroup.contains("dependencies")) return;
    
    const auto dependencies = dependencyGroup["dependencies"];
    for (auto it = dependencies.begin(); it != dependencies.end(); ++it) {
        auto id = it.value()["id"].get<std::string>();
        utils::to_lower(id);
        
        if (!utils::has_prefix(id, "altv.")) continue;
        DownloadNuGet(httpClient, id, version);
    }
}

void CoreClr::Update() {
    const auto httpClient = _core->CreateHttpClient(nullptr);

    static auto url = GetBaseCdnUrl() + "update.json";
    const auto updateFile = utils::download_file_sync(httpClient, url);
    const auto updateJson = nlohmann::json::parse(updateFile.body);
    
    auto attempt = 0;
    while (!ValidateRuntime(updateJson, httpClient)) {
        if (attempt++ >= 3) throw std::runtime_error("Failed to confirm CoreCLR download after " + std::to_string(attempt) + " attempts");
        try {
            DownloadRuntime(httpClient);
        } catch(const std::exception& e) {
            Log::Error << "Failed to download CoreCLR: " << e.what() << Log::Endl;
        }
    }
    
    attempt = 0;
    while (!ValidateHost(updateJson)) {
        if (attempt++ >= 3) throw std::runtime_error("Failed to confirm Host download after " + std::to_string(attempt) + " attempts");
        try {
            DownloadHost(httpClient);
        } catch(const std::exception& e) {
            Log::Error << "Failed to download Host: " << e.what() << Log::Endl;
        }
    }

    if (sandbox) {
        attempt = 0;
        while (!ValidateNuGets(httpClient)) {
            if (attempt++ >= 3) throw std::runtime_error("Failed to confirm NuGet download after " + std::to_string(attempt) + " attempts");
            try {
                DownloadNuGets(httpClient);
            } catch(const std::exception& e) {
                Log::Error << "Failed to download NuGets: " << e.what() << Log::Endl;
            }
        }
    }
}