---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3WinHandle
---

# Get-AU3WinHandle

## SYNOPSIS

Gets the handle of a window.

## SYNTAX

### __AllParameterSets

```
Get-AU3WinHandle [-Title] <string> [[-Text] <string>] [-AsText] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Get-AU3WinHandle cmdlet retrieves the window handle (HWND) of a window identified by title and optional text. This corresponds to the AutoIt WinGetHandle() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3WinHandle cmdlet.

## PARAMETERS

### -AsText

Returns the window handle as text instead of an IntPtr object.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Text

Optional text to help identify the window. This is the visible text content within the window.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 1
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Title

The title of the window to access. This can be a window title, window handle, or window class name.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

The title or text used to identify the target window or control.

## OUTPUTS

### System.IntPtr

The window handle as an IntPtr.

## NOTES

This cmdlet is based on the WinGetHandle() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/WinGetHandle.htm)
