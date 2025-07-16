---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Set-AU3Clip
---

# Set-AU3Clip

## SYNOPSIS

Sets the contents of the Windows clipboard.

## SYNTAX

### __AllParameterSets

```
Set-AU3Clip [-Text] <string> [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Set-AU3Clip cmdlet sets the contents of the Windows clipboard to the specified text. This corresponds to the AutoIt ClipPut() function.

## EXAMPLES

### Example 1

This example demonstrates basic usage of the Set-AU3Clip cmdlet.

## PARAMETERS

### -Text

Optional text to help identify the window. This is the visible text content within the window.

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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

The title or text used to identify the target window or control.

## OUTPUTS

### System.Object

Success: Returns 1.
Failure: Returns 0.

## NOTES

This cmdlet is based on the ClipPut() AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[Function Documentation](https://www.autoitscript.com/autoit3/docs/functions/ClipPut.htm)
