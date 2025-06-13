FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY gitnetcore.csproj .
RUN dotnet restore "gitnetcore.csproj"
COPY . .
RUN dotnet build "gitnetcore.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "gitnetcore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","gitnetcore.dll"]
