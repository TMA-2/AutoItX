using System;
using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Retrieves the text from a control within a window.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ControlGetText() function to retrieve the visible text
/// from a control such as edit boxes, buttons, static text, etc. This is useful for
/// reading form data, button captions, or any text displayed in UI controls.
/// </remarks>
/// <example>
/// <code>
/// Get-AU3ControlText -Title "Notepad" -Control "Edit1"
/// </code>
/// This example retrieves the text from the main text area in Notepad.
/// </example>
/// <example>
/// <code>
/// $WinHandle = Get-AU3WinHandle -Title "Calculator"
/// $ControlHandle = Get-AU3ControlHandle -WinHandle $WinHandle -Control "Static1"
/// Get-AU3ControlText -WinHandle $WinHandle -ControlHandle $ControlHandle
/// </code>
/// This example retrieves control text using window and control handles.
/// </example>
/// <inputs>
/// <para type="description">You can pipe window handles to this cmdlet.</para>
/// </inputs>
/// <outputs>
/// <para type="description">
/// Returns the text content of the specified control as a string. Returns empty string if
/// the control has no text or if the control/window cannot be found.
/// </para>
/// </outputs>
[Cmdlet("Get", "AU3ControlText", DefaultParameterSetName = "Text")]
public class Get_AU3ControlText : PSCmdlet
{
    private string title = string.Empty;

    private string text = string.Empty;

    private string control = string.Empty;    private global::System.IntPtr winHandle;

    private global::System.IntPtr controlHandle;

    /// <summary>
    /// Gets or sets the title of the window containing the control. Supports partial matching and regular expressions.
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
            title = value;        }
    }

    /// <summary>
    /// Gets or sets the handle of the window containing the control.
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
            winHandle = value;        }
    }

    /// <summary>
    /// Gets or sets additional text to help identify the window. Optional parameter for more precise window matching.
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
            text = value;        }
    }

    /// <summary>
    /// Gets or sets the handle of the control within the window.
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
            controlHandle = value;        }
    }

    /// <summary>
    /// Gets or sets the control identifier (e.g., "Edit1", "Button2", "[CLASS:Button; INSTANCE:1]").
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

    protected override void ProcessRecord()
    {
        string parameterSetName = ((PSCmdlet)this).ParameterSetName;
        if (!(parameterSetName == "Text"))
        {
            if (parameterSetName == "Handle")
            {
                ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetText(winHandle, controlHandle, 65535), true);
            }
        }
        else
        {
            ((Cmdlet)this).WriteObject((object)AutoItX.ControlGetText(title, text, control, 65535), true);
        }
    }
}
