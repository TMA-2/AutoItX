using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Get", "AU3ErrorCode")]
public class Get_AU3ErrorCode : PSCmdlet
{
    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.ErrorCode(), true);
    }
}
