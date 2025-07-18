using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Gets the caret (text cursor) position in the active window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinGetCaretPos() function, which retrieves the current position of the caret in the active window.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3WinCaretPos
/// </code>
/// This example gets the caret position in the active window.
/// </example>
[Cmdlet("Get", "AU3WinCaretPos", DefaultParameterSetName = "Text")]
public class Get_AU3WinCaretPos : PSCmdlet
{
    /// <summary>
    /// Executes the cmdlet to get the caret position.
    /// </summary>
    protected override void ProcessRecord()
    {
        //IL_0001: Unknown result type (might be due to invalid IL or missing references)
        ((Cmdlet)this).WriteObject((object)AutoItX.WinGetCaretPos(), true);
    }
}
