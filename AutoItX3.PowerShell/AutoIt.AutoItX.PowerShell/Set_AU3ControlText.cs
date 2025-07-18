using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Sets the text of a control within a window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ControlSetText() function to modify the text content 
/// of controls such as edit boxes, buttons, static text controls, etc. This is useful 
/// for automating form filling, changing button captions, or updating text displays.
/// </remarks>
/// <example>
/// <code>
/// Set-AU3ControlText -Title "Notepad" -Control "Edit1" -NewText "Hello World"
/// </code>
/// This example sets the text in Notepad's main text area to "Hello World".
/// </example>
/// <example>
/// <code>
/// $WinHandle = Get-AU3WinHandle -Title "Calculator"
/// $ControlHandle = Get-AU3ControlHandle -WinHandle $WinHandle -Control "Edit1"
/// Set-AU3ControlText -WinHandle $WinHandle -ControlHandle $ControlHandle -NewText "123"
/// </code>
/// This example sets control text using window and control handles.
/// </example>
/// <inputs>
/// <para type="description">You can pipe window handles to this cmdlet.</para>
/// </inputs>
/// <outputs>
/// <para type="description">
/// Returns 1 if successful, 0 if the control could not be found or text could not be set.
/// </para>
/// </outputs>
[Cmdlet("Set", "AU3ControlText", DefaultParameterSetName = "Text")]
public class Set_AU3ControlText : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

    private string newText;

    [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Text", ValueFromPipeline = true)]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }

    [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Handle", ValueFromPipeline = true)]
    [ValidateNotNull]
    public global::System.IntPtr WinHandle
    {
        get
        {
            return winHandle;
        }
        set
        {
            winHandle = value;
        }
    }

    [Parameter(Position = 1, Mandatory = false, ParameterSetName = "Text")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Text
    {
        get
        {
            return text;
        }
        set
        {
            text = value;
        }
    }

    [Parameter(Position = 1, Mandatory = true, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public global::System.IntPtr ControlHandle
    {
        get
        {
            return controlHandle;
        }
        set
        {
            controlHandle = value;
        }
    }

    [Parameter(Position = 2, Mandatory = false, ParameterSetName = "Text")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Control
    {
        get
        {
            return control;
        }
        set
        {
            control = value;
        }
    }

    [Parameter(Position = 3, Mandatory = true, ParameterSetName = "Text")]
    [Parameter(Position = 2, Mandatory = true, ParameterSetName = "Handle")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string NewText
    {
        get
        {
            return newText;
        }
        set
        {
            newText = value;
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlSetText(winHandle, controlHandle, newText), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlSetText(title, text, control, newText), true);
        }
    }
}
