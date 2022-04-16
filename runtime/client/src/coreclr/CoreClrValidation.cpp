#include <json.hpp>
#include <Log.h>
#include <sha1.hpp>
#include <zip_file.hpp>
#include <sha512.hpp>
#include <iomanip>

#include "CoreClr.h"
#include "../../cpp-sdk/SDK.h"

using namespace alt;
namespace fs = std::filesystem;

bool CoreClr::Validate(Ref<alt::IHttpClient> httpClient) const {
    auto const clrDirectoryPath = GetDataDirectoryPath();
    if (!fs::exists(clrDirectoryPath)) return false;
    
    const auto updateFile = utils::download_file_sync(httpClient, "https://cdn.block2play.com/coreclr/update.json");
    auto updateJson = nlohmann::json::parse(updateFile.body);
    
    const auto hashList = updateJson["hashList"];
    
    for (auto it = hashList.begin(); it != hashList.end(); ++it) {
        Log::Info << "Validating " << it.key() << Log::Endl;
        auto path = clrDirectoryPath;
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
            return false;
        }
    }
    
    for (auto& entry : fs::recursive_directory_iterator(clrDirectoryPath)) {
        if (entry.is_directory() || !entry.is_regular_file()) continue;
        auto relativePath = fs::relative( entry.path(), clrDirectoryPath ).generic_string();
        Log::Info << "Checking if " << relativePath << " is in the json" << Log::Endl;
        if (!hashList.contains(relativePath)) {
            Log::Warning << "File " << entry.path() << " is not in update.json" << Log::Endl;
            if (!fs::remove(entry.path())) {
                throw std::runtime_error("Failed to remove file " + entry.path().string());
            }
        }
    }

    return true;
}

void CoreClr::Download(Ref<alt::IHttpClient> httpClient) const {
    auto attempt = 0;

    while (true) {
        if (attempt++ >= 6) throw std::runtime_error("Failed to download CoreCLR after " + std::to_string(attempt) + " attempts");
        
        Log::Info << "Downloading CoreCLR (attempt " << attempt << ")" << Log::Endl;
        
        const auto response = utils::download_file_sync(httpClient, "https://cdn.block2play.com/coreclr/csharp-cache.zip");
        Log::Info << "Update finished" << Log::Endl;

        const auto clrDirectoryPath = GetDataDirectoryPath();
        if (!fs::exists(clrDirectoryPath)) fs::create_directories(clrDirectoryPath);
            
        std::istringstream is(response.body, std::ios::binary);
        Log::Info << "Extracting zip" << Log::Endl;
            
        try {
            miniz_cpp::zip_file zip(is);
            zip.extractall(clrDirectoryPath.string());
            Log::Info << "Extract finished" << Log::Endl;
            return;
        } catch (std::runtime_error& e) {
            Log::Error << "Failed to extract zip: " << e.what() << Log::Endl;
        }
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

void CoreClr::Update(alt::IResource* resource) {
    const auto httpClient = _core->CreateHttpClient(resource);

    auto attempt = 0;
    while (!Validate(httpClient)) {
        if (attempt++ >= 3) throw std::runtime_error("Failed to confirm CoreCLR download after " + std::to_string(attempt) + " attempts");
        try {
            Download(httpClient);
        } catch(const std::exception& e) {
            Log::Error << "Failed to download CoreCLR: " << e.what() << Log::Endl;
        }
    }

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