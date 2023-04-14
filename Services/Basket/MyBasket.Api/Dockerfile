#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Basket/MyBasket.Api/MyBasket.Api.csproj", "Services/Basket/MyBasket.Api/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/Basket/MyBasket.Api/MyBasket.Api.csproj"
COPY . .
WORKDIR "/src/Services/Basket/MyBasket.Api"
RUN dotnet build "MyBasket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBasket.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBasket.Api.dll"]