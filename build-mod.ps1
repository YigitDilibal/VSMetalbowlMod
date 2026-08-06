# Builds the assembly and packages modinfo.json + assets/ + the DLL into a mod zip,
# then drops it into the Vintage Story Mods folder.

$ErrorActionPreference = "Stop"

$projectDir = $PSScriptRoot
$modsDir = Join-Path $env:APPDATA "VintagestoryData\Mods"
$zipPath = Join-Path $modsDir "metalbowlsandpots.zip"
$staging = Join-Path $env:TEMP "mbap-staging"

Write-Host "Building assembly..." -ForegroundColor Cyan
dotnet build "$projectDir\MetalBowlsAndPots.csproj" -c Release
if ($LASTEXITCODE -ne 0) { throw "Build failed" }

Write-Host "Staging mod files..." -ForegroundColor Cyan
if (Test-Path $staging) { Remove-Item $staging -Recurse -Force }
New-Item -ItemType Directory -Path $staging -Force | Out-Null

Copy-Item "$projectDir\modinfo.json" $staging
Copy-Item "$projectDir\modicon.png" $staging
Copy-Item "$projectDir\assets" $staging -Recurse
Copy-Item "$projectDir\bin\Release\MetalBowlsAndPots.dll" $staging

Write-Host "Packing zip..." -ForegroundColor Cyan
if (Test-Path $zipPath) { Remove-Item $zipPath -Force }
Compress-Archive -Path "$staging\*" -DestinationPath $zipPath

Remove-Item $staging -Recurse -Force
Write-Host "Done -> $zipPath" -ForegroundColor Green
