#Stage 1: Build
From mcr.microsoft.com/dotnet/sdk:10.0 AS build 
WORKDIR /src

COPY . .
RUN dotnet publish AgenticEngineer.API/AgenticEngineer.API.csproj -c Release -o /app/publish

#Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT["dotnet", "AgenticEngineer.API.dll"]