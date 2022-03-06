@echo off

(
  echo #pragma once
  echo.
  echo #define CSHARP_VERSION "%GITHUB_REF_NAME%"
) > version.h.tmp

if not exist version.h goto rename

fc version.h version.h.tmp > nul
if errorlevel 1 goto remove

rm version.h.tmp
goto end

:remove
rm version.h
:rename
mv version.h.tmp version.h

:end