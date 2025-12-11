#!/bin/bash
set -e

echo "Waiting for SQL Server to be available..."

# wait until SQL Server responds
until /opt/mssql-tools/bin/sqlcmd -S sqlserver,1433 -U sa -P "$SA_PASSWORD" -Q "SELECT 1" &> /dev/null
do
  echo "SQL Server is starting..."
  sleep 2
done

echo "SQL Server is up. Running migrations..."

# run EF migrations
dotnet EntrioX.API.dll --migrate

echo "Starting application..."
exec dotnet EntrioX.API.dll
