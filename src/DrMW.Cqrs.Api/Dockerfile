FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# GDI+ libraries and timezone setup
RUN apt-get update && apt-get install -y libc6-dev libgdiplus

RUN apt-get update && apt-get install -y curl

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DrMW.Cqrs.Api/DrMW.Cqrs.Api.csproj", "src/DrMW.Cqrs.Api/"]
COPY ["src/DrMW.Cqrs.Services/DrMW.Cqrs.Services.csproj", "src/DrMW.Cqrs.Services/"]
COPY ["src/DrMW.Cqrs.Repository/DrMW.Cqrs.Repository.csproj", "src/DrMW.Cqrs.Repository/"]
COPY ["src/DrMW.Cqrs.Core/DrMW.Cqrs.Core.csproj", "src/DrMW.Cqrs.Core/"]
COPY ["src/DrMW.Cqrs.Models/DrMW.Cqrs.Models.csproj", "src/DrMW.Cqrs.Models/"]
RUN dotnet restore "src/DrMW.Cqrs.Api/DrMW.Cqrs.Api.csproj"
COPY . .
WORKDIR "/src/src/DrMW.Cqrs.Api"
RUN dotnet build "DrMW.Cqrs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DrMW.Cqrs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrMW.Cqrs.Api.dll"]
