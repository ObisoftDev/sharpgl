using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGL.Natives
{

    public delegate IntPtr WindowProcess(IntPtr handle, uint msg, int wParam, int lParam);
    public delegate bool SwapInterval(int interval);
    public delegate void TimerProcess(IntPtr handle, uint message, IntPtr id, uint interval);

}