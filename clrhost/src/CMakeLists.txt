set(TARGET_NAME core_clr_host)

add_library(${TARGET_NAME} SHARED altv.cpp clrHost.cpp)

set_target_properties(${TARGET_NAME} PROPERTIES OUTPUT_NAME "dotnet-wrapper")

if(MSVC)
    set_target_properties(${TARGET_NAME} PROPERTIES LINK_FLAGS "/WHOLEARCHIVE:altv_c_api")
else()
    set_target_properties(${TARGET_NAME} PROPERTIES LINK_FLAGS "-Wl,-whole-archive")
endif(MSVC)

target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../include)
target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty)

target_link_libraries(${TARGET_NAME} PUBLIC altv_c_api)

install(FILES ${CMAKE_BINARY_DIR}/src/dotnet-wrapper.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../server/modules")