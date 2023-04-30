#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/WorkSchedule/WorkSchedule.API/WorkSchedule.API.csproj", "src/Services/WorkSchedule/WorkSchedule.API/"]
COPY ["src/Services/WorkSchedule/WorkSchedule.Application/WorkSchedule.Application.csproj", "src/Services/WorkSchedule/WorkSchedule.Application/"]
COPY ["src/Services/WorkSchedule/WorkSchedule.Domain/WorkSchedule.Domain.csproj", "src/Services/WorkSchedule/WorkSchedule.Domain/"]
COPY ["src/Services/WorkSchedule/WorkSchedule.Infrastructure/WorkSchedule.Infrastructure.csproj", "src/Services/WorkSchedule/WorkSchedule.Infrastructure/"]
RUN dotnet restore "src/Services/WorkSchedule/WorkSchedule.API/WorkSchedule.API.csproj"
COPY . .
WORKDIR "/src/src/Services/WorkSchedule/WorkSchedule.API"
RUN dotnet build "WorkSchedule.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkSchedule.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkSchedule.API.dll"]