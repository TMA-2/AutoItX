---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Wait-AU3WinClose
---

# Wait-AU3WinClose

## SYNOPSIS

Waits for a window to close.

## SYNTAX

### Text (Default)

```
Wait-AU3WinClose [-Title] <string> [[-Text] <string>] [[-Timeout] <int>] [<CommonParameters>]
```

### Handle

```
Wait-AU3WinClose [-WinHandle] <IntPtr> [[-Timeout] <int>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Wait-AU3WinClose cmdlet waits for a window to close before continuing. This corresponds to the AutoIt WinWaitClose() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Wait-AU3WinClose cmdlet.

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

### -Timeout

The timeout value in milliseconds.

```yaml
Type: System.Int32
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

### System.Object

1 if the window closes, 0 on timeout.

## NOTES

This cmdlet is based on the WinWaitClose() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/WinWaitClose.htm)
