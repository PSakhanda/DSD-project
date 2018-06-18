FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MicroBolt.Stock.Web/MicroBolt.Stock.Web.csproj MicroBolt.Stock.Web/
RUN dotnet restore MicroBolt.Stock.Web/MicroBolt.Stock.Web.csproj
COPY . .
WORKDIR /src/MicroBolt.Stock.Web
RUN dotnet build MicroBolt.Stock.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroBolt.Stock.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroBolt.Stock.Web.dll"]
