FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MicroBolt.Clients.Web/MicroBolt.Clients.Web.csproj MicroBolt.Clients.Web/
RUN dotnet restore MicroBolt.Clients.Web/MicroBolt.Clients.Web.csproj
COPY . .
WORKDIR /src/MicroBolt.Clients.Web
RUN dotnet build MicroBolt.Clients.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroBolt.Clients.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroBolt.Clients.Web.dll"]
