using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace SharpGL.Desktop
{
    public class InputDevice : IDisposable
    {
        public static InputDevice Current { get; internal set; }



        //Keys Region
        internal List<Keys> DownKeys = new List<Keys>();
        internal List<Keys> UpKeys = new List<Keys>();
        internal List<Keys> LastKeys = new List<Keys>();
        //MouseRegion
        internal List<MouseButtons> DownMouse = new List<MouseButtons>();
        internal List<MouseButtons> UpMouse = new List<MouseButtons>();
        internal List<MouseButtons> LastMouse = new List<MouseButtons>();

        //InputAxis
        internal List<InputAxis> Axis = new List<InputAxis>();

        public void AddNewAxis(InputAxis axis)
        {
            axis.myDevice = this;
            Axis.Add(axis);
        }

        public InputAxis GetAxis(string name)
        {
            foreach (var a in Axis)
                if (a.Name.ToLower() == name.ToLower())
                    return a;
            return InputAxis.Empty;
        }


        static float h = 0;
        static float v = 0;
        static float mx = 0;
        static float my = 0;
        public float GetAxisValue(string name)
        {
            switch (name.ToLower())
            {
                case "horizontal":
                    return h;
                case "vertical":
                    return v;
                case "mouse x":
                    return mx;
                case "mouse y":
                    return my;
            }
            foreach (var a in Axis)
                if (a.Name.ToLower() == name.ToLower())
                    return a.Axis;
            return 0;
        }




        //Mouse Position
        public Vector2 MousePosition { get; internal set; }



        public void Update()
        {
            if (IsKeyPressed(KeyCode.D) || IsKeyPressed(KeyCode.Right))
                h += 1;
            else if (IsKeyPressed(KeyCode.A) || IsKeyPressed(KeyCode.Left))
                h -= 1;
            else
                h = 0;

            if (IsKeyPressed(KeyCode.W) || IsKeyPressed(KeyCode.Up))
                v -= 1;
            else if (IsKeyPressed(KeyCode.S) || IsKeyPressed(KeyCode.Down))
                v += 1;
            else
                v = 0;

            h = Mathf.Clamp(h, -1, 1);
            v = Mathf.Clamp(v, -1, 1);
            mx = Mathf.Clamp(mx, -1, 1);
            my = Mathf.Clamp(my, -1, 1);

            foreach (var a in Axis) a.Update();
        }

        public void Clear()
        {
            mx = 0;
            my = 0;
            inMoving = false;
            UpMouse.Clear();
        }


        Control control;
        public InputDevice(Control c) : base()
        {
            Current = this;
            control = c;
            SetKeyEvents(c);
            SetMouseEvents(c);
        }

        public void SetKeyEvents(Control c)
        {
            c.KeyDown += OnKeyDown;
            c.KeyUp += OnKeyUp;
        }
        public void SetMouseEvents(Control c)
        {
            c.MouseMove += MouseMove;
            c.MouseDown += MouseDown;
            c.MouseUp += MouseUp;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            while (DownMouse.Contains(e.Button))
            {
                UpMouse.Add(e.Button);
                DownMouse.Remove(e.Button);
                LastMouse.Remove(e.Button);
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (!DownMouse.Contains(e.Button))
                DownMouse.Add(e.Button);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            while (DownKeys.Contains(e.KeyCode))
            {
                UpKeys.Add(e.KeyCode);
                DownKeys.Remove(e.KeyCode);
                LastKeys.Remove(e.KeyCode);
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!DownKeys.Contains(e.KeyCode))
                DownKeys.Add(e.KeyCode);
        }


        bool inMoving = false;
        float lastX = 0;
        float lastY = 0;
        private void MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition = new Vector2(e.X, e.Y);

            if (!inMoving)
            {
                lastX = e.X;
                lastY = e.Y;
                inMoving = true;
            }

            if (e.X > lastX)
                mx += 1f;
            if (e.X < lastX)
                mx -= 1f;
            if (e.Y > lastY)
                my += 1f;
            if (e.Y < lastY)
                my -= 1f;
        }


        //KEY Functions
        public bool IsKeyPressed(KeyCode key) => (DownKeys.Contains((Keys)key));
        public bool IsKeyUp(KeyCode key) => (UpKeys.Contains((Keys)key));
        public bool IsKeyDown(KeyCode key)
        {
            if (IsKeyPressed(key) && !LastKeys.Contains((Keys)key))
            {
                LastKeys.Add((Keys)key);
                return true;
            }
            return false;
        }

        //Mouse Functions
        public bool IsMousePressed(MouseCode code) => (DownMouse.Contains((MouseButtons)code));
        public bool IsMouseUp(MouseCode code) => (UpMouse.Contains((MouseButtons)code));
        public bool IsMouseDown(MouseCode code)
        {
            if (IsMousePressed(code) && !LastMouse.Contains((MouseButtons)code))
            {
                LastMouse.Add((MouseButtons)code);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Axis.Clear();
            DownKeys.Clear();
            UpKeys.Clear();
            LastKeys.Clear();
            LastMouse.Clear();
            DownMouse.Clear();
            UpMouse.Clear();
        }
    }

    public enum MouseCode
    {
        None = MouseButtons.None,
        Left = MouseButtons.Left,
        Middle = MouseButtons.Middle,
        Right = MouseButtons.Right,
        XButton1 = MouseButtons.XButton1,
        XButton2 = MouseButtons.XButton2,
    }
    public enum KeyCode
    {
        A = Keys.A,
        B = Keys.B,
        C = Keys.C,
        D = Keys.D,
        E = Keys.E,
        F = Keys.F,
        G = Keys.G,
        H = Keys.H,
        I = Keys.I,
        J = Keys.J,
        K = Keys.K,
        L = Keys.L,
        M = Keys.M,
        N = Keys.N,
        O = Keys.O,
        P = Keys.P,
        Q = Keys.Q,
        R = Keys.R,
        S = Keys.S,
        T = Keys.T,
        U = Keys.U,
        V = Keys.V,
        W = Keys.W,
        X = Keys.X,
        Y = Keys.Y,
        Z = Keys.Z,
        Space = Keys.Space,
        Control = Keys.LControlKey,
        Alt = Keys.Alt,
        Up = Keys.Up,
        Down = Keys.Down,
        Left = Keys.Left,
        Right = Keys.Right,
    }

}