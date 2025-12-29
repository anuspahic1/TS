#!/bin/bash
set -e

echo "Waiting for SQL Server on port 1433..."

until timeout 1s bash -c 'cat < /dev/null > /dev/tcp/sqlserver/1433' 2>/dev/null; do
  echo "SQL Server is not reachable yet - waiting..."
  sleep 2
done

echo "SQL Server is up! Running migrations..."
dotnet EntrioX.dll --migrate || echo "Migration failed or already applied"

echo "Starting application..."
exec dotnet EntrioX.dll
