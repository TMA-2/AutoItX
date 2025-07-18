using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the control identifier of the control that currently has focus within a window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ControlGetFocus() function to determine which control
/// within a window currently has keyboard focus. This is useful for determining the active
/// input field or button in dialog boxes and forms.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3ControlFocus -Title "Notepad"
/// </code>
/// This example gets the control identifier that has focus in the Notepad window.
/// </example>
/// <example>
/// <code>
/// $Handle = Get-AU3WinHandle -Title "Dialog"
/// Get-AU3ControlFocus -WinHandle $Handle
/// </code>
/// This example gets the focused control using a window handle.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns the control identifier string of the focused control, or empty string if no control has focus.
/// </para>
/// </outputs>
[Cmdlet("Get", "AU3ControlFocus", DefaultParameterSetName = "Text")]
public class Get_AU3ControlFocus : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private global::System.IntPtr winHandle;

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

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetFocus(winHandle, 65535), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetFocus(title, text, 65535), true);
        }
    }
}
