# Linux tabanlı bir .NET Core imajını baz al
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
EXPOSE 88

# Gerekirse, daha fazla yapılandırma ve bağımlılıklar ekleyebilirsiniz

# Uygulama dosyalarını kopyala
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Çalıştırılabilir imajı oluştur
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Etkinlik_Takip_Sistemi.dll"]
