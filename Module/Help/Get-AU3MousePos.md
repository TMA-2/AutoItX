---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3MousePos
---

# Get-AU3MousePos

## SYNOPSIS

Gets the current mouse cursor position.

## SYNTAX

### Text (Default)

```
Get-AU3MousePos [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Get-AU3MousePos cmdlet retrieves the current position of the mouse cursor on the screen. This corresponds to the AutoIt MouseGetPos() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3MousePos cmdlet.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Drawing.Point

A Point containing the current position (x, y) of the mouse cursor.

## NOTES

This cmdlet is based on the MouseGetPos() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/MouseGetPos.htm)
