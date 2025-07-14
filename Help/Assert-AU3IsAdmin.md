---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Assert-AU3IsAdmin
---

# Assert-AU3IsAdmin

## SYNOPSIS

Checks if the current process is running with administrator privileges.

## SYNTAX

### __AllParameterSets

```
Assert-AU3IsAdmin [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Assert-AU3IsAdmin cmdlet checks whether the current PowerShell process is running with administrator privileges. This is useful for ensuring that scripts or commands that require elevated permissions can execute properly. The cmdlet corresponds to the AutoIt function IsAdmin().

## EXAMPLES

### Example 1

```powershell
Assert-AU3IsAdmin
```

This example checks if the current process is running with administrator privileges. Returns $true if running as admin, $false otherwise.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Object

Returns a boolean value indicating whether the current process has administrator privileges.

## NOTES

This cmdlet is based on the AutoIt IsAdmin() function and is useful for determining if elevation is required before executing administrative tasks.

## RELATED LINKS

[AutoIt IsAdmin Function](https://www.autoitscript.com/autoit3/docs/functions/IsAdmin.htm)










