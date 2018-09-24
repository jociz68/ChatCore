FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 2089
EXPOSE 44338

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/services/Identity.API/Identity.API.csproj src/services/Identity.API/
RUN dotnet restore src/services/Identity.API/Identity.API.csproj
COPY . .
WORKDIR /src/src/services/Identity.API
RUN dotnet build Identity.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Identity.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity.API.dll"]
