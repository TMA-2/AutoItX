using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Invokes commands on a TreeView control in a window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ControlTreeView() function to send commands to a TreeView control.
/// </remarks>
/// <example>
/// <code>
/// Invoke-AU3ControlTreeView -Title "MyApp" -Control "SysTreeView321" -Command "Exists"
/// </code>
/// This example checks if a TreeView item exists.
/// </example>
[Cmdlet("Invoke", "AU3ControlTreeView", DefaultParameterSetName = "Text")]
public class Invoke_AU3ControlTreeView : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;

    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

    private string command = string.Empty;

    private string extra1 = string.Empty;

    private string extra2 = string.Empty;

    /// <summary>
    /// Sets the title of the window containing the TreeView control.
    /// </summary>
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

    /// <summary>
    /// Sets the handle of the window containing the TreeView control.
    /// </summary>
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

    /// <summary>
    /// Sets additional text to help identify the window.
    /// </summary>
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

    /// <summary>
    /// Sets the handle of the TreeView control.
    /// </summary>
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

    /// <summary>
    /// Sets the TreeView control identifier.
    /// </summary>
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

    /// <summary>
    /// Sets the command to send to the TreeView control.
    /// </summary>
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

    /// <summary>
    /// Sets the first extra parameter for the command.
    /// </summary>
    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 3, Mandatory = false, ParameterSetName = "Handle")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Extra1
    {
        get
        {
            return extra1;
        }
        set
        {
            extra1 = value;
        }
    }

    /// <summary>
    /// Sets the second extra parameter for the command.
    /// </summary>
    [Parameter(Position = 5, Mandatory = false, ParameterSetName = "Text")]
    [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Handle")]
    [AllowEmptyString]
    [ValidateNotNull]
    public string Extra2
    {
        get
        {
            return extra2;
        }
        set
        {
            extra2 = value;
        }
    }

    /// <summary>
    /// Executes the cmdlet to invoke the TreeView command.
    /// </summary>
    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlTreeView(winHandle, controlHandle, command, extra1, extra2, 65535), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlTreeView(title, text, control, command, extra1, extra2, 65535), true);
        }
    }
}
