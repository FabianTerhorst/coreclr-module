#!/bin/bash
BASEDIR=$(dirname $0)
export LD_LIBRARY_PATH=${BASEDIR}
./altv-server
