set(TARGET_NAME core_clr_host)

add_library(${TARGET_NAME} SHARED altv.cpp CSharpScriptRuntime.cpp CSharpResource.cpp CoreClr.cpp)# clrHost.cpp

if(UNIX AND NOT APPLE)
    target_compile_options(${TARGET_NAME} PRIVATE -std=c++17 -static -nostdinc++ -I/home/parallels/Desktop/clang_7.0.1/include/c++/v1 -nodefaultlibs -lc++ -lc++abi -lm -lc -lgcc_s -lgcc)
else()
    target_compile_options(${TARGET_NAME} PRIVATE -std=c++17 -stdlib=libc++ -static)
endif()

set_target_properties(${TARGET_NAME} PROPERTIES OUTPUT_NAME "csharp-module")

target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../include)
target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty)

if(MSVC)
    install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")
else()
    install(FILES ${CMAKE_BINARY_DIR}/src/csharp-module.so DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")
endif(MSVC)
