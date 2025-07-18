using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Invoke", "AU3ControlClick", DefaultParameterSetName = "Text")]
public class Invoke_AU3ControlClick : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

    private string button = "left";

    private int numClicks = 1;

    private int x = -2147483647;

    private int y = -2147483647;

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

    [Parameter(Position = 3, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 2, Mandatory = false, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public string Button
    {
        get
        {
            return button;
        }
        set
        {
            button = value;
        }
    }

    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 3, Mandatory = false, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public int NumClicks
    {
        get
        {
            return numClicks;
        }
        set
        {
            numClicks = value;
        }
    }

    [Parameter(Position = 5, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }

    [Parameter(Position = 6, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 5, Mandatory = false, ParameterSetName = "Handle")]
    [ValidateNotNull]
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlClick(winHandle, controlHandle, button, numClicks, x, y), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlClick(title, text, control, button, numClicks, x, y), true);
        }
    }
}
