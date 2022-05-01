using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Graphics
{
    public class FrameBuffer
    {
        public uint fboID;
        public Texture texture { get; private set; }

        public FrameBuffer(int w, int h)
        {
            fboID = GL.GenFramebuffer();

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fboID);

            texture = Texture.Create(w, h);

            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer,
                FramebufferAttachment.ColorAttachment0,
                TextureTarget.Texture2D, texture.ID, 0);


            uint rboID = GL.GenRenderbuffer();
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, rboID);
            GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer,
                RenderbufferStorage.DepthComponent32, w, h);
            GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer,
                FramebufferAttachment.DepthAttachment,
                RenderbufferTarget.Renderbuffer, rboID);

            if (GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer)
                != FramebufferErrorCode.FramebufferComplete)
            {
                throw new Exception("No Frame Buffer Create");
            }
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        public void Use()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, fboID);
        }

        public void Stop()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }
    }
}
