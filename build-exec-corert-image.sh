docker build -t altv-server-corert -f DockerfileCoreRT .
docker run -d --publish 7788:7788 -it --entrypoint /bin/bash altv-server-corert