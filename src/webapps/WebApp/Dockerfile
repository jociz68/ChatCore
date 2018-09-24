FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52245
EXPOSE 44387

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/webapps/WebApp/WebApp.csproj src/webapps/WebApp/
RUN dotnet restore src/webapps/WebApp/WebApp.csproj
COPY . .
WORKDIR /src/src/webapps/WebApp
RUN dotnet build WebApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApp.dll"]
