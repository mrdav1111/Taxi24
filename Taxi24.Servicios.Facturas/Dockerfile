#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Taxi24.Servicios.Facturas/Taxi24.Servicios.Facturas.csproj", "Taxi24.Servicios.Facturas/"]
RUN dotnet restore "Taxi24.Servicios.Facturas/Taxi24.Servicios.Facturas.csproj"
COPY . .
WORKDIR "/src/Taxi24.Servicios.Facturas"
RUN dotnet build "Taxi24.Servicios.Facturas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taxi24.Servicios.Facturas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taxi24.Servicios.Facturas.dll"]