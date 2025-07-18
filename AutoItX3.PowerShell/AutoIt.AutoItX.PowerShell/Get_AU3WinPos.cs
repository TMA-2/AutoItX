using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Get", "AU3WinPos", DefaultParameterSetName = "Text")]
public class Get_AU3WinPos : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private global::System.IntPtr winHandle;

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

    protected override void ProcessRecord()
    {
        //IL_002f: Unknown result type (might be due to invalid IL or missing references)
        //IL_0047: Unknown result type (might be due to invalid IL or missing references)
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.WinGetPos(winHandle), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinGetPos(title, text), true);
        }
    }
}
