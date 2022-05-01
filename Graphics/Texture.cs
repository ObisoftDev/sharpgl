using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Graphics
{
    public class Texture
    {
        internal Bitmap Output;

        public uint ID { get; internal set; }
        public int W { get; internal set; }
        public int H { get; internal set; }

        internal Texture(uint textureID, int w, int h)
        {
            ID = textureID;
            W = w;
            H = h;
        }

        public static Texture CreateFromBitmap(Bitmap bmp)
        {
            uint id = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, id);

            System.Drawing.Imaging.BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);


            GL.TexImage2D(TextureTarget.Texture2D, 0,
                (uint)PixelInternalFormat.Rgba, data.Width, data.Height
                , 0, (uint)PixelFormat.Bgra, (uint)PixelType.UnsignedByte,data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D,
                 (uint)TextureParameterName.TextureWrapS, (int)
                 (uint)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D,
              (uint)TextureParameterName.TextureWrapT, (int)
             (uint)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D,
           (uint)TextureParameterName.TextureMinFilter, (int)
           (uint)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D,
            (uint)TextureParameterName.TextureMagFilter, (int)
           (uint)TextureMagFilter.Linear);

            Texture tex = new Texture(id, bmp.Width, bmp.Height);
            tex.Output = bmp;
            return tex;
        }
        public static Texture Create(int w, int h) => CreateFromBitmap(new Bitmap(w, h));
        public static Texture CreateFromFile(string file) => CreateFromBitmap(new Bitmap(file));
    }
}
