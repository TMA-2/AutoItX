#Requires -Version 5.1

<#
.SYNOPSIS
    Build script for the AutoItX3.PowerShell module.

.DESCRIPTION
    This script builds the AutoItX3.PowerShell module by:
    1. Cleaning previous build artifacts
    2. Building the AutoItX3.Assembly dependency
    3. Building the AutoItX3.PowerShell module
    4. Copying built assemblies to the Module directory
    5. Updating XML documentation
    6. Running optional tests

.PARAMETER Configuration
    Build configuration: Debug or Release. Default is Release.

.PARAMETER Clean
    If specified, performs a clean build by removing all bin and obj directories.

.PARAMETER SkipTests
    If specified, skips running any tests after the build.

.PARAMETER OutputPath
    Custom output path for the built module. Default is .\Module

.EXAMPLE
    .\Build-AutoItXModule.ps1
    Build the module in Release configuration.

.EXAMPLE
    .\Build-AutoItXModule.ps1 -Configuration Debug -Clean
    Perform a clean Debug build.

.EXAMPLE
    .\Build-AutoItXModule.ps1 -OutputPath "C:\MyModules\AutoItX"
    Build and copy to a custom output directory.
#>

[CmdletBinding()]
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release',

    [switch]$Clean,

    [switch]$SkipTests,

    [string]$OutputPath = '.\Module'
)

# Script variables
$script:StartTime = Get-Date
$script:RootPath = $PSScriptRoot
$script:SolutionFile = Join-Path $script:RootPath "AutoItX3.PowerShell.sln"
$script:ModuleOutputPath = Join-Path $script:RootPath $OutputPath
$script:AssemblyProject = Join-Path $script:RootPath "AutoItX3.Assembly\AutoItX3.Assembly.csproj"
$script:PowerShellProject = Join-Path $script:RootPath "AutoItX3.PowerShell\AutoItX3.PowerShell.csproj"

# Build functions
function Write-BuildMessage {
    param(
        [Parameter(Mandatory)]
        [string]$Message,

        [ValidateSet('Info', 'Warning', 'Error', 'Success')]
        [string]$Type = 'Info'
    )

    $timestamp = Get-Date -Format "HH:mm:ss"
    $color = switch ($Type) {
        'Info'    { 'Cyan' }
        'Warning' { 'Yellow' }
        'Error'   { 'Red' }
        'Success' { 'Green' }
    }

    Write-Host "[$timestamp] " -NoNewline -ForegroundColor DarkGray
    Write-Host $Message -ForegroundColor $color
}

function Test-Prerequisites {
    Write-BuildMessage "Checking build prerequisites..." -Type Info

    # Check for .NET SDK
    try {
        $dotnetVersion = & dotnet --version 2>$null
        if ($LASTEXITCODE -eq 0) {
            Write-BuildMessage "Found .NET SDK version: $dotnetVersion" -Type Success
        } else {
            throw "dotnet command failed"
        }
    } catch {
        Write-BuildMessage "ERROR: .NET SDK not found. Please install .NET SDK." -Type Error
        return $false
    }

    # Check for MSBuild (fallback)
    try {
        $msbuildPath = & where.exe msbuild.exe 2>$null
        if ($msbuildPath) {
            Write-BuildMessage "Found MSBuild at: $msbuildPath" -Type Success
        }
    } catch {
        Write-BuildMessage "MSBuild not found in PATH (using dotnet build instead)" -Type Warning
    }

    # Check required files exist
    $requiredFiles = @($script:SolutionFile, $script:AssemblyProject, $script:PowerShellProject)
    foreach ($file in $requiredFiles) {
        if (-not (Test-Path $file)) {
            Write-BuildMessage "ERROR: Required file not found: $file" -Type Error
            return $false
        }
    }

    Write-BuildMessage "Prerequisites check completed successfully" -Type Success
    return $true
}

function Invoke-CleanBuild {
    if ($Clean) {
        Write-BuildMessage "Performing clean build..." -Type Info

        # Clean solution
        & dotnet clean $script:SolutionFile --configuration $Configuration --verbosity minimal
        if ($LASTEXITCODE -ne 0) {
            Write-BuildMessage "ERROR: Failed to clean solution" -Type Error
            return $false
        }

        # Remove bin and obj directories
        $cleanDirs = Get-ChildItem -Path $script:RootPath -Recurse -Directory | Where-Object { $_.Name -in @('bin', 'obj') }
        foreach ($dir in $cleanDirs) {
            Write-BuildMessage "Removing directory: $($dir.FullName)" -Type Info
            Remove-Item $dir.FullName -Recurse -Force -ErrorAction SilentlyContinue
        }

        Write-BuildMessage "Clean completed successfully" -Type Success
    }
    return $true
}

function Invoke-RestorePackages {
    Write-BuildMessage "Restoring NuGet packages..." -Type Info

    & dotnet restore $script:SolutionFile --verbosity minimal
    if ($LASTEXITCODE -ne 0) {
        Write-BuildMessage "ERROR: Package restore failed" -Type Error
        return $false
    }

    Write-BuildMessage "Package restore completed successfully" -Type Success
    return $true
}

function Invoke-BuildProject {
    param(
        [Parameter(Mandatory)]
        [string]$ProjectPath,

        [Parameter(Mandatory)]
        [string]$ProjectName
    )

    Write-BuildMessage "Building $ProjectName..." -Type Info

    $buildArgs = @(
        'build'
        $ProjectPath
        '--configuration', $Configuration
        '--verbosity', 'minimal'
        '--no-restore'
    )

    & dotnet @buildArgs
    if ($LASTEXITCODE -ne 0) {
        Write-BuildMessage "ERROR: Failed to build $ProjectName" -Type Error
        return $false
    }

    Write-BuildMessage "$ProjectName built successfully" -Type Success
    return $true
}

function Copy-BuildArtifacts {
    Write-BuildMessage "Copying build artifacts to module directory..." -Type Info

    # Ensure output directory exists
    if (-not (Test-Path $script:ModuleOutputPath)) {
        New-Item -Path $script:ModuleOutputPath -ItemType Directory -Force | Out-Null
    }

    # Define source paths
    $assemblyBinPath = Join-Path $script:RootPath "AutoItX3.Assembly\bin\$Configuration\net48"
    $powerShellBinPath = Join-Path $script:RootPath "AutoItX3.PowerShell\bin\$Configuration\net48"

    # Files to copy
    $filesToCopy = @(
        @{
            Source = Join-Path $assemblyBinPath "AutoItX3.Assembly.dll"
            Target = Join-Path $script:ModuleOutputPath "AutoItX3.Assembly.dll"
        },
        @{
            Source = Join-Path $assemblyBinPath "AutoItX3.Assembly.xml"
            Target = Join-Path $script:ModuleOutputPath "AutoItX3.Assembly.xml"
        },
        @{
            Source = Join-Path $powerShellBinPath "AutoItX3.PowerShell.dll"
            Target = Join-Path $script:ModuleOutputPath "AutoItX3.PowerShell.dll"
        }
    )

    # Copy native AutoItX DLLs if they exist in Dependencies
    $dependenciesPath = Join-Path $script:RootPath "Dependencies"
    if (Test-Path $dependenciesPath) {
        $nativeDlls = @("AutoItX3.dll", "AutoItX3_x64.dll")
        foreach ($dll in $nativeDlls) {
            $sourceDll = Join-Path $dependenciesPath $dll
            if (Test-Path $sourceDll) {
                $filesToCopy += @{
                    Source = $sourceDll
                    Target = Join-Path $script:ModuleOutputPath $dll
                }
            }
        }
    }

    # Perform the copying
    foreach ($file in $filesToCopy) {
        if (Test-Path $file.Source) {
            Write-BuildMessage "Copying $($file.Source) -> $($file.Target)" -Type Info
            Copy-Item -Path $file.Source -Destination $file.Target -Force
        } else {
            Write-BuildMessage "WARNING: Source file not found: $($file.Source)" -Type Warning
        }
    }

    Write-BuildMessage "Build artifacts copied successfully" -Type Success
    return $true
}

function Test-ModuleBuild {
    if ($SkipTests) {
        Write-BuildMessage "Skipping tests as requested" -Type Info
        return $true
    }

    Write-BuildMessage "Testing module build..." -Type Info

    # Test if module can be imported
    try {
        $manifestPath = Join-Path $script:ModuleOutputPath "AutoItX.psd1"
        if (Test-Path $manifestPath) {
            $testResult = Test-ModuleManifest -Path $manifestPath -ErrorAction Stop
            Write-BuildMessage "Module manifest is valid: $($testResult.Name) v$($testResult.Version)" -Type Success
        } else {
            Write-BuildMessage "WARNING: Module manifest not found at $manifestPath" -Type Warning
        }

        # Test if main DLL exists and is valid
        $mainDll = Join-Path $script:ModuleOutputPath "AutoItX3.PowerShell.dll"
        if (Test-Path $mainDll) {
            $assemblyInfo = [System.Reflection.Assembly]::ReflectionOnlyLoadFrom($mainDll)
            Write-BuildMessage "Main assembly loaded successfully: $($assemblyInfo.FullName)" -Type Success
        } else {
            Write-BuildMessage "ERROR: Main assembly not found: $mainDll" -Type Error
            return $false
        }

    } catch {
        Write-BuildMessage "ERROR: Module test failed: $($_.Exception.Message)" -Type Error
        return $false
    }

    Write-BuildMessage "Module testing completed successfully" -Type Success
    return $true
}

function Show-BuildSummary {
    $endTime = Get-Date
    $duration = $endTime - $script:StartTime

    Write-Host ""
    Write-Host "═══════════════════════════════════════════════════════════════" -ForegroundColor DarkGray
    Write-Host "                          BUILD SUMMARY                          " -ForegroundColor Cyan
    Write-Host "═══════════════════════════════════════════════════════════════" -ForegroundColor DarkGray
    Write-Host "Configuration: " -NoNewline -ForegroundColor White
    Write-Host $Configuration -ForegroundColor Yellow
    Write-Host "Duration: " -NoNewline -ForegroundColor White
    Write-Host "$($duration.TotalSeconds.ToString('F2')) seconds" -ForegroundColor Yellow
    Write-Host "Output Path: " -NoNewline -ForegroundColor White
    Write-Host $script:ModuleOutputPath -ForegroundColor Yellow

    # Show output files
    if (Test-Path $script:ModuleOutputPath) {
        $outputFiles = Get-ChildItem -Path $script:ModuleOutputPath -File | Where-Object { $_.Extension -in @('.dll', '.xml', '.psd1') }
        if ($outputFiles) {
            Write-Host "Output Files:" -ForegroundColor White
            foreach ($file in $outputFiles) {
                Write-Host "  • $($file.Name)" -ForegroundColor Green
            }
        }
    }

    Write-Host "═══════════════════════════════════════════════════════════════" -ForegroundColor DarkGray
    Write-Host ""
}

# Main build process
function Start-Build {
    Write-Host ""
    Write-Host "╔══════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
    Write-Host "║                    AutoItX3.PowerShell Build                 ║" -ForegroundColor Cyan
    Write-Host "╚══════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
    Write-Host ""

    Write-BuildMessage "Starting build process..." -Type Info
    Write-BuildMessage "Configuration: $Configuration" -Type Info
    Write-BuildMessage "Output Path: $script:ModuleOutputPath" -Type Info
    Write-Host ""

    # Execute build steps
    $steps = @(
        @{ Name = "Prerequisites"; Action = { Test-Prerequisites } },
        @{ Name = "Clean"; Action = { Invoke-CleanBuild } },
        @{ Name = "Restore Packages"; Action = { Invoke-RestorePackages } },
        @{ Name = "Build AutoItX3.Assembly"; Action = { Invoke-BuildProject -ProjectPath $script:AssemblyProject -ProjectName "AutoItX3.Assembly" } },
        @{ Name = "Build AutoItX3.PowerShell"; Action = { Invoke-BuildProject -ProjectPath $script:PowerShellProject -ProjectName "AutoItX3.PowerShell" } },
        @{ Name = "Copy Artifacts"; Action = { Copy-BuildArtifacts } },
        @{ Name = "Test Module"; Action = { Test-ModuleBuild } }
    )

    foreach ($step in $steps) {
        Write-Host ""
        Write-BuildMessage "─── $($step.Name) $('─' * (50 - $step.Name.Length))" -Type Info

        $success = & $step.Action
        if (-not $success) {
            Write-BuildMessage "BUILD FAILED at step: $($step.Name)" -Type Error
            exit 1
        }
    }

    Write-Host ""
    Write-BuildMessage "BUILD COMPLETED SUCCESSFULLY!" -Type Success
    Show-BuildSummary
}

# Start the build process
Start-Build
