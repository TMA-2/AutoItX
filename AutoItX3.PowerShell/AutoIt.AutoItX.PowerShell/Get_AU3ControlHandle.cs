using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the internal handle (HWND) of a control. This handle can be used for advanced control manipulation and is useful for automation scripts that need to work with control handles directly.
/// </summary>
/// <param name="title">The title of the window to access. This can be a window title, window handle, or window class name.</param>
/// <param name="text">Optional text to help identify the window. This is the visible text content within the window.</param>
/// <param name="control">The control to interact with. This can be a control ID, control ClassNameNN, or control text.</param>
/// <param name="winHandle">The handle of the window to access. Use this parameter set when you already have a window handle.</param>
/// <returns>Returns the handle (HWND) value as an IntPtr. Returns 0 if no window matches the criteria or if the control is not found.</returns>
[Cmdlet("Get", "AU3ControlHandle")]
public class Get_AU3ControlHandle : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

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

    [Parameter(Position = 1, Mandatory = false, ParameterSetName = "Handle")]
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
                ((Cmdlet)this).WriteObject((object)(nint)AutoItX.ControlGetHandle(winHandle, control), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetHandleAsText(title, text, control, 65535), true);
        }
    }
}
