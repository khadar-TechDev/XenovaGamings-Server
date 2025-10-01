# Base image: .NET runtime for console apps
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files first for restore caching
COPY XenovaGamings-Repo/XenovaGamings-Repo.csproj XenovaGamings-Repo/
COPY XenovaGamings-Service/XenovaGamings-Service.csproj XenovaGamings-Service/

RUN dotnet restore XenovaGamings-Service/XenovaGamings-Service.csproj

# Copy all source
COPY XenovaGamings-Repo/ XenovaGamings-Repo/
COPY XenovaGamings-Service/ XenovaGamings-Service/

WORKDIR /src/XenovaGamings-Service
RUN dotnet build -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XenovaGamings-Service.dll"]
