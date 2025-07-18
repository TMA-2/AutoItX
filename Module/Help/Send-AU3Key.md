---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Send-AU3Key
---

# Send-AU3Key

## SYNOPSIS

Sends keystrokes to the active window.

## SYNTAX

### __AllParameterSets

```
Send-AU3Key [-Key] <string> [[-Mode] <int>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Send-AU3Key cmdlet sends keystrokes to the currently active window. This corresponds to the AutoIt Send() function.
Use the modifiers `!` for Alt, `+` for Shift, `^` for Control, and `#` for Windows. Most special keys are surrounded with curly braces, such as `{ENTER}`. For all special keys, refer to the [official documentation](https://www.autoitscript.com/autoit3/docs/functions/Send.htm).

## EXAMPLES

### Example 1
```powershell
Send-AU3Key -Key "Hello World"
```
This example sends the text "Hello World" to the active window.

### Example 2
```powershell
Send-AU3Key -Key "{ENTER}"
```
This example sends the Enter key to the active window.

### Example 3
```powershell
Send-AU3Key -Key "^c"
```
This example sends Ctrl+C (copy) to the active window.

### Example 4
```powershell
Send-AU3Key -Key "{ALT}fm" -Mode 1
```
This example sends Alt+F+M with raw mode enabled.

## PARAMETERS

### -Key

The key or key combination to send. Use AutoIt key notation for special keys.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 0
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Mode

The mode for sending keys. 0 = default, 1 = raw mode.

```yaml
Type: System.Int32
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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

This cmdlet is based on the Send() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/Send.htm)
