using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

[Cmdlet("Move", "AU3Win")]
public class Move_AU3Win : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private global::System.IntPtr winHandle;

    private int x;

    private int y;

    private int width = -1;

    private int height = -1;

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
    [AllowEmptyString]
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

    [Parameter(Position = 3, Mandatory = true, ParameterSetName = "Text")]
    [Parameter(Position = 2, Mandatory = true, ParameterSetName = "Handle")]
    [AllowEmptyString]
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

    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 3, Mandatory = false, ParameterSetName = "Handle")]
    [AllowEmptyString]
    [ValidateNotNull]
    public int Width
    {
        get
        {
            return width;
        }
        set
        {
            width = value;
        }
    }

    [Parameter(Position = 5, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Handle")]
    [AllowEmptyString]
    [ValidateNotNull]
    public int Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
        }
    }

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.WinMove(winHandle, x, y, width, height), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.WinMove(title, text, x, y, width, height), true);
        }
    }
}
