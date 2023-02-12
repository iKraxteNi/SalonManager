#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SalonManager/Server/SalonManager.Server.csproj", "SalonManager/Server/"]
COPY ["SalonManager/Client/SalonManager.Client.csproj", "SalonManager/Client/"]
COPY ["SalonManager/Shared/SalonManager.Shared.csproj", "SalonManager/Shared/"]
RUN dotnet restore "SalonManager/Server/SalonManager.Server.csproj"
COPY . .
WORKDIR "/src/SalonManager/Server"
RUN dotnet build "SalonManager.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalonManager.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalonManager.Server.dll"]