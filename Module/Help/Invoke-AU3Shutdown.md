---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Invoke-AU3Shutdown
---

# Invoke-AU3Shutdown

## SYNOPSIS

Initiates a system shutdown, restart, or logoff.

## SYNTAX

### __AllParameterSets

```
Invoke-AU3Shutdown [-Flag] <int> [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Invoke-AU3Shutdown cmdlet initiates a system shutdown, restart, or logoff operation. This corresponds to the AutoIt Shutdown() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Invoke-AU3Shutdown cmdlet.

## PARAMETERS

### -Flag

A flag value that controls the operation behavior.

```yaml
Type: System.Int32
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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32

An integer value used as a parameter for the operation.

## OUTPUTS

### System.Int32

1 on success, 0 on failure.

## NOTES

This cmdlet is based on the Shutdown() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/Shutdown.htm)
