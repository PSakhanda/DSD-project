FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MicroBolt.Cart.Web/MicroBolt.Cart.Web.csproj MicroBolt.Cart.Web/
RUN dotnet restore MicroBolt.Cart.Web/MicroBolt.Cart.Web.csproj
COPY . .
WORKDIR /src/MicroBolt.Cart.Web
RUN dotnet build MicroBolt.Cart.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroBolt.Cart.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroBolt.Cart.Web.dll"]
