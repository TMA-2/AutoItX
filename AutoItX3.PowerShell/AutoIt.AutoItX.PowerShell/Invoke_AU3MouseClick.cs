using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Performs a mouse click at the specified coordinates or current position.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX MouseClick() function to simulate mouse clicks at specific
/// screen coordinates or at the current mouse position. It supports different mouse buttons,
/// multiple clicks, and variable click speed for automation scenarios.
/// </remarks>
/// <example>
/// <code>
/// Invoke-AU3MouseClick
/// </code>
/// This example performs a left mouse click at the current mouse position.
/// </example>
/// <example>
/// <code>
/// Invoke-AU3MouseClick -Button "right" -X 100 -Y 200
/// </code>
/// This example performs a right mouse click at coordinates (100, 200).
/// </example>
/// <example>
/// <code>
/// Invoke-AU3MouseClick -Button "left" -X 300 -Y 150 -NumClicks 2 -Speed 5
/// </code>
/// This example performs a double-click at coordinates (300, 150) with slow speed.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns 1 if successful, 0 if the mouse click could not be performed.
/// </para>
/// </outputs>
[Cmdlet("Invoke", "AU3MouseClick")]
public class Invoke_AU3MouseClick : PSCmdlet
{
    private string button = "left";

    private int numClicks = 1;

    private int x = -2147483647;

    private int y = -2147483647;    private int speed = -1;

    /// <summary>
    /// Gets or sets the mouse button to click. Valid values are "left", "right", "middle", "main", "menu", "primary", "secondary".
    /// </summary>
    [Parameter(Position = 0, Mandatory = false)]
    [ValidateNotNull]
    public string Button
    {
        get
        {
            return button;
        }
        set
        {
            button = value;        }
    }

    /// <summary>
    /// Gets or sets the X coordinate for the mouse click. If not specified, uses the current mouse position.
    /// </summary>
    [Parameter(Position = 1, Mandatory = false)]
    [ValidateNotNull]
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;        }
    }

    /// <summary>
    /// Gets or sets the Y coordinate for the mouse click. If not specified, uses the current mouse position.
    /// </summary>
    [Parameter(Position = 2, Mandatory = false)]
    [ValidateNotNull]
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;        }
    }

    /// <summary>
    /// Gets or sets the number of clicks to perform. Default is 1 for single click, 2 for double-click, etc.
    /// </summary>
    [Parameter(Position = 3, Mandatory = false)]
    [ValidateNotNull]
    public int NumClicks
    {
        get
        {
            return numClicks;
        }
        set
        {
            numClicks = value;        }
    }

    /// <summary>
    /// Gets or sets the speed of the mouse movement (1=fastest, 10=slowest, 0=instant). Default is -1 for current speed setting.
    /// </summary>
    [Parameter(Position = 4, Mandatory = false)]
    [ValidateNotNull]
    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.MouseClick(button, x, y, numClicks, speed), true);
    }
}
