using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AutoItX3.Assembly.AutoIt;

/// <summary>
/// The AutoItX DLL wrapper class for the native AutoItX3.dll.
/// </summary>
internal static class AutoItX_DLLImport
{
    internal struct RECT
    {
        public int left;

        public int top;

        public int right;

        public int bottom;
    }

    internal struct POINT
    {
        public int x;

        public int y;
    }

    private const string AUTOITXDLL_x86 = "AutoItX3.dll";

    private const string AUTOITXDLL_x64 = "AutoItX3_x64.dll";

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Init", SetLastError = true)]
    internal static extern void AU3_Init32();

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Init", SetLastError = true)]
    internal static extern void AU3_Init64();

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_error", SetLastError = true)]
    internal static extern int AU3_error32();

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_error", SetLastError = true)]
    internal static extern int AU3_error64();

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_AutoItSetOption", SetLastError = true)]
    internal static extern int AU3_AutoItSetOption32([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_AutoItSetOption", SetLastError = true)]
    internal static extern int AU3_AutoItSetOption64([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ClipGet", SetLastError = true)]
    internal static extern void AU3_ClipGet32([MarshalAs(UnmanagedType.LPWStr)] StringBuilder clip, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ClipGet", SetLastError = true)]
    internal static extern void AU3_ClipGet64([MarshalAs(UnmanagedType.LPWStr)] StringBuilder clip, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ClipPut", SetLastError = true)]
    internal static extern void AU3_ClipPut32([MarshalAs(UnmanagedType.LPWStr)] string clip);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ClipPut", SetLastError = true)]
    internal static extern void AU3_ClipPut64([MarshalAs(UnmanagedType.LPWStr)] string clip);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClick", SetLastError = true)]
    internal static extern int AU3_ControlClick32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClick", SetLastError = true)]
    internal static extern int AU3_ControlClick64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClickByHandle", SetLastError = true)]
    internal static extern int AU3_ControlClickByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlClickByHandle", SetLastError = true)]
    internal static extern int AU3_ControlClickByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string button, int numClicks, int x, int y);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommand", SetLastError = true)]
    internal static extern void AU3_ControlCommand32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommand", SetLastError = true)]
    internal static extern void AU3_ControlCommand64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommandByHandle", SetLastError = true)]
    internal static extern void AU3_ControlCommandByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlCommandByHandle", SetLastError = true)]
    internal static extern void AU3_ControlCommandByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListView", SetLastError = true)]
    internal static extern void AU3_ControlListView32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListView", SetLastError = true)]
    internal static extern void AU3_ControlListView64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListViewByHandle", SetLastError = true)]
    internal static extern void AU3_ControlListViewByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlListViewByHandle", SetLastError = true)]
    internal static extern void AU3_ControlListViewByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisable", SetLastError = true)]
    internal static extern int AU3_ControlDisable32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisable", SetLastError = true)]
    internal static extern int AU3_ControlDisable64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisableByHandle", SetLastError = true)]
    internal static extern int AU3_ControlDisableByHandle32(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlDisableByHandle", SetLastError = true)]
    internal static extern int AU3_ControlDisableByHandle64(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnable", SetLastError = true)]
    internal static extern int AU3_ControlEnable32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnable", SetLastError = true)]
    internal static extern int AU3_ControlEnable64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnableByHandle", SetLastError = true)]
    internal static extern int AU3_ControlEnableByHandle32(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlEnableByHandle", SetLastError = true)]
    internal static extern int AU3_ControlEnableByHandle64(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocus", SetLastError = true)]
    internal static extern int AU3_ControlFocus32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocus", SetLastError = true)]
    internal static extern int AU3_ControlFocus64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocusByHandle", SetLastError = true)]
    internal static extern int AU3_ControlFocusByHandle32(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlFocusByHandle", SetLastError = true)]
    internal static extern int AU3_ControlFocusByHandle64(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocus", SetLastError = true)]
    internal static extern void AU3_ControlGetFocus32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocus", SetLastError = true)]
    internal static extern void AU3_ControlGetFocus64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocusByHandle", SetLastError = true)]
    internal static extern void AU3_ControlGetFocusByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetFocusByHandle", SetLastError = true)]
    internal static extern void AU3_ControlGetFocusByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlWithFocus, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandle", SetLastError = true)]
    internal static extern IntPtr AU3_ControlGetHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandle", SetLastError = true)]
    internal static extern IntPtr AU3_ControlGetHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandleAsText", SetLastError = true)]
    internal static extern void AU3_ControlGetHandleAsText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetHandleAsText", SetLastError = true)]
    internal static extern void AU3_ControlGetHandleAsText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPos", SetLastError = true)]
    internal static extern int AU3_ControlGetPos32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, ref RECT rect);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPos", SetLastError = true)]
    internal static extern int AU3_ControlGetPos64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, ref RECT rect);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPosByHandle", SetLastError = true)]
    internal static extern int AU3_ControlGetPosByHandle32(IntPtr winHandle, IntPtr controlHandle, ref RECT rect);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetPosByHandle", SetLastError = true)]
    internal static extern int AU3_ControlGetPosByHandle64(IntPtr winHandle, IntPtr controlHandle, ref RECT rect);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetText", SetLastError = true)]
    internal static extern void AU3_ControlGetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetText", SetLastError = true)]
    internal static extern void AU3_ControlGetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetTextByHandle", SetLastError = true)]
    internal static extern void AU3_ControlGetTextByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlGetTextByHandle", SetLastError = true)]
    internal static extern void AU3_ControlGetTextByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder controlText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHide", SetLastError = true)]
    internal static extern int AU3_ControlHide32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHide", SetLastError = true)]
    internal static extern int AU3_ControlHide64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHideByHandle", SetLastError = true)]
    internal static extern int AU3_ControlHideByHandle32(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlHideByHandle", SetLastError = true)]
    internal static extern int AU3_ControlHideByHandle64(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMove", SetLastError = true)]
    internal static extern int AU3_ControlMove32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, int x, int y, int width, int height);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMove", SetLastError = true)]
    internal static extern int AU3_ControlMove64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, int x, int y, int width, int height);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMoveByHandle", SetLastError = true)]
    internal static extern int AU3_ControlMoveByHandle32(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width, int height);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlMoveByHandle", SetLastError = true)]
    internal static extern int AU3_ControlMoveByHandle64(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width, int height);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSend", SetLastError = true)]
    internal static extern int AU3_ControlSend32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSend", SetLastError = true)]
    internal static extern int AU3_ControlSend64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSendByHandle", SetLastError = true)]
    internal static extern int AU3_ControlSendByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSendByHandle", SetLastError = true)]
    internal static extern int AU3_ControlSendByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetText", SetLastError = true)]
    internal static extern int AU3_ControlSetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetText", SetLastError = true)]
    internal static extern int AU3_ControlSetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetTextByHandle", SetLastError = true)]
    internal static extern int AU3_ControlSetTextByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlSetTextByHandle", SetLastError = true)]
    internal static extern int AU3_ControlSetTextByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string controlText);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShow", SetLastError = true)]
    internal static extern int AU3_ControlShow32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShow", SetLastError = true)]
    internal static extern int AU3_ControlShow64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShowByHandle", SetLastError = true)]
    internal static extern int AU3_ControlShowByHandle32(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlShowByHandle", SetLastError = true)]
    internal static extern int AU3_ControlShowByHandle64(IntPtr winHandle, IntPtr controlHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeView", SetLastError = true)]
    internal static extern void AU3_ControlTreeView32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeView", SetLastError = true)]
    internal static extern void AU3_ControlTreeView64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string control, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeViewByHandle", SetLastError = true)]
    internal static extern void AU3_ControlTreeViewByHandle32(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ControlTreeViewByHandle", SetLastError = true)]
    internal static extern void AU3_ControlTreeViewByHandle64(IntPtr winHandle, IntPtr controlHandle, [MarshalAs(UnmanagedType.LPWStr)] string command, [MarshalAs(UnmanagedType.LPWStr)] string extra1, [MarshalAs(UnmanagedType.LPWStr)] string extra2, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapAdd", SetLastError = true)]
    internal static extern void AU3_DriveMapAdd32([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] string share, int flags, [MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string pwd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapAdd", SetLastError = true)]
    internal static extern void AU3_DriveMapAdd64([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] string share, int flags, [MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string pwd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder result, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapDel", SetLastError = true)]
    internal static extern int AU3_DriveMapDel32([MarshalAs(UnmanagedType.LPWStr)] string device);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapDel", SetLastError = true)]
    internal static extern int AU3_DriveMapDel64([MarshalAs(UnmanagedType.LPWStr)] string device);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapGet", SetLastError = true)]
    internal static extern void AU3_DriveMapGet32([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder mapping, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_DriveMapGet", SetLastError = true)]
    internal static extern void AU3_DriveMapGet64([MarshalAs(UnmanagedType.LPWStr)] string device, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder mapping, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_IsAdmin", SetLastError = true)]
    internal static extern int AU3_IsAdmin32();

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_IsAdmin", SetLastError = true)]
    internal static extern int AU3_IsAdmin64();

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClick", SetLastError = true)]
    internal static extern int AU3_MouseClick32([MarshalAs(UnmanagedType.LPWStr)] string button, int x, int y, int clicks, int speed);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClick", SetLastError = true)]
    internal static extern int AU3_MouseClick64([MarshalAs(UnmanagedType.LPWStr)] string button, int x, int y, int clicks, int speed);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClickDrag", SetLastError = true)]
    internal static extern int AU3_MouseClickDrag32([MarshalAs(UnmanagedType.LPWStr)] string button, int x1, int y1, int x2, int y2, int speed);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseClickDrag", SetLastError = true)]
    internal static extern int AU3_MouseClickDrag64([MarshalAs(UnmanagedType.LPWStr)] string button, int x1, int y1, int x2, int y2, int speed);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseDown", SetLastError = true)]
    internal static extern void AU3_MouseDown32([MarshalAs(UnmanagedType.LPWStr)] string button);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseDown", SetLastError = true)]
    internal static extern void AU3_MouseDown64([MarshalAs(UnmanagedType.LPWStr)] string button);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetCursor", SetLastError = true)]
    internal static extern int AU3_MouseGetCursor32();

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetCursor", SetLastError = true)]
    internal static extern int AU3_MouseGetCursor64();

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetPos", SetLastError = true)]
    internal static extern void AU3_MouseGetPos32(ref POINT pt);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseGetPos", SetLastError = true)]
    internal static extern void AU3_MouseGetPos64(ref POINT pt);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseMove", SetLastError = true)]
    internal static extern int AU3_MouseMove32(int x, int y, int speed);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseMove", SetLastError = true)]
    internal static extern int AU3_MouseMove64(int x, int y, int speed);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseUp", SetLastError = true)]
    internal static extern void AU3_MouseUp32([MarshalAs(UnmanagedType.LPWStr)] string button);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseUp", SetLastError = true)]
    internal static extern void AU3_MouseUp64([MarshalAs(UnmanagedType.LPWStr)] string button);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseWheel", SetLastError = true)]
    internal static extern void AU3_MouseWheel32([MarshalAs(UnmanagedType.LPWStr)] string direction, int clicks);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_MouseWheel", SetLastError = true)]
    internal static extern void AU3_MouseWheel64([MarshalAs(UnmanagedType.LPWStr)] string direction, int clicks);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Opt", SetLastError = true)]
    internal static extern int AU3_Opt32([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Opt", SetLastError = true)]
    internal static extern int AU3_Opt64([MarshalAs(UnmanagedType.LPWStr)] string option, int val);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_PixelChecksum", SetLastError = true)]
    internal static extern uint AU3_PixelChecksum32(ref RECT rect, int step);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_PixelChecksum", SetLastError = true)]
    internal static extern uint AU3_PixelChecksum64(ref RECT rect, int step);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_PixelGetColor", SetLastError = true)]
    internal static extern int AU3_PixelGetColor32(int x, int y);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_PixelGetColor", SetLastError = true)]
    internal static extern int AU3_PixelGetColor64(int x, int y);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_PixelSearch", SetLastError = true)]
    internal static extern void AU3_PixelSearch32(ref RECT rect, int color, int shade, int step, ref POINT winPoint);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_PixelSearch", SetLastError = true)]
    internal static extern void AU3_PixelSearch64(ref RECT rect, int color, int shade, int step, ref POINT winPoint);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessClose", SetLastError = true)]
    internal static extern int AU3_ProcessClose32([MarshalAs(UnmanagedType.LPWStr)] string process);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessClose", SetLastError = true)]
    internal static extern int AU3_ProcessClose64([MarshalAs(UnmanagedType.LPWStr)] string process);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessExists", SetLastError = true)]
    internal static extern int AU3_ProcessExists32([MarshalAs(UnmanagedType.LPWStr)] string process);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessExists", SetLastError = true)]
    internal static extern int AU3_ProcessExists64([MarshalAs(UnmanagedType.LPWStr)] string process);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessSetPriority", SetLastError = true)]
    internal static extern int AU3_ProcessSetPriority32([MarshalAs(UnmanagedType.LPWStr)] string process, int priority);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessSetPriority", SetLastError = true)]
    internal static extern int AU3_ProcessSetPriority64([MarshalAs(UnmanagedType.LPWStr)] string process, int priority);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWait", SetLastError = true)]
    internal static extern int AU3_ProcessWait32([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWait", SetLastError = true)]
    internal static extern int AU3_ProcessWait64([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWaitClose", SetLastError = true)]
    internal static extern int AU3_ProcessWaitClose32([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ProcessWaitClose", SetLastError = true)]
    internal static extern int AU3_ProcessWaitClose64([MarshalAs(UnmanagedType.LPWStr)] string process, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Run", SetLastError = true)]
    internal static extern int AU3_Run32([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Run", SetLastError = true)]
    internal static extern int AU3_Run64([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_RunAs", SetLastError = true)]
    internal static extern int AU3_RunAs32([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_RunAs", SetLastError = true)]
    internal static extern int AU3_RunAs64([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_RunAsWait", SetLastError = true)]
    internal static extern int AU3_RunAsWait32([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_RunAsWait", SetLastError = true)]
    internal static extern int AU3_RunAsWait64([MarshalAs(UnmanagedType.LPWStr)] string user, [MarshalAs(UnmanagedType.LPWStr)] string domain, [MarshalAs(UnmanagedType.LPWStr)] string password, int logonFlag, [MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_RunWait", SetLastError = true)]
    internal static extern int AU3_RunWait32([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_RunWait", SetLastError = true)]
    internal static extern int AU3_RunWait64([MarshalAs(UnmanagedType.LPWStr)] string program, [MarshalAs(UnmanagedType.LPWStr)] string dir, int showFlag);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Send", SetLastError = true)]
    internal static extern void AU3_Send32([MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Send", SetLastError = true)]
    internal static extern void AU3_Send64([MarshalAs(UnmanagedType.LPWStr)] string sendText, int mode);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Shutdown", SetLastError = true)]
    internal static extern int AU3_Shutdown32(int flags);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Shutdown", SetLastError = true)]
    internal static extern int AU3_Shutdown64(int flags);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Sleep", SetLastError = true)]
    internal static extern void AU3_Sleep32(int milliseconds);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_Sleep", SetLastError = true)]
    internal static extern void AU3_Sleep64(int milliseconds);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetText", SetLastError = true)]
    internal static extern void AU3_StatusbarGetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetText", SetLastError = true)]
    internal static extern void AU3_StatusbarGetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetTextByHandle", SetLastError = true)]
    internal static extern void AU3_StatusbarGetTextByHandle32(IntPtr winHandle, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_StatusbarGetTextByHandle", SetLastError = true)]
    internal static extern void AU3_StatusbarGetTextByHandle64(IntPtr winHandle, int part, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder statusText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ToolTip", SetLastError = true)]
    internal static extern void AU3_ToolTip32([MarshalAs(UnmanagedType.LPWStr)] string tip, int x, int y);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_ToolTip", SetLastError = true)]
    internal static extern void AU3_ToolTip64([MarshalAs(UnmanagedType.LPWStr)] string tip, int x, int y);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivate", SetLastError = true)]
    internal static extern int AU3_WinActivate32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivate", SetLastError = true)]
    internal static extern int AU3_WinActivate64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivateByHandle", SetLastError = true)]
    internal static extern int AU3_WinActivateByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActivateByHandle", SetLastError = true)]
    internal static extern int AU3_WinActivateByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActive", SetLastError = true)]
    internal static extern int AU3_WinActive32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActive", SetLastError = true)]
    internal static extern int AU3_WinActive64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActiveByHandle", SetLastError = true)]
    internal static extern int AU3_WinActiveByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinActiveByHandle", SetLastError = true)]
    internal static extern int AU3_WinActiveByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinClose", SetLastError = true)]
    internal static extern int AU3_WinClose32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinClose", SetLastError = true)]
    internal static extern int AU3_WinClose64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinCloseByHandle", SetLastError = true)]
    internal static extern int AU3_WinCloseByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinCloseByHandle", SetLastError = true)]
    internal static extern int AU3_WinCloseByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinExists", SetLastError = true)]
    internal static extern int AU3_WinExists32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinExists", SetLastError = true)]
    internal static extern int AU3_WinExists64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinExistsByHandle", SetLastError = true)]
    internal static extern int AU3_WinExistsByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinExistsByHandle", SetLastError = true)]
    internal static extern int AU3_WinExistsByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetCaretPos", SetLastError = true)]
    internal static extern int AU3_WinGetCaretPos32(out POINT pt);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetCaretPos", SetLastError = true)]
    internal static extern int AU3_WinGetCaretPos64(out POINT pt);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassList", SetLastError = true)]
    internal static extern void AU3_WinGetClassList32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassList", SetLastError = true)]
    internal static extern void AU3_WinGetClassList64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassListByHandle", SetLastError = true)]
    internal static extern void AU3_WinGetClassListByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClassListByHandle", SetLastError = true)]
    internal static extern void AU3_WinGetClassListByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSize", SetLastError = true)]
    internal static extern int AU3_WinGetClientSize32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref RECT rect);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSize", SetLastError = true)]
    internal static extern int AU3_WinGetClientSize64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref RECT rect);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSizeByHandle", SetLastError = true)]
    internal static extern int AU3_WinGetClientSizeByHandle32(IntPtr winHandle, ref RECT rect);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetClientSizeByHandle", SetLastError = true)]
    internal static extern int AU3_WinGetClientSizeByHandle64(IntPtr winHandle, ref RECT rect);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandle", SetLastError = true)]
    internal static extern IntPtr AU3_WinGetHandle32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandle", SetLastError = true)]
    internal static extern IntPtr AU3_WinGetHandle64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandleAsText", SetLastError = true)]
    internal static extern void AU3_WinGetHandleAsText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetHandleAsText", SetLastError = true)]
    internal static extern void AU3_WinGetHandleAsText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPos", SetLastError = true)]
    internal static extern int AU3_WinGetPos32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref RECT rect);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPos", SetLastError = true)]
    internal static extern int AU3_WinGetPos64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, ref RECT rect);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPosByHandle", SetLastError = true)]
    internal static extern int AU3_WinGetPosByHandle32(IntPtr winHandle, ref RECT rect);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetPosByHandle", SetLastError = true)]
    internal static extern int AU3_WinGetPosByHandle64(IntPtr winHandle, ref RECT rect);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcess", SetLastError = true)]
    internal static extern uint AU3_WinGetProcess32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcess", SetLastError = true)]
    internal static extern uint AU3_WinGetProcess64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcessByHandle", SetLastError = true)]
    internal static extern uint AU3_WinGetProcessByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetProcessByHandle", SetLastError = true)]
    internal static extern uint AU3_WinGetProcessByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetState", SetLastError = true)]
    internal static extern int AU3_WinGetState32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetState", SetLastError = true)]
    internal static extern int AU3_WinGetState64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetStateByHandle", SetLastError = true)]
    internal static extern int AU3_WinGetStateByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetStateByHandle", SetLastError = true)]
    internal static extern int AU3_WinGetStateByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetText", SetLastError = true)]
    internal static extern void AU3_WinGetText32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetText", SetLastError = true)]
    internal static extern void AU3_WinGetText64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTextByHandle", SetLastError = true)]
    internal static extern void AU3_WinGetTextByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTextByHandle", SetLastError = true)]
    internal static extern void AU3_WinGetTextByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitle", SetLastError = true)]
    internal static extern void AU3_WinGetTitle32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitle", SetLastError = true)]
    internal static extern void AU3_WinGetTitle64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitleByHandle", SetLastError = true)]
    internal static extern void AU3_WinGetTitleByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinGetTitleByHandle", SetLastError = true)]
    internal static extern void AU3_WinGetTitleByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder retText, int bufSize);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinKill", SetLastError = true)]
    internal static extern int AU3_WinKill32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinKill", SetLastError = true)]
    internal static extern int AU3_WinKill64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinKillByHandle", SetLastError = true)]
    internal static extern int AU3_WinKillByHandle32(IntPtr winHandle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinKillByHandle", SetLastError = true)]
    internal static extern int AU3_WinKillByHandle64(IntPtr winHandle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMenuSelectItem", SetLastError = true)]
    internal static extern int AU3_WinMenuSelectItem32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string item1, [MarshalAs(UnmanagedType.LPWStr)] string item2, [MarshalAs(UnmanagedType.LPWStr)] string item3, [MarshalAs(UnmanagedType.LPWStr)] string item4, [MarshalAs(UnmanagedType.LPWStr)] string item5, [MarshalAs(UnmanagedType.LPWStr)] string item6, [MarshalAs(UnmanagedType.LPWStr)] string item7, [MarshalAs(UnmanagedType.LPWStr)] string item8);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAll", SetLastError = true)]
    internal static extern void AU3_WinMinimizeAll32();

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAll", SetLastError = true)]
    internal static extern void AU3_WinMinimizeAll64();

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAllUndo", SetLastError = true)]
    internal static extern void AU3_WinMinimizeAllUndo32();

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMinimizeAllUndo", SetLastError = true)]
    internal static extern void AU3_WinMinimizeAllUndo64();

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMove", SetLastError = true)]
    internal static extern int AU3_WinMove32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int x, int y, int width, int height);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMove", SetLastError = true)]
    internal static extern int AU3_WinMove64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int x, int y, int width, int height);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMoveByHandle", SetLastError = true)]
    internal static extern int AU3_WinMoveByHandle32(IntPtr winHandle, int x, int y, int width, int height);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinMoveByHandle", SetLastError = true)]
    internal static extern int AU3_WinMoveByHandle64(IntPtr winHandle, int x, int y, int width, int height);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTop", SetLastError = true)]
    internal static extern int AU3_WinSetOnTop32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flag);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTop", SetLastError = true)]
    internal static extern int AU3_WinSetOnTop64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flag);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTopByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetOnTopByHandle32(IntPtr winHandle, int flag);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetOnTopByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetOnTopByHandle64(IntPtr winHandle, int flag);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetState", SetLastError = true)]
    internal static extern int AU3_WinSetState32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flags);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetState", SetLastError = true)]
    internal static extern int AU3_WinSetState64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int flags);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetStateByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetStateByHandle32(IntPtr winHandle, int flags);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetStateByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetStateByHandle64(IntPtr winHandle, int flags);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitle", SetLastError = true)]
    internal static extern int AU3_WinSetTitle32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitle", SetLastError = true)]
    internal static extern int AU3_WinSetTitle64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitleByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetTitleByHandle32(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTitleByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetTitleByHandle64(IntPtr winHandle, [MarshalAs(UnmanagedType.LPWStr)] string newTitle);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTrans", SetLastError = true)]
    internal static extern int AU3_WinSetTrans32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int trans);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTrans", SetLastError = true)]
    internal static extern int AU3_WinSetTrans64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int trans);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTransByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetTransByHandle32(IntPtr winHandle, int trans);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinSetTransByHandle", SetLastError = true)]
    internal static extern int AU3_WinSetTransByHandle64(IntPtr winHandle, int trans);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWait", SetLastError = true)]
    internal static extern int AU3_WinWait32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWait", SetLastError = true)]
    internal static extern int AU3_WinWait64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitByHandle32(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitByHandle64(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActive", SetLastError = true)]
    internal static extern int AU3_WinWaitActive32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActive", SetLastError = true)]
    internal static extern int AU3_WinWaitActive64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActiveByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitActiveByHandle32(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitActiveByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitActiveByHandle64(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitClose", SetLastError = true)]
    internal static extern int AU3_WinWaitClose32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitClose", SetLastError = true)]
    internal static extern int AU3_WinWaitClose64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitCloseByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitCloseByHandle32(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitCloseByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitCloseByHandle64(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActive", SetLastError = true)]
    internal static extern int AU3_WinWaitNotActive32([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActive", SetLastError = true)]
    internal static extern int AU3_WinWaitNotActive64([MarshalAs(UnmanagedType.LPWStr)] string title, [MarshalAs(UnmanagedType.LPWStr)] string text, int timeout);

    [DllImport("AutoItX3.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActiveByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitNotActiveByHandle32(IntPtr winHandle, int timeout);

    [DllImport("AutoItX3_x64.dll", CharSet = CharSet.Auto, EntryPoint = "AU3_WinWaitNotActiveByHandle", SetLastError = true)]
    internal static extern int AU3_WinWaitNotActiveByHandle64(IntPtr winHandle, int timeout);
}
