using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using AutoItX3.Assembly.AutoIt;

namespace AutoIt;

/// <summary>
/// The AutoItX DLL wrapper class for the native AutoItX3.dll.
/// </summary>
public static class AutoItX
{
    /// <summary>
    /// Default value for _some_ int parameters (largest negative number).
    /// </summary>
    public const int INTDEFAULT = -2147483647;

    /// <summary>
    ///
    /// </summary>
    public const int SW_HIDE = 0;

    /// <summary>
    /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position.
    /// </summary>
    public const int SW_SHOWNORMAL = 1;

    /// <summary>
    /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position.
    /// </summary>
    public const int SW_NORMAL = 1;

    /// <summary>
    /// Activates the window and displays it as a minimized window.
    /// </summary>
    public const int SW_SHOWMINIMIZED = 2;

    /// <summary>
    /// Activates the window and displays it as a maximized window.
    /// </summary>
    public const int SW_SHOWMAXIMIZED = 3;

    /// <summary>
    /// Maximizes the specified window.
    /// </summary>
    public const int SW_MAXIMIZE = 3;

    /// <summary>
    ///
    /// </summary>
    public const int SW_SHOWNOACTIVATE = 4;

    /// <summary>
    ///             Activates the window and displays it in its current size and position.
    /// </summary>
    public const int SW_SHOW = 5;

    /// <summary>
    /// Minimizes the specified window and activates the next top-level window in the Z order.
    /// </summary>
    public const int SW_MINIMIZE = 6;

    /// <summary>
    /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
    /// </summary>
    public const int SW_SHOWMINNOACTIVE = 7;

    /// <summary>
    /// Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.
    /// </summary>
    public const int SW_SHOWNA = 8;

    /// <summary>
    /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position.
    /// </summary>
    public const int SW_RESTORE = 9;

    /// <summary>
    /// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function.
    /// </summary>
    public const int SW_SHOWDEFAULT = 10;

    /// <summary>
    /// Minimizes a window, even if the thread that owns the window is not responding.
    /// </summary>
    public const int SW_FORCEMINIMIZE = 11;

    private const int StringSizePath = 260;

    private const int StringSizeSmall = 1024;

    private const int StringSizeMedium = 65535;

    private const int StringSizeLarge = 1048576;

    /// <summary>
    /// Checks if currently running in 64bit.
    /// </summary>
    public static void Init()
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_Init64();
        }
        else
        {
            AutoItX_DLLImport.AU3_Init32();
        }
    }

    /// <summary>
    /// Returns the last error code.
    /// </summary>
    /// <returns>The last error code as an integer value.</returns>
    public static int ErrorCode()
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_error64();
        }
        return AutoItX_DLLImport.AU3_error32();
    }

    /// <summary>
    /// Changes the operation of various AutoIt functions/parameters.
    /// </summary>
    /// <param name="option">The option to change. See <see href="https://www.autoitscript.com/autoit3/docs/functions/AutoItSetOption.htm">Remarks</see>.</param>
    /// <param name="optionValue">The value to assign to the option. The type and meaning vary by option. If the param is not provided, then the function just returns the value already assigned to the option.</param>
    /// <returns>The <see cref="T:System.Int32" /> value of the previous setting for the option.</returns>
    public static int AutoItSetOption(string option, int optionValue)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_AutoItSetOption64(option, optionValue);
        }
        return AutoItX_DLLImport.AU3_AutoItSetOption32(option, optionValue);
    }

    /// <summary>
    /// Retrieves text from the clipboard.
    /// </summary>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the clipboard as a string.</returns>
    public static string ClipGet(int maxLen = 1048576)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ClipGet64(stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ClipGet32(stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Writes text to the clipboard.
    /// </summary>
    /// <param name="text">The text to write to the clipboard.</param>
    public static void ClipPut(string text)
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ClipPut64(text);
        }
        else
        {
            AutoItX_DLLImport.AU3_ClipPut32(text);
        }
    }

    /// <summary>
    /// Sends a mouse click command to a given control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="button">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary". Default is "left".</param>
    /// <param name="numClicks">The number of times to click the mouse. Default is 1.</param>
    /// <param name="x">The x position to click within the control. Default is center.</param>
    /// <param name="y">The y position to click within the control. Default is center.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlClick(string title, string text, string control, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlClick64(title, text, control, button, numClicks, x, y);
        }
        return AutoItX_DLLImport.AU3_ControlClick32(title, text, control, button, numClicks, x, y);
    }

    /// <summary>
    /// Sends a mouse click command to a given control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="button">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary". Default is "left".</param>
    /// <param name="numClicks">The number of times to click the mouse. Default is 1.</param>
    /// <param name="x">The x position to click within the control. Default is center.</param>
    /// <param name="y">The y position to click within the control. Default is center.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlClick(IntPtr winHandle, IntPtr controlHandle, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlClickByHandle64(winHandle, controlHandle, button, numClicks, x, y);
        }
        return AutoItX_DLLImport.AU3_ControlClickByHandle32(winHandle, controlHandle, button, numClicks, x, y);
    }

    /// <summary>
    /// Sends a command to a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="command">The command to send to the control.</param>
    /// <param name="extra">Additional parameter required by some commands.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The response from the control command as a string.</returns>
    public static string ControlCommand(string title, string text, string control, string command, string extra, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlCommand64(title, text, control, command, extra, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlCommand32(title, text, control, command, extra, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Sends a command to a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="command">The command to send to the control.</param>
    /// <param name="extra">Additional parameter required by some commands.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The response from the control command as a string.</returns>
    public static string ControlCommand(IntPtr winHandle, IntPtr controlHandle, string command, string extra, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlCommandByHandle64(winHandle, controlHandle, command, extra, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlCommandByHandle32(winHandle, controlHandle, command, extra, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Sends a command to a ListView32 control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="command">The command to send to the ListView control.</param>
    /// <param name="extra1">Additional parameter required by some commands.</param>
    /// <param name="extra2">Additional parameter required by some commands.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The response from the ListView control command as a string.</returns>
    public static string ControlListView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlListView64(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlListView32(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Sends a command to a ListView32 control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="command">The command to send to the ListView control.</param>
    /// <param name="extra1">Additional parameter required by some commands.</param>
    /// <param name="extra2">Additional parameter required by some commands.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The response from the ListView control command as a string.</returns>
    public static string ControlListView(IntPtr winHandle, IntPtr controlHandle, string command, string extra1, string extra2, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlListViewByHandle64(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlListViewByHandle32(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Disables or "grays-out" a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlDisable(string title, string text, string control)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlDisable64(title, text, control);
        }
        return AutoItX_DLLImport.AU3_ControlDisable32(title, text, control);
    }

    /// <summary>
    /// Disables or "grays-out" a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlDisable(IntPtr winHandle, IntPtr controlHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlDisableByHandle64(winHandle, controlHandle);
        }
        return AutoItX_DLLImport.AU3_ControlDisableByHandle32(winHandle, controlHandle);
    }

    /// <summary>
    /// Enables a "grayed-out" control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlEnable(string title, string text, string control)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlEnable64(title, text, control);
        }
        return AutoItX_DLLImport.AU3_ControlEnable32(title, text, control);
    }

    /// <summary>
    /// Enables a "grayed-out" control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlEnable(IntPtr winHandle, IntPtr controlHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlEnableByHandle64(winHandle, controlHandle);
        }
        return AutoItX_DLLImport.AU3_ControlEnableByHandle32(winHandle, controlHandle);
    }

    /// <summary>
    /// Sets input focus to a given control on a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlFocus(string title, string text, string control)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlFocus64(title, text, control);
        }
        return AutoItX_DLLImport.AU3_ControlFocus32(title, text, control);
    }

    /// <summary>
    /// Sets input focus to a given control on a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlFocus(IntPtr winHandle, IntPtr controlHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlFocusByHandle64(winHandle, controlHandle);
        }
        return AutoItX_DLLImport.AU3_ControlFocusByHandle32(winHandle, controlHandle);
    }

    /// <summary>
    /// Returns the ControlRef# of the control that has keyboard focus within a specified window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The ControlRef# of the focused control as a string.</returns>
    public static string ControlGetFocus(string title = "", string text = "", int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetFocus64(title, text, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetFocus32(title, text, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Returns the ControlRef# of the control that has keyboard focus within a specified window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The ControlRef# of the focused control as a string.</returns>
    public static string ControlGetFocus(IntPtr winHandle, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetFocusByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetFocusByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the internal handle of a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>The control handle as an IntPtr.</returns>
    public static IntPtr ControlGetHandle(IntPtr winHandle, string control = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlGetHandle64(winHandle, control);
        }
        return AutoItX_DLLImport.AU3_ControlGetHandle32(winHandle, control);
    }

    /// <summary>
    /// Retrieves the internal handle of a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The control handle as a string.</returns>
    public static string ControlGetHandleAsText(string title = "", string text = "", string control = "", int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetHandleAsText64(title, text, control, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetHandleAsText32(title, text, control, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the position and size of a control relative to it's window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>A Rectangle containing the position (x, y) and size (width, height) properties of the control.</returns>
    public static Rectangle ControlGetPos(string title = "", string text = "", string control = "")
    {
        AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetPos64(title, text, control, ref rect);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetPos32(title, text, control, ref rect);
        }
        return new Rectangle
        {
            X = rect.left,
            Y = rect.top,
            Width = rect.right - rect.left,
            Height = rect.bottom - rect.top
        };
    }

    /// <summary>
    /// Retrieves the position and size of a control relative to it's window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <returns>A Rectangle containing the position (x, y) and size (width, height) properties of the control.</returns>
    public static Rectangle ControlGetPos(IntPtr winHandle, IntPtr controlHandle)
    {
        AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetPosByHandle64(winHandle, controlHandle, ref rect);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetPosByHandle32(winHandle, controlHandle, ref rect);
        }
        return new Rectangle
        {
            X = rect.left,
            Y = rect.top,
            Width = rect.right - rect.left,
            Height = rect.bottom - rect.top
        };
    }

    /// <summary>
    /// Retrieves text from a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the control as a string.</returns>
    public static string ControlGetText(string title, string text, string control, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetText64(title, text, control, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetText32(title, text, control, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves text from a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the control as a string.</returns>
    public static string ControlGetText(IntPtr winHandle, IntPtr controlHandle, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlGetTextByHandle64(winHandle, controlHandle, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlGetTextByHandle32(winHandle, controlHandle, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Hides a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlHide(string title, string text, string control)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlHide64(title, text, control);
        }
        return AutoItX_DLLImport.AU3_ControlHide32(title, text, control);
    }

    /// <summary>
    /// Hides a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlHide(IntPtr winHandle, IntPtr controlHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlHideByHandle64(winHandle, controlHandle);
        }
        return AutoItX_DLLImport.AU3_ControlHideByHandle32(winHandle, controlHandle);
    }

    /// <summary>
    /// Moves a control within a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="x">The new x position of the control.</param>
    /// <param name="y">The new y position of the control.</param>
    /// <param name="width">The new width of the control.</param>
    /// <param name="height">The new height of the control.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlMove(string title, string text, string control, int x, int y, int width = -1, int height = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlMove64(title, text, control, x, y, width, height);
        }
        return AutoItX_DLLImport.AU3_ControlMove32(title, text, control, x, y, width, height);
    }

    /// <summary>
    /// Moves a control within a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="x">The new x position of the control.</param>
    /// <param name="y">The new y position of the control.</param>
    /// <param name="width">The new width of the control.</param>
    /// <param name="height">The new height of the control.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlMove(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width = -1, int height = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlMoveByHandle64(winHandle, controlHandle, x, y, width, height);
        }
        return AutoItX_DLLImport.AU3_ControlMoveByHandle32(winHandle, controlHandle, x, y, width, height);
    }

    /// <summary>
    /// Sends a string of characters to a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="sendText">String of characters to send to the control.</param>
    /// <param name="mode">Changes how keys are processed: 0 = default (special characters like + and ! indicate SHIFT and ALT), 1 = raw mode (keys are sent raw).</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlSend(string title, string text, string control, string sendText, int mode = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlSend64(title, text, control, sendText, mode);
        }
        return AutoItX_DLLImport.AU3_ControlSend32(title, text, control, sendText, mode);
    }

    /// <summary>
    /// Sends a string of characters to a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="sendText">String of characters to send to the control.</param>
    /// <param name="mode">Changes how keys are processed: 0 = default (special characters like + and ! indicate SHIFT and ALT), 1 = raw mode (keys are sent raw).</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlSend(IntPtr winHandle, IntPtr controlHandle, string sendText, int mode = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlSendByHandle64(winHandle, controlHandle, sendText, mode);
        }
        return AutoItX_DLLImport.AU3_ControlSendByHandle32(winHandle, controlHandle, sendText, mode);
    }

    /// <summary>
    /// Sets text of a control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="controlText">The text to set in the control.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlSetText(string title, string text, string control, string controlText)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlSetText64(title, text, control, controlText);
        }
        return AutoItX_DLLImport.AU3_ControlSetText32(title, text, control, controlText);
    }

    /// <summary>
    /// Sets text of a control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="controlText">The text to set in the control.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlSetText(IntPtr winHandle, IntPtr controlHandle, string controlText)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlSetTextByHandle64(winHandle, controlHandle, controlText);
        }
        return AutoItX_DLLImport.AU3_ControlSetTextByHandle32(winHandle, controlHandle, controlText);
    }

    /// <summary>
    /// Shows a control that was hidden.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlShow(string title, string text, string control)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlShow64(title, text, control);
        }
        return AutoItX_DLLImport.AU3_ControlShow32(title, text, control);
    }

    /// <summary>
    /// Shows a control that was hidden.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ControlShow(IntPtr winHandle, IntPtr controlHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ControlShowByHandle64(winHandle, controlHandle);
        }
        return AutoItX_DLLImport.AU3_ControlShowByHandle32(winHandle, controlHandle);
    }

    /// <summary>
    /// Sends a command to a TreeView32 control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="control">The control to search for.</param>
    /// <param name="command">The command to send to the TreeView control.</param>
    /// <param name="extra1">Additional parameter required by some commands, typically the item reference.</param>
    /// <param name="extra2">Additional parameter required by some commands.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The response from the TreeView control command as a string.</returns>
    public static string ControlTreeView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlTreeView64(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlTreeView32(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Sends a command to a TreeView32 control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="controlHandle">The control handle to search for.</param>
    /// <param name="command">The command to send to the TreeView control.</param>
    /// <param name="extra1">Additional parameter required by some commands, typically the item reference.</param>
    /// <param name="extra2">Additional parameter required by some commands.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The response from the TreeView control command as a string.</returns>
    public static string ControlTreeView(IntPtr winHandle, IntPtr controlHandle, string command, string extra1, string extra2, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ControlTreeViewByHandle64(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_ControlTreeViewByHandle32(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Maps a network drive.
    /// </summary>
    /// <param name="device">The device to map, for example "O:" or "LPT1:". If empty string, a connection is made but not mapped to a specific drive. If "*", an unused drive letter will be automatically selected.</param>
    /// <param name="share">The remote share to connect to in the form "\\server\share".</param>
    /// <param name="flags">A combination of flags: 0 = default, 1 = persistent mapping, 8 = show authentication dialog if required.</param>
    /// <param name="user">The username to use to connect, in the form "username" or "domain\username".</param>
    /// <param name="password">The password to use to connect.</param>
    /// <returns>The mapped drive letter on success, empty string on failure.</returns>
    public static string DriveMapAdd(string device, string share, int flags = 0, string user = "", string password = "")
    {
        StringBuilder stringBuilder = new StringBuilder(4);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_DriveMapAdd64(device, share, flags, user, password, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_DriveMapAdd32(device, share, flags, user, password, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Disconnects a network drive.
    /// </summary>
    /// <param name="device">The device to disconnect (e.g., "O:").</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int DriveMapDel(string device)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_DriveMapDel64(device);
        }
        return AutoItX_DLLImport.AU3_DriveMapDel32(device);
    }

    /// <summary>
    /// Retreives the details of a mapped drive.
    /// </summary>
    /// <param name="device">The device to query (e.g., "O:").</param>
    /// <returns>The UNC path of the mapped drive as a string.</returns>
    public static string DriveMapGet(string device)
    {
        StringBuilder stringBuilder = new StringBuilder(260);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_DriveMapGet64(device, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_DriveMapGet32(device, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Checks if the current user has administrator privileges.
    /// </summary>
    /// <returns>1 if the current user has administrator privileges, 0 otherwise.</returns>
    public static int IsAdmin()
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_IsAdmin64();
        }
        return AutoItX_DLLImport.AU3_IsAdmin32();
    }

    /// <summary>
    /// Perform a mouse click operation.
    /// </summary>
    /// <param name="button">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
    /// <param name="x">The x coordinate to move the mouse to. If not specified, current position is used.</param>
    /// <param name="y">The y coordinate to move the mouse to. If not specified, current position is used.</param>
    /// <param name="numClicks">The number of times to click the mouse. Default is 1.</param>
    /// <param name="speed">The speed to move the mouse in the range 1 (fastest) to 100 (slowest). A speed of 0 will move the mouse instantly. Default is 10.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int MouseClick(string button = "LEFT", int x = -2147483647, int y = -2147483647, int numClicks = 1, int speed = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_MouseClick64(button, x, y, numClicks, speed);
        }
        return AutoItX_DLLImport.AU3_MouseClick32(button, x, y, numClicks, speed);
    }

    /// <summary>
    /// Perform a mouse click and drag operation.
    /// </summary>
    /// <param name="button">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
    /// <param name="x1">The x coordinate to start the drag operation from.</param>
    /// <param name="y1">The y coordinate to start the drag operation from.</param>
    /// <param name="x2">The x coordinate to end the drag operation at.</param>
    /// <param name="y2">The y coordinate to end the drag operation at.</param>
    /// <param name="speed">The speed to move the mouse in the range 1 (fastest) to 100 (slowest). A speed of 0 will move the mouse instantly. Default is 10.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int MouseClickDrag(string button, int x1, int y1, int x2, int y2, int speed = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_MouseClickDrag64(button, x1, y1, x2, y2, speed);
        }
        return AutoItX_DLLImport.AU3_MouseClickDrag32(button, x1, y1, x2, y2, speed);
    }

    /// <summary>
    /// Perform a mouse down event at the current mouse position.
    /// </summary>
    /// <param name="button">The button to press down: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
    public static void MouseDown(string button = "LEFT")
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_MouseDown64(button);
        }
        else
        {
            AutoItX_DLLImport.AU3_MouseDown32(button);
        }
    }

    /// <summary>
    /// Returns a cursor ID Number of the current Mouse Cursor.
    /// </summary>
    /// <returns>The cursor ID number as an integer.</returns>
    public static int MouseGetCursor()
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_MouseGetCursor64();
        }
        return AutoItX_DLLImport.AU3_MouseGetCursor32();
    }

    /// <summary>
    /// Retrieves the current position of the mouse cursor.
    /// </summary>
    /// <returns>A Point containing the current position (x, y) of the mouse cursor.</returns>
    public static Point MouseGetPos()
    {
        AutoItX_DLLImport.POINT pt = default(AutoItX_DLLImport.POINT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_MouseGetPos64(ref pt);
        }
        else
        {
            AutoItX_DLLImport.AU3_MouseGetPos32(ref pt);
        }
        return new Point(pt.x, pt.y);
    }

    /// <summary>
    /// Moves the mouse pointer.
    /// </summary>
    /// <param name="x">The x coordinate to move the mouse to.</param>
    /// <param name="y">The y coordinate to move the mouse to.</param>
    /// <param name="speed">The speed to move the mouse in the range 1 (fastest) to 100 (slowest). A speed of 0 will move the mouse instantly. Default is 10.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int MouseMove(int x, int y, int speed = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_MouseMove64(x, y, speed);
        }
        return AutoItX_DLLImport.AU3_MouseMove32(x, y, speed);
    }

    /// <summary>
    /// Perform a mouse up event at the current mouse position.
    /// </summary>
    /// <param name="button">The button to release: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
    public static void MouseUp(string button = "LEFT")
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_MouseUp64(button);
        }
        else
        {
            AutoItX_DLLImport.AU3_MouseUp32(button);
        }
    }

    /// <summary>
    /// Moves the mouse wheel up or down.
    /// </summary>
    /// <param name="direction">The direction to move the wheel: "up" or "down".</param>
    /// <param name="numClicks">The number of times to move the wheel. Default is 1.</param>
    public static void MouseWheel(string direction, int numClicks)
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_MouseWheel64(direction, numClicks);
        }
        else
        {
            AutoItX_DLLImport.AU3_MouseWheel32(direction, numClicks);
        }
    }

    /// <summary>
    /// Generates a checksum for a region of pixels.
    /// </summary>
    /// <param name="rect">The rectangle area to checksum.</param>
    /// <param name="step">Instead of checksumming each pixel, use a value larger than 1 to skip pixels (for speed). Default is 1.</param>
    /// <returns>The checksum value as an integer.</returns>
    public static uint PixelChecksum(Rectangle rect, int step = 1)
    {
        AutoItX_DLLImport.RECT rect2 = default(AutoItX_DLLImport.RECT);
        rect2.left = rect.Left;
        rect2.top = rect.Top;
        rect2.right = rect.Right;
        rect2.bottom = rect.Bottom;
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_PixelChecksum64(ref rect2, step);
        }
        return AutoItX_DLLImport.AU3_PixelChecksum32(ref rect2, step);
    }

    /// <summary>
    /// Returns a pixel color according to x,y pixel coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the pixel.</param>
    /// <param name="y">The y coordinate of the pixel.</param>
    /// <returns>The color value as an integer.</returns>
    public static int PixelGetColor(int x, int y)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_PixelGetColor64(x, y);
        }
        return AutoItX_DLLImport.AU3_PixelGetColor32(x, y);
    }

    /// <summary>
    /// Searches a rectangle of pixels for the pixel color provided.
    /// </summary>
    /// <param name="rect">The rectangle area to search.</param>
    /// <param name="color">Color value of pixel to find (in decimal or hex).</param>
    /// <param name="shade">A number between 0 and 255 to indicate the allowed number of shades of variation of the red, green, and blue components of the color. Default is 0 (exact match).</param>
    /// <param name="step">Instead of searching each pixel, use a value larger than 1 to skip pixels (for speed). Default is 1.</param>
    /// <returns>A Point containing the coordinates of the found pixel, or Point.Empty if not found.</returns>
    public static Point PixelSearch(Rectangle rect, int color, int shade = 0, int step = 1)
    {
        AutoItX_DLLImport.RECT rect2 = default(AutoItX_DLLImport.RECT);
        rect2.left = rect.Left;
        rect2.top = rect.Top;
        rect2.right = rect.Right;
        rect2.bottom = rect.Bottom;
        AutoItX_DLLImport.POINT winPoint = default(AutoItX_DLLImport.POINT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_PixelSearch64(ref rect2, color, shade, step, ref winPoint);
        }
        else
        {
            AutoItX_DLLImport.AU3_PixelSearch32(ref rect2, color, shade, step, ref winPoint);
        }
        return new Point(winPoint.x, winPoint.y);
    }

    /// <summary>
    /// Terminates a named process.
    /// </summary>
    /// <param name="process">The name or PID of the process to terminate.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ProcessClose(string process)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ProcessClose64(process);
        }
        return AutoItX_DLLImport.AU3_ProcessClose32(process);
    }

    /// <summary>
    /// Checks to see if a specified process exists.
    /// </summary>
    /// <param name="process">The name or PID of the process to check.</param>
    /// <returns>The process ID (PID) if the process exists, 0 otherwise.</returns>
    public static int ProcessExists(string process)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ProcessExists64(process);
        }
        return AutoItX_DLLImport.AU3_ProcessExists32(process);
    }

    /// <summary>
    /// Changes the priority of a process.
    /// </summary>
    /// <param name="process">The name or PID of the process to change priority for.</param>
    /// <param name="priority">The priority to set: 0 = Idle/Low, 1 = Below Normal, 2 = Normal, 3 = Above Normal, 4 = High, 5 = Realtime (use with caution).</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int ProcessSetPriority(string process, int priority)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ProcessSetPriority64(process, priority);
        }
        return AutoItX_DLLImport.AU3_ProcessSetPriority32(process, priority);
    }

    /// <summary>
    /// Pauses script execution until a given process exists.
    /// </summary>
    /// <param name="process">The name of the process to wait for.</param>
    /// <param name="timeout">How long to wait (in seconds). Default is to wait indefinitely.</param>
    /// <returns>The process ID (PID) when found, 0 on timeout.</returns>
    public static int ProcessWait(string process, int timeout)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ProcessWait64(process, timeout);
        }
        return AutoItX_DLLImport.AU3_ProcessWait32(process, timeout);
    }

    /// <summary>
    /// Pauses script execution until a given process does not exist.
    /// </summary>
    /// <param name="process">The name or PID of the process to wait for closure.</param>
    /// <param name="timeout">How long to wait (in seconds). Default is to wait indefinitely.</param>
    /// <returns>1 when the process closes, 0 on timeout.</returns>
    public static int ProcessWaitClose(string process, int timeout)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_ProcessWaitClose64(process, timeout);
        }
        return AutoItX_DLLImport.AU3_ProcessWaitClose32(process, timeout);
    }

    /// <summary>
    /// Runs an external program.
    /// </summary>
    /// <param name="program">The program to run.</param>
    /// <param name="dir">The working directory to use.</param>
    /// <param name="showFlag">The "show" flag of the executed program: 0 = hidden window, 1 = normal window, 3 = maximized window.</param>
    /// <returns>The process ID (PID) of the launched program, 0 on failure.</returns>
    public static int Run(string program, string dir, int showFlag = 1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_Run64(program, dir, showFlag);
        }
        return AutoItX_DLLImport.AU3_Run32(program, dir, showFlag);
    }

    /// <summary>
    /// Runs an external program as a specified user.
    /// </summary>
    /// <param name="user">The username to log on with.</param>
    /// <param name="domain">The domain to authenticate against.</param>
    /// <param name="password">The password for the user.</param>
    /// <param name="logonFlag">Logon flag: 0 = Interactive logon with no profile, 1 = Interactive logon with profile, 2 = Network credentials only, 4 = Inherit calling process environment.</param>
    /// <param name="program">The program to run.</param>
    /// <param name="dir">The working directory to use.</param>
    /// <param name="showFlag">The "show" flag of the executed program: 0 = hidden window, 1 = normal window, 3 = maximized window.</param>
    /// <returns>The process ID (PID) of the launched program, 0 on failure.</returns>
    public static int RunAs(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_RunAs64(user, domain, password, logonFlag, program, dir, showFlag);
        }
        return AutoItX_DLLImport.AU3_RunAs32(user, domain, password, logonFlag, program, dir, showFlag);
    }

    /// <summary>
    /// Runs an external program as a specified user and wait for it to close.
    /// </summary>
    /// <param name="user">The username to log on with.</param>
    /// <param name="domain">The domain to authenticate against.</param>
    /// <param name="password">The password for the user.</param>
    /// <param name="logonFlag">Logon flag: 0 = Interactive logon with no profile, 1 = Interactive logon with profile, 2 = Network credentials only, 4 = Inherit calling process environment.</param>
    /// <param name="program">The program to run.</param>
    /// <param name="dir">The working directory to use.</param>
    /// <param name="showFlag">The "show" flag of the executed program: 0 = hidden window, 1 = normal window, 3 = maximized window.</param>
    /// <returns>The exit code of the program that was run.</returns>
    public static int RunAsWait(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_RunAsWait64(user, domain, password, logonFlag, program, dir, showFlag);
        }
        return AutoItX_DLLImport.AU3_RunAsWait32(user, domain, password, logonFlag, program, dir, showFlag);
    }

    /// <summary>
    /// Runs an external program and wait for it to close.
    /// </summary>
    /// <param name="program">The program to run.</param>
    /// <param name="dir">The working directory to use.</param>
    /// <param name="showFlag">The "show" flag of the executed program: 0 = hidden window, 1 = normal window, 3 = maximized window.</param>
    /// <returns>The exit code of the program that was run.</returns>
    public static int RunWait(string program, string dir, int showFlag = 1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_RunWait64(program, dir, showFlag);
        }
        return AutoItX_DLLImport.AU3_RunWait32(program, dir, showFlag);
    }

    /// <summary>
    /// Sends simulated keystrokes to the active window.
    /// </summary>
    /// <param name="sendText">The sequence of keys to send.</param>
    /// <param name="mode">Changes how keys are processed: 0 = text contains special characters like + and ! to indicate SHIFT and ALT (default), 1 = keys are sent raw.</param>
    public static void Send(string sendText, int mode = 0)
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_Send64(sendText, mode);
        }
        else
        {
            AutoItX_DLLImport.AU3_Send32(sendText, mode);
        }
    }

    /// <summary>
    /// Shut down the system.
    /// </summary>
    /// <param name="flag">A combination of shutdown codes: 0 = logoff, 1 = shutdown, 2 = reboot, 4 = force, 8 = power down, 16 = force if hung, 32 = standby, 64 = hibernate.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int Shutdown(int flag)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_Shutdown64(flag);
        }
        return AutoItX_DLLImport.AU3_Shutdown32(flag);
    }

    /// <summary>
    /// Pause for specified number of milliseconds.
    /// </summary>
    /// <param name="milliseconds">The number of milliseconds to pause execution.</param>
    public static void Sleep(int milliseconds)
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_Sleep64(milliseconds);
        }
        else
        {
            AutoItX_DLLImport.AU3_Sleep32(milliseconds);
        }
    }

    /// <summary>
    /// Retrieves the text from a standard status bar control.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="part">The "part" number of the status bar to read. Default is 1 (the first part).</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the status bar as a string.</returns>
    public static string StatusBarGetText(string title = "", string text = "", int part = 1, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_StatusbarGetText64(title, text, part, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_StatusbarGetText32(title, text, part, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the text from a standard status bar control.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="part">The "part" number of the status bar to read. Default is 1 (the first part).</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the status bar as a string.</returns>
    public static string StatusBarGetText(IntPtr winHandle, int part = 1, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_StatusbarGetTextByHandle64(winHandle, part, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_StatusbarGetTextByHandle32(winHandle, part, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Creates a tooltip anywhere on the screen.
    /// </summary>
    /// <param name="tip">The text of the tooltip. Use an empty string to clear a displayed tooltip.</param>
    /// <param name="x">The x position of the tooltip.</param>
    /// <param name="y">The y position of the tooltip.</param>
    public static void ToolTip(string tip, int x = -2147483647, int y = -2147483647)
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_ToolTip64(tip, x, y);
        }
        else
        {
            AutoItX_DLLImport.AU3_ToolTip32(tip, x, y);
        }
    }

    /// <summary>
    /// Activates (gives focus to) a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinActivate(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinActivate64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinActivate32(title, text);
    }

    /// <summary>
    /// Activates (gives focus to) a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinActivate(IntPtr winHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinActivateByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinActivateByHandle32(winHandle);
    }

    /// <summary>
    /// Checks to see if a specified window exists and is currently active.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>1 if the window is active, 0 otherwise.</returns>
    public static int WinActive(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinActive64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinActive32(title, text);
    }

    /// <summary>
    /// Checks to see if a specified window exists and is currently active.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>1 if the window is active, 0 otherwise.</returns>
    public static int WinActive(IntPtr winHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinActiveByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinActiveByHandle32(winHandle);
    }

    /// <summary>
    /// Checks to see if a specified window exists.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>1 if the window exists, 0 otherwise.</returns>
    public static int WinExists(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinExists64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinExists32(title, text);
    }

    /// <summary>
    /// Checks to see if a specified window exists.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>1 if the window exists, 0 otherwise.</returns>
    public static int WinExists(IntPtr winHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinExistsByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinExistsByHandle32(winHandle);
    }

    /// <summary>
    /// Closes a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinClose(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinClose64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinClose32(title, text);
    }

    /// <summary>
    /// Closes a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinClose(IntPtr winHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinCloseByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinCloseByHandle32(winHandle);
    }

    /// <summary>
    /// Returns the coordinates of the caret in the foreground window.
    /// </summary>
    /// <returns>A Point containing the coordinates of the caret in the foreground window.</returns>
    public static Point WinGetCaretPos()
    {
        AutoItX_DLLImport.POINT pt;
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetCaretPos64(out pt);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetCaretPos32(out pt);
        }
        return new Point(pt.x, pt.y);
    }

    /// <summary>
    /// Retrieves the classes from a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The class list from the window as a string.</returns>
    public static string WinGetClassList(string title = "", string text = "", int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetClassList64(title, text, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetClassList32(title, text, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the classes from a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The class list from the window as a string.</returns>
    public static string WinGetClassList(IntPtr winHandle, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetClassListByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetClassListByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the size of a given window's client area.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>A Rectangle containing the client area size of the window.</returns>
    public static Rectangle WinGetClientSize(string title = "", string text = "")
    {
        AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetClientSize64(title, text, ref rect);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetClientSize32(title, text, ref rect);
        }
        return new Rectangle
        {
            X = rect.left,
            Y = rect.top,
            Width = rect.right - rect.left,
            Height = rect.bottom - rect.top
        };
    }

    /// <summary>
    /// Retrieves the size of a given window's client area.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>A Rectangle containing the client area size of the window.</returns>
    public static Rectangle WinGetClientSize(IntPtr winHandle)
    {
        AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetClientSizeByHandle64(winHandle, ref rect);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetClientSizeByHandle32(winHandle, ref rect);
        }
        return new Rectangle
        {
            X = rect.left,
            Y = rect.top,
            Width = rect.right - rect.left,
            Height = rect.bottom - rect.top
        };
    }

    /// <summary>
    /// Retrieves the internal handle of a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>The window handle as an IntPtr.</returns>
    public static IntPtr WinGetHandle(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinGetHandle64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinGetHandle32(title, text);
    }

    /// <summary>
    /// Retrieves the internal handle of a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The window handle as a string.</returns>
    public static string WinGetHandleAsText(string title = "", string text = "", int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetHandleAsText64(title, text, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetHandleAsText32(title, text, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the position and size of a given window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>A Rectangle containing the position (x, y) and size (width, height) properties of the window.</returns>
    public static Rectangle WinGetPos(string title = "", string text = "")
    {
        AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetPos64(title, text, ref rect);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetPos32(title, text, ref rect);
        }
        return new Rectangle
        {
            X = rect.left,
            Y = rect.top,
            Width = rect.right - rect.left,
            Height = rect.bottom - rect.top
        };
    }

    /// <summary>
    /// Retrieves the position and size of a given window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>A Rectangle containing the position (x, y) and size (width, height) properties of the window.</returns>
    public static Rectangle WinGetPos(IntPtr winHandle)
    {
        AutoItX_DLLImport.RECT rect = default(AutoItX_DLLImport.RECT);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetPosByHandle64(winHandle, ref rect);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetPosByHandle32(winHandle, ref rect);
        }
        return new Rectangle
        {
            X = rect.left,
            Y = rect.top,
            Width = rect.right - rect.left,
            Height = rect.bottom - rect.top
        };
    }

    /// <summary>
    /// Retrieves the Process ID (PID) associated with a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>A UInt representing the process ID of the window.</returns>
    public static uint WinGetProcess(string title = "", string text = "", int maxLen = 65535)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinGetProcess64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinGetProcess32(title, text);
    }

    /// <summary>
    /// Retrieves the Process ID (PID) associated with a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>A UInt representing the process ID of the window.</returns>
    public static uint WinGetProcess(IntPtr winHandle, int maxLen = 65535)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinGetProcessByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinGetProcessByHandle32(winHandle);
    }

    /// <summary>
    /// Retrieves the state of a given window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>The window state as an integer flag.</returns>
    public static int WinGetState(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinGetState64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinGetState32(title, text);
    }

    /// <summary>
    /// Retrieves the state of a given window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>The window state as an integer flag.</returns>
    public static int WinGetState(IntPtr winHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinGetStateByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinGetStateByHandle32(winHandle);
    }

    /// <summary>
    /// Retrieves the text from a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the window as a string.</returns>
    public static string WinGetText(string title = "", string text = "", int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetText64(title, text, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetText32(title, text, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the text from a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The text from the window as a string.</returns>
    public static string WinGetText(IntPtr winHandle, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetTextByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetTextByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the full title from a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The title of the window as a string.</returns>
    public static string WinGetTitle(string title = "", string text = "", int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetTitle64(title, text, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetTitle32(title, text, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Retrieves the full title from a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="maxLen">The maximum number of characters to return.</param>
    /// <returns>The title of the window as a string.</returns>
    public static string WinGetTitle(IntPtr winHandle, int maxLen = 65535)
    {
        StringBuilder stringBuilder = new StringBuilder(maxLen);
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinGetTitleByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        else
        {
            AutoItX_DLLImport.AU3_WinGetTitleByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Forces a window to close.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinKill(string title = "", string text = "")
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinKill64(title, text);
        }
        return AutoItX_DLLImport.AU3_WinKill32(title, text);
    }

    /// <summary>
    /// Forces a window to close.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinKill(IntPtr winHandle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinKillByHandle64(winHandle);
        }
        return AutoItX_DLLImport.AU3_WinKillByHandle32(winHandle);
    }

    /// <summary>
    /// Minimizes all windows.
    /// </summary>
    public static void WinMinimizeAll()
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinMinimizeAll64();
        }
        else
        {
            AutoItX_DLLImport.AU3_WinMinimizeAll32();
        }
    }

    /// <summary>
    /// Undoes a previous WinMinimizeAll function.
    /// </summary>
    public static void WinMinimizeAllUndo()
    {
        if (Is64Bit())
        {
            AutoItX_DLLImport.AU3_WinMinimizeAllUndo64();
        }
        else
        {
            AutoItX_DLLImport.AU3_WinMinimizeAllUndo32();
        }
    }

    /// <summary>
    /// Moves and/or resizes a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="x">The new x position of the window.</param>
    /// <param name="y">The new y position of the window.</param>
    /// <param name="width">The new width of the window.</param>
    /// <param name="height">The new height of the window.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinMove(string title, string text, int x, int y, int width = -1, int height = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinMove64(title, text, x, y, width, height);
        }
        return AutoItX_DLLImport.AU3_WinMove32(title, text, x, y, width, height);
    }

    /// <summary>
    /// Moves and/or resizes a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="x">The new x position of the window.</param>
    /// <param name="y">The new y position of the window.</param>
    /// <param name="width">The new width of the window.</param>
    /// <param name="height">The new height of the window.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinMove(IntPtr winHandle, int x, int y, int width = -1, int height = -1)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinMoveByHandle64(winHandle, x, y, width, height);
        }
        return AutoItX_DLLImport.AU3_WinMoveByHandle32(winHandle, x, y, width, height);
    }

    /// <summary>
    /// Change a window's "Always On Top" attribute.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="flag">Determines whether the window should be topmost: 1 = set on top, 0 = remove on top.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetOnTop(string title, string text, int flag)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetOnTop64(title, text, flag);
        }
        return AutoItX_DLLImport.AU3_WinSetOnTop32(title, text, flag);
    }

    /// <summary>
    /// Change a window's "Always On Top" attribute.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="flag">Determines whether the window should be topmost: 1 = set on top, 0 = remove on top.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetOnTop(IntPtr winHandle, int flag)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetOnTopByHandle64(winHandle, flag);
        }
        return AutoItX_DLLImport.AU3_WinSetOnTopByHandle32(winHandle, flag);
    }

    /// <summary>
    /// Shows, hides, minimizes, maximizes, or restores a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="flags">The state to set the window to: 0 = hide, 1 = show, 2 = minimize, 3 = maximize, 4 = restore.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetState(string title, string text, int flags)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetState64(title, text, flags);
        }
        return AutoItX_DLLImport.AU3_WinSetState32(title, text, flags);
    }

    /// <summary>
    /// Shows, hides, minimizes, maximizes, or restores a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="flags">The state to set the window to: 0 = hide, 1 = show, 2 = minimize, 3 = maximize, 4 = restore.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetState(IntPtr winHandle, int flags)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetStateByHandle64(winHandle, flags);
        }
        return AutoItX_DLLImport.AU3_WinSetStateByHandle32(winHandle, flags);
    }

    /// <summary>
    /// Changes the title of a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="newTitle">The new title to give to the window.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetTitle(string title, string text, string newTitle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetTitle64(title, text, newTitle);
        }
        return AutoItX_DLLImport.AU3_WinSetTitle32(title, text, newTitle);
    }

    /// <summary>
    /// Changes the title of a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="newTitle">The new title to give to the window.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetTitle(IntPtr winHandle, string newTitle)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetTitleByHandle64(winHandle, newTitle);
        }
        return AutoItX_DLLImport.AU3_WinSetTitleByHandle32(winHandle, newTitle);
    }

    /// <summary>
    /// Sets the transparency of a window.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="trans">The transparency level (0-255). 0 = invisible, 255 = opaque.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetTrans(string title, string text, int trans)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetTrans64(title, text, trans);
        }
        return AutoItX_DLLImport.AU3_WinSetTrans32(title, text, trans);
    }

    /// <summary>
    /// Sets the transparency of a window.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="trans">The transparency level (0-255). 0 = invisible, 255 = opaque.</param>
    /// <returns>1 on success, 0 on failure.</returns>
    public static int WinSetTrans(IntPtr winHandle, int trans)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinSetTransByHandle64(winHandle, trans);
        }
        return AutoItX_DLLImport.AU3_WinSetTransByHandle32(winHandle, trans);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window exists.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWait(string title = "", string text = "", int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWait64(title, text, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWait32(title, text, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window exists.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWait(IntPtr winHandle, int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitByHandle64(winHandle, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitByHandle32(winHandle, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window is active.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWaitActive(string title = "", string text = "", int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitActive64(title, text, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitActive32(title, text, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window is active.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWaitActive(IntPtr winHandle, int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitActiveByHandle64(winHandle, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitActiveByHandle32(winHandle, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window does not exist.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWaitClose(string title = "", string text = "", int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitClose64(title, text, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitClose32(title, text, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window does not exist.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWaitClose(IntPtr winHandle, int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitCloseByHandle64(winHandle, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitCloseByHandle32(winHandle, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window is not active.
    /// </summary>
    /// <param name="title">The window title to search for.</param>
    /// <param name="text">The window text to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWaitNotActive(string title = "", string text = "", int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitNotActive64(title, text, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitNotActive32(title, text, timeout);
    }

    /// <summary>
    /// Pauses execution of the script until the requested window is not active.
    /// </summary>
    /// <param name="winHandle">The window handle to search for.</param>
    /// <param name="timeout">Timeout in seconds. Default is to wait indefinitely.</param>
    /// <returns>1 on success, 0 on timeout.</returns>
    public static int WinWaitNotActive(IntPtr winHandle, int timeout = 0)
    {
        if (Is64Bit())
        {
            return AutoItX_DLLImport.AU3_WinWaitNotActiveByHandle64(winHandle, timeout);
        }
        return AutoItX_DLLImport.AU3_WinWaitNotActiveByHandle32(winHandle, timeout);
    }

    private static bool Is64Bit()
    {
        if (Marshal.SizeOf((object)(nint)IntPtr.Zero) == 4)
        {
            return false;
        }
        return true;
    }
}
