@echo off
setlocal EnableExtensions

REM Validate arg
if "%~1"=="" goto :usage

set "MIGRATION_NAME=%~1"
echo Adding migration "%MIGRATION_NAME%"...

REM Run EF Core migration (use quotes and backslashes on Windows)
dotnet ef migrations add "%MIGRATION_NAME%" ^
  --project "src\Migrations\Matchmaking.Migrations.Data" ^
  --startup-project "src\Hosts\Matchmaking.Hosts.WebApi"

set "rc=%ERRORLEVEL%"

if %rc% equ 0 (
  echo Migration "%MIGRATION_NAME%" added successfully.
) else (
  echo Error adding migration "%MIGRATION_NAME%". Exit code: %rc%
)

goto :eof

:usage
echo Usage: %~nx0 ^<MigrationName^>
exit /b 1
