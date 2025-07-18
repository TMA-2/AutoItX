---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3WinCaretPos
---

# Get-AU3WinCaretPos

## SYNOPSIS

Gets the position of the text caret in a window.

## SYNTAX

### Text (Default)

```
Get-AU3WinCaretPos [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Get-AU3WinCaretPos cmdlet retrieves the position of the text caret (cursor) within a window. This corresponds to the AutoIt WinGetCaretPos() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3WinCaretPos cmdlet.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Drawing.Point

A Point containing the caret coordinates.

## NOTES

This cmdlet is based on the WinGetCaretPos() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/WinGetCaretPos.htm)
