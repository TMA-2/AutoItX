---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Set-AU3ControlFocus
---

# Set-AU3ControlFocus

## SYNOPSIS

Sets focus to a control in a window.

## SYNTAX

### Text (Default)

```
Set-AU3ControlFocus [-Title] <string> [[-Text] <string>] [[-Control] <string>] [<CommonParameters>]
```

### Handle

```
Set-AU3ControlFocus [-WinHandle] <IntPtr> [-ControlHandle] <IntPtr> [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Set-AU3ControlFocus cmdlet sets focus to a specific control within a window. The control can be identified by its ID, ClassNameNN, or text within the specified window. This corresponds to the AutoIt ControlFocus() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Set-AU3ControlFocus cmdlet.

## PARAMETERS

### -Control

The control to interact with. This can be a control ID, control ClassNameNN, or control text.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Text
  Position: 2
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ControlHandle

The handle of the control to interact with. Use this parameter set when you already have a control handle.

```yaml
Type: System.IntPtr
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Handle
  Position: 1
  IsRequired: true
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

1 on success, 0 on failure.

## NOTES

This cmdlet is based on the ControlFocus() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/ControlFocus.htm)
