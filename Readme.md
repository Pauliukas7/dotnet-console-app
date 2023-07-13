Commands: git checkout webapi
cd ChessBoard.Api
docker-compose up -d

Docker-compose file spins up a mongoDB container on local port 27017, connection string is: `mongodb://localhost:27017`.\
Then it spins up the webapi application based on Dockerfile configuration. The app connects to the mongo container. The swagger URL to access the app is http://localhost:8080/swagger/index.html