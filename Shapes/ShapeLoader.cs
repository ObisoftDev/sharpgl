using SharpGL.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Shapes
{
    public static class ShapeLoader
    {
        private static List<uint> VAOS = new List<uint>();
        private static List<uint> VBOS = new List<uint>();
        private static List<Texture> TEXTURES = new List<Texture>();

        public static RawModel loadToVAO(float[] positions,float[] textureCoords,float[] normals,int[] indices)
        {
            uint vaoID = CreateVAO();
            bindIndicesBuffer(indices);
            storeDataInAttributeList(0,3, positions);
            storeDataInAttributeList(1,2, textureCoords);
            storeDataInAttributeList(2,3, normals);
            unbindVAO();
            return new RawModel((int)vaoID, indices.Length);
        }

        public static Texture loadTexture(string file)
        {
            Texture tex = Texture.CreateFromFile(file);
            TEXTURES.Add(tex);
            return tex;
        }


        public static void cleanUP()
        {
            for (int i = 0; i < VAOS.Count; i++)
                GL.DeleteVertexArray(VAOS[i]);
            for (int i = 0; i < VBOS.Count; i++)
                GL.DeleteBuffer(VBOS[i]);

           /* for (int i = 0; i < TEXTURES.Count; i++)
                GL.Texture(TEXTURES[i].ID);*/
        }

        public static uint CreateVAO()
        {
            uint vaoID = GL.GenVertexArray();
            VAOS.Add(vaoID);
            GL.BindVertexArray(vaoID);
            return vaoID;
        }

        public static void storeDataInAttributeList(uint attributeNumber,int coordinateSize,float[] data)
        {
            uint vboID = GL.GenBuffer();
            VBOS.Add(vboID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * 4, data, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attributeNumber, coordinateSize,VertexAttribPointerType.Float,false,0,IntPtr.Zero);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        public static void unbindVAO()
        {
            GL.BindVertexArray(0);
        }


        public static void bindIndicesBuffer(int[] indices)
        {
            uint vboID = GL.GenBuffer();
            VBOS.Add(vboID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * 4, indices, BufferUsageHint.StaticDraw);
        }
    }
}
