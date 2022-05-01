using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Graphics
{
    public class Light
    {
        public Vector3 Position { get; set; }
        public Vector3 Color { get; set; }

        public Light(Vector3 position, Vector3 color)
        {
            Position = position;
            Color = color;
        }
    }
}
