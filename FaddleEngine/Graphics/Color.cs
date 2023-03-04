using OpenTK.Mathematics;
using System;

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
            this.r = r / 255;
            this.g = g / 255;
            this.b = b / 255;
            this.a = a / 255;
        }

        public static Color White => new(1f, 1f, 1f, 1f);
        public static Color Black => new(0f, 0f, 0f, 1f);
        public static Color Transparent => new(0f, 0f, 0f, 0f);

        public static implicit operator Color4(Color c) => new(c.r, c.g, c.b, c.a);

        public override string ToString()
        {
            return $"R: {r}, G: {g}, B: {b}, A: {a}";
        }
    }
}
