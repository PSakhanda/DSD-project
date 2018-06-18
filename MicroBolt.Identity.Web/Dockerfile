FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 59427
EXPOSE 44335

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MicroBolt.Identity.Web/MicroBolt.Identity.Web.csproj MicroBolt.Identity.Web/
RUN dotnet restore MicroBolt.Identity.Web/MicroBolt.Identity.Web.csproj
COPY . .
WORKDIR /src/MicroBolt.Identity.Web
RUN dotnet build MicroBolt.Identity.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroBolt.Identity.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroBolt.Identity.Web.dll"]
