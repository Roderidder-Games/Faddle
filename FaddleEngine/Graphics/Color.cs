using OpenTK.Mathematics;
using System.Diagnostics.CodeAnalysis;

namespace FaddleEngine
{
    public struct Color
    {
        /// <summary>
        /// The color channel of the color.
        /// </summary>
        public float r, g, b, a;

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(byte r, byte g, byte b, byte a)
        {
            this.r = (float)r / 255;
            this.g = (float)g / 255;
            this.b = (float)b / 255;
            this.a = (float)a / 255;
        }

        public Vector4 ToBytes()
        {
            return new Vector4(r * 255, g * 255, b * 255, a * 255);
        }

        public static Color White => new(1f, 1f, 1f, 1f);
        public static Color Black => new(0f, 0f, 0f, 1f);
        public static Color Transparent => new(0f, 0f, 0f, 0f);

        public static implicit operator Color4(Color c) => new(c.r, c.g, c.b, c.a);

        public override string ToString()
        {
            return $"R: {r}, G: {g}, B: {b}, A: {a}";
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Color c)
            {
                return c.r == r && c.g == g && c.b == b && c.a == a;
            }

            return false;
        }

        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Color left, Color right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
