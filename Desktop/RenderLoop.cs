using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpGL.Desktop
{
    public delegate void OnUpdate(RenderLoop loop, float fps,float deltaTime);
    public class RenderLoop
    {
        public static RenderLoop Current { get; private set; }
        public int Update_Cap = 15;


        private float Frames;
        private float TimeStarted;
        private Stopwatch stopwatch;
        public float Fps { get;private set; }
        public float DeltaTime { get; private set; }
        


        public OnUpdate onUpdate { get; private set; }


        public RenderLoop() { Current = this; }

        public RenderLoop(OnUpdate func) : base() => onUpdate = func;

        public void Run()
        {
            InternalLoad();
            Timer t = new Timer();
            t.Interval = Update_Cap;
            t.Tick += (s,e) => { InternalUpdate(); };
            t.Start();
        }

        private void InternalLoad()
        {
            TimeStarted = Environment.TickCount;
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        private void InternalUpdate()
        {
            if (onUpdate != null)
                onUpdate(this, Fps, DeltaTime);
            Update();
            UpdateTime();
        }

        private void UpdateTime()
        {
            stopwatch.Stop();
            DeltaTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stopwatch.Restart();

            if (Environment.TickCount > (TimeStarted + 1000))
            {
                Fps = Frames;
                Frames = 0;
                TimeStarted = Environment.TickCount;
            }
            Frames++;
        }

        public virtual void Update()
        {

        }
    }
}
