using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the position and size of a control within a window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ControlGetPos() function to get the position and size of a control.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3ControlPos -Title "Notepad" -Control "Edit1"
/// </code>
/// This example retrieves the position and size of the main text area in Notepad.
/// </example>
[Cmdlet("Get", "AU3ControlPos", DefaultParameterSetName = "Text")]
public class Get_AU3ControlPos : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

    /// <summary>
    /// Sets the title of the window containing the control.
    /// </summary>
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

    /// <summary>
    /// Sets the handle of the window containing the control.
    /// </summary>
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

    /// <summary>
    /// Sets additional text to help identify the window.
    /// </summary>
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

    /// <summary>
    /// Sets the handle of the control within the window.
    /// </summary>
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

    /// <summary>
    /// Sets the control identifier (e.g., "Edit1", "Button2").
    /// </summary>
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

    /// <summary>
    /// Executes the cmdlet to get the control position and size.
    /// </summary>
    protected override void ProcessRecord()
    {
        //IL_0035: Unknown result type (might be due to invalid IL or missing references)
        //IL_0053: Unknown result type (might be due to invalid IL or missing references)
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetPos(winHandle, controlHandle), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetPos(title, text, control), true);
        }
    }
}
