---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Invoke-AU3MouseWheel
---

# Invoke-AU3MouseWheel

## SYNOPSIS

Scrolls the mouse wheel.

## SYNTAX

### __AllParameterSets

```
Invoke-AU3MouseWheel [-Direction] <string> [[-NumClicks] <int>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Invoke-AU3MouseWheel cmdlet scrolls the mouse wheel up or down. This corresponds to the AutoIt MouseWheel() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Invoke-AU3MouseWheel cmdlet.

## PARAMETERS

### -Direction

The direction to scroll the mouse wheel. Use "up" or "down".

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

### -NumClicks

The number of times to click the mouse button. Default is 1.

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

### System.Object

The Invoke-AU3MouseWheel cmdlet scrolls the mouse wheel up or down. This corresponds to the AutoIt MouseWheel() function.

## NOTES

This cmdlet is based on the corresponding AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[AutoIt Documentation](https://www.autoitscript.com/autoit3/docs/)












