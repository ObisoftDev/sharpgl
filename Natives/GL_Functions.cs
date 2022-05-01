using SharpGL.Natives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Graphics
{
    public static partial class GL
    {
        public const uint GL_TRUE = 1;
        public const uint GL_FALSE = 0;
        public static GLCreateResult Create(IntPtr handle)
        {
            GLCreateResult result = new GLCreateResult();
            result.HWND = handle;
            result.IsCreated = false;
            IntPtr HDC = USER32.GetDC(handle);
            result.HDC = HDC;
            PixelFormatDesc pFD = new PixelFormatDesc(1,
                   (uint)PFD.DrawToWindow | (uint)PFD.SupportOpenGL | (uint)PFD.DoubleBuffer,
                   (byte)PFD.TypeRGBA, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                   (sbyte)PFD.MainPlane, 0, 0, 0, 0);
            result.PFD = pFD;
            int pF = GDI.ChoosePixelFormat(HDC, ref pFD);
            if (pF == 0)
                return result;
            result.PF = pF;
            GDI.SetPixelFormat(HDC, pF, ref pFD);
            IntPtr HRC = WglCreateContext(HDC);
            if (HRC == IntPtr.Zero)
                return result;
            result.HRC = HRC;
            WglMakeCurrent(HDC, HRC);
            result.IsCreated = true;
            LoadExtensions();
            return result;
        }
        public static bool Destroy(GLCreateResult result)
        {
            WglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
            WglDeleteContext(result.HRC);
            USER32.ReleaseDC(result.HWND, result.HDC);
            return true;
        }
        public static void SwapBuffers(GLCreateResult gLCreate) => GDI.SwapBuffers(gLCreate.HDC);
        public static void SwapBuffers(IntPtr hdc) => GDI.SwapBuffers(hdc);

    }
}
