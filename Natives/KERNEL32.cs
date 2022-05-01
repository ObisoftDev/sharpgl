using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpGL.Natives
{

    internal static class KERNEL32
    {
        private const string Kernel = "kernel32.dll";

        [DllImport(Kernel, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport(Kernel, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibrary(string lpLibraryName);

        [DllImport(Kernel, CharSet = CharSet.Auto)]
        public static extern bool FreeLibrary(IntPtr hLibModule);

        [DllImport(Kernel, CharSet = CharSet.Auto)]
        public static extern IntPtr GetProcAddress(IntPtr module,string procName);
    }
}
