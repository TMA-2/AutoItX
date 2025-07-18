using System.Management.Automation;

namespace AutoIt.AutoItX.PowerShell;

/// <summary>
/// Checks if the current user has administrator privileges.
/// </summary>
/// <remarks>
/// This cmdlet wraps the AutoItX IsAdmin() function to determine whether the current user
/// is running with administrator privileges on the system.
/// </remarks>
/// <example>
/// <code>
/// Assert-AU3IsAdmin
/// </code>
/// This example checks if the current user has administrator privileges and returns a boolean value.
/// </example>
/// <outputs>
/// <para type="description">
/// Returns a boolean value indicating whether the current user has administrator privileges.
/// </para>
/// </outputs>
[Cmdlet("Assert", "AU3IsAdmin")]
public class Assert_AU3IsAdmin : PSCmdlet
{
    protected override void ProcessRecord()
    {
        ((Cmdlet)this).WriteObject((object)AutoItX.IsAdmin(), true);
    }
}
