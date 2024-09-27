#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CIA.Net.Public.Bot/CIA.Net.Public.Bot.csproj", "CIA.Net.Public.Bot/"]
COPY ["CIA.Net.Public.Data/CIA.Net.Public.Data.csproj", "CIA.Net.Public.Data/"]
COPY ["CIA.Net.Public.Domain/CIA.Net.Public.Domain.csproj", "CIA.Net.Public.Domain/"]
RUN dotnet restore "./CIA.Net.Public.Bot/CIA.Net.Public.Bot.csproj"
COPY . .
WORKDIR "/src/CIA.Net.Public.Bot"
RUN dotnet build "./CIA.Net.Public.Bot.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CIA.Net.Public.Bot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CIA.Net.Public.Bot.dll"]