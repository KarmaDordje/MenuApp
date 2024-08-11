# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# syntax=docker/dockerfile:1.3

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
ARG DB_CONNECTION_STRING
ARG NUTRITION_API_BASE_URL
ARG NUTRITION_API_KEY
ARG DEEPL_API_BASE_URL
ARG DEEPL_API_KEY

# Use secrets for build and set environment variables directly
RUN --mount=type=secret,id=NUTRITION_API_BASE_URL \
    --mount=type=secret,id=NUTRITION_API_KEY \
    --mount=type=secret,id=DEEPL_API_BASE_URL \
    --mount=type=secret,id=DEEPL_API_KEY \
    dotnet restore "./Recipe.API/Recipe.API.csproj"

COPY . .
WORKDIR "/src/Recipe/Recipe.API/"
RUN dotnet build "Recipe.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recipe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variables for runtime
ARG DB_CONNECTION_STRING
ENV ConnectionStrings__Postgress=${DB_CONNECTION_STRING}

ARG NUTRITION_API_BASE_URL
ENV Nutrition__NUTRITION_API_BASE_URL=${NUTRITION_API_BASE_URL}

ARG NUTRITION_API_KEY
ENV Nutrition__NUTRITION_API_KEY=${NUTRITION_API_KEY}

ARG DEEPL_API_BASE_URL
ENV DeepL__DEEPL_API_BASE_URL=${DEEPL_API_BASE_URL}

ARG DEEPL_API_KEY
ENV DeepL__DEEPL_API_KEY=${DEEPL_API_KEY}

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Recipe.API.dll"]
