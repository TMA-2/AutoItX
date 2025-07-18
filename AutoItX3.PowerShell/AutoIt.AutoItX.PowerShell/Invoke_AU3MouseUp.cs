using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3MouseUp")]
public class Invoke_AU3MouseUp : PSCmdlet
{
    private string button = "left";

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
            button = value;
        }
    }

    protected override void ProcessRecord()
    {
        AutoItX.MouseUp(button);
    }
}
