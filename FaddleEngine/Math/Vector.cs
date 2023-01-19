namespace FaddleEngine
{
    public struct Vector2
    {
        public float x, y;

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator +(Vector2 a, float b) => new Vector2(a.x + b, a.y + b);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator -(Vector2 a, float b) => new Vector2(a.x - b, a.y - b);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.x * b, a.y * b);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);
        public static Vector2 operator /(Vector2 a, float b) => new Vector2(a.x / b, a.y / b);
    }

    public struct Vector2Int
    {
        public int x, y;

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);
        public static Vector2Int operator +(Vector2Int a, int b) => new Vector2Int(a.x + b, a.y + b);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.x - b.x, a.y - b.y);
        public static Vector2Int operator -(Vector2Int a, int b) => new Vector2Int(a.x - b, a.y - b);
        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new Vector2Int(a.x * b.x, a.y * b.y);
        public static Vector2Int operator *(Vector2Int a, int b) => new Vector2Int(a.x * b, a.y * b);
        public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new Vector2Int(a.x / b.x, a.y / b.y);
        public static Vector2Int operator /(Vector2Int a, int b) => new Vector2Int(a.x / b, a.y / b);

        public static implicit operator OpenTK.Mathematics.Vector2i(Vector2Int a) => new OpenTK.Mathematics.Vector2i(a.x, a.y);
    }
}
