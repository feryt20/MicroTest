Npgsql // Install package
Dapper // Install package

docker pull postgres
docker pull dpage/pgadmin4

docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d

