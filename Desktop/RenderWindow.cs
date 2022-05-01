using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL.Graphics;
using SharpGL.Natives;


namespace SharpGL.Desktop
{
    public class RenderWindow : IDisposable
    {
        public static RenderWindow Current { get; private set; }

        private Form wnd;
        private Panel ctl;
        private GLCreateResult gl;
        private RenderLoop loop;


        private string title = "RenderWindow";
        public string Title { get { return title; } set { title = value; } }
        public int Width { get { return wnd.Width; } set { wnd.Width = value; } }
        public int Height { get { return wnd.Height; } set { wnd.Height = value; } }
        public int ControlWidth => ctl.Width;
        public int ControlHeight => ctl.Height;

        public InputDevice InputDevice { get; internal set; }


        public bool EnableFps { get; set; } = true;
        public bool FullScreen { 
            get
            {
                if (wnd.FormBorderStyle == FormBorderStyle.None && wnd.WindowState == FormWindowState.Minimized)
                    return true;
                return false;
            }
            set
            {
                if(value)
                {
                    wnd.FormBorderStyle = FormBorderStyle.None;
                    wnd.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    wnd.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    wnd.WindowState = FormWindowState.Normal;
                }
            }
        }


        public RenderWindow(string title="RenderWindow",int w = 800,int h = 600)
        {
            Current = this;
            wnd = new Form();
            wnd.StartPosition = FormStartPosition.CenterScreen;
            wnd.MinimumSize = new System.Drawing.Size(400, 300);
            this.title = title;
            Width = w;
            Height = h;

            ctl = new Panel();
            ctl.Dock = DockStyle.Fill;
            wnd.Controls.Add(ctl);

            gl = GL.Create(ctl.Handle);

            wnd.Resize += (s, e) => OnResize(ControlWidth,ControlHeight);

            InputDevice = new InputDevice(ctl);
            InputDevice.SetKeyEvents(wnd);

            OnResize(ControlWidth, ControlHeight);
        }


        public void Run()
        {
            if (gl.IsCreated)
            {
                OnLoad();
                loop = new RenderLoop(InternalUpdate);
                loop.Run();
                Application.Run(wnd);
            }
        }

        private void InternalUpdate(RenderLoop loop, float fps, float deltaTime)
        {
            InputDevice.Update();


            OnUpdate(loop);
            OnRender();
            SwapBuffers();


            InputDevice.Clear();

            if (EnableFps)
            wnd.Text = $"{title} Fps:{fps}";
            else
            wnd.Text = $"{title}";

            
        }



        public virtual void OnLoad()
        {

        }
        public virtual void OnUpdate(RenderLoop loop)
        {

        }
        public virtual void OnRender()
        {

        }

        public virtual void OnResize(int w,int h)
        {

        }


        public void SwapBuffers() => GL.SwapBuffers(gl);

        public void Dispose()
        {
            gl.Dispose();    
        }
    }
}
