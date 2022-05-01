using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL
{


    public static class Mathf
    {
        public static readonly float PI = (float)Math.PI;

        public static float Sin(float val) => (float)Math.Sin(val);
        public static float Cos(float val) => (float)Math.Cos(val);
        public static float Tan(float val) => (float)Math.Tan(val);

        public static float Power(float val, float pow) => (float)Math.Pow(val, pow);
        public static float Round(float val, int digits = 0) => (float)Math.Round(val, digits);

        public static float Map(float val, float oMin, float oMax, float nMin, float nMax) => (val - oMin) / (oMax - oMin) * (nMax - nMin) + nMin;
        public static float Clamp(float val, float min, float max) => Math.Max(Math.Min(max, val), min);
        public static float Lerp(float start, float end, float amt) => Map(amt, 0, 1, start, end);
        public static float Wrap(float val, float min, float max)
        {
            if (val > max)
                return val - min;
            if (val < min)
                return val - max;
            return val;
        }
        public static float Distance(float x1, float y1, float x2, float y2) => Power(Power(x2 - x1, 2) + Power(y2 - y1, 2), 1 / 2);
        public static float Magnitude(float x, float y) => Power(Power(x, 2) + Power(y, 2), 1 / 2);
        public static bool Between(float val, float min, float max) => val > min && val < max;

        public static void Seed() => seed = Environment.TickCount % int.MaxValue;
        public static void Seed(int s) => seed = s;
        public static int Random(int max) => Random(0, max);
        public static int Random(int min, int max) => RandomInt(min, max);
        public static float Random() => Random(0f, 1f);
        public static float Random(float max) => Random(0, max);
        public static float Random(float min, float max) => RandomFloat(min, max);
        public static T Random<T>(params T[] list) => list[Random(list.Length)];
        public static T Random<T>(List<T> list) => list[Random(list.Count)];
        public static T Random<T>(IEnumerable<T> list) => Random(list.ToArray());

        public static float Degrees(float radians) => (float)(radians * 180 / Math.PI);
        public static float Radians(float degrees) => (float)(degrees * Math.PI / 180);


        public static T[] MakeArray<T>(params T[] items) => items;
        public static T[] MakeArray<T>(int count, Func<int, T> selector)
        {
            T[] arr = new T[count];
            for (int i = 0; i < count; i++)
                arr[i] = selector(i);
            return arr;
        }

        public static List<T> MakeList<T>(params T[] items) => items.ToList();
        public static List<T> MakeList<T>(int count, Func<int, T> selector)
        {
            List<T> list = new List<T>(count);
            for (int i = 0; i < count; i++)
                list.Add(selector(i));
            return list;
        }



        private static Random rnd = new Random();
        private static int seed;

        public static int Seedd { get => seed; set { seed = value; rnd = new Random(value); } }

        public static void RandomInit() => Seedd = Environment.TickCount;

        public static byte RandomByte(int count) => RandomBytes(1)[0];

        public static byte[] RandomBytes(int count)
        {
            byte[] b = new byte[count];
            rnd.NextBytes(b);
            return b;
        }

        public static int RandomInt(int min, int max) => rnd.Next(min, max);

        public static float RandomFloat(float min = 0, float max = 1) => (float)rnd.NextDouble() * (max - min) + min;








        public static float Min(float a, float b)
        {
            return a >= b ? b : a;
        }

        public static double Min(double a, double b)
        {
            return a >= b ? b : a;
        }

        public static long Min(long a, long b)
        {
            return a >= b ? b : a;
        }

        public static ulong Min(ulong a, ulong b)
        {
            return a >= b ? b : a;
        }
        public static float Min(params float[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0f;

            float single = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] < single)
                    single = values[i];

            return single;
        }

        public static int Min(int a, int b)
        {
            return a >= b ? b : a;
        }
        public static int Min(params int[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0;

            int num = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] < num)
                    num = values[i];

            return num;
        }


        public static float Max(float a, float b)
        {
            return a <= b ? b : a;
        }

        public static double Max(double a, double b)
        {
            return a <= b ? b : a;
        }

        public static long Max(long a, long b)
        {
            return a <= b ? b : a;
        }

        public static ulong Max(ulong a, ulong b)
        {
            return a <= b ? b : a;
        }
        public static float Max(params float[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0f;

            float single = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] > single)
                    single = values[i];

            return single;
        }
        public static int Max(int a, int b)
        {
            return a <= b ? b : a;
        }
        public static int Max(params int[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0;

            int num = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] > num)
                    num = values[i];

            return num;
        }

    }
}