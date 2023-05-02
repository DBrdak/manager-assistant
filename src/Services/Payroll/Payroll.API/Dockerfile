#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Payroll/Payroll.API/Payroll.API.csproj", "src/Services/Payroll/Payroll.API/"]
RUN dotnet restore "src/Services/Payroll/Payroll.API/Payroll.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Payroll/Payroll.API"
RUN dotnet build "Payroll.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payroll.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payroll.API.dll"]