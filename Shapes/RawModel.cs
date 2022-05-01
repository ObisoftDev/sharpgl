
using SharpGL;
using SharpGL.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Shapes
{
    public class RawModel
    {
        public int vaoID { get; private set; }
        public int vertexCount { get; private set; }
        public Color4 RenderColor { get; set; } = Color4.White;

        public RawModel(int vaoID ,int vertexCount)
        {
            this.vaoID = vaoID;
            this.vertexCount = vertexCount;
        }
    }
}
