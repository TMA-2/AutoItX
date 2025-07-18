#Requires -Version 5.1

<#
.SYNOPSIS
    Wrapper script to invoke PSake build for AutoItX3.PowerShell module.

.DESCRIPTION
    This script provides an easy way to run the PSake build without needing to remember
    the PSake syntax. It installs PSake if needed and provides common build scenarios.

.PARAMETER Task
    The PSake task(s) to run. Default is 'Default' which runs the full build pipeline.

.PARAMETER Configuration
    Build configuration: Debug or Release. Default is Release.

.PARAMETER SkipTests
    Skip running tests during the build.

.PARAMETER OutputPath
    Custom output path for the built module. Default is .\Module

.PARAMETER ShowTasks
    Show available PSake tasks and exit.

.PARAMETER Force
    Force reinstall of PSake module if already present.

.EXAMPLE
    .\Invoke-PSakeBuild.ps1
    Run the default build (Clean, Restore, Build, Test, Package).

.EXAMPLE
    .\Invoke-PSakeBuild.ps1 -Task Build
    Run only the Build task.

.EXAMPLE
    .\Invoke-PSakeBuild.ps1 -Task Clean,Build,Package
    Run specific tasks in order.

.EXAMPLE
    .\Invoke-PSakeBuild.ps1 -Configuration Debug -SkipTests
    Debug build without tests.

.EXAMPLE
    .\Invoke-PSakeBuild.ps1 -ShowTasks
    Display all available PSake tasks.

.EXAMPLE
    .\Invoke-PSakeBuild.ps1 -Task QuickBuild
    Run a quick build (Restore, Build, Package) without cleaning or tests.
#>

[CmdletBinding()]
param(
    [string[]]$Task = @('Full'),

    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release',

    [switch]$SkipTests,

    [string]$OutputPath = '.\Module',

    [switch]$ShowTasks,

    [switch]$Force
)

$ErrorActionPreference = 'Stop'

# Script variables
$PSakeFile = Join-Path $PSScriptRoot "psake.ps1"

function Install-PSakeIfNeeded {
    Write-Host "🔍 Checking for PSake module..." -ForegroundColor Cyan

    $psakeModule = Get-Module -Name psake -ListAvailable

    if (-not $psakeModule -or $Force) {
        if ($Force -and $psakeModule) {
            Write-Host "🔄 Force reinstalling PSake..." -ForegroundColor Yellow
            Uninstall-Module -Name psake -AllVersions -Force -ErrorAction SilentlyContinue
        } else {
            Write-Host "📦 PSake not found. Installing PSake module..." -ForegroundColor Yellow
        }

        try {
            Install-Module -Name psake -Scope CurrentUser -Force -AllowClobber
            Write-Host "✅ PSake installed successfully" -ForegroundColor Green
        } catch {
            Write-Error "Failed to install PSake: $($_.Exception.Message)"
            exit 1
        }
    } else {
        Write-Host "✅ PSake module found: v$($psakeModule.Version)" -ForegroundColor Green
    }

    # Import the module
    Import-Module psake -Force
}

function Show-AvailableTasks {
    Write-Host ""
    Write-Host "📋 Available PSake Tasks:" -ForegroundColor Cyan
    Write-Host ("─" * 50) -ForegroundColor DarkGray

    try {
        # Get task information from PSake file
        $tasks = Invoke-psake $PSakeFile -docs
        return
    } catch {
        # Fallback to manual task list
        $taskDescriptions = @{
            'Default'     = 'Run full build pipeline (Clean, Restore, Build, Test, Package)'
            'Init'        = 'Initialize build environment and verify prerequisites'
            'Clean'       = 'Clean previous build artifacts'
            'Restore'     = 'Restore NuGet packages'
            'Build'       = 'Build the solution'
            'Test'        = 'Run module tests and validation'
            'Package'     = 'Copy build artifacts to module directory'
            'ShowSummary' = 'Display build summary'
            'Rebuild'     = 'Clean + Build'
            'Full'        = 'Complete build with summary'
            'QuickBuild'  = 'Fast build without clean or tests'
        }

        foreach ($task in $taskDescriptions.GetEnumerator() | Sort-Object Key) {
            Write-Host ("  {0,-12} - {1}" -f $task.Key, $task.Value) -ForegroundColor White
        }
    }

    Write-Host ""
    Write-Host "💡 Usage Examples:" -ForegroundColor Yellow
    Write-Host "  .\Invoke-PSakeBuild.ps1                           # Full build" -ForegroundColor Gray
    Write-Host "  .\Invoke-PSakeBuild.ps1 -Task Build               # Build only" -ForegroundColor Gray
    Write-Host "  .\Invoke-PSakeBuild.ps1 -Task Clean,Build         # Clean then build" -ForegroundColor Gray
    Write-Host "  .\Invoke-PSakeBuild.ps1 -Configuration Debug      # Debug build" -ForegroundColor Gray
    Write-Host "  .\Invoke-PSakeBuild.ps1 -Task QuickBuild          # Fast build" -ForegroundColor Gray
    Write-Host ""
}

function Invoke-PSakeBuildProcess {
    Write-Host ""
    Write-Host "🏗️  Starting PSake Build Process" -ForegroundColor Cyan
    Write-Host ("═" * 60) -ForegroundColor DarkGray
    Write-Host "Tasks: $($Task -join ', ')" -ForegroundColor White
    Write-Host "Configuration: $Configuration" -ForegroundColor White
    Write-Host "Skip Tests: $SkipTests" -ForegroundColor White
    Write-Host "Output Path: $OutputPath" -ForegroundColor White
    Write-Host ("═" * 60) -ForegroundColor DarkGray
    Write-Host ""

    # Prepare PSake parameters
    $psakeParameters = @{
        Configuration = $Configuration
        SkipTests = $SkipTests
        OutputPath = $OutputPath
    }

    try {
        # Run PSake with specified tasks and parameters
        Invoke-psake -buildFile $PSakeFile -taskList $Task -parameters $psakeParameters

        if ($psake.build_success) {
            Write-Host ""
            Write-Host "🎉 PSake build completed successfully!" -ForegroundColor Green
        } else {
            Write-Host ""
            Write-Host "❌ PSake build failed!" -ForegroundColor Red
            exit 1
        }
    } catch {
        Write-Host ""
        Write-Host "❌ PSake build error: $($_.Exception.Message)" -ForegroundColor Red
        exit 1
    }
}

# Main execution
try {
    # Check if PSake file exists
    if (-not (Test-Path $PSakeFile)) {
        Write-Error "PSake file not found: $PSakeFile"
        exit 1
    }

    # Install PSake if needed
    Install-PSakeIfNeeded

    # Show tasks if requested
    if ($ShowTasks) {
        Show-AvailableTasks
        return
    }

    # Run the build
    Invoke-PSakeBuildProcess

} catch {
    Write-Host ""
    Write-Host "💥 Script execution failed: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
