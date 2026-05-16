#Requires -Modules psake

<#
.SYNOPSIS
    PSake build script for AutoItX3.PowerShell module.

.DESCRIPTION
    This PSake build script automates the build process for the AutoItX3.PowerShell module.

    Available tasks:
    - Clean: Remove bin/obj directories and clean solution
    - Restore: Restore NuGet packages
    - Build: Build the solution
    - Test: Run module tests
    - Package: Copy artifacts to module directory
    - Default: Run Clean, Restore, Build, Test, Package

.EXAMPLE
    Invoke-psake .\psakefile.ps1
    Run the default build task.

.EXAMPLE
    Invoke-psake .\psakefile.ps1 -taskList Clean,Build
    Run only Clean and Build tasks.

.EXAMPLE
    Invoke-psake .\psakefile.ps1 -parameters @{Configuration='Debug'}
    Build in Debug configuration.

.EXAMPLE
    Invoke-psake .\psakefile.ps1 -parameters @{Configuration='Release'; SkipTests=$true}
    Release build without tests.
#>

# Build properties with defaults
Properties {
    $Configuration = 'Release'
    $SkipTests = $false
    $OutputPath = '.\Module'
    $SolutionFile = 'AutoItX3.PowerShell.sln'
    $AssemblyProject = 'AutoItX3.Assembly\AutoItX3.Assembly.csproj'
    $PowerShellProject = 'AutoItX3.PowerShell\AutoItX3.PowerShell.csproj'
    $DotNetVerbosity = 'minimal'
}

# Format check - ensures required tools are available
FormatTaskName {
    param($taskName)
    Write-Host "🔨 Executing Task: " -NoNewline -ForegroundColor Cyan
    Write-Host $taskName -ForegroundColor Yellow
    Write-Host ("─" * 60) -ForegroundColor DarkGray
}

# Task definitions
Task Default -Depends Clean, Restore, Build, Test, Package

Task Init {
    Write-Host "🚀 AutoItX3.PowerShell Build Script" -ForegroundColor Cyan
    Write-Host "Configuration: $Configuration" -ForegroundColor White
    Write-Host "Output Path: $OutputPath" -ForegroundColor White
    Write-Host "Skip Tests: $SkipTests" -ForegroundColor White
    Write-Host ""

    # Verify build tools
    Assert (Get-Command dotnet -ErrorAction SilentlyContinue) "dotnet CLI is required for building"

    # Verify project files exist
    Assert (Test-Path $SolutionFile) "Solution file not found: $SolutionFile"
    Assert (Test-Path $AssemblyProject) "Assembly project not found: $AssemblyProject"
    Assert (Test-Path $PowerShellProject) "PowerShell project not found: $PowerShellProject"

    Write-Host "✅ Initialization completed" -ForegroundColor Green
}

Task Clean -Depends Init {
    Write-Host "🧹 Cleaning previous build artifacts..." -ForegroundColor Yellow

    # Clean the solution
    Exec { dotnet clean $SolutionFile --configuration $Configuration --verbosity $DotNetVerbosity }

    # Remove bin and obj directories
    $cleanDirs = Get-ChildItem -Recurse -Directory | Where-Object { $_.Name -in @('bin', 'obj') }
    foreach ($dir in $cleanDirs) {
        Write-Host "  Removing: $($dir.FullName)" -ForegroundColor DarkGray
        Remove-Item $dir.FullName -Recurse -Force -ErrorAction SilentlyContinue
    }

    Write-Host "✅ Clean completed" -ForegroundColor Green
}

Task Restore -Depends Init {
    Write-Host "📦 Restoring NuGet packages..." -ForegroundColor Yellow

    Exec { dotnet restore $SolutionFile --verbosity $DotNetVerbosity }

    Write-Host "✅ Package restore completed" -ForegroundColor Green
}

Task Build -Depends Restore {
    Write-Host "🔧 Building solution..." -ForegroundColor Yellow

    # Build AutoItX3.Assembly first (dependency)
    Write-Host "  Building AutoItX3.Assembly..." -ForegroundColor White
    Exec {
        dotnet build $AssemblyProject `
            --configuration $Configuration `
            --verbosity $DotNetVerbosity `
            --no-restore
    }

    # Build AutoItX3.PowerShell
    Write-Host "  Building AutoItX3.PowerShell..." -ForegroundColor White
    Exec {
        dotnet build $PowerShellProject `
            --configuration $Configuration `
            --verbosity $DotNetVerbosity `
            --no-restore
    }

    Write-Host "✅ Build completed" -ForegroundColor Green
}

Task Test -Depends Build -precondition { -not $SkipTests } {
    Write-Host "🧪 Testing module build..." -ForegroundColor Yellow

    $moduleDir = Resolve-Path $OutputPath -ErrorAction SilentlyContinue
    if (-not $moduleDir) {
        $moduleDir = $OutputPath
    }

    # Test if module manifest exists and is valid
    $manifestPath = Join-Path $moduleDir "AutoItX.psd1"
    if (Test-Path $manifestPath) {
        $manifest = Test-ModuleManifest -Path $manifestPath -ErrorAction Stop
        Write-Host "  Module manifest valid: $($manifest.Name) v$($manifest.Version)" -ForegroundColor White
    } else {
        Write-Warning "Module manifest not found at: $manifestPath"
    }

    # Test if main assembly exists and can be loaded
    $assemblyBin = "AutoItX3.PowerShell\bin\$Configuration\net48"
    $mainDll = Join-Path $assemblyBin "AutoItX3.PowerShell.dll"

    if (Test-Path $mainDll) {
        try {
            $assembly = [System.Reflection.Assembly]::ReflectionOnlyLoadFrom((Resolve-Path $mainDll))
            Write-Host "  Assembly loaded: $($assembly.GetName().Name)" -ForegroundColor White
        } catch {
            throw "Failed to load assembly: $($_.Exception.Message)"
        }
    } else {
        throw "Main assembly not found: $mainDll"
    }

    Write-Host "✅ Tests completed" -ForegroundColor Green
}

Task Package -Depends Build {
    Write-Host "📦 Packaging module artifacts..." -ForegroundColor Yellow

    # Ensure output directory exists
    if (-not (Test-Path $OutputPath)) {
        New-Item -Path $OutputPath -ItemType Directory -Force | Out-Null
        Write-Host "  Created output directory: $OutputPath" -ForegroundColor White
    }

    # Define source and target paths
    $assemblyBin = "AutoItX3.Assembly\bin\$Configuration\net48"
    $powerShellBin = "AutoItX3.PowerShell\bin\$Configuration\net48"

    # Copy main assemblies
    $filesToCopy = @(
        @{
            Source = Join-Path $assemblyBin "AutoItX3.Assembly.dll"
            Target = Join-Path $OutputPath "AutoItX3.Assembly.dll"
            Description = "AutoItX3 Assembly"
        },
        @{
            Source = Join-Path $assemblyBin "AutoItX3.Assembly.xml"
            Target = Join-Path $OutputPath "AutoItX3.Assembly.xml"
            Description = "XML Documentation"
        },
        @{
            Source = Join-Path $powerShellBin "AutoItX3.PowerShell.dll"
            Target = Join-Path $OutputPath "AutoItX3.PowerShell.dll"
            Description = "PowerShell Module"
        }
    )

    # Copy native AutoItX DLLs if they exist
    $dependenciesPath = "Dependencies"
    if (Test-Path $dependenciesPath) {
        $nativeDlls = @("AutoItX3.dll", "AutoItX3_x64.dll")
        foreach ($dll in $nativeDlls) {
            $sourceDll = Join-Path $dependenciesPath $dll
            if (Test-Path $sourceDll) {
                $filesToCopy += @{
                    Source = $sourceDll
                    Target = Join-Path $OutputPath $dll
                    Description = "Native AutoItX DLL ($dll)"
                }
            }
        }
    }

    # Perform file copying
    foreach ($file in $filesToCopy) {
        if (Test-Path $file.Source) {
            Write-Host "  Copying: $($file.Description)" -ForegroundColor White
            Copy-Item -Path $file.Source -Destination $file.Target -Force
        } else {
            Write-Warning "Source file not found: $($file.Source)"
        }
    }

    Write-Host "✅ Packaging completed" -ForegroundColor Green
}

Task ShowSummary -Depends Package {
    Write-Host ""
    Write-Host "📊 BUILD SUMMARY" -ForegroundColor Cyan
    Write-Host ("═" * 40) -ForegroundColor DarkGray
    Write-Host "Configuration: $Configuration" -ForegroundColor White
    Write-Host "Output Path: $(Resolve-Path $OutputPath)" -ForegroundColor White

    # Show packaged files
    if (Test-Path $OutputPath) {
        $outputFiles = Get-ChildItem -Path $OutputPath -File | Where-Object { $_.Extension -in @('.dll', '.xml', '.psd1') }
        if ($outputFiles) {
            Write-Host "Packaged Files:" -ForegroundColor White
            foreach ($file in $outputFiles) {
                $size = [math]::Round($file.Length / 1KB, 1)
                Write-Host "  📄 $($file.Name) ($size KB)" -ForegroundColor Green
            }
        }
    }

    Write-Host ("═" * 40) -ForegroundColor DarkGray
    Write-Host "🎉 BUILD SUCCESSFUL!" -ForegroundColor Green
    Write-Host ""
}

# Task aliases for convenience
Task Rebuild -Depends Clean, Build
Task Full -Depends Default, ShowSummary
Task QuickBuild -Depends Restore, Build, Package
