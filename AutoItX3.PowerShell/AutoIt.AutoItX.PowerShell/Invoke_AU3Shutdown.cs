using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3Shutdown")]
public class Invoke_AU3Shutdown : PSCmdlet
{
    private int flag;

    [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
    [ValidateNotNull]
    public int Flag
    {
        get
        {
            return flag;
        }
        set
        {
            flag = value;
        }
    }

    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.Shutdown(flag), true);
    }
}
