using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the handle of a window based on its title and optional text.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinGetHandle() function to obtain a window handle (HWND)
/// that can be used with other AutoItX functions. Window handles provide a more reliable
/// way to identify windows than titles, which can change.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3WinHandle -Title "Notepad"
/// </code>
/// This example retrieves the handle of the first Notepad window found.
/// </example>
/// <example>
/// <code>
/// Get-AU3WinHandle -Title "Calculator" -AsText
/// </code>
/// This example retrieves the window handle as a text string instead of an IntPtr.
/// </example>
/// <example>
/// <code>
/// $Handle = Get-AU3WinHandle -Title "Notepad" -Text "Untitled"
/// Show-AU3WinActivate -WinHandle $Handle
/// </code>
/// This example gets a window handle and uses it to activate the window.
/// </example>
/// <inputs>
/// <para type="description">You can pipe window titles to this cmdlet.</para>
/// </inputs>
/// <outputs>
/// <para type="description">
/// Returns the window handle as an IntPtr by default, or as a string if AsText is specified.
/// Returns null/empty if the window is not found.
/// </para>
/// </outputs>
[Cmdlet("Get", "AU3WinHandle")]
public class Get_AU3WinHandle : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;    private bool asText;

    /// <summary>
    /// Gets or sets the title of the window to find. Supports partial matching and regular expressions.
    /// </summary>
    [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
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
            title = value;        }
    }

    /// <summary>
    /// Gets or sets additional text to help identify the window. Optional parameter for more precise window matching.
    /// </summary>
    [Parameter(Position = 1, Mandatory = false)]
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
            text = value;        }
    }

    /// <summary>
    /// Gets or sets whether to return the window handle as a text string instead of an IntPtr.
    /// </summary>
    [Parameter(Mandatory = false)]
    public SwitchParameter AsText
    {
        get
        {
            //IL_0006: Unknown result type (might be due to invalid IL or missing references)
            return SwitchParameter.op_Implicit(asText);
        }
        set
        {
            //IL_0001: Unknown result type (might be due to invalid IL or missing references)
            asText = SwitchParameter.op_Implicit(value);
        }
    }

    protected override void ProcessRecord()
    {
        if (asText)
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinGetHandleAsText(title, text, 65535), true);
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)(nint)AutoItX.WinGetHandle(title, text), true);
        }
    }
}
