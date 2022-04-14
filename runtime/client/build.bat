@echo off

:: Build project
IF NOT EXIST build\ (
    mkdir build
)

IF NOT EXIST build\coreclr-client-module (
    mkdir build\coreclr-client-module
)

cmake . -Bcmake-build-release
cmake --build cmake-build-release --config RelWithDebInfo
copy .\cmake-build-release\RelWithDebInfo\core_clr_client.dll .\build\coreclr-client-module\coreclr-client-module.dll
copy .\cmake-build-release\RelWithDebInfo\core_clr_client.pdb .\build\coreclr-client-module\coreclr-client-module.pdb