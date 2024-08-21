#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# syntax=docker/dockerfile:1.3
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["Directory.Build.Props", "."]
COPY ["src/ApiGateway/ApiGateway.csproj", "ApiGateway/"]

RUN dotnet restore "./ApiGateway/ApiGateway.csproj" 

COPY . .
WORKDIR "/src/src/ApiGateway/"

FROM build AS publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
