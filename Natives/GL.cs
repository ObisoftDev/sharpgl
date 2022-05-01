using SharpGL.Natives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpGL.Graphics
{
    public static partial class GL
    {
        private const string OpenGl = "opengl32.dll";

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "wglCreateContext")]
        public static extern IntPtr WglCreateContext(IntPtr hdc);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "wglDeleteContext")]
        public static extern IntPtr WglDeleteContext(IntPtr hdc);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "wglGetProcAddress")]
        public static extern IntPtr WglGetProcAddress(string name);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "wglMakeCurrent")]
        public static extern int WglMakeCurrent(IntPtr hdc, IntPtr hrc);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glEnable")]
        public static extern void Enable([MarshalAs(UnmanagedType.I4)] EnableCap cap);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glGenTextures")]
        public static extern void GenTextures(int n, [MarshalAs(UnmanagedType.LPArray)] uint[] textures);

        public static uint GenTexture()
        {
            uint[] textures = { 0 };
            GenTextures(1, textures);
            return textures[0];
        }

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glCullFace")]
        public static extern void CullFace([MarshalAs(UnmanagedType.I4)] CullFaceMode mode);
        

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glBindTexture")]
        public static extern void BindTexture([MarshalAs(UnmanagedType.I4)] TextureTarget target, uint texture);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glTexParameteri")]
        public static extern void TexParameter([MarshalAs(UnmanagedType.I4)]  TextureTarget target, uint pname, int param);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glTexEnvf")]
        public static extern void TexEnvf(uint target, uint pname, float param);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D([MarshalAs(UnmanagedType.I4)]  TextureTarget target, int level, uint internalformat, int width, int height, int border, uint format, uint type,IntPtr pixels);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glTexSubImage2D")]
        public static extern void TexSubImage2D([MarshalAs(UnmanagedType.I4)]  TextureTarget target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type,IntPtr pixels);

        //[SuppressUnmanagedCodeSecurity]
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glBegin")]
        public static extern void Begin([MarshalAs(UnmanagedType.I4)] PrimitiveType type);

        //[SuppressUnmanagedCodeSecurity]
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glEnd")]
        public static extern void End();

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glTexCoord2f")]
        public static extern void TexCoord2(float s, float t);
        public static void TexCoord2(Vector2 v) => TexCoord2(v.X,v.Y);


        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glNormal3f")]
        public static extern void Normal3(float x, float y, float z);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glNormal3i")]
        public static extern void Normal3(int x, int y, int z);
        public static void Normal3(Vector3 v) => Normal3(v.X,v.Y,v.Z);


        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glLightf")]
        public static extern void Light([MarshalAs(UnmanagedType.I4)] LightName lightName, [MarshalAs(UnmanagedType.I4)] LightParameter lightParameter, float param);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glLightfv")]
        public static extern void Light([MarshalAs(UnmanagedType.I4)] LightName lightName, [MarshalAs(UnmanagedType.I4)] LightParameter lightParameter, float[] param);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glVertex3f")]
        public static extern void Vertex3(float x, float y, float z);
        public static void Vertex3(Vector3 v) => Vertex3(v.X, v.Y,v.Z);

        //[SuppressUnmanagedCodeSecurity]
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glVertex2f")]
        public static extern void Vertex2(float x, float y);
        public static void Vertex2(Vector2 v) => Vertex2(v.X,v.Y);

        //[SuppressUnmanagedCodeSecurity]
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glColor3ub")]
        public static extern void Color(byte red, byte green, byte blue);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glColor4ub")]
        public static extern void Color(byte red, byte green, byte blue, byte alpha);
        public static void Color(Color4 color) => Color(color.R, color.G, color.B,color.A);


        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glFlush")]
        public static extern void Flush();

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glFinish")]
        public static extern void Finish();

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glClearColor")]
        public static extern void ClearColor(byte r, byte g, byte b, byte a);
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glClearColor")]
        public static extern void ClearColor([MarshalAs(UnmanagedType.LPArray)] Color4 color);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glClear")]
        public static extern void Clear([MarshalAs(UnmanagedType.I4)] ClearBufferMask mask);

        //Nuevos
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glViewport")]
        public static extern void Viewport(int x, int y, int w, int h);


        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode([MarshalAs(UnmanagedType.I4)] MatrixMode mode);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity();

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glOrtho")]
        public static extern void Ortho(double left, double right, double bottom, double top, double near, double far);

        //Matrix
        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix();

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix();

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glRotatef")]
        public static extern void Rotate(float angle, float x, float y, float z);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glScalef")]
        public static extern void Scale(float x, float y, float z);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glTranslatef")]
        public static extern void Translate(float x, float y, float z);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glMultMatrixf")]
        public static extern void MultMatrix(ref Matrix4 m);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glLoadMatrixf")]
        public static extern void LoadMatrix(ref Matrix4 m);

        [DllImport(OpenGl, SetLastError = true, EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc([MarshalAs(UnmanagedType.I4)] Blending sfactor, [MarshalAs(UnmanagedType.I4)] Blending dfactor);


    }

}