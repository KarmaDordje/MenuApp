#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
ARG DB_CONNECTION_STRING
RUN echo "ConnectionStrings Postgress: ${DB_CONNECTION_STRING}"
WORKDIR /src
COPY ["Directory.Build.Props", "."]
COPY ["Recipe/Recipe.API/Recipe.API.csproj", "Recipe.API/"]
COPY ["Recipe/Recipe.Domain/Recipe.Domain.csproj", "Recipe.Domain/"]
COPY ["Recipe/Recipe.Infrastructure/Recipe.Infrastructure.csproj", "Recipe.Infrastructure/"]
COPY ["Recipe/Recipe.Application/Recipe.Application.csproj", "Recipe.Application/"]
COPY ["Recipe/Recipe.Contracts/Recipe.Contracts.csproj", "Recipe.Contracts/"]
RUN dotnet restore "./Recipe.API/Recipe.API.csproj" 

COPY . .
WORKDIR "/src/Recipe/Recipe.API/"
RUN dotnet build "Recipe.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recipe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ConnectionStrings__Postgress=${DB_CONNECTION_STRING}

#Debugging: Output the environment variable to verify
RUN echo "ConnectionStrings__Postgress=${ConnectionStrings__Postgress}"

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Recipe.API.dll"]
