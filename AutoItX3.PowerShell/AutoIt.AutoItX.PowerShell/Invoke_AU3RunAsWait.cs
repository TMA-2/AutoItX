using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3RunAsWait")]
public class Invoke_AU3RunAsWait : PSCmdlet
{
    private string user = string.Empty;

    private string domain = string.Empty;

    private string password = string.Empty;

    private int logonFlag = 1;

    private string program = string.Empty;

    private string dir = string.Empty;

    private int showFlag = 1;

    [Parameter(Position = 0, Mandatory = true)]
    [ValidateNotNull]
    public string User
    {
        get
        {
            return user;
        }
        set
        {
            user = value;
        }
    }

    [Parameter(Position = 1, Mandatory = true)]
    [ValidateNotNull]
    public string Domain
    {
        get
        {
            return domain;
        }
        set
        {
            domain = value;
        }
    }

    [Parameter(Position = 2, Mandatory = true)]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }

    [Parameter(Position = 3, Mandatory = false)]
    [ValidateNotNull]
    public int LogonFlag
    {
        get
        {
            return logonFlag;
        }
        set
        {
            logonFlag = value;
        }
    }

    [Parameter(Position = 4, Mandatory = true)]
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

    [Parameter(Position = 5, Mandatory = false)]
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

    [Parameter(Position = 6, Mandatory = false)]
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
        ((Cmdlet)this).WriteObject((object)AutoItX.RunAsWait(user, domain, password, logonFlag, program, dir, showFlag), true);
    }
}
