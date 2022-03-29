@echo off

:: Build project
IF NOT EXIST build\ (
    mkdir build
)

IF NOT EXIST build\coreclr-client-module (
    mkdir build\coreclr-client-module
)

cmake . -Bcmake-build-release
cmake --build cmake-build-release --config Release
copy .\cmake-build-release\Release\core_clr_client.dll .\build\coreclr-client-module\coreclr-client-module.dll
copy .\thirdparty\coreclr\nethost.dll .\build\coreclr-client-module
copy .\thirdparty\coreclr\AltV.Net.Client.runtimeconfig.json .\build\coreclr-client-module