#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Taxi24.Gateways.REST/Taxi24.Gateways.REST.csproj", "Taxi24.Gateways.REST/"]
RUN dotnet restore "Taxi24.Gateways.REST/Taxi24.Gateways.REST.csproj"
COPY . .
WORKDIR "/src/Taxi24.Gateways.REST"
RUN dotnet build "Taxi24.Gateways.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taxi24.Gateways.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taxi24.Gateways.REST.dll"]