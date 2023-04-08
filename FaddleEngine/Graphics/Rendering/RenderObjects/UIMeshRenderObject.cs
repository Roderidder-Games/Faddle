using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;

namespace FaddleEngine
{
    internal class UIMeshRenderObject : IDisposable, IRenderer
    {
        public Mesh mesh;
        public Shader shader;

        private readonly VertexBuffer vbo;
        private readonly IndexBuffer ebo;
        private readonly VertexArrayObject vao;

        private readonly int zIndex;

        private Matrix4 model;

        public UIMeshRenderObject(Mesh mesh, Shader shader, bool isStatic, int zIndex)
        {
            this.mesh = mesh;
            this.shader = shader;
            this.zIndex = zIndex;

            vbo = new VertexBuffer(Vertex.VertexInfo, mesh.vertices.Length, isStatic);
            vbo.SetData(mesh.vertices, mesh.vertices.Length);

            vao = new VertexArrayObject(vbo);

            ebo = new IndexBuffer(mesh.indices.Length, isStatic);
            ebo.SetData(mesh.indices, mesh.indices.Length);
        }

        public int GetZIndex() => zIndex;

        public void SetModel(Matrix4 model)
        {
            this.model = model;
        }

        public void Render()
        {
            vao.Use();

            shader.Use();
            shader.SetUniform("model", model);
            shader.SetUniform("projection", Camera.UI.GetProjectionMatrix());
            shader.SetUniform("view", Camera.UI.GetViewMatrix());

            mesh.texture?.Use(TextureUnit.Texture0);

            ebo.Use();
        }

        public void Dispose()
        {
            vbo.Dispose();
            vao.Dispose();
            ebo.Dispose();
        }
    }
}
