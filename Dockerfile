FROM 7hazard/node-clang-7 as clang

RUN apt-get update && apt-get install -y valgrind

# build coreclr-module
WORKDIR /clrhost
COPY clrhost/ .

RUN sh linux-build.sh
WORKDIR /clrhost/cmake-build-linux/src

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as dotnet

# build example resource
WORKDIR /altv-example/
COPY src/ .

RUN dotnet publish -c Release

FROM ubuntu:18.04

# construct server structure
WORKDIR /altv-server
COPY altv-server .
COPY server.cfg .
COPY resource.cfg resources/example/
COPY data/ ./data
COPY --from=clang /clrhost/cmake-build-linux/src/libcsharp-module.so modules/
COPY --from=dotnet /altv-example/AltV.Net.Example/bin/Release/netcoreapp2.2/publish resources/example/
COPY --from=dotnet /usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.2 /usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.2

RUN chmod +x ./altv-server

EXPOSE 7788/udp
EXPOSE 7788/tcp
EXPOSE 80/tcp

#ENTRYPOINT ["tail", "-f", "/dev/null"]
CMD ./altv-server