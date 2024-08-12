#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# syntax=docker/dockerfile:1.3
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
ARG DB_CONNECTION_STRING
ARG NUTRITION_API_KEY
ARG NUTRITION_API_BASE_URL
ARG DEEPL_API_BASE_URL
ARG DEEPL_API_KEY
ARG RABBIT_HOST
ARG RABBIT_PASSWORD
ARG RABBIT_USERNAME

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

FROM build AS publish
RUN dotnet publish "Recipe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variable for runtime
ARG DB_CONNECTION_STRING
ENV ConnectionStrings__Postgress=${DB_CONNECTION_STRING}

#Debugging: Output the environment variable to verify
RUN echo "ConnectionStrings__Postgress=${ConnectionStrings__Postgress}"


ARG NUTRITION_API_BASE_URL
ENV Nutrition__NUTRITION_API_BASE_URL=${NUTRITION_API_BASE_URL}

ARG NUTRITION_API_KEY
ENV Nutrition__NUTRITION_API_KEY=${NUTRITION_API_KEY}

ARG DEEPL_API_BASE_URL
ENV DeepL__DEEPL_API_BASE_URL=${DEEPL_API_BASE_URL}

ARG DEEPL_API_KEY
ENV DeepL__DEEPL_API_KEY=${DEEPL_API_KEY}

ARG RABBIT_HOST
ENV RabbitMQ__Host=${RABBIT_HOST}
RUN echo "RabbitMQ__Host=${RabbitMQ__Host}"

ARG RABBIT_PASSWORD
ENV RabbitMQ__Password=${RABBIT_PASSWORD}

ARG RABBIT_USERNAME
ENV RabbitMQ__Username=${RABBIT_USERNAME}

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Recipe.API.dll"]
