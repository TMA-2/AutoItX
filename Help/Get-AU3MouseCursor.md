---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3MouseCursor
---

# Get-AU3MouseCursor

## SYNOPSIS

Gets the current mouse cursor type.

## SYNTAX

### __AllParameterSets

```
Get-AU3MouseCursor [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Get-AU3MouseCursor cmdlet retrieves the current mouse cursor type or ID. This corresponds to the AutoIt MouseGetCursor() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3MouseCursor cmdlet.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

None. This cmdlet does not accept pipeline input.

## OUTPUTS

### System.Int32

The current mouse cursor ID. Returns specific numeric values corresponding to different cursor types.

## NOTES

This cmdlet is based on the corresponding AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[AutoIt Documentation](https://www.autoitscript.com/autoit3/docs/)









