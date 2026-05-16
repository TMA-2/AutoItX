# AutoItX PowerShell
The AutoItX PowerShell module, decompiled to `AutoItX3.Assembly` (the .NET wrapper) and `AutoItX3.PowerShell` (the module cmdlets) CS projects and VS solution with added in-line documentation, XML documentation, Markdown, and MAML help.

- [License](LICENSE.md)
- [Changelog](CHANGELOG.md)

## Disclaimer
⚠️*NOTE*: I make no claims to authorship or ownership. The author and owner of AutoItX is [Jonathan Bennett](https://github.com/jonathanbennett73). If you'd like me to remove this, please let me know and I'll comply.

## Purpose / Goals
My purpose with this is to have an improved experience using the AutoItX module, getting its functionality and standards more in-line with PowerShell than AutoIt.
To that end, I've decompiled the .NET assemblies (`AutoItX3.Assembly.dll` and `AutoItX3.PowerShell.dll`) with ILSpy in order to add in-line documentation and to see how they work.

1. [x] Add XML documentation to the .NET wrapper and cmdlet projects
2. [ ] Add Markdown and MAML help to the cmdlet project in place of the .chm.
3. [ ] [Refactor the cmdlets](#refactor-the-cmdlets)
4. [ ] Add proper cmdlet exception throwing.
5. [ ] Add new PowerShell examples.
6. [ ] Contact Jonathan Bennett about updating the module on the [official AutoIt site](https://www.autoitscript.com) for the community's benefit.

### Module Help
The original module's help was in a compiled HTML help file (`.chm`), which is not ideal for PowerShell users.
I plan to replace this with Markdown and MAML help files, which are more standard for PowerShell modules, as well as XMLDoc `AutoItX.PowerShell.xml`, which will contain the XML documentation for the .NET wrapper assembly.

### Refactor the cmdlets
If I can figure out what the hell I'm doing, I'd like to change the functionality to change `Get-` cmdlets from the standard of returning some value on success and 0 on failure to returning the requested value on success or throwing an exception on failure.
For cmdlets that make changes, e.g. `New`, `Set`, `Remove`, etc., returning nothing on success (unless `-PassThru` is used) or an exception on failure.
Having to pipe `Get-AU3` cmdlets to `Out-Null` (or casting to `[void]`, or assigning to `$null`) quickly gets tedious and isn't how PowerShell cmdlets should work.

### Exception Throwing
The original module's cmdlets always return a value, and 0 on failure (or set the "error macro" you have to retrieve with `Get-AU3ErrorCode`).
I plan to change this to throw exceptions on failure, which is more standard for PowerShell cmdlets and allows for better error handling.

### Examples
The original module's examples are all in C++ and VBScript, without any PowerShell.
I plan to add new examples in PowerShell to the module, or at least compile the examples used in the cmdlets' help info.

### Update Official AutoItX
On completion, seeing if Mr. Bennett is interested in updating the module on the [official AutoIt site](https://www.autoitscript.com) for the community's benefit.

## Other Versions
[AutoItX.NetCore](https://github.com/kkb912002/AutoItX.NetCore)
