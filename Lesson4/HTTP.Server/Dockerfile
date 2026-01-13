# Базовый образ
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Сборка
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копируем все проекты и решение
COPY . .

# Восстанавливаем зависимости через основной проект или .sln
RUN dotnet restore "HTTP.Server/HTTP.Server.csproj"

# Собираем
WORKDIR "/src/HTTP.Server"
RUN dotnet build "HTTP.Server.csproj" -c Release -o /app/build

# Публикация
FROM build AS publish
RUN dotnet publish "HTTP.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HTTP.Server.dll"]