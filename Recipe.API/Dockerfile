#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Directory.Build.Props", "."]
COPY ["Recipe.API/Recipe.API.csproj", "Recipe.API/"]
COPY ["Recipe.Domain/Recipe.Domain.csproj", "Recipe.Domain/"]
COPY ["Recipe.Infrastructure/Recipe.Infrastructure.csproj", "Recipe.Infrastructure/"]
COPY ["Recipe.Application/Recipe.Application.csproj", "Recipe.Application/"]
COPY ["Recipe.Contracts/Recipe.Contracts.csproj", "Recipe.Contracts/"]
RUN dotnet restore "./Recipe.API/Recipe.API.csproj" -a $TARGETARCH 
COPY . .
WORKDIR "/src/Recipe.API"
RUN dotnet build "./Recipe.API.csproj" -a $TARGETARCH -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Recipe.API.csproj" -a $TARGETARCH -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Recipe.API.dll"]
