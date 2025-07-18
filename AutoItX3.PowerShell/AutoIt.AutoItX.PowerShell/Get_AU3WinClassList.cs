using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// PowerShell cmdlet that retrieves a list of window classes for a specified window.
/// This cmdlet supports two parameter sets: identifying the window by title/text or by window handle.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinGetClassList function to provide PowerShell integration.
/// It can be used to enumerate all control classes within a target window, which is useful
/// for window automation and UI inspection tasks.
///
/// Parameter Sets:
/// - Text: Uses window title and optional text to identify the target window
/// - Handle: Uses a window handle (IntPtr) to directly reference the target window
/// </remarks>
/// <example>
/// <code>Get-AU3WinClassList -Title "Notepad"</code>
/// Get class list by window title
/// </example>
/// <example>
/// <code>Get-AU3WinClassList -Title "Calculator" -Text ""</code>
/// Get class list by window title and text
/// </example>
/// <example>
/// <code>
/// $handle = [IntPtr]::new(0x12345)
/// Get-AU3WinClassList -WinHandle $handle
/// </code>
/// # Get class list by window handle
/// </example>
[Cmdlet("Get", "AU3WinClassList")]
public class Get_AU3WinClassList : PSCmdlet
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
                ((Cmdlet)this).WriteObject((object)AutoItX.WinGetClassList(winHandle, 65535), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinGetClassList(title, text, 65535), true);
        }
    }
}
