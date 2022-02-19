cmake_minimum_required (VERSION 3.8)

set(TARGET_NAME core_clr_client)

project(${TARGET_NAME})
message(${PROJECT_SOURCE_DIR})

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

file(GLOB_RECURSE PROJECT_SOURCE_FILES
        "src/*.h"
        "src/*.cpp"
        src/c-api/mvalue.h
        src/c-api/mvalue.cpp
)

add_library(${TARGET_NAME} SHARED
        "${PROJECT_SOURCE_FILES}"
)
#add_executable(${TARGET_NAME} ${PROJECT_SOURCE_FILES})

target_compile_definitions(${PROJECT_NAME} PRIVATE
        # Compliation
        -DCXX_COMPILER_ID="${CMAKE_CXX_COMPILER_ID}"
        -D_SILENCE_CXX17_CODECVT_HEADER_DEPRECATION_WARNING

        # Platform
        -DUNICODE
        -D_UNICODE

        # alt:V
        -DALT_CLIENT
        -DALT_CLIENT_API

        # CoreCLR
        -DNETHOST_USE_AS_STATIC

        # Debug
#        -DDEBUG_CLIENT
)

include_directories(${TARGET_NAME} PRIVATE
        "src"
        "thirdparty"
)

target_link_libraries(${TARGET_NAME} PRIVATE
        "${PROJECT_SOURCE_DIR}/thirdparty/coreclr/nethost.lib"
)

install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")