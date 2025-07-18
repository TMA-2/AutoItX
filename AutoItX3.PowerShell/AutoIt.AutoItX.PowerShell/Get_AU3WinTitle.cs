using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Get", "AU3WinTitle")]
public class Get_AU3WinTitle : PSCmdlet
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
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.WinGetTitle(winHandle, 65535), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinGetTitle(title, text, 65535), true);
        }
    }
}
