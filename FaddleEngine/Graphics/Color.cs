using OpenTK.Mathematics;

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

        public static Color White => new Color(1f, 1f, 1f, 1f);
        public static Color Black => new Color(0f, 0f, 0f, 1f);
        public static Color Transparent => new Color(0f, 0f, 0f, 0f);

        public static implicit operator Color4(Color c) => new Color4(c.r, c.g, c.b, c.a);
    }
}
