using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3MouseWheel")]
public class Invoke_AU3MouseWheel : PSCmdlet
{
    private string direction = string.Empty;

    private int numClicks = 1;

    [Parameter(Position = 0, Mandatory = true)]
    [ValidateNotNull]
    public string Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    [Parameter(Position = 1, Mandatory = false)]
    [ValidateNotNull]
    public int NumClicks
    {
        get
        {
            return numClicks;
        }
        set
        {
            numClicks = value;
        }
    }

    protected override void ProcessRecord()
    {
        AutoItX.MouseWheel(direction, numClicks);
    }
}
