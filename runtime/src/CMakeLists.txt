cmake_minimum_required (VERSION 3.9.2)

set(TARGET_NAME core_clr_host)

add_library(${TARGET_NAME} SHARED altv.cpp CSharpScriptRuntime.cpp CSharpResource.cpp CoreClr.cpp
        altv-c-api/altv.cpp altv-c-api/blip.cpp altv-c-api/vehicle.cpp altv-c-api/player.cpp altv-c-api/checkpoint.cpp altv-c-api/entity.cpp altv-c-api/server.cpp
        altv-c-api/baseobject.cpp altv-c-api/mvalue.cpp altv-c-api/function.cpp altv-c-api/position.h altv-c-api/rotation.h altv-c-api/rgba.h altv-c-api/resource.h altv-c-api/resource.cpp altv-c-api/voice_channel.cpp altv-c-api/colshape.cpp)# clrHost.cpp

if(UNIX AND NOT APPLE)
    target_compile_options(${TARGET_NAME} PRIVATE -std=c++17 -static)
    target_link_libraries(${TARGET_NAME} -lstdc++ -static-libstdc++)
    # target_link_libraries(${TARGET_NAME} -static-libgcc -static-libstdc++)
else()
    target_compile_options(${TARGET_NAME} PRIVATE)# -I/home/parallels/Desktop/clang_7.0.1/include/c++/v1  -stdlib=libc++ -I$ENV{PROGRAMFILES}/LLVM/lib/clang/7.0.1/include -nodefaultlibs
endif()

target_compile_definitions(${TARGET_NAME} PRIVATE ALT_SERVER_API=true)

set_target_properties(${TARGET_NAME} PROPERTIES OUTPUT_NAME "csharp-module")

target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../include)
target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty)

if(MSVC)
    install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")
else()
    install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.so DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")
endif(MSVC)
