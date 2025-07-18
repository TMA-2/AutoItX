using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Waits until a window with the specified properties exists.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinWait() function to pause script execution until a window
/// with the specified title/text or handle appears. This is useful for waiting for applications
/// to start, dialog boxes to appear, or windows to be created before continuing automation.
/// </remarks>
/// <example>
/// <code>
/// Wait-AU3Win -Title "Notepad"
/// </code>
/// This example waits indefinitely for a Notepad window to appear.
/// </example>
/// <example>
/// <code>
/// Wait-AU3Win -Title "Save As" -Timeout 10
/// </code>
/// This example waits up to 10 seconds for a "Save As" dialog to appear.
/// </example>
/// <example>
/// <code>
/// $Handle = Get-AU3WinHandle -Title "Calculator"
/// Wait-AU3Win -WinHandle $Handle -Timeout 5
/// </code>
/// This example waits for a window with the specified handle to exist.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns 1 if the window appears within the timeout period, 0 if timeout occurs.
/// </para>
/// </outputs>
[Cmdlet("Wait", "AU3Win")]
public class Wait_AU3Win : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private global::System.IntPtr winHandle;

    private int timeout;

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
    public int Timeout
    {
        get
        {
            return timeout;
        }
        set
        {
            timeout = value;
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.WinWait(winHandle, timeout), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinWait(title, text, timeout), true);
        }
    }
}
