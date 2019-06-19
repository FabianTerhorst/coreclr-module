FROM 7hazard/node-clang-7 as clang

# build coreclr-module
WORKDIR /runtime
COPY runtime/ .

RUN sh linux-build.sh
WORKDIR /runtime/cmake-build-linux/src

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

# install valgrind
#RUN apt-get update && apt-get install -y valgrind

# construct server structure
WORKDIR /altv-server
COPY altv-server .
COPY server.cfg .
COPY start.sh .
COPY resource.cfg resources/example/
COPY data/ ./data
COPY --from=clang /runtime/cmake-build-linux/src/libcsharp-module.so modules/
COPY --from=dotnet /altv-example/AltV.Net.Example/bin/Release/netcoreapp2.2/publish resources/example/
COPY --from=dotnet /usr/share/dotnet/shared/Microsoft.NETCore.App /usr/share/dotnet/shared/Microsoft.NETCore.App

RUN chmod +x ./altv-server

EXPOSE 7788/udp
EXPOSE 7788/tcp

ENTRYPOINT ["tail", "-f", "/dev/null"]
#CMD ./altv-server