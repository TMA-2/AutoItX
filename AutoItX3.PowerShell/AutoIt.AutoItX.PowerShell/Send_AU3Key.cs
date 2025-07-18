using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

public enum SendMode
{
    /// <summary>
    /// Normal mode with AutoIt special key processing.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Raw mode where keys are sent exactly as specified without special processing.
    /// </summary>
    Raw = 1
}

/// <summary>
/// Sends keystrokes to the active window as if typed on the keyboard.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX Send() function to send a series of keystrokes to the active window.
/// The keys are sent as if they were typed on the keyboard. Special keys and key combinations can be
/// sent using special syntax enclosed in braces.
/// </remarks>
/// <example>
/// <code>
/// Send-AU3Key -Key "Hello World"
/// </code>
/// This example sends the text "Hello World" to the active window.
/// </example>
/// <example>
/// <code>
/// Send-AU3Key -Key "{ENTER}"
/// </code>
/// This example sends the Enter key to the active window.
/// </example>
/// <example>
/// <code>
/// Send-AU3Key -Key "^c"
/// </code>
/// This example sends Ctrl+C (copy) to the active window.
/// </example>
/// <example>
/// <code>
/// Send-AU3Key -Key "{ALT}fm" -Mode 1
/// </code>
/// This example sends Alt+F+M with raw mode enabled.
/// </example>
/// <inputs>
/// <para type="description">None. This cmdlet does not accept pipeline input.</para>
/// </inputs>
/// <outputs>
/// <para type="description">None. This cmdlet does not generate output.</para>
/// </outputs>
[Cmdlet("Send", "AU3Key")]
public class Send_AU3Key : PSCmdlet
{
    private string key = string.Empty;

    private SendMode mode;

    /// <summary>
    /// Gets or sets the keystrokes to send. Can include regular text and special key sequences.
    /// </summary>
    /// <remarks>
    /// Special keys are enclosed in braces: {ENTER}, {TAB}, {SPACE}, etc.
    /// Modifier keys use symbols: ^ (Ctrl), ! (Alt), + (Shift), # (Windows key)
    /// Repeated keys use syntax: {key count}, e.g., {TAB 3} sends Tab 3 times.
    ///
    /// Common special keys:
    /// - {ENTER} or {RETURN} - Enter key
    /// - {TAB} - Tab key
    /// - {SPACE} - Space bar
    /// - {BACKSPACE} or {BS} - Backspace
    /// - {DELETE} or {DEL} - Delete key
    /// - {UP}, {DOWN}, {LEFT}, {RIGHT} - Arrow keys
    /// - {HOME}, {END} - Home and End keys
    /// - {PGUP}, {PGDN} - Page Up and Page Down
    /// - {F1} through {F12} - Function keys
    /// - {ESC} - Escape key
    /// </remarks>
    [Parameter(Position = 0, Mandatory = true)]
    [ValidateNotNull]
    public string Key
    {
        get
        {
            return key;
        }
        set
        {
            key = value;
        }
    }

    /// <summary>
    /// Gets or sets the send mode. 0 (default) for normal mode with AutoIt special key processing,
    /// 1 for raw mode where keys are sent exactly as specified without special processing.
    /// </summary>
    [Parameter(Position = 1, Mandatory = false)]
    [ValidateNotNull]
    public SendMode Mode
    {
        get
        {
            return mode;
        }
        set
        {
            mode = value;
        }
    }

    protected override void ProcessRecord()
    {
        AutoItX.Send(key, (int)mode);
    }
}
