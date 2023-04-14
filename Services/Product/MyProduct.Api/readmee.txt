using MongoDB.Driver; // Install package

docker pull mongo

docker run -d -p 27017:27017 --name productdb-mongo mongo 
docker ps


docker logs -f productdb-mongo
//Ctrl+C for stop

docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d



docker run -d -p 3000:3000 mongoclient/mongoclient


