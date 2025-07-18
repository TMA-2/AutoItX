---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Get-AU3ControlHandle
---

# Get-AU3ControlHandle

## SYNOPSIS

Retrieves the internal handle of a control.

## SYNTAX

### Text

```
Get-AU3ControlHandle [-Title] <string> [[-Text] <string>] [[-Control] <string>] [<CommonParameters>]
```

### Handle

```
Get-AU3ControlHandle [-WinHandle] <IntPtr> [[-Control] <string>] [<CommonParameters>]
```



## DESCRIPTION

The Get-AU3ControlHandle cmdlet retrieves the internal handle (HWND) of a control. This handle can be used for advanced control manipulation and is useful for automation scripts that need to work with control handles directly. The function returns a HWND/Handle value that can be used with other Windows API functions or AutoItX cmdlets.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Get-AU3ControlHandle cmdlet.

## PARAMETERS

### -Control

The control to interact with. This can be a control ID, control ClassNameNN, or control text.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Handle
  Position: 1
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
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

The title of the window to access. This can be a window title, window handle, or window class name.

### System.IntPtr

The handle of the window to access. Use this parameter set when you already have a window handle.

## OUTPUTS

### System.IntPtr

Returns the handle (HWND) value as an IntPtr. Returns 0 if no window matches the criteria or if the control is not found.

## NOTES

- This function returns a HWND/Handle value that can be used for advanced control manipulation
- The Title parameter can accept window titles, handles, or class names
- The Control parameter can be a control ID, ClassNameNN, or control text
- Returns 0 if the window or control cannot be found

## RELATED LINKS

[Get-AU3ControlPos](Get-AU3ControlPos.md)
[Get-AU3ControlText](Get-AU3ControlText.md)
[Get-AU3ControlFocus](Get-AU3ControlFocus.md)











