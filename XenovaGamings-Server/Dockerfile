# Base image: Linux ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage: SDK for building/publishing
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["XenovaGamings-Server.csproj", "./"]
RUN dotnet restore "./XenovaGamings-Server.csproj"
COPY . .
RUN dotnet build "XenovaGamings-Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XenovaGamings-Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XenovaGamings-Server.dll"]
