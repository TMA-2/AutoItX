---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Invoke-AU3MouseUp
---

# Invoke-AU3MouseUp

## SYNOPSIS

Releases a mouse button.

## SYNTAX

### __AllParameterSets

```
Invoke-AU3MouseUp [[-Button] <string>] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Invoke-AU3MouseUp cmdlet releases a previously pressed mouse button. This corresponds to the AutoIt MouseUp() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Invoke-AU3MouseUp cmdlet.

## PARAMETERS

### -Button

The mouse button to use. Valid values are "left", "right", "middle", "main", "menu", "primary", or "secondary".

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 0
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

The Invoke-AU3MouseUp cmdlet releases a previously pressed mouse button. This corresponds to the AutoIt MouseUp() function.

## NOTES

This cmdlet is based on the corresponding AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[AutoIt Documentation](https://www.autoitscript.com/autoit3/docs/)












