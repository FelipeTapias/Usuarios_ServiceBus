#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Usuarios_ServiceBus/src/Application/Usuarios_ServiceBus/Usuarios_ServiceBus.csproj", "Usuarios_ServiceBus/src/Application/Usuarios_ServiceBus/"]
RUN dotnet restore "Usuarios_ServiceBus/src/Application/Usuarios_ServiceBus/Usuarios_ServiceBus.csproj"
COPY . .
WORKDIR "/src/Usuarios_ServiceBus/src/Application/Usuarios_ServiceBus"
RUN dotnet build "Usuarios_ServiceBus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Usuarios_ServiceBus.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Usuarios_ServiceBus.dll"]