using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Gets the current mouse cursor ID.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX MouseGetCursor() function, which retrieves the current mouse cursor shape as an integer ID.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3MouseCursor
/// </code>
/// This example gets the current mouse cursor ID.
/// </example>
[Cmdlet("Get", "AU3MouseCursor")]
public class Get_AU3MouseCursor : PSCmdlet
{
    /// <summary>
    /// Executes the cmdlet to get the current mouse cursor ID.
    /// </summary>
    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.MouseGetCursor(), true);
    }
}
