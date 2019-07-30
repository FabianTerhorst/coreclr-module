#FROM 7hazard/node-clang-7 as clang
FROM ubuntu:18.10 as clang

# build coreclr-module
WORKDIR /runtime

RUN add-apt-repository -y ppa:ubuntu-toolchain-r/test;apt-get update;apt-get -y install gcc-8 g++-8; apt-get -y install build-essential;
RUN CXX=/usr/bin/g++-8
RUN CC=/usr/bin/gcc-8
RUN apt-get -y install cmake

COPY runtime/ .
RUN mkdir build && cd build && cmake -DCMAKE_BUILD_TYPE=RelWithDebInfo .. && cmake --build . --config Release

#RUN sh linux-build.sh
#WORKDIR /runtime/cmake-build-linux/src

WORKDIR /runtime/build/src

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as dotnet

# build example resource
WORKDIR /altv-example/
COPY api/ .

RUN cd AltV.Net.Example && dotnet publish -c Release

#FROM debian:stable
FROM ubuntu:18.10

RUN apt-get update
RUN apt-get install -y apt-utils
RUN apt-get install -y libc6-i386

RUN apt-get install -y gdb

# install valgrind
#RUN apt-get update && apt-get install -y valgrind

# construct server structure
WORKDIR /altv-server
COPY altv-server .
COPY server.cfg .
COPY start.sh .
COPY resource.cfg resources/example/
COPY data/ ./data
COPY --from=clang /runtime/build/src/libcsharp-module.so modules/
COPY --from=dotnet /altv-example/AltV.Net.Example/bin/Release/netcoreapp2.2/publish resources/example/
COPY --from=dotnet /usr/share/dotnet/shared/Microsoft.NETCore.App /usr/share/dotnet/shared/Microsoft.NETCore.App

RUN chmod +x ./altv-server

EXPOSE 7788/udp
EXPOSE 7788/tcp

#ENTRYPOINT ["tail", "-f", "/dev/null"]
CMD sh start.sh