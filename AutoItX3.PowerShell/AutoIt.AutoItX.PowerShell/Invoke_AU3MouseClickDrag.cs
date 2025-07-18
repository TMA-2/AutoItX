using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3MouseClickDrag")]
public class Invoke_AU3MouseClickDrag : PSCmdlet
{
    private string button = "left";

    private int x1;

    private int y1;

    private int x2;

    private int y2;

    private int speed = -1;

    [Parameter(Position = 0, Mandatory = true)]
    [ValidateNotNull]
    public string Button
    {
        get
        {
            return button;
        }
        set
        {
            button = value;
        }
    }

    [Parameter(Position = 1, Mandatory = true)]
    [ValidateNotNull]
    public int X1
    {
        get
        {
            return x1;
        }
        set
        {
            x1 = value;
        }
    }

    [Parameter(Position = 2, Mandatory = true)]
    [ValidateNotNull]
    public int Y1
    {
        get
        {
            return y1;
        }
        set
        {
            y1 = value;
        }
    }

    [Parameter(Position = 3, Mandatory = true)]
    [ValidateNotNull]
    public int X2
    {
        get
        {
            return x2;
        }
        set
        {
            x2 = value;
        }
    }

    [Parameter(Position = 4, Mandatory = true)]
    [ValidateNotNull]
    public int Y2
    {
        get
        {
            return y2;
        }
        set
        {
            y2 = value;
        }
    }

    [Parameter(Position = 5, Mandatory = false)]
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
        ((Cmdlet)this).WriteObject((object)AutoItX.MouseClickDrag(button, x1, y1, x2, y2, speed), true);
    }
}
