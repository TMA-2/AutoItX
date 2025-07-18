#Requires -Version 5.1

<#
.SYNOPSIS
    Quick build script for AutoItX3.PowerShell module.

.DESCRIPTION
    A simplified build script that performs the essential steps to build the AutoItX3.PowerShell module.

.PARAMETER Configuration
    Build configuration: Debug or Release. Default is Release.

.EXAMPLE
    .\Quick-Build.ps1
    Build the module in Release configuration.

.EXAMPLE
    .\Quick-Build.ps1 -Configuration Debug
    Build the module in Debug configuration.
#>

[CmdletBinding()]
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release'
)

$ErrorActionPreference = 'Stop'

try {
    Write-Host "🔨 Building AutoItX3.PowerShell Module ($Configuration)" -ForegroundColor Cyan
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray

    # Restore packages
    Write-Host "📦 Restoring NuGet packages..." -ForegroundColor Yellow
    dotnet restore AutoItX3.PowerShell.sln --verbosity quiet

    # Build solution
    Write-Host "🔧 Building solution..." -ForegroundColor Yellow
    dotnet build AutoItX3.PowerShell.sln --configuration $Configuration --verbosity minimal --no-restore

    # Copy assemblies to Module directory
    Write-Host "📋 Copying assemblies to Module directory..." -ForegroundColor Yellow

    $assemblyBin = "AutoItX3.Assembly\bin\$Configuration\net48"
    $powerShellBin = "AutoItX3.PowerShell\bin\$Configuration\net48"
    $moduleDir = "Module"

    # Copy main assemblies
    Copy-Item "$assemblyBin\AutoItX3.Assembly.dll" "$moduleDir\" -Force
    Copy-Item "$assemblyBin\AutoItX3.Assembly.xml" "$moduleDir\" -Force
    Copy-Item "$powerShellBin\AutoItX3.PowerShell.dll" "$moduleDir\" -Force

    Write-Host "✅ Build completed successfully!" -ForegroundColor Green
    Write-Host "📂 Module files are in: $(Resolve-Path $moduleDir)" -ForegroundColor Green

} catch {
    Write-Host "❌ Build failed: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
