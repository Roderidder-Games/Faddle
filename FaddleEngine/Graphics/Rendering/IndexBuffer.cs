using OpenTK.Graphics.OpenGL4;
using System;

namespace FaddleEngine.Graphics
{
    internal class IndexBuffer : IDisposable
    {
        private const int MIN_INDEX_COUNT = 1;
        private const int MAX_INDEX_COUNT = 250_000;

        public readonly int handle;

        private readonly int indexCount;

        private bool disposed;

        public IndexBuffer(int indexCount, bool isStatic)
        {
            if (indexCount < MIN_INDEX_COUNT || indexCount > MAX_INDEX_COUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(indexCount));
            }

            this.indexCount = indexCount;

            handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, handle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexCount * sizeof(int), IntPtr.Zero, isStatic ? BufferUsageHint.StaticDraw : BufferUsageHint.StreamDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Use()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, handle);
            GL.DrawElements(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, 0);
        }

        public void SetData(int[] data, int count)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            if (count <= 0 || count > indexCount || count > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, handle);
            GL.BufferSubData(BufferTarget.ElementArrayBuffer, IntPtr.Zero, count * sizeof(int), data);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        ~IndexBuffer()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.DeleteBuffer(handle);

            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
