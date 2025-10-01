# Build stage: SDK for building/publishing
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["XenovaGamings-Repo.csproj", "./"]
RUN dotnet restore "./XenovaGamings-Repo.csproj"
COPY . .
RUN dotnet build "XenovaGamings-Repo.csproj" -c Release -o /app/build
RUN dotnet publish "XenovaGamings-Repo.csproj" -c Release -o /app/publish /p:UseAppHost=false
