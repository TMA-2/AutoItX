using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Move", "AU3Mouse")]
public class Move_AU3Mouse : PSCmdlet
{
    private int x;

    private int y;

    private int speed = -1;

    [Parameter(Position = 0, Mandatory = true)]
    [ValidateNotNull]
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }

    [Parameter(Position = 1, Mandatory = true)]
    [ValidateNotNull]
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }

    [Parameter(Position = 2, Mandatory = false)]
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
        ((Cmdlet)this).WriteObject((object)AutoItX.MouseMove(x, y, speed), true);
    }
}
