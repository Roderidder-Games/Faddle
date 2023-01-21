using OpenTK.Graphics.OpenGL4;
using System;

namespace FaddleEngine.Graphics
{
    internal class VertexBuffer : IDisposable
    {
        private const int MIN_VERTEX_COUNT = 1;
        private const int MAX_VERTEX_COUNT = 100_000;

        public readonly int handle;

        public readonly VertexInfo vertexInfo;

        private readonly int vertexCount;

        private bool disposed;

        public VertexBuffer(VertexInfo vertexInfo, int vertexCount, bool isStatic)
        {
            disposed = false;

            if (vertexCount < MIN_VERTEX_COUNT || vertexCount > MAX_VERTEX_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(vertexCount));
            }

            this.vertexInfo = vertexInfo;
            this.vertexCount = vertexCount;

            handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, handle);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexCount * vertexInfo.byteSize, IntPtr.Zero, isStatic ? BufferUsageHint.StaticDraw : BufferUsageHint.StreamDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void SetData<T>(T[] data, int count) where T : struct
        {
            if (typeof(T) != vertexInfo.type)
            {
                throw new ArgumentException("Vertex type does not match VertexBuffer type.");
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            if (count <= 0 || count > vertexCount || count > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            GL.BindBuffer(BufferTarget.ArrayBuffer, handle);
            GL.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, count * vertexInfo.byteSize, data);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        ~VertexBuffer()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(handle);

            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
