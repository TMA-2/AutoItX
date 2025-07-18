using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the current contents of the Windows clipboard.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ClipGet() function to retrieve the current text contents
/// of the Windows clipboard. This is useful for automation scripts that need to capture
/// clipboard data or verify what was copied to the clipboard.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3Clip
/// </code>
/// This example retrieves the current clipboard contents and returns it as a string.
/// </example>
/// <example>
/// <code>
/// $ClipboardText = Get-AU3Clip
/// Write-Host "Clipboard contains: $ClipboardText"
/// </code>
/// This example captures the clipboard contents in a variable and displays it.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns the current clipboard contents as a string. Returns empty string if clipboard
/// is empty or contains non-text data.
/// </para>
/// </outputs>
[Cmdlet("Get", "AU3Clip")]
public class Get_AU3Clip : PSCmdlet
{
    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.ClipGet(1048576), true);
    }
}
