#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -fsSL https://deb.nodesource.com/setup_15.x | bash \
    && apt-get install nodejs -yq

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -fsSL https://deb.nodesource.com/setup_15.x | bash \
    && apt-get install nodejs -yq

COPY ["src/Web/SIGO.APP/SIGO.APP.csproj", "src/Web/SIGO.APP/"]
RUN dotnet restore "src/Web/SIGO.APP/SIGO.APP.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SIGO.APP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGO.APP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.APP.dll"]
