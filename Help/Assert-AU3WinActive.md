---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Assert-AU3WinActive
---

# Assert-AU3WinActive

## SYNOPSIS

Checks if a window is currently active.

## SYNTAX

### Text

```
Assert-AU3WinActive [-Title] <string> [[-Text] <string>] [<CommonParameters>]
```

### Handle

```
Assert-AU3WinActive [-WinHandle] <IntPtr> [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Assert-AU3WinActive cmdlet checks whether a specified window is currently the active window. You can identify windows by their title and optional text content, or by using a window handle. This corresponds to the AutoIt WinActive() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Assert-AU3WinActive cmdlet.

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

The title of the window to access. This can be a window title, window handle, or window class name.

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

The handle of the window to access. Use this parameter set when you already have a window handle.

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

The title or text used to identify the target window or control.

### System.IntPtr

A handle to the target window or control.

## OUTPUTS

### System.Int32

1 if the window is active, 0 otherwise.

## NOTES

This cmdlet is based on the corresponding AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[AutoIt Documentation](https://www.autoitscript.com/autoit3/docs/)










