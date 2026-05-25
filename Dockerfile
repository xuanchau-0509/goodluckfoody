FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MVClayout/MVClayout.csproj", "MVClayout/"]
RUN dotnet restore "MVClayout/MVClayout.csproj"
COPY . .
WORKDIR "/src/MVClayout"
RUN dotnet build "MVClayout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVClayout.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVClayout.dll"]