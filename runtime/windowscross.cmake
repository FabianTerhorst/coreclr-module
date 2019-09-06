cmake_minimum_required (VERSION 3.13)

# https://github.com/llvm-mirror/llvm/blob/master/cmake/platforms/WinMsvc.cmake

if(NOT CMAKE_HOST_SYSTEM_NAME MATCHES "Windows" AND NOT CMAKE_HOST_SYSTEM_PROCESSOR MATCHES "amd64")
  set(CMAKE_CROSS_COMPILING TRUE)
endif()

set(CMAKE_SYSTEM_NAME Windows)
set(CMAKE_SYSTEM_VERSION 10.0)
set(CMAKE_SYSTEM_PROCESSOR AMD64)

set(TARGET_ARCH x86_64)
set(WINSDK_ARCH x64)

set(MSVC_BASE "/WINDOWS/VC/Tools/MSVC/14.16.27023")
set(WINSDK_BASE "/WINDOWS/SDK")
set(WINSDK_VER "10.0.17763.0")

set(MSVC_INCLUDE "${MSVC_BASE}/include")
set(MSVC_LIB "${MSVC_BASE}/lib")
set(WINSDK_INCLUDE "${WINSDK_BASE}/Include/${WINSDK_VER}")
set(WINSDK_LIB "${WINSDK_BASE}/Lib/${WINSDK_VER}")

if(NOT EXISTS "${WINSDK_INCLUDE}/um/Windows.h")
    message(FATAL_ERROR "Cannot find Windows.h")
endif()
if(NOT EXISTS "${WINSDK_INCLUDE}/um/WINDOWS.H")
    set(case_sensitive_filesystem TRUE)
endif()

function(init_user_prop prop)
  if(${prop})
    set(ENV{_${prop}} "${${prop}}")
  else()
    set(${prop} "$ENV{_${prop}}" PARENT_SCOPE)
  endif()
endfunction()

function(generate_winsdk_vfs_overlay winsdk_include_dir output_path)
  set(include_dirs)
  file(GLOB_RECURSE entries LIST_DIRECTORIES true "${winsdk_include_dir}/*")
  foreach(entry ${entries})
    if(IS_DIRECTORY "${entry}")
      list(APPEND include_dirs "${entry}")
    endif()
  endforeach()

  file(WRITE "${output_path}"  "version: 0\n")
  file(APPEND "${output_path}" "case-sensitive: false\n")
  file(APPEND "${output_path}" "roots:\n")

  foreach(dir ${include_dirs})
    file(GLOB headers RELATIVE "${dir}" "${dir}/*.h")
    if(NOT headers)
      continue()
    endif()

    file(APPEND "${output_path}" "  - name: \"${dir}\"\n")
    file(APPEND "${output_path}" "    type: directory\n")
    file(APPEND "${output_path}" "    contents:\n")

    foreach(header ${headers})
      file(APPEND "${output_path}" "      - name: \"${header}\"\n")
      file(APPEND "${output_path}" "        type: file\n")
      file(APPEND "${output_path}" "        external-contents: \"${dir}/${header}\"\n")
    endforeach()
  endforeach()
endfunction()

function(generate_winsdk_lib_symlinks winsdk_um_lib_dir output_dir)
  execute_process(COMMAND "${CMAKE_COMMAND}" -E make_directory "${output_dir}")
  file(GLOB libraries RELATIVE "${winsdk_um_lib_dir}" "${winsdk_um_lib_dir}/*")
  foreach(library ${libraries})
    get_filename_component(name_we "${library}" NAME_WE)
    get_filename_component(ext "${library}" EXT)
    string(TOLOWER "${name_we}" lower_name)
    string(TOUPPER "${name_we}" upper_name)
    string(TOLOWER "${ext}" lower_ext)
    string(TOUPPER "${ext}" upper_ext)

    execute_process(COMMAND
      "${CMAKE_COMMAND}"
      -E create_symlink
      "${winsdk_um_lib_dir}/${library}"
      "${output_dir}/${lower_name}${lower_ext}"
    )

    execute_process(COMMAND
      "${CMAKE_COMMAND}"
      -E create_symlink
      "${winsdk_um_lib_dir}/${library}"
      "${output_dir}/${upper_name}${upper_ext}"
    )

    execute_process(COMMAND
      "${CMAKE_COMMAND}"
      -E create_symlink
      "${winsdk_um_lib_dir}/${library}"
      "${output_dir}/${upper_name}${lower_ext}"
    )

    execute_process(COMMAND
      "${CMAKE_COMMAND}"
      -E create_symlink
      "${winsdk_um_lib_dir}/${library}"
      "${output_dir}/${lower_name}${upper_ext}"
    )
  endforeach()
endfunction()

set(CMAKE_ASM_COMPILER clang-cl)
set(CMAKE_C_COMPILER clang-cl)
set(CMAKE_CXX_COMPILER clang-cl)
set(CMAKE_LINKER lld-link)

set(CMAKE_NINJA_DEPTYPE_RC msvc)
set(CMAKE_RC_COMPILER ${CMAKE_SOURCE_DIR}/deps/buildtools/llvm-rc)

#set(CMAKE_C_COMPILER_TARGET ${TARGET_TRIPLE})
#set(CMAKE_CXX_COMPILER_TARGET ${TARGET_TRIPLE})

####
#### Compilation
####

set(COMPILE_FLAGS
  -fuse-ld=lld
  -D_CRT_SECURE_NO_WARNINGS
  --target=${TARGET_ARCH}-windows-msvc
  -fms-compatibility-version=19.11
  -imsvc "${MSVC_INCLUDE}"
  -imsvc "${WINSDK_INCLUDE}/ucrt"
  -imsvc "${WINSDK_INCLUDE}/shared"
  -imsvc "${WINSDK_INCLUDE}/um"
  -imsvc "${WINSDK_INCLUDE}/winrt"
)
if(case_sensitive_filesystem)
  # Ensure all sub-configures use the top-level VFS overlay instead of generating their own.
  init_user_prop(winsdk_vfs_overlay_path)
  if(NOT winsdk_vfs_overlay_path)
    set(winsdk_vfs_overlay_path "${CMAKE_BINARY_DIR}/winsdk_vfs_overlay.yaml")
    generate_winsdk_vfs_overlay("${WINSDK_BASE}/Include/${WINSDK_VER}" "${winsdk_vfs_overlay_path}")
    init_user_prop(winsdk_vfs_overlay_path)
  endif()
  list(APPEND COMPILE_FLAGS
       -Xclang -ivfsoverlay -Xclang "${winsdk_vfs_overlay_path}")
endif()
string(REPLACE ";" " " COMPILE_FLAGS "${COMPILE_FLAGS}")

set(_CMAKE_C_FLAGS_INITIAL "${CMAKE_C_FLAGS}" CACHE STRING "")
set(CMAKE_C_FLAGS "${_CMAKE_C_FLAGS_INITIAL} ${COMPILE_FLAGS}" CACHE STRING "" FORCE)

set(_CMAKE_CXX_FLAGS_INITIAL "${CMAKE_CXX_FLAGS}" CACHE STRING "")
set(CMAKE_CXX_FLAGS "${_CMAKE_CXX_FLAGS_INITIAL} ${COMPILE_FLAGS}" CACHE STRING "" FORCE)

####
#### Linking
####

set(LINK_FLAGS
    /manifest:no

    -libpath:"${MSVC_LIB}/${WINSDK_ARCH}"
    -libpath:"${WINSDK_LIB}/ucrt/${WINSDK_ARCH}"
    -libpath:"${WINSDK_LIB}/um/${WINSDK_ARCH}"
)
if(case_sensitive_filesystem)
  # Ensure all sub-configures use the top-level symlinks dir instead of generating their own.
  init_user_prop(winsdk_lib_symlinks_dir)
  if(NOT winsdk_lib_symlinks_dir)
    set(winsdk_lib_symlinks_dir "${CMAKE_BINARY_DIR}/winsdk_lib_symlinks")
    generate_winsdk_lib_symlinks("${WINSDK_BASE}/Lib/${WINSDK_VER}/um/${WINSDK_ARCH}" "${winsdk_lib_symlinks_dir}")
    generate_winsdk_lib_symlinks("${MSVC_LIB}/${WINSDK_ARCH}" "${winsdk_lib_symlinks_dir}")
    init_user_prop(winsdk_lib_symlinks_dir)
  endif()
  list(APPEND LINK_FLAGS
       -libpath:"${winsdk_lib_symlinks_dir}")
endif()
string(REPLACE ";" " " LINK_FLAGS "${LINK_FLAGS}")

set(_CMAKE_EXE_LINKER_FLAGS_INITIAL "${CMAKE_EXE_LINKER_FLAGS}" CACHE STRING "")
set(CMAKE_EXE_LINKER_FLAGS "${_CMAKE_EXE_LINKER_FLAGS_INITIAL} ${LINK_FLAGS}" CACHE STRING "" FORCE)

set(_CMAKE_MODULE_LINKER_FLAGS_INITIAL "${CMAKE_MODULE_LINKER_FLAGS}" CACHE STRING "")
set(CMAKE_MODULE_LINKER_FLAGS "${_CMAKE_MODULE_LINKER_FLAGS_INITIAL} ${LINK_FLAGS}" CACHE STRING "" FORCE)

set(_CMAKE_SHARED_LINKER_FLAGS_INITIAL "${CMAKE_SHARED_LINKER_FLAGS}" CACHE STRING "")
set(CMAKE_SHARED_LINKER_FLAGS "${_CMAKE_SHARED_LINKER_FLAGS_INITIAL} ${LINK_FLAGS}" CACHE STRING "" FORCE)

####
#### RC Compiler (llvm-rc doesnt work, use https://raw.githubusercontent.com/nico/hack/master/res/rc.cc)
####

#set(CMAKE_RC_COMPILER_INIT llvm-rc-7 CACHE INTERNAL "${CMAKE_SYSTEM_NAME} llvm rc" FORCE)
#set(CMAKE_RC_COMPLIER llvm-rc-7 CACHE INTERNAL "${CMAKE_SYSTEM_NAME} llvm rc" FORCE)
#set(CMAKE_GENERATOR_RC llvm-rc-7 CACHE INTERNAL "${CMAKE_SYSTEM_NAME} llvm rc" FORCE)

####
####
####

#set(CMAKE_C_STANDARD_LIBRARIES "" CACHE STRING "" FORCE)
#set(CMAKE_CXX_STANDARD_LIBRARIES "" CACHE STRING "" FORCE)