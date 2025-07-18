using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Closes a window gracefully or forcefully terminates it.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinClose() and WinKill() functions to close windows.
/// Without the Force parameter, it sends a close message to the window (equivalent to clicking the X button).
/// With the Force parameter, it forcefully terminates the window and its associated process.
/// </remarks>
/// <example>
/// <code>
/// Close-AU3Win -Title "Notepad"
/// </code>
/// This example gracefully closes a Notepad window.
/// </example>
/// <example>
/// <code>
/// Close-AU3Win -Title "Notepad" -Force
/// </code>
/// This example forcefully terminates a Notepad window.
/// </example>
/// <example>
/// <code>
/// $Handle = Get-AU3WinHandle -Title "Calculator"
/// Close-AU3Win -WinHandle $Handle
/// </code>
/// This example closes a window using its handle.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns 1 if successful, 0 if the window was not found or could not be closed.
/// </para>
/// </outputs>
[Cmdlet("Close", "AU3Win")]
public class Close_AU3Win : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private bool force;

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

    [Parameter(Mandatory = false)]
    public SwitchParameter Force
    {
        get
        {
            //IL_0006: Unknown result type (might be due to invalid IL or missing references)
            return SwitchParameter.op_Implicit(force);
        }
        set
        {
            //IL_0001: Unknown result type (might be due to invalid IL or missing references)
            force = SwitchParameter.op_Implicit(value);
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                if (force)
                {
                    ((Cmdlet)this).WriteObject((object)AutoItX.WinClose(winHandle), true);
                }
                else
                {
                    ((Cmdlet)this).WriteObject((object)AutoItX.WinKill(winHandle), true);
                }
            }
        }
        else if (force)
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinKill(title, text), true);
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinClose(title, text), true);
        }
    }
}
