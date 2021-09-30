docker build -t altv-server-executable -f DockerfileExecutable .
docker run -d --publish 7788:7788 altv-server-executable