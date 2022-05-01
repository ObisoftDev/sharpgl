using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace SharpGL.Natives
{
    public static class USER32
    {
        private const string User = "user32.dll";

        [DllImport(User)]
        public static extern void PostQuitMessage(int exitCode);

        [DllImport(User)]
        public static extern IntPtr SetTimer(IntPtr handle, IntPtr timerID, uint interval, IntPtr callback);

        [DllImport(User)]
        public static extern bool KillTimer(IntPtr handle, IntPtr timerID);

        [DllImport(User)]
        public static extern bool ScreenToClient(IntPtr handle, ref Point p);

        [DllImport(User)]
        public static extern bool GetCursorPos(ref Point p);

        [DllImport(User)]
        public static extern short GetKeyState(int vk);

        [DllImport(User, SetLastError = true, CharSet = CharSet.Auto), SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetWindowText(IntPtr hwnd, string text);

        [DllImport(User, SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport(User, SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport(User, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(uint dwExStyle, [MarshalAs(UnmanagedType.LPStr)] string lpClassName, [MarshalAs(UnmanagedType.LPStr)] string lpWindowName,
            uint dwStyle, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport(User, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hwnd, int cmd);

        [DllImport(User, SetLastError = true)]
        public static extern bool PeekMessage(ref Message msg, IntPtr hwnd, uint MsgfilterMin, uint MsgfilterMax, uint MsgRemove);

        [DllImport(User)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

        [DllImport(User)]
        public static extern IntPtr LoadCursorA(IntPtr handle, IntPtr cursor);

        [DllImport(User, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport(User, SetLastError = true)]
        public static extern int RegisterClassEx(ref WindowClassEx wcex);

        [DllImport(User)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool AdjustWindowRectEx(ref Rect lpRect, uint dwStyle, bool bMenu, uint dwExStyle);

        [DllImport(User, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(User)]
        public static extern int GetMessage(out Message msg, IntPtr hwnd, uint maxFilter, uint minFilter);

        [DllImport(User)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool TranslateMessage(ref Message msg);

        [DllImport(User)]
        public static extern IntPtr DispatchMessage(ref Message lpmsg);

        [DllImport(User)]
        public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport(User, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfo lpmi);

        [DllImport(User)]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport(User, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport(User)]
        public static extern IntPtr DefWindowProc(IntPtr handle, uint msg, int min, int max);

        [DllImport(User, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport(User, SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    }

}