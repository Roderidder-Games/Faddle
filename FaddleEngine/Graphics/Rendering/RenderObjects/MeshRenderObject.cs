﻿using OpenTK.Mathematics;
using System;

namespace FaddleEngine
{
    internal class MeshRenderObject : IDisposable, IRenderer
    {
        public Mesh mesh;
        public Shader shader;

        private readonly VertexBuffer vbo;
        private readonly IndexBuffer ebo;
        private readonly VertexArrayObject vao;

        private readonly Camera camera;

        private readonly int zIndex;

        private Matrix4 model;

        public MeshRenderObject(Mesh mesh, Shader shader, bool isStatic, Camera camera, int zIndex)
        {
            this.mesh = mesh;
            this.shader = shader;
            this.zIndex = zIndex;

            vbo = new VertexBuffer(Vertex.VertexInfo, mesh.vertices.Length, isStatic);
            vbo.SetData(mesh.vertices, mesh.vertices.Length);

            vao = new VertexArrayObject(vbo);

            ebo = new IndexBuffer(mesh.indices.Length, isStatic);
            ebo.SetData(mesh.indices, mesh.indices.Length);

            this.camera = camera ?? Camera.Main;
        }

        public int GetZIndex()
        {
            return zIndex;
        }

        public void SetModel(Matrix4 model)
        {
            this.model = model;
        }

        public void Render()
        {
            vao.Use();

            shader.Use();

            mesh.texture?.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);

            shader.SetUniform("model", model);
            shader.SetUniform("view", camera.GetViewMatrix());
            shader.SetUniform("projection", camera.GetProjectionMatrix());

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
