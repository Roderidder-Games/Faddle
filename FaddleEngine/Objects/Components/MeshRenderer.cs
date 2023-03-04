using FaddleEngine.Graphics;

namespace FaddleEngine
{
    public sealed class MeshRenderer : Component
    {
        public Mesh mesh;
        public Shader shader;

        private readonly VertexBuffer vbo;
        private readonly IndexBuffer ebo;
        private readonly VertexArrayObject vao;

        public MeshRenderer(Mesh mesh, Shader shader, bool isStatic = true)
        {
            this.mesh = mesh;
            this.shader = shader;

            vbo = new VertexBuffer(Vertex.VertexInfo, mesh.vertices.Length, isStatic);
            vbo.SetData(mesh.vertices, mesh.vertices.Length);

            vao = new VertexArrayObject(vbo);

            ebo = new IndexBuffer(mesh.indices.Length, isStatic);
            ebo.SetData(mesh.indices, mesh.indices.Length);

            mesh.texture?.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);
        }

        public override void OnAdd()
        {
        }

        public override void OnRemove()
        {
            vbo.Dispose();
            vao.Dispose();
            ebo.Dispose();
        }

        public override void OnUpdate()
        {
        }

        public override void OnRender()
        {
            base.OnRender();

            vao.Use();

            shader.Use();
            if (mesh.usesSpriteSheet)
            {
                mesh.spriteSheet?.DrawSprite(Parent.transform, mesh, mesh.spriteSheetIndex);
            } 
            else
            {
                mesh.texture?.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);
            }
            shader.SetUniform("model", Parent.transform.Model);
            shader.SetUniform("view", Camera.Main.GetViewMatrix());
            shader.SetUniform("projection", Camera.Main.GetProjectionMatrix());

            ebo.Use();
        }
    }
}
