#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskTracker.API/TaskTracker.API.csproj", "TaskTracker.API/"]
COPY ["TaskTracker.BLL/TaskTracker.BLL.csproj", "TaskTracker.BLL/"]
COPY ["TaskTracker.Models/TaskTracker.Infrastructures.csproj", "TaskTracker.Models/"]
COPY ["TaskTracker.DAL/TaskTracker.DAL.csproj", "TaskTracker.DAL/"]
RUN dotnet restore "TaskTracker.API/TaskTracker.API.csproj"
COPY . .
WORKDIR "/src/TaskTracker.API"
RUN dotnet build "TaskTracker.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskTracker.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskTracker.API.dll"]