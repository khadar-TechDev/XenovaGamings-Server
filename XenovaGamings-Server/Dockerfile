# Base image: ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files first (restore caching)
COPY XenovaGamings-Repo/XenovaGamings-Repo.csproj XenovaGamings-Repo/
COPY XenovaGamings-Service/XenovaGamings-Service.csproj XenovaGamings-Service/
COPY XenovaGamings-Server/XenovaGamings-Server.csproj XenovaGamings-Server/

# Restore dependencies
RUN dotnet restore XenovaGamings-Server/XenovaGamings-Server.csproj

# Copy all source code
COPY XenovaGamings-Repo/ XenovaGamings-Repo/
COPY XenovaGamings-Service/ XenovaGamings-Service/
COPY XenovaGamings-Server/ XenovaGamings-Server/

# Build
WORKDIR /src/XenovaGamings-Server
RUN dotnet build -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point
ENTRYPOINT ["dotnet", "XenovaGamings-Server.dll"]
