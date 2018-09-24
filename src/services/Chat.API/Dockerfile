FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 2425
EXPOSE 44343

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/services/Chat.API/Chat.API.csproj src/services/Chat.API/
RUN dotnet restore src/services/Chat.API/Chat.API.csproj
COPY . .
WORKDIR /src/src/services/Chat.API
RUN dotnet build Chat.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Chat.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chat.API.dll"]
