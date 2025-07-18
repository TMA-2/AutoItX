using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Checks if a specified window is currently the active (foreground) window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinActive() function to determine if a window identified
/// by title/text or handle is currently the active window that has focus.
/// </remarks>
/// <example>
/// <code>
/// Assert-AU3WinActive -Title "Notepad"
/// </code>
/// This example checks if a window with title "Notepad" is currently active.
/// </example>
/// <example>
/// <code>
/// $Handle = Get-AU3WinHandle -Title "Calculator"
/// Assert-AU3WinActive -WinHandle $Handle
/// </code>
/// This example checks if a window with the specified handle is currently active.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns 1 (true) if the specified window is active, 0 (false) otherwise.
/// </para>
/// </outputs>
[Cmdlet("Assert", "AU3WinActive")]
public class Assert_AU3WinActive : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private IntPtr winHandle;

    /// <summary>
    /// Gets or sets the title of the window to check. Supports partial matching and regular expressions.
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
    /// Gets or sets the handle of the window to check for active status.
    /// </summary>
    [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Handle", ValueFromPipeline = true)]
    [ValidateNotNull]
    public IntPtr WinHandle
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
    /// Gets or sets additional text to help identify the window. Optional parameter for more precise window matching.
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

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.WinActive(winHandle), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinActive(title, text), true);
        }
    }
}
