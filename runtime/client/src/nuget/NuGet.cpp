#include "NuGet.h"

#include <Log.h>

#include "utils.h"

NuGet::NuGet(const alt::Ref<alt::IHttpClient> httpClient) {
    _httpClient = httpClient;
    const auto data = utils::download_file_sync(_httpClient.Get(), "https://api.nuget.org/v3/index.json");
    _serviceIndex = nlohmann::json::parse(data.body);
}

std::string NuGet::GetIndexUrl(const std::string& type) {
    const auto resources = _serviceIndex["resources"];
    for (auto it = resources.begin(); it != resources.end(); ++it) {
        const auto value = it.value();
        if (value["@type"] == type) return value["@id"];
    }

    return "";
}

std::vector<std::string> NuGet::GetPackageVersions(const std::string& package) {
    static std::string url = GetIndexUrl("PackageBaseAddress/3.0.0");
    const auto data = utils::download_file_sync(_httpClient.Get(), url + package + "/index.json");
    if (data.statusCode != 200) {
        throw std::runtime_error("Failed to get package "  + package + " versions");
    }
    const auto json = nlohmann::json::parse(data.body);
    return json["versions"].get<std::vector<std::string>>();
}

nlohmann::basic_json<> NuGet::GetCatalog(const std::string& package, const std::string& version) {
    static std::string url = GetIndexUrl("RegistrationsBaseUrl");
    const auto data = utils::download_file_sync(_httpClient.Get(), url + package + "/" + version + ".json");
    if (data.statusCode != 200) {
        throw std::runtime_error("Failed to get package "  + package + " registration");
    }
    const auto json = nlohmann::json::parse(data.body);
    const auto catalogData = utils::download_file_sync(_httpClient.Get(), json["catalogEntry"].get<std::string>());
    if (catalogData.statusCode != 200) {
        throw std::runtime_error("Failed to get package "  + package + " catalog");
    }
    return nlohmann::json::parse(catalogData.body);
}

std::string NuGet::DownloadPackage(const std::string& package, const std::string& version) {
    static std::string url = GetIndexUrl("PackageBaseAddress/3.0.0");
    const auto data = utils::download_file_sync(_httpClient.Get(), url + package + "/" + version + "/" + package + "." + version + ".nupkg");
    if (data.statusCode != 200) {
        throw std::runtime_error("Failed to download "  + package);
    }
    return data.body;
}
