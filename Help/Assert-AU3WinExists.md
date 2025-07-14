---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Assert-AU3WinExists
---

# Assert-AU3WinExists

## SYNOPSIS

Checks if a window exists based on title, text, or handle.

## SYNTAX

### Text

```
Assert-AU3WinExists [-Title] <string> [[-Text] <string>] [<CommonParameters>]
```

### Handle

```
Assert-AU3WinExists [-WinHandle] <IntPtr> [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Assert-AU3WinExists cmdlet checks whether a window exists on the desktop. You can identify windows by their title and optional text content, or by using a window handle. This corresponds to the AutoIt WinExists() function.

## EXAMPLES

### Example 1

```powershell
Assert-AU3WinExists -Title "Notepad"
```

This example checks if a window with the title "Notepad" exists. Returns $true if the window exists, $false otherwise.

## PARAMETERS

### -Text

Optional text to help identify the window. This is the visible text content within the window.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Text
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

The title of the window to check for existence. This can be a window title, window handle, or window class name.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Text
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WinHandle

The handle of the window to check for existence. Use this parameter set when you already have a window handle.

```yaml
Type: System.IntPtr
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Handle
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

The window title to check for existence.

### System.IntPtr

A window handle to check for existence.

## OUTPUTS

### System.Object

Returns a boolean value indicating whether the specified window exists.

## NOTES

This cmdlet is based on the AutoIt WinExists() function. Window titles can use advanced window matching modes including regular expressions and partial matches.

## RELATED LINKS

[AutoIt WinExists Function](https://www.autoitscript.com/autoit3/docs/functions/WinExists.htm)









