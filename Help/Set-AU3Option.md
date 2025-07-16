---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Set-AU3Option
---

# Set-AU3Option

## SYNOPSIS

Sets various AutoIt configuration options.

## SYNTAX

### __AllParameterSets

```
Set-AU3Option [-Option] <string> [-Value] <int> [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Set-AU3Option cmdlet sets various AutoIt configuration options that control automation behavior. This corresponds to the AutoIt AutoItSetOption() / Opt() functions. Refer to the table for accepted options and values:

| Option              | Default | Values                                                  |
| ------------------- | ------: | ------------------------------------------------------- |
| CaretCoordMode      |       1 | 1=absolute, 0=relative, 2=client                        |
| MouseClickDelay     |      10 | 10 milliseconds                                         |
| MouseClickDownDelay |      10 | 10 milliseconds                                         |
| MouseClickDragDelay |     250 | 250 milliseconds                                        |
| MouseCoordMode      |       1 | 1=absolute, 0=relative, 2=client                        |
| PixelCoordMode      |       1 | 1=absolute, 0=relative, 2=client                        |
| SendAttachMode      |       0 | 0=don't attach, 1=do attach                             |
| SendCapslockMode    |       1 | 1=store and restore, 0=don't                            |
| SendKeyDelay        |       5 | 5 milliseconds                                          |
| SendKeyDownDelay    |       1 | 1 millisecond                                           |
| WinDetectHiddenText |       0 | 0=don't detect, 1=do detect                             |
| WinSearchChildren   |       1 | 0=no, 1=search children also                            |
| WinTextMatchMode    |       1 | 1=complete, 2=quick                                     |
| WinTitleMatchMode   |       1 | 1=start, 2=subStr, 3=exact, 4=advanced, -1 to -4=Nocase |
| WinWaitDelay        |     250 | 250 milliseconds                                        |


## EXAMPLES

### Example 1
Set-AU3Option -Option WinTitleMatchMode -Value 3

This sets the window title match mode to Exact.

## PARAMETERS

### -Option

The AutoIt option name to set.

```yaml
Type: AutoIt.AutoItX.PowerShell.AU3Option
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

### -Value

The value to set for the specified option.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 1
  IsRequired: true
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

### System.Int32

The value of the previous setting for the option.

## NOTES

The list of Option parameters is as follows:
| Option | Description |
| ------ | ----------- |
| CaretCoordMode | Sets the way coords are used in the caret functions, either absolute coords or coords relative to the current active window. |
| MouseClickDelay | Alters the length of the brief pause in between mouse clicks. |
| MouseClickDownDelay | Alters the length a click is held down before release. |
| MouseClickDragDelay | Alters the length of the brief pause at the start and end of a mouse drag operation. |
| MouseCoordMode | Sets the way coords are used in the mouse functions, either absolute coords or coords relative to the current active window. |
| PixelCoordMode | Sets the way coords are used in the pixel functions, either absolute coords or coords relative to the current active window. |
| SendAttachMode | Specifies if AutoIt attaches input threads when using then Send() function. When not attaching (default mode=0) detecting the state of capslock/scrolllock and numlock can be unreliable under NT4. However, when you specify attach mode=1 the Send("{... down/up}") syntax will not work and there may be problems with sending keys to "hung" windows. ControlSend() ALWAYS attaches and is not affected by this mode. |
| SendCapslockMode | Specifies if AutoIt should store the state of capslock before a Send function and restore it afterwards. |
| SendKeyDelay | Alters the the length of the brief pause in between sent keystrokes. |
| SendKeyDownDelay | Alters the length of time a key is held down before released during a keystroke. For applications that take a while to register keypresses (and many games) you may need to raise this value from the default. |
| WinDetectHiddenText | Specifies if hidden window text can be "seen" by the window matching functions. |
| WinSearchChildren | Allows the window search routines to search child windows as well as top-level windows. |
| WinTextMatchMode | Alters the method that is used to match window text during search operations. |
| WinTitleMatchMode | Alters the method that is used to match window titles during search operations. |
| WinWaitDelay | Alters how long a script should briefly pause after a successful window-related operation. |


## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/AutoItSetOption.htm)
