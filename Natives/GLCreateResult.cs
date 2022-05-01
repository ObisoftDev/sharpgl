using SharpGL.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Natives
{
    public struct GLCreateResult : IDisposable
    {
        public IntPtr HWND { get; internal set; }
        public IntPtr HDC { get; internal set; }
        public IntPtr HRC { get; internal set; }
        public PixelFormatDesc PFD { get; internal set; }
        public int PF { get; internal set; }
        public bool IsCreated { get; internal set; }

        public void Dispose() => GL.Destroy(this);
    }
}
