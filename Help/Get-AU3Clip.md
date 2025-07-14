---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3Clip
---

# Get-AU3Clip

## SYNOPSIS

Retrieves the current contents of the Windows clipboard.

## SYNTAX

### __AllParameterSets

```
Get-AU3Clip [<CommonParameters>]
```



## DESCRIPTION

The Get-AU3Clip cmdlet retrieves the current text contents of the Windows clipboard. This is useful for automation scripts that need to capture clipboard data or verify what was copied to the clipboard. The cmdlet only retrieves text data and returns an empty string if the clipboard contains non-text data such as images or files.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3Clip cmdlet.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.String

Returns the current clipboard contents as a string. Returns an empty string if the clipboard is empty or contains non-text data.

## NOTES

- This cmdlet only retrieves text data from the clipboard
- If the clipboard contains binary data (images, files, etc.), an empty string is returned
- The clipboard contents are retrieved as they exist at the time the cmdlet is called

## RELATED LINKS

[Set-AU3Clip](Set-AU3Clip.md)









