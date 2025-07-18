using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the current position of the mouse cursor on the screen.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX MouseGetPos() function to get the current X and Y coordinates
/// of the mouse cursor relative to the desktop. This is useful for recording mouse positions
/// for automation scripts or determining cursor location for mouse operations.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3MousePos
/// </code>
/// This example retrieves the current mouse cursor position.
/// </example>
/// <example>
/// <code>
/// $Position = Get-AU3MousePos
/// Invoke-AU3MouseClick -X $Position.X -Y $Position.Y
/// </code>
/// This example gets the current mouse position and performs a click at that location.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns a point object containing the X and Y coordinates of the mouse cursor.
/// </para>
/// </outputs>
[Cmdlet("Get", "AU3MousePos", DefaultParameterSetName = "Text")]
public class Get_AU3MousePos : PSCmdlet
{
    protected override void ProcessRecord()
    {
        //IL_0001: Unknown result type (might be due to invalid IL or missing references)
        ((Cmdlet)this).WriteObject((object)AutoItX.MouseGetPos(), true);
    }
}
