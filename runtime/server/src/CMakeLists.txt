cmake_minimum_required (VERSION 3.13)

include(../../cpp-sdk/CMakeLists.txt)

set(TARGET_NAME core_clr_host)


file(GLOB_RECURSE CAPI_FILES "../../c-api/*.h" "../../c-api/*.cpp")

add_library(${TARGET_NAME} SHARED altv.cpp CSharpScriptRuntime.cpp CSharpResourceImpl.cpp CoreClr.cpp "${CAPI_FILES}")

#link_directories(nethost)

#include_directories(${CMAKE_CURRENT_SOURCE_DIR}/../nethost/include)
#find_library(NetHost libnethost "${CMAKE_CURRENT_SOURCE_DIR}/../nethost/lib")
#target_link_libraries(${TARGET_NAME} ${NetHost})

if(UNIX AND NOT APPLE)
    # target_compile_options(${TARGET_NAME} PRIVATE -std=c++17 -static)
    # target_link_libraries(${TARGET_NAME} -lstdc++ -static-libstdc++)
    # target_link_libraries(${TARGET_NAME} -static-libgcc -static-libstdc++)
    target_link_libraries(${TARGET_NAME} PRIVATE ${CMAKE_SOURCE_DIR}/../nethost/libnethost.a)
else()
    target_link_libraries(${TARGET_NAME} PRIVATE ${CMAKE_SOURCE_DIR}/../nethost/libnethost.lib)
    #target_compile_options(${TARGET_NAME} PRIVATE)# -I/home/parallels/Desktop/clang_7.0.1/include/c++/v1  -stdlib=libc++ -I$ENV{PROGRAMFILES}/LLVM/lib/clang/7.0.1/include -nodefaultlibs
endif()

target_compile_definitions(${TARGET_NAME} PRIVATE ALT_SERVER_API=true)
target_compile_definitions(${TARGET_NAME} PRIVATE NETHOST_USE_AS_STATIC=true)

set_target_properties(${TARGET_NAME} PROPERTIES OUTPUT_NAME "csharp-module")

target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../include)
target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty)

if(MSVC)
    install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")
else()
    install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.so DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")
endif(MSVC)

add_dependencies(core_clr_host alt-sdk)