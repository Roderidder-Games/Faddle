using OpenTK.Mathematics;
using System;

namespace FaddleEngine
{
    internal class MeshRenderObject : IDisposable
    {
        public Mesh mesh;
        public Shader shader;

        private readonly VertexBuffer vbo;
        private readonly IndexBuffer ebo;
        private readonly VertexArrayObject vao;

        public MeshRenderObject(Mesh mesh, Shader shader, bool isStatic)
        {
            this.mesh = mesh;
            this.shader = shader;

            vbo = new VertexBuffer(Vertex.VertexInfo, mesh.vertices.Length, isStatic);
            vbo.SetData(mesh.vertices, mesh.vertices.Length);

            vao = new VertexArrayObject(vbo);

            ebo = new IndexBuffer(mesh.indices.Length, isStatic);
            ebo.SetData(mesh.indices, mesh.indices.Length);

            mesh.SetRenderer(this);
            mesh.texture?.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);
        }

        public void RenderMesh(Matrix4 model)
        {
            vao.Use();

            shader.Use();

            mesh.texture?.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);

            shader.SetUniform("model", model);
            shader.SetUniform("view", Camera.Main.GetViewMatrix());
            shader.SetUniform("projection", Camera.Main.GetProjectionMatrix());

            ebo.Use();
        }

        internal void SetTexture()
        {
            mesh.texture?.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);
        }

        public void Dispose()
        {
            vbo.Dispose();
            vao.Dispose();
            ebo.Dispose();
        }
    }
}
