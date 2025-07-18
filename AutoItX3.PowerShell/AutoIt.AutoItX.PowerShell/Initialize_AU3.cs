using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Initialize", "AU3")]
public class Initialize_AU3 : PSCmdlet
{
    protected override void ProcessRecord()
    {
        AutoItX.Init();
    }
}
