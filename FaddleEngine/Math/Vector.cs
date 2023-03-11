using OpenTK.Mathematics;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FaddleEngine
{
    public struct Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        #region VECTORS

        public static Vector2 Zero => new(0, 0);
        public static Vector2 One => new(1, 1);

        #endregion

        #region MATH

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(x * x + y * y);
            }
        }

        public static Vector2 Normalize(Vector2 v)
        {
            return new Vector2(v.x / v.Magnitude, v.y / v.Magnitude);
        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            float dx = a.x - b.x;
            float dy = a.y - b.y;
            return MathF.Sqrt(dx * dx + dy * dy);
        }

        public static float Cross(Vector2 a, Vector2 b)
        {
            return a.x * b.y - a.y * b.x;
        }

        #endregion

        #region OPERATORS

        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.x + b.x, a.y + b.y);
        public static Vector2 operator +(Vector2 a, float b) => new(a.x + b, a.y + b);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.x - b.x, a.y - b.y);
        public static Vector2 operator -(Vector2 a, float b) => new(a.x - b, a.y - b);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.x * b.x, a.y * b.y);
        public static Vector2 operator *(Vector2 a, float b) => new(a.x * b, a.y * b);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new(a.x / b.x, a.y / b.y);
        public static Vector2 operator /(Vector2 a, float b) => new(a.x / b, a.y / b);
        public static Vector2 operator -(Vector2 v) => new(-v.x, -v.y);

        public static implicit operator OpenTK.Mathematics.Vector2(Vector2 a) => new(a.x, a.y);
        public static implicit operator Vector2(OpenTK.Mathematics.Vector2 a) => new(a.X, a.Y);
        public static implicit operator Vector2(Vector3 vec) => new(vec.x, vec.y);
        public static implicit operator Vector2(Vector2Int vec) => new(vec.x, vec.y);

        #endregion

        public override string ToString() => $"{x}, {y}";
        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Vector2 vec)
            {
                return x == vec.x && y == vec.y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }
    }

    public struct Vector2Int
    {
        public int x, y;

        public static Vector2Int Zero => new(0, 0);
        public static Vector2Int One => new(1, 1);

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new(a.x + b.x, a.y + b.y);
        public static Vector2Int operator +(Vector2Int a, int b) => new(a.x + b, a.y + b);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new(a.x - b.x, a.y - b.y);
        public static Vector2Int operator -(Vector2Int a, int b) => new(a.x - b, a.y - b);
        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new(a.x * b.x, a.y * b.y);
        public static Vector2Int operator *(Vector2Int a, int b) => new(a.x * b, a.y * b);
        public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new(a.x / b.x, a.y / b.y);
        public static Vector2Int operator /(Vector2Int a, int b) => new(a.x / b, a.y / b);

        public static implicit operator OpenTK.Mathematics.Vector2i(Vector2Int a) => new(a.x, a.y);
        public static implicit operator Vector2Int(OpenTK.Mathematics.Vector2i a) => new(a.X, a.Y);
        public static implicit operator Vector2Int(Vector3Int vec) => new(vec.x, vec.y);
        public static implicit operator Vector2Int(Vector2 vec) => new((int)vec.x, (int)vec.y);

        public override string ToString() => $"{x}, {y}";

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Vector2Int vec)
            {
                return x == vec.x && y == vec.y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector2Int left, Vector2Int right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector2Int left, Vector2Int right)
        {
            return !(left == right);
        }
    }

    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #region VECTORS

        public static Vector3 Zero => new(0, 0, 0);
        public static Vector3 One => new(1, 1, 1);
        public static Vector3 UnitX => new(1, 0, 0);
        public static Vector3 UnitY => new(0, 1, 0);
        public static Vector3 UnitZ => new(0, 0, 1);

        #endregion

        #region MATH

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(x * x + y * y + z * z);
            }
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            float x, y, z;
            x = a.y * b.z - a.z * b.y;
            y = (a.x * b.z - b.x * a.z) * -1;
            z = a.x * b.y - b.x * a.y;

            return new Vector3(x, y, z);
        }

        public static Vector3 Normalize(Vector3 v)
        {
            return new Vector3(v.x / v.Magnitude, v.y / v.Magnitude, v.z / v.Magnitude);
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            float dx = a.x - b.x;
            float dy = a.y - b.y;
            float dz = a.z - b.z;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y * a.z * b.z;
        }

        public Vector3 ToRadians() => new(MathHelper.DegreesToRadians(x), MathHelper.DegreesToRadians(y), MathHelper.DegreesToRadians(z));

        #endregion

        #region OPERATORS

        public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator +(Vector3 a, float b) => new(a.x + b, a.y + b, a.z + b);
        public static Vector3 operator -(Vector3 a) => new(-a.x, -a.y, -a.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator -(Vector3 a, float b) => new(a.x - b, a.y - b, a.z - b);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator *(Vector3 a, float b) => new(a.x * b, a.y * b, a.z * b);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vector3 operator /(Vector3 a, float b) => new(a.x / b, a.y / b, a.z / b);

        public static implicit operator OpenTK.Mathematics.Vector3(Vector3 a) => new(a.x, a.y, a.z);
        public static implicit operator Vector3(OpenTK.Mathematics.Vector3 a) => new(a.X, a.Y, a.Z);
        public static implicit operator Vector3(Vector2 vec) => new(vec.x, vec.y, 0f);
        public static implicit operator Vector3(Vector3Int vec) => new(vec.x, vec.y, vec.z);
        public static implicit operator System.Numerics.Vector3(Vector3 vec) => new(vec.x, vec.y, vec.z);

        #endregion

        public override string ToString() => $"{x}, {y}, {z}";

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Vector3 vec)
            {
                return x == vec.x && y == vec.y && z == vec.z;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }
    }

    public struct Vector3Int
    {
        public int x, y, z;

        public static Vector3Int Zero => new(0, 0, 0);
        public static Vector3Int One => new(1, 1, 1);

        public Vector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3Int operator +(Vector3Int a, Vector3Int b) => new(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3Int operator +(Vector3Int a, int b) => new(a.x + b, a.y + b, a.z + b);
        public static Vector3Int operator -(Vector3Int a, Vector3Int b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3Int operator -(Vector3Int a, int b) => new(a.x - b, a.y - b, a.z - b);
        public static Vector3Int operator *(Vector3Int a, Vector3Int b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3Int operator *(Vector3Int a, int b) => new(a.x * b, a.y * b, a.z * b);
        public static Vector3Int operator /(Vector3Int a, Vector3Int b) => new(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vector3Int operator /(Vector3Int a, int b) => new(a.x / b, a.y / b, a.z / b);

        public static implicit operator Vector3Int(Vector2Int vec) => new(vec.x, vec.y, 0);
        public static implicit operator Vector3Int(Vector3 vec) => new((int)vec.x, (int)vec.y, (int)vec.z);

        public override string ToString() => $"{x}, {y}, {z}";

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Vector3Int vec)
            {
                return x == vec.x && y == vec.y && z == vec.z;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector3Int left, Vector3Int right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3Int left, Vector3Int right)
        {
            return !(left == right);
        }
    }

    public struct Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #region VECTORS

        public static Vector4 Zero => new(0, 0, 0, 0);
        public static Vector4 One => new(1, 1, 1, 1);
        public static Vector4 UnitX => new(1, 0, 0, 0);
        public static Vector4 UnitY => new(0, 1, 0, 0);
        public static Vector4 UnitZ => new(0, 0, 1, 0);
        public static Vector4 UnitW => new(0, 0, 0, 1);

        #endregion

        #region MATH

        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(x * x + y * y + z * z + w * w);
            }
        }

        public static Vector4 Normalize(Vector4 v)
        {
            return new Vector4(v.x / v.Magnitude, v.y / v.Magnitude, v.z / v.Magnitude, v.w / v.Magnitude);
        }

        public static float Distance(Vector4 a, Vector4 b)
        {
            float dx = a.x - b.x;
            float dy = a.y - b.y;
            float dz = a.z - b.z;
            float dw = a.w - b.w;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        public static float Dot(Vector4 a, Vector4 b)
        {
            return a.x * b.x + a.y * b.y * a.z * b.z + a.w * b.w;
        }

        public Vector4 ToRadians() => new(MathHelper.DegreesToRadians(x), MathHelper.DegreesToRadians(y), MathHelper.DegreesToRadians(z), MathHelper.DegreesToRadians(w));

        #endregion

        #region OPERATORS

        public static Vector4 operator +(Vector4 a, Vector4 b) => new(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static Vector4 operator +(Vector4 a, float b) => new(a.x + b, a.y + b, a.z + b, a.w + b);
        public static Vector4 operator -(Vector4 a) => new(-a.x, -a.y, -a.z, -a.w);
        public static Vector4 operator -(Vector4 a, Vector4 b) => new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        public static Vector4 operator -(Vector4 a, float b) => new(a.x - b, a.y - b, a.z - b, a.w - b);
        public static Vector4 operator *(Vector4 a, Vector4 b) => new(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static Vector4 operator *(Vector4 a, float b) => new(a.x * b, a.y * b, a.z * b, a.w * b);
        public static Vector4 operator /(Vector4 a, Vector4 b) => new(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static Vector4 operator /(Vector4 a, float b) => new(a.x / b, a.y / b, a.z / b, a.w / b);

        public static implicit operator OpenTK.Mathematics.Vector4(Vector4 a) => new(a.x, a.y, a.z, a.w);
        public static implicit operator Vector4(OpenTK.Mathematics.Vector4 a) => new(a.X, a.Y, a.Z, a.W);
        public static implicit operator Vector4(Vector2 vec) => new(vec.x, vec.y, 0f, 0f);

        #endregion

        public override string ToString() => $"{x}, {y}, {z}, {w}";

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Vector4 vec)
            {
                return x == vec.x && y == vec.y && z == vec.z && w == vec.w;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !(left == right);
        }
    }
}
