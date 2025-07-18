using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Set", "AU3WinState")]
public class Set_AU3WinState : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private global::System.IntPtr winHandle;

    private int flags;

    [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Text", ValueFromPipeline = true)]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }

    [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Handle", ValueFromPipeline = true)]
    [ValidateNotNull]
    public global::System.IntPtr WinHandle
    {
        get
        {
            return winHandle;
        }
        set
        {
            winHandle = value;
        }
    }

    [Parameter(Position = 1, Mandatory = false, ParameterSetName = "Text")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Text
    {
        get
        {
            return text;
        }
        set
        {
            text = value;
        }
    }

    [Parameter(Position = 2, Mandatory = true, ParameterSetName = "Text")]
    [Parameter(Position = 1, Mandatory = true, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public int Flags
    {
        get
        {
            return flags;
        }
        set
        {
            flags = value;
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.WinSetState(winHandle, flags), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinSetState(title, text, flags), true);
        }
    }
}
