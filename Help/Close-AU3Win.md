---
document type: cmdlet
external help file: AutoItX3.PowerShell.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: AutoItX
ms.date: 07/08/2025
PlatyPS schema version: 2024-05-01
title: Close-AU3Win
---

# Close-AU3Win

## SYNOPSIS

Closes a window by title, text, or handle.

## SYNTAX

### Text

```
Close-AU3Win [-Title] <string> [[-Text] <string>] [-Force] [<CommonParameters>]
```

### Handle

```
Close-AU3Win [-WinHandle] <IntPtr> [-Force] [<CommonParameters>]
```

## ALIASES

This cmdlet has no aliases.

## DESCRIPTION

The Close-AU3Win cmdlet closes a window identified by its title and optional text content, or by its window handle. You can optionally force the window to close if it doesn't respond to normal close requests. This corresponds to the AutoIt WinClose() function.

## EXAMPLES

### Example 1

```powershell
Close-AU3Win -Title "Notepad"
```

This example closes a window with the title "Notepad".

## PARAMETERS

### -Force

Forces the operation to complete even if the window does not respond to normal requests.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
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

The title or text used to identify the target window or control.

### System.IntPtr

A handle to the target window or control.

## OUTPUTS

### System.Int32

1 on success, 0 if the window is not found.

## NOTES

This cmdlet is based on the corresponding AutoIt function and provides Windows automation capabilities.

## RELATED LINKS

[AutoIt Documentation](https://www.autoitscript.com/autoit3/docs/)










