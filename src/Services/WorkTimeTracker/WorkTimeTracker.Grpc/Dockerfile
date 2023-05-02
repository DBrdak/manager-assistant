#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/WorkTimeTracker/WorkTimeTracker.Grpc/WorkTimeTracker.Grpc.csproj", "src/Services/WorkTimeTracker/WorkTimeTracker.Grpc/"]
RUN dotnet restore "src/Services/WorkTimeTracker/WorkTimeTracker.Grpc/WorkTimeTracker.Grpc.csproj"
COPY . .
WORKDIR "/src/src/Services/WorkTimeTracker/WorkTimeTracker.Grpc"
RUN dotnet build "WorkTimeTracker.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkTimeTracker.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkTimeTracker.Grpc.dll"]