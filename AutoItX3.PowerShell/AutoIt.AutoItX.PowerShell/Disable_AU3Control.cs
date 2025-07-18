using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Disables a control within a window, making it unresponsive to user input.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ControlDisable() function to disable controls such as buttons,
/// edit boxes, checkboxes, etc. A disabled control appears grayed out and cannot be interacted
/// with by the user until it is re-enabled.
/// </remarks>
/// <example>
/// <code>
/// Disable-AU3Control -Title "Dialog" -Control "Button1"
/// </code>
/// This example disables a button control in a dialog window.
/// </example>
/// <example>
/// <code>
/// $WinHandle = Get-AU3WinHandle -Title "Settings"
/// $ControlHandle = Get-AU3ControlHandle -WinHandle $WinHandle -Control "Edit1"
/// Disable-AU3Control -WinHandle $WinHandle -ControlHandle $ControlHandle
/// </code>
/// This example disables a control using window and control handles.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns 1 if successful, 0 if the control could not be found or disabled.
/// </para>
/// </outputs>
[Cmdlet("Disable", "AU3Control", DefaultParameterSetName = "Text")]
public class Disable_AU3Control : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

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

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlDisable(winHandle, controlHandle), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlDisable(title, text, control), true);
        }
    }
}
