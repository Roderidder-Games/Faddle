using OpenTK.Graphics.OpenGL4;
using System;

namespace FaddleEngine.Graphics
{
    internal class VertexArrayObject : IDisposable
    {
        public readonly int handle;

        private bool disposed;

        public VertexArrayObject(VertexBuffer vbo)
        {
            disposed = false;

            if (vbo == null)
            {
                throw new ArgumentNullException(nameof(vbo));
            }

            handle = GL.GenVertexArray();
            GL.BindVertexArray(handle);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.handle);

            VertexAttribute[] attribs = vbo.vertexInfo.vertexAttributes;

            for (int i = 0; i < attribs.Length; i++)
            {
                VertexAttribute attrib = attribs[i];
                GL.VertexAttribPointer(attrib.index, attrib.componentCount, VertexAttribPointerType.Float, false, vbo.vertexInfo.byteSize, attrib.offset);
                GL.EnableVertexAttribArray(attrib.index);
            }

            GL.BindVertexArray(0);
        }

        public void Use()
        {
            GL.BindVertexArray(handle);
        }

        ~VertexArrayObject()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            GL.BindVertexArray(0);
            GL.DeleteVertexArray(handle);

            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
