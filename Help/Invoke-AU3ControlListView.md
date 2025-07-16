---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Invoke-AU3ControlListView
---

# Invoke-AU3ControlListView

## SYNOPSIS

Performs ListView operations.

## SYNTAX

### Text (Default)

```
Invoke-AU3ControlListView [-Title] <string> [[-Text] <string>] [[-Control] <string>]
 [-Command] <string> [[-Extra1] <string>] [[-Extra2] <string>] [<CommonParameters>]
```

### Handle

```
Invoke-AU3ControlListView [-WinHandle] <IntPtr> [-ControlHandle] <IntPtr> [-Command] <string>
 [[-Extra1] <string>] [[-Extra2] <string>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Invoke-AU3ControlListView cmdlet performs operations on ListView controls within a window. This corresponds to the AutoIt ControlListView() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Invoke-AU3ControlListView cmdlet.

## PARAMETERS

### -Command

The command to send to the control. This varies depending on the control type.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Text
  Position: 3
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Handle
  Position: 2
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

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

### -Extra1

First additional parameter specific to the command being executed.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Text
  Position: 4
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Handle
  Position: 3
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Extra2

Second additional parameter specific to the command being executed.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Text
  Position: 5
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Handle
  Position: 4
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

### System.Int32

An integer value used as a parameter for the operation.

### System.IntPtr

A handle to the target window or control.

## OUTPUTS

### System.String

The response from the ListView control command as a string.

## NOTES

This cmdlet is based on the ControlListView() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/ControlListView.htm)
