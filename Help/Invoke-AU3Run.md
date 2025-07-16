---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Invoke-AU3Run
---

# Invoke-AU3Run

## SYNOPSIS

Runs an external program.

## SYNTAX

### __AllParameterSets

```
Invoke-AU3Run [-Program] <string> [[-Dir] <string>] [[-ShowFlag] <int>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Invoke-AU3Run cmdlet runs an external program or command. This corresponds to the AutoIt Run() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Invoke-AU3Run cmdlet.

## PARAMETERS

### -Dir

The working directory for the program. If not specified, uses the current directory.

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

### -Program

The program or command to execute.

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

### -ShowFlag

Controls how the window is displayed when the program starts.

```yaml
Type: System.Int32
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 2
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

### System.String

The title or text used to identify the target window or control.

### System.Int32

An integer value used as a parameter for the operation.

## OUTPUTS

### System.Object

The process ID (PID) of the launched program, 0 on failure.

## NOTES

This cmdlet is based on the Run() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/Run.htm)
