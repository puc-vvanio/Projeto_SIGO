#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Services/Normas/Normas.API/Normas.API.csproj", "src/Services/Normas/Normas.API/"]
RUN dotnet restore "src/Services/Normas/Normas.API/Normas.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Normas/Normas.API"
RUN dotnet build "Normas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Normas.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Normas.API.dll"]