using System.Management.Automation;
using System.Management.Automation.Language;
using System.Collections;
using System.Collections.Generic;
using System;

namespace AutoIt.AutoItX.PowerShell;

#region Enums
public enum AU3Option
{
    CaretCoordMode, // Sets the way coords are used in the caret functions, either absolute coords or coords relative to the current active window. Default = 1.
    MouseClickDelay, // Alters the length of the brief pause in between mouse clicks. Default = 10ms.
    MouseClickDownDelay, // Alters the length a click is held down before release. Default = 10ms.
    MouseClickDragDelay, // Alters the length of the brief pause at the start and end of a mouse drag operation. Default = 250ms.
    MouseCoordMode, // Sets the way coords are used in the mouse functions, either absolute coords or coords relative to the current active window. Default = 1.
    PixelCoordMode, // Sets the way coords are used in the pixel functions, either absolute coords or coords relative to the current active window. Default = 1.
    SendAttachMode, // Specifies if AutoIt attaches input threads when using then Send() function. When not attaching (default mode=0) detecting the state of capslock/scrolllock and numlock can be unreliable under NT4. However, when you specify attach mode=1 the Send("{... down/up}") syntax will not work and there may be problems with sending keys to "hung" windows. ControlSend() ALWAYS attaches and is not affected by this mode.
    SendCapslockMode, // Specifies if AutoIt should store the state of capslock before a Send function and restore it afterwards. Default = 1.
    SendKeyDelay, // Alters the the length of the brief pause in between sent keystrokes. Default = 5ms.
    SendKeyDownDelay, // Alters the length of time a key is held down before released during a keystroke. For applications that take a while to register keypresses (and many games) you may need to raise this value from the default. Default = 1ms.
    WinDetectHiddenText, // Specifies if hidden window text can be "seen" by the window matching functions. Default = 0.
    WinSearchChildren, // Allows the window search routines to search child windows as well as top-level windows. Default = 0.
    WinTextMatchMode, // Alters the method that is used to match window text during search operations. Default = 1.
    WinTitleMatchMode, // Alters the method that is used to match window titles during search operations. Default = 1.
    WinWaitDelay // Alters how long a script should briefly pause after a successful window-related operation. Default = 250ms.
}
public enum CoordMode
{
    Absolute = 0, // Coordinates are absolute screen coordinates.
    Relative = 1, // Coordinates are relative to the current active window.
    Client = 2 // Coordinates are relative to the client area of the current active window.
}
public enum SendAttachMode
{
    DoNotAttach = 0, // Do not attach input threads when using the Send function.
    Attach = 1 // Attach input threads when using the Send function.
}
public enum SendCapslockMode
{
    DoNotRestore = 0, // Do not restore the state of capslock after sending keys.
    Restore = 1 // Restore the state of capslock after sending keys.
}
public enum WinDetectHiddenText
{
    DoNotDetect = 0, // Do not detect hidden window text.
    Detect = 1 // Detect hidden window text.
}
public enum WinSearchChildren
{
    DoNotSearch = 0, // Do not search child windows.
    Search = 1 // Search child windows as well as top-level windows.
}
public enum WinTextMatchMode
{
    Complete = 1, // Match the complete text of the window.
    Quick = 2 // Match the text quickly, allowing for partial matches.
}
public enum WinTitleMatchMode
{
    IStart = -1, // Match the start of the window title (case-insensitive).
    ISubString = -2, // Match any substring of the window title (case-insensitive).
    IExact = -3, // Match the exact window title (case-insensitive).
    IAdvanced = -4, // Use advanced matching techniques for the window title (case-insensitive).
    Start = 1, // Match the start of the window title.
    SubString = 2, // Match any substring of the window title.
    Exact = 3, // Match the exact window title.
    Advanced = 4 // Use advanced matching techniques for the window title.
}
#endregion Enums

public class OptionArgumentCompleter : IArgumentCompleter
{
    public OptionArgumentCompleter(Type type)
    {
    }

    public List<CompletionResult> CompleteEnum(Type enumType)
    {
        var resultList = new List<CompletionResult>();
        foreach (var enumVal in Enum.GetNames(enumType))
            resultList.Add(new CompletionResult(enumVal.ToString()));
        return resultList;
    }

    public IEnumerable<CompletionResult> CompleteArgument(
        string commandName,
        string parameterName,
        string wordToComplete,
        CommandAst commandAst,
        IDictionary fakeBoundParameters)
    {
        var resultList = new List<CompletionResult>();
        AU3Option selectedOption = (AutoItX.PowerShell.AU3Option)(fakeBoundParameters.Contains("Option") ? fakeBoundParameters["Option"] : null);

        switch (selectedOption)
        {
            case AU3Option.CaretCoordMode:
                return CompleteEnum(typeof(CoordMode));
            case AU3Option.MouseCoordMode:
                return CompleteEnum(typeof(CoordMode));
            case AU3Option.PixelCoordMode:
                return CompleteEnum(typeof(CoordMode));
            case AU3Option.SendAttachMode:
                return CompleteEnum(typeof(SendAttachMode));
            case AU3Option.SendCapslockMode:
                return CompleteEnum(typeof(SendCapslockMode));
            case AU3Option.WinDetectHiddenText:
                return CompleteEnum(typeof(WinDetectHiddenText));
            case AU3Option.WinSearchChildren:
                return CompleteEnum(typeof(WinSearchChildren));
            case AU3Option.WinTextMatchMode:
                return CompleteEnum(typeof(WinTextMatchMode));
            case AU3Option.WinTitleMatchMode:
                return CompleteEnum(typeof(WinTitleMatchMode));
            default:
                return new List<CompletionResult>();
        }

        // resultList.Add(new CompletionResult(i.ToString()));
        // return resultList;
    }
}

[Cmdlet("Set", "AU3Option")]
public class Set_AU3Option : PSCmdlet
/// <summary>
/// Sets an AutoIt option to change the way certain AutoIt functions operate.
/// This cmdlet allows you to configure various AutoIt behavior settings by specifying
/// an option name and its corresponding value.
/// </summary>
/// <remarks>
/// The Set-AU3Option cmdlet modifies AutoIt's internal settings that control how
/// various AutoIt functions behave. These options affect things like window detection,
/// coordinate modes, error handling, and other operational parameters.
/// </remarks>
/// <example>
/// <code>
/// Set-AU3Option -Option MouseCoordMode -Value 2
/// </code>
/// This example sets the mouse coordinate mode to relative coordinates.
/// </example>
/// <example>
/// <code>
/// Set-AU3Option -Option WinTitleMatchMode -Value 1
/// </code>
/// This example sets the window title match mode to start with the specified text.
/// </example>
/// <see href="https://www.autoitscript.com/autoit3/docs/functions/AutoItSetOption.htm"/>
{
    private AU3Option option;
    private int optionValue;

    /// <summary>
    /// The AutoItX option to set. See the documentation for available options and descriptions.
    /// </summary>
    [Parameter(Position = 0, Mandatory = true)]
    [ValidateNotNull]
    public AU3Option Option
    {
        get
        {
            return option;
        }
        set
        {
            option = value;
        }
    }

    /// <summary>
    /// The value to set. See the documentation for each option's accepted values.
    /// </summary>
    [Parameter(Position = 1, Mandatory = true)]
    [ValidateNotNull]
    [ArgumentCompleter(typeof(OptionArgumentCompleter))]
    public int Value
    {
        get
        {
            return optionValue;
        }
        set
        {
            optionValue = value;
        }
    }

    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.AutoItSetOption(option.ToString(), optionValue), true);
    }
}
