FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DotNETCore.Identity.API.Presentation/DotNETCore.Identity.API.Presentation.csproj", "src/DotNETCore.Identity.API.Presentation/"]
COPY ["src/DotNETCore.Identity.API.Application/DotNETCore.Identity.API.Application.csproj", "src/DotNETCore.Identity.API.Application/"]
COPY ["src/DotNETCore.Identity.API.CrossCutting.Core/DotNETCore.Identity.API.CrossCutting.Core.csproj", "src/DotNETCore.Identity.API.CrossCutting.Core/"]
COPY ["src/DotNETCore.Identity.API.Domain/DotNETCore.Identity.API.Domain.csproj", "src/DotNETCore.Identity.API.Domain/"]
COPY ["src/DotNETCore.Identity.API.CrossCutting/DotNETCore.Identity.API.CrossCutting.csproj", "src/DotNETCore.Identity.API.CrossCutting/"]
COPY ["src/DotNETCore.Identity.API.Infrastructure.Data/DotNETCore.Identity.API.Infrastructure.Data.csproj", "src/DotNETCore.Identity.API.Infrastructure.Data/"]
COPY ["src/DotNETCore.Identity.API.Infrastructure.Providers/DotNETCore.Identity.API.Infrastructure.Providers.csproj", "src/DotNETCore.Identity.API.Infrastructure.Providers/"]
RUN dotnet restore "./src/DotNETCore.Identity.API.Presentation/./DotNETCore.Identity.API.Presentation.csproj"
COPY . .
WORKDIR "/src/src/DotNETCore.Identity.API.Presentation"
RUN dotnet build "./DotNETCore.Identity.API.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotNETCore.Identity.API.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNETCore.Identity.API.Presentation.dll"]
