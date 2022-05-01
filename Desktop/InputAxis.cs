using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Desktop
{
    public class InputAxis
    {
        public static InputAxis Empty = new InputAxis("empty",new KeyCode[0]);

        internal InputDevice myDevice;

        public static bool operator !=(InputAxis a1, InputAxis a2) => (a1.Name!=a2.Name);
        public static bool operator ==(InputAxis a1,InputAxis a2) => (a1.Name != a2.Name);



        public string Name { get; internal set; }
        public List<KeyCode> KValues { get; internal set; }
        public List<MouseCode> MValues { get; internal set; }
        public float Axis  { get; internal set; }

        public bool IsPressed { get; internal set; }
        public bool IsDown { get; internal set; }
        public bool IsUp { get; internal set; }


        public InputAxis(string name,params KeyCode[] values)
        {
            KValues = new List<KeyCode>();
            MValues = new List<MouseCode>();
            Name = name;
            KValues.AddRange(values);
            Axis = 0;
            IsPressed = false;
            IsUp = false;
            IsDown = false;
        }
        public InputAxis(string name, params MouseCode[] values)
        {
            KValues = new List<KeyCode>();
            MValues = new List<MouseCode>();
            Name = name;
            MValues.AddRange(values);
            Axis = 0;
            IsPressed = false;
            IsUp = false;
            IsDown = false;
        }

        public void AddCodeValue(KeyCode key) => KValues.Add(key);
        public void AddCodeValue(MouseCode key) => MValues.Add(key);

        internal void Update()
        {
            foreach(var key in KValues)
            {
                IsPressed = myDevice.IsKeyPressed(key);
                IsDown = myDevice.IsKeyDown(key);
                IsUp = myDevice.IsKeyUp(key);
            }
            foreach (var m in MValues)
            {
                IsPressed = myDevice.IsMousePressed(m);
                IsDown = myDevice.IsMouseDown(m);
                IsUp = myDevice.IsMouseUp(m);
            }

            if (IsPressed)
                Axis += 0.1f ;
            else
                Axis -= 0.1f;
            Axis = Mathf.Clamp(Axis,0, 1);
        }
    }
}
