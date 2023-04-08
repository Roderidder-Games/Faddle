namespace FaddleEngine
{
    public sealed class MeshRenderer : Component
    {

        internal readonly MeshRenderObject renderer;

        public MeshRenderer(Mesh mesh, Shader shader, int zIndex = 0, bool isStatic = true, Camera camera = null)
        {
            renderer = new MeshRenderObject(mesh, shader, isStatic, camera, zIndex);
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
            renderer.SetModel(Parent.transform.Model);
            renderer.Render();
        }
    }
}
