# BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./EntrioX/EntrioX.csproj"

# WORKDIR is critical here so 'dotnet publish' sees the Migrations folder
WORKDIR "/src/EntrioX"
RUN dotnet publish "EntrioX.csproj" -c Release -o /app/publish --no-restore

# RUNTIME STAGE
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY ./EntrioX/entrypoint.sh .
RUN chmod +x entrypoint.sh
ENTRYPOINT ["./entrypoint.sh"]
