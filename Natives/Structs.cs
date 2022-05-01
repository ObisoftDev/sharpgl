using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SharpGL.Natives
{

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr Handle;
        public uint Msg;
        public IntPtr WParam;
        public IntPtr LParam;
        public int Time;
        public Point Point;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MonitorInfo
    {
        public int Size;
        public Rect Monitor;
        public Rect WorkArea;
        public uint Flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WaveHdr
    {
        public IntPtr Data;
        public int BufferLength;
        public int BytesRecorded;
        public IntPtr User;
        public int Flags;
        public int Loops;
        public IntPtr Next;
        public int Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class WaveFormatEx
    {
        public short FormatTag;
        public short Channels;
        public int SamplesPerSec;
        public int AvgBytesPerSec;
        public short BlockAlign;
        public short BitsPerSample;
        public short Size;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WindowClassEx
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint Size;
        [MarshalAs(UnmanagedType.U4)]
        public int Style;
        public WindowProcess WindowsProc;
        public int ClsExtra;
        public int WndExtra;
        public IntPtr Instance;
        public IntPtr Icon;
        public IntPtr Cursor;
        public IntPtr Background;
        [MarshalAs(UnmanagedType.LPStr)]
        public string MenuName;
        [MarshalAs(UnmanagedType.LPStr)]
        public string ClassName;
        public IntPtr IconSm;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct PixelFormatDesc
    {
        [FieldOffset(0)]
        public ushort Size;
        [FieldOffset(2)]
        public ushort Version;
        [FieldOffset(4)]
        public uint Flags;
        [FieldOffset(8)]
        public byte PixelType;
        [FieldOffset(9)]
        public byte ColorBits;
        [FieldOffset(10)]
        public byte RedBits;
        [FieldOffset(11)]
        public byte RedShift;
        [FieldOffset(12)]
        public byte GreenBits;
        [FieldOffset(13)]
        public byte GreenShift;
        [FieldOffset(14)]
        public byte BlueBits;
        [FieldOffset(15)]
        public byte BlueShift;
        [FieldOffset(16)]
        public byte AlphaBits;
        [FieldOffset(17)]
        public byte AlphaShift;
        [FieldOffset(18)]
        public byte AccumBits;
        [FieldOffset(19)]
        public byte AccumRedBits;
        [FieldOffset(20)]
        public byte AccumGreenBits;
        [FieldOffset(21)]
        public byte AccumBlueBits;
        [FieldOffset(22)]
        public byte AccumAlphaBits;
        [FieldOffset(23)]
        public byte DepthBits;
        [FieldOffset(24)]
        public byte StencilBits;
        [FieldOffset(25)]
        public byte AuxBuffers;
        [FieldOffset(26)]
        public sbyte LayerType;
        [FieldOffset(27)]
        public byte Reserved;
        [FieldOffset(28)]
        public uint LayerMask;
        [FieldOffset(32)]
        public uint VisibleMask;
        [FieldOffset(36)]
        public uint DamageMask;

        public PixelFormatDesc(ushort version, uint flags, byte pixelType, byte colorBits,
            byte redBits, byte redShift, byte greenBits, byte greenShift, byte blueBits, byte blueShift, byte alphaBits, byte alphaShift,
            byte accumBits, byte accumRedBits, byte accumGreenBits, byte accumBlueBits, byte accumAlphaBits,
            byte depthBits, byte stencilBits, byte auxBuffers, sbyte layerType, byte reserved,
            uint layerMask, uint visibleMask, uint damageMask) : this()
        {
            Size = (ushort)Marshal.SizeOf(this);
            Version = version;
            Flags = flags;
            PixelType = pixelType;
            ColorBits = colorBits;
            RedBits = redBits;
            RedShift = redShift;
            GreenBits = greenBits;
            GreenShift = greenShift;
            BlueBits = blueBits;
            BlueShift = blueShift;
            AlphaBits = alphaBits;
            AlphaShift = alphaShift;
            AccumBits = accumBits;
            AccumRedBits = accumRedBits;
            AccumGreenBits = accumGreenBits;
            AccumBlueBits = accumBlueBits;
            AccumAlphaBits = accumAlphaBits;
            DepthBits = depthBits;
            StencilBits = stencilBits;
            AuxBuffers = auxBuffers;
            LayerType = layerType;
            Reserved = reserved;
            LayerMask = layerMask;
            VisibleMask = visibleMask;
            DamageMask = damageMask;
        }
    }
}