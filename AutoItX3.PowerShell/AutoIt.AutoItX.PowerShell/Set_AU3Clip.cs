using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Sets the clipboard text.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX ClipPut() function to set the Windows clipboard contents.
/// </remarks>
/// <example>
/// <code>
/// Set-AU3Clip -Text "Hello, world!"
/// </code>
/// This example sets the clipboard to the specified text.
/// </example>
[Cmdlet("Set", "AU3Clip")]
public class Set_AU3Clip : PSCmdlet
{
    private string text = string.Empty;

    /// <summary>
    /// Sets the text to place on the clipboard.
    /// </summary>
    [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
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
    /// Executes the cmdlet to set the clipboard text.
    /// </summary>
    protected override void ProcessRecord()
    {
        AutoItX.ClipPut(text);
    }
}
