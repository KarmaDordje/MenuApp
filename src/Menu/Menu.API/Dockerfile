#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# syntax=docker/dockerfile:1.3
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
ARG DB_CONNECTION_STRING
ARG RABBIT_HOST
ARG RABBIT_PASSWORD
ARG RABBIT_USERNAME

WORKDIR /src
COPY ["Directory.Build.Props", "."]
COPY ["src/Menu/Menu.API/Menu.API.csproj", "Menu.API/"]
COPY ["src/Menu/Menu.Domain/Menu.Domain.csproj", "Menu.Domain/"]
COPY ["src/Menu/Menu.Infrastructure/Menu.Infrastructure.csproj", "Menu.Infrastructure/"]
COPY ["src/Menu/Menu.Application/Menu.Application.csproj", "Menu.Application/"]
COPY ["src/Menu/Menu.Contracts/Menu.Contracts.csproj", "Menu.Contracts/"]
RUN dotnet restore "./Menu.API/Menu.API.csproj" 

COPY . .
WORKDIR "/src/src/Menu/Menu.API/"

FROM build AS publish
RUN dotnet publish "Menu.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variable for runtime
ARG DB_CONNECTION_STRING
ENV ConnectionStrings__Postgress=${DB_CONNECTION_STRING}


ARG RABBIT_HOST
ENV RabbitMQ__Host=${RABBIT_HOST}
RUN echo "RabbitMQ__Host=${RabbitMQ__Host}"

ARG RABBIT_PASSWORD
ENV RabbitMQ__Password=${RABBIT_PASSWORD}

ARG RABBIT_USERNAME
ENV RabbitMQ__Username=${RABBIT_USERNAME}
RUN echo "RabbitMQ__Username=${RabbitMQ__Username}"

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Menu.API.dll"]
