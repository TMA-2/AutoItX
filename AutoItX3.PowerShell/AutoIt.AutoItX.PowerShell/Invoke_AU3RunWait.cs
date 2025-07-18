using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3RunWait")]
public class Invoke_AU3RunWait : PSCmdlet
{
    private string program = string.Empty;

    private string dir = string.Empty;

    private int showFlag = 1;

    [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
    [ValidateNotNull]
    public string Program
    {
        get
        {
            return program;
        }
        set
        {
            program = value;
        }
    }

    [Parameter(Position = 1, Mandatory = false)]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Dir
    {
        get
        {
            return dir;
        }
        set
        {
            dir = value;
        }
    }

    [Parameter(Position = 2, Mandatory = false)]
    [ValidateNotNull]
    public int ShowFlag
    {
        get
        {
            return showFlag;
        }
        set
        {
            showFlag = value;
        }
    }

    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.RunWait(program, dir, showFlag), true);
    }
}
