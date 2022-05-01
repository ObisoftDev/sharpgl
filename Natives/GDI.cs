using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpGL.Natives
{

    internal static class GDI
    {
        private const string Gdi = "gdi32.dll";

        public const int DoubleClicks = 0x8;
        public const int VRedraw = 0x1;
        public const int HRedraw = 0x2;
        public const int OwnDC = 0x20;

        public const int WheelDelta = 120;

        public const int WomDone = 0x3BD;

        public const int MonitorDefaultNearest = 2;

        public static readonly IntPtr WindowTop = new IntPtr(0);

        public static readonly IntPtr TimerOne = new IntPtr(1001);

        public const int ApplicationIcon = 32512;
        public const int ArrowCursor = 32512;
        public const int ColorWindow = 5;

        public const int WaveFormatPcm = 1;
        public const int WaveMapper = -1;
        public const int WHdrPrepared = 2;

        public const int CallbackFunction = 0x30000;


        [DllImport(Gdi, SetLastError = true)]
        public static extern int ChoosePixelFormat(IntPtr hDC, [In] ref PixelFormatDesc ppfd);

        [DllImport(Gdi, SetLastError = true)]
        public static extern int SetPixelFormat(IntPtr hDC, int iPixelFormat, [In] ref PixelFormatDesc ppfd);

        [DllImport(Gdi, SetLastError = true)]
        public static extern bool SwapBuffers(IntPtr hDC);
    }
}
