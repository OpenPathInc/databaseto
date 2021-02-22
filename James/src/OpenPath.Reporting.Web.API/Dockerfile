#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster AS build
WORKDIR /src
COPY ["OpenPath.Reporting.Web.API/OpenPath.Reporting.Web.API.csproj", "OpenPath.Reporting.Web.API/"]
RUN dotnet restore "OpenPath.Reporting.Web.API/OpenPath.Reporting.Web.API.csproj"
COPY . .
WORKDIR "/src/OpenPath.Reporting.Web.API"
RUN dotnet build "OpenPath.Reporting.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenPath.Reporting.Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenPath.Reporting.Web.API.dll"]
