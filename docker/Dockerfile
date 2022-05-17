#FROM 7hazard/node-clang-7 as clang
FROM ubuntu:22.04 as clang

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

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as dotnet

# build example resource
WORKDIR /altv-example/
COPY api/ .

RUN cd AltV.Net.Example && dotnet publish -c Release

RUN cd AltV.Net.Host && dotnet publish -c Release

RUN cd AltV.Net.Resources.Chat && dotnet publish -c Release

#FROM debian:stable
FROM ubuntu:22.04

COPY --from=dotnet /usr/share/dotnet /usr/share/dotnet
RUN ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

RUN apt-get update
RUN apt-get install -y apt-utils
RUN apt-get install -y libc6-i386

RUN apt-get install -y gdb

RUN apt-get install -y wget

RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb

RUN apt-get install -y software-properties-common

RUN add-apt-repository universe
RUN apt-get install -y apt-transport-https

RUN apt-get update

RUN export PATH="$PATH:/root/.dotnet/tools"

RUN dotnet tool install --global dotnet-trace --version 3.0.0-preview9.19454.1

RUN apt-get install libatomic1

RUN dotnet tool install --global dotnet-sos

#RUN dotnet-sos install

# construct server structure
WORKDIR /altv-server
COPY altv-server .
COPY server.cfg .
COPY start.sh .
COPY startgdb.sh .
COPY libnode.so.72 .
COPY libnode-module.so modules/

COPY --from=dotnet /altv-example/AltV.Net.Benchmarks resources/example/

COPY resource.cfg resources/example/
COPY --from=dotnet /altv-example/AltV.Net.Resources.Chat/resource.cfg resources/chat/
COPY data/ ./data
#COPY chat/ resources/chat
COPY --from=clang /runtime/build/src/libcsharp-module.so modules/
COPY --from=dotnet /altv-example/AltV.Net.Example/bin/Release/netcoreapp3.1/publish resources/example/
COPY --from=dotnet /altv-example/AltV.Net.Resources.Chat/bin/Release/netcoreapp3.1/publish resources/chat/
#COPY --from=dotnet /altv-example/AltV.Net.Host/bin/Release/netcoreapp3.1/publish .
COPY --from=dotnet /altv-example/AltV.Net.Host/bin/Release/netcoreapp3.1/publish/AltV.Net.Host.dll .
#COPY --from=dotnet /altv-example/AltV.Net.Host/bin/Release/netcoreapp3.1/publish/AltV.Net.Host.runtimeconfig.json .
#COPY --from=dotnet /altv-example/AltV.Net.Host/bin/Release/netcoreapp3.1/publish/Microsoft.Diagnostics.Tracing.TraceEvent.dll .
RUN ls -l
RUN chmod +x ./altv-server

EXPOSE 7788/udp
EXPOSE 7788/tcp

RUN COREHOST_TRACE=1

#ENTRYPOINT ["tail", "-f", "/dev/null"]
#CMD sh startgdb.sh