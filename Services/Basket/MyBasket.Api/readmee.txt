Microsoft.Extensions.Caching.StackExchangeRedis // Install package

docker pull redis

docker run -d -p 6379:6379 --name basketdb-redis redis 
docker ps



//Ctrl+C for stop
////detachment mode

docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d


docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up --build

