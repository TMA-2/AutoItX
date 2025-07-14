---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Invoke-AU3ControlCommand
---

# Invoke-AU3ControlCommand

## SYNOPSIS

Sends commands to a control.

## SYNTAX

### Text (Default)

```
Invoke-AU3ControlCommand [-Title] <string> [[-Text] <string>] [[-Control] <string>]
 [-Command] <string> [[-Extra] <string>] [<CommonParameters>]
```

### Handle

```
Invoke-AU3ControlCommand [-WinHandle] <IntPtr> [-ControlHandle] <IntPtr> [-Command] <string>
 [[-Extra] <string>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Invoke-AU3ControlCommand cmdlet sends commands to a control within a window. The available commands vary depending on the control type. This corresponds to the AutoIt ControlCommand() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Invoke-AU3ControlCommand cmdlet.

## PARAMETERS

### -Command

The command to send to the control. This varies depending on the control type.

*Supported commands*:
IsVisible, IsEnabled, ShowDropDown, HideDropDown, AddString, DelString, FindString, GetCount, SetCurrentSelection, SelectString, IsChecked, Check, UnCheck, GetCurrentLine, GetCurrentCol, GetCurrentSelection, GetLineCount, GetLine, GetSelected, EditPaste, CurrentTab, TabRight, TabLeft, SendCommandID

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

### -Extra

Additional parameter specific to the command being executed.

Supported commands / Extra parameters:
- AddString / 'string' / Adds a string to a ListBox or ComboBox
- DelString / occurrence / Deletes a ListBox or ComboBox entry
- EditPaste / 'string' / Paste the value at an Edit caret position
- FindString / 'string' / Returns position of a ListBox or ComboBox entry
- GetLine / line / Get line number of text in an Edit
- SelectString / 'string' / Set selection in a ListBox or ComboBox
- SendCommandID / Command ID / Simulate a WM_COMMAND message. Mostly for ToolbarWindow32.
- SetCurrentSelection / occurrence / Set ListBox or ComboBox selection

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

The Invoke-AU3ControlCommand cmdlet sends commands to a control within a window. The available commands vary depending on the control type. This corresponds to the AutoIt ControlCommand() function.

### System.IntPtr

The Invoke-AU3ControlCommand cmdlet sends commands to a control within a window. The available commands vary depending on the control type. This corresponds to the AutoIt ControlCommand() function.

## OUTPUTS

### System.Object

Depends on

## NOTES

This cmdlet is based on the corresponding AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[AutoIt Documentation](https://www.autoitscript.com/autoit3/docs/)












