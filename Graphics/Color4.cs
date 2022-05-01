using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Graphics
{
    public struct Color4 
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public Color4(byte r, byte g, byte b, byte a){R = r;G = g; B = b;A = a;}


        public int ToRgb
        {
            get
            {
                int ret = R << 16;
                ret |= G << 8;
                ret |= B;
                return ret;
            }
        }
        public int ToArgb
        {
            get
            {
                int ret = A << 24;
                ret |= R << 16;
                ret |= G << 8;
                ret |= B;
                return ret;
            }
        }

        public static implicit operator Color4(int rgb) => FromRgb(rgb);

        public static bool operator !=(Color4 c1, Color4 c2) => (c1.R!=c2.R || c1.G != c2.G || c1.B != c2.B || c1.A != c2.A);
        public static bool operator ==(Color4 c1, Color4 c2) => (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B && c1.A == c2.A);


        //0xFF00FF
        public static Color4 FromRgb(int rgb)
        {
            byte r = (byte)((rgb & 0xFF0000) >> 16);
            byte g = (byte)((rgb & 0x00FF00) >> 8);
            byte b = (byte)((rgb & 0x0000FF));
            return new Color4(r,g,b,255);
        }
        public static Color4 FromArgb(long argb)
        {
            byte a = (byte)((argb & 0xFF0000) >> 24);
            byte r = (byte)((argb & 0xFF0000) >> 16);
            byte g = (byte)((argb & 0x00FF00) >> 8);
            byte b = (byte)((argb & 0x0000FF));
            return new Color4(r, g, b, a);
        }

        public static Color4 RandomRgb()
        {
            byte[] b = new byte[3];
            Random rnd = new Random();
            rnd.NextBytes(b);
            return new Color4(b[0],b[1],b[2],255);
        }
        public static Color4 RandomArgb()
        {
            byte[] b = new byte[4];
            Random rnd = new Random();
            rnd.NextBytes(b);
            return new Color4(b[0], b[1], b[2], b[3]);
        }

        public static Color4 Empty => new Color4(0, 0, 0, 0);
        public static Color4 White => FromRgb(0xffffff);
        public static Color4 Grey => FromRgb(0xa9a9a9);
        public static Color4 Red => FromRgb(0xff0000);
        public static Color4 Yellow => FromRgb(0xffff00);
        public static Color4 Green => FromRgb(0x00ff00);
        public static Color4 Cyan => FromRgb(0x00ffff);
        public static Color4 Blue => FromRgb(0x0000ff);
        public static Color4 Magenta => FromRgb(0xff00ff);
        public static Color4 Brown => FromRgb(0x9a6324);
        public static Color4 Orange => FromRgb(0xf58231);
        public static Color4 Purple => FromRgb(0x911eb4);
        public static Color4 Lime => FromRgb(0xbfef45);
        public static Color4 Pink => FromRgb(0xfabebe);
        public static Color4 Snow => FromRgb(0xFFFAFA);
        public static Color4 Teal => FromRgb(0x469990);
        public static Color4 Lavender => FromRgb(0xe6beff);
        public static Color4 Beige => FromRgb(0xfffac8);
        public static Color4 Maroon => FromRgb(0x800000);
        public static Color4 Mint => FromRgb(0xaaffc3);
        public static Color4 Olive => FromRgb(0x808000);
        public static Color4 Apricot => FromRgb(0xffd8b1);
        public static Color4 Navy => FromRgb(0x000075);
        public static Color4 Black => FromRgb(0x000000);
        public static Color4 DarkGrey => FromRgb(0x8B8B8B);
        public static Color4 DarkRed => FromRgb(0x8B0000);
        public static Color4 DarkYellow => FromRgb(0x8B8B00);
        public static Color4 DarkGreen => FromRgb(0x008B00);
        public static Color4 DarkCyan => FromRgb(0x008B8B);
        public static Color4 DarkBlue => FromRgb(0x00008B);
        public static Color4 DarkMagenta => FromRgb(0x8B008B);


        //Matematicas de Colores
        public static Color4 Lerp(Color4 start,Color4 end,float amount=1)
        {
            Color4 ret = start;
            ret.R = (byte)Mathf.Lerp(ret.R, end.R, amount);
            ret.G = (byte)Mathf.Lerp(ret.G, end.G, amount);
            ret.B = (byte)Mathf.Lerp(ret.B, end.B, amount);
            ret.A = (byte)Mathf.Lerp(ret.A, end.A, amount);
            return ret;
        }

        public static Color4 operator *(Color4 c1, Color4 c2) 
            => new Color4(
                (byte)((int)c1.R* (int)c2.R),
                (byte)((int)c1.G * (int)c2.G),
                (byte)((int)c1.B * (int)c2.B),
                (byte)((int)c1.A * (int)c2.A));
        public static Color4 operator /(Color4 c1, Color4 c2)
          => new Color4(
              (byte)((int)c1.R / (int)c2.R),
              (byte)((int)c1.G / (int)c2.G),
              (byte)((int)c1.B / (int)c2.B),
              (byte)((int)c1.A / (int)c2.A));

        public static Color4 operator /(float val, Color4 c2)
          => new Color4(
              (byte)((int)val / (int)c2.R),
              (byte)((int)val / (int)c2.G),
              (byte)((int)val / (int)c2.B),
              (byte)((int)val / (int)c2.A));
        public static Color4 operator /(Color4 c1, float val)
         => new Color4(
             (byte)((int)c1.R / val),
             (byte)((int)c1.G / val),
             (byte)((int)c1.B / val),
             (byte)((int)c1.A / val));

        public static Color4 operator *(float val, Color4 c2)
         => new Color4(
             (byte)((int)val * (int)c2.R),
             (byte)((int)val * (int)c2.G),
             (byte)((int)val * (int)c2.B),
             (byte)((int)val * (int)c2.A));
        public static Color4 operator *(Color4 c1, float val)
         => new Color4(
             (byte)((int)c1.R * val),
             (byte)((int)c1.G * val),
             (byte)((int)c1.B * val),
             (byte)((int)c1.A * val));
    }
}
