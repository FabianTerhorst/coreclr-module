if (WIN32)
  add_custom_target(c-api
    call get-version.bat
    WORKING_DIRECTORY ${CMAKE_CURRENT_LIST_DIR}/version
  )
else()
  add_custom_target(c-api
    bash get-version.sh
    WORKING_DIRECTORY ${CMAKE_CURRENT_LIST_DIR}/version
  )
endif()