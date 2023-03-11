namespace FaddleEngine
{
    public sealed class MeshRenderer : Component
    {

        internal readonly MeshRenderObject renderer;

        public MeshRenderer(Mesh mesh, Shader shader, bool isStatic = true)
        {
            renderer = new MeshRenderObject(mesh, shader, isStatic);
        }

        internal override void OnAdd()
        {
        }

        internal override void OnRemove()
        {
            renderer.Dispose();
        }

        internal override void OnUpdate()
        {
        }

        internal override void OnRender()
        {
            renderer.RenderMesh(Parent.transform.Model);
        }
    }
}
