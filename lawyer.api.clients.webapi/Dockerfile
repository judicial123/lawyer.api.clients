FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
EXPOSE 5124

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["lawyer.api.clients.webapi/lawyer.api.clients.webapi.csproj", "lawyer.api.clients.webapi/"]
COPY ["lawyer.api.clients.application/lawyer.api.clients.application.csproj", "lawyer.api.clients.application/"]
COPY ["lawyer.api.clients.domain/lawyer.api.clients.domain.csproj", "lawyer.api.clients.domain/"]
COPY ["lawyer.api.clients.datastore.mssql/lawyer.api.clients.datastore.mssql.csproj", "lawyer.api.clients.datastore.mssql/"]
RUN dotnet restore "lawyer.api.clients.webapi/lawyer.api.clients.webapi.csproj"
COPY . .
WORKDIR "/src/lawyer.api.clients.webapi"
RUN dotnet build "./lawyer.api.clients.webapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./lawyer.api.clients.webapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lawyer.api.clients.webapi.dll"]
