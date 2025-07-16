---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3ErrorCode
---

# Get-AU3ErrorCode

## SYNOPSIS

Gets the last AutoIt error code.

## SYNTAX

### __AllParameterSets

```
Get-AU3ErrorCode [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Get-AU3ErrorCode cmdlet retrieves the last error code from AutoIt operations. This is useful for debugging and error handling in automation scripts.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3ErrorCode cmdlet.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Int32

The last error code as an integer value.

## NOTES

This cmdlet is based on the ErrorCode() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/ErrorCode.htm)
