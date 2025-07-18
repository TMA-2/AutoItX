using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3ControlCommand", DefaultParameterSetName = "Text")]
public class Invoke_AU3ControlCommand : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

    private string command = string.Empty;

    private string extra = string.Empty;

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

    [Parameter(Position = 1, Mandatory = true, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public global::System.IntPtr ControlHandle
    {
        get
        {
            return controlHandle;
        }
        set
        {
            controlHandle = value;
        }
    }

    [Parameter(Position = 2, Mandatory = false, ParameterSetName = "Text")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Control
    {
        get
        {
            return control;
        }
        set
        {
            control = value;
        }
    }

    [Parameter(Position = 3, Mandatory = true, ParameterSetName = "Text")]
    [Parameter(Position = 2, Mandatory = true, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public string Command
    {
        get
        {
            return command;
        }
        set
        {
            command = value;
        }
    }

    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 3, Mandatory = false, ParameterSetName = "Handle")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Extra
    {
        get
        {
            return extra;
        }
        set
        {
            extra = value;
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlCommand(winHandle, controlHandle, command, extra, 65535), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlCommand(title, text, control, command, extra, 65535), true);
        }
    }
}
