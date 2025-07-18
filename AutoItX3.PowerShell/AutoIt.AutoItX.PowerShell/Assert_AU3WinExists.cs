using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Checks if a window with the specified properties exists.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinExists() function to determine if a window identified
/// by title/text or handle exists on the desktop, regardless of its state (minimized, hidden, etc.).
/// </remarks>
/// <example>
/// <code>
/// Assert-AU3WinExists -Title "Notepad"
/// </code>
/// This example checks if a window with title "Notepad" exists.
/// </example>
/// <example>
/// <code>
/// $Handle = Get-AU3WinHandle -Title "Calculator"
/// Assert-AU3WinExists -WinHandle $Handle
/// </code>
/// This example checks if a window with the specified handle exists.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns 1 (true) if the specified window exists, 0 (false) otherwise.
/// </para>
/// </outputs>
[Cmdlet("Assert", "AU3WinExists")]
public class Assert_AU3WinExists : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private global::System.IntPtr winHandle;    /// <summary>
    /// Gets or sets the title of the window to check for existence. Supports partial matching and regular expressions.
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
    }    /// <summary>
    /// Gets or sets the handle of the window to check for existence.
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
    }    /// <summary>
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
                ((Cmdlet)this).WriteObject((object)AutoItX.WinExists(winHandle), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinExists(title, text), true);
        }
    }
}
