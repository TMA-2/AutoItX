using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3MouseDown")]
public class Invoke_AU3MouseDown : PSCmdlet
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
        AutoItX.MouseDown(button);
    }
}
