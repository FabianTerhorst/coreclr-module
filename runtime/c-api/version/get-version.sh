#!/bin/bash

cat <<EOM >> version.h.tmp
#pragma once

#define CSHARP_VERSION "$VERSION"
EOM

if [ -f version.h ]; then
  if cmp -s version.h.tmp version.h; then
    rm version.h.tmp
  else
    rm version.h
    mv version.h.tmp version.h
  fi
else
  mv version.h.tmp version.h
fi

