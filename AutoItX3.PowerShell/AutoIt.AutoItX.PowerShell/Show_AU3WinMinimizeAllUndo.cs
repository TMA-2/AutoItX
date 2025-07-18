using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Restores all previously minimized windows on the desktop.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX WinMinimizeAllUndo() function, which undoes the effect of minimizing all windows.
/// </remarks>
/// <example>
/// <code>
/// Show-AU3WinMinimizeAllUndo
/// </code>
/// This example restores all minimized windows.
/// </example>
[Cmdlet("Show", "AU3WinMinimizeAllUndo")]
public class Show_AU3WinMinimizeAllUndo : PSCmdlet
{
    /// <summary>
    /// Executes the cmdlet to restore all minimized windows.
    /// </summary>
    protected override void ProcessRecord()
    {
        AutoItX.WinMinimizeAllUndo();
    }
}
