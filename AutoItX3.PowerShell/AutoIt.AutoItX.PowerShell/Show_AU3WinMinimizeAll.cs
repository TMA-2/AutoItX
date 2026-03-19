using System.Management.Automation;

namespace AutoIt.PowerShell;

[Cmdlet("Show", "AU3WinMinimizeAll")]
public class Show_AU3WinMinimizeAll : PSCmdlet
{
    protected override void ProcessRecord()
    {
        AutoItX.WinMinimizeAll();
    }
}
