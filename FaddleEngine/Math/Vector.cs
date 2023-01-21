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

        public static implicit operator OpenTK.Mathematics.Vector2(Vector2 a) => new OpenTK.Mathematics.Vector2(a.x, a.y);

        public override string ToString() => $"{x}, {y}";
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
        public static implicit operator Vector2Int(OpenTK.Mathematics.Vector2i a) => new Vector2Int(a.X, a.Y);

        public override string ToString() => $"{x}, {y}";
    }

    public struct Vector3
    {
        public float x, y, z;

        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);
        public static Vector3 UnitX => new Vector3(1, 0, 0);
        public static Vector3 UnitY => new Vector3(0, 1, 0);
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator +(Vector3 a, float b) => new Vector3(a.x + b, a.y + b, a.z + b);
        public static Vector3 operator -(Vector3 a) => new Vector3(-a.x, -a.y, -a.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator -(Vector3 a, float b) => new Vector3(a.x - b, a.y - b, a.z - b);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.x * b, a.y * b, a.z * b);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vector3 operator /(Vector3 a, float b) => new Vector3(a.x / b, a.y / b, a.z / b);

        public static implicit operator OpenTK.Mathematics.Vector3(Vector3 a) => new OpenTK.Mathematics.Vector3(a.x, a.y, a.z);
        public static implicit operator Vector3(OpenTK.Mathematics.Vector3 a) => new Vector3(a.X, a.Y, a.Z);

        public override string ToString() => $"{x}, {y}, {z}";
    }

    public struct Vector3Int
    {
        public int x, y, z;

        public static Vector3Int Zero => new Vector3Int(0, 0, 0);
        public static Vector3Int One => new Vector3Int(1, 1, 1);

        public Vector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3Int operator +(Vector3Int a, Vector3Int b) => new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3Int operator +(Vector3Int a, int b) => new Vector3Int(a.x + b, a.y + b, a.z + b);
        public static Vector3Int operator -(Vector3Int a, Vector3Int b) => new Vector3Int(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3Int operator -(Vector3Int a, int b) => new Vector3Int(a.x - b, a.y - b, a.z - b);
        public static Vector3Int operator *(Vector3Int a, Vector3Int b) => new Vector3Int(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3Int operator *(Vector3Int a, int b) => new Vector3Int(a.x * b, a.y * b, a.z * b);
        public static Vector3Int operator /(Vector3Int a, Vector3Int b) => new Vector3Int(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vector3Int operator /(Vector3Int a, int b) => new Vector3Int(a.x / b, a.y / b, a.z / b);

        public override string ToString() => $"{x}, {y}, {z}";
    }
}
