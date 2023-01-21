namespace FaddleEngine.Graphics
{
    public class Mesh
    {
        public readonly Vertex2D[] vertices;
        public readonly int[] indices;

        public Mesh(Vertex2D[] vertices, int[] indices)
        {
            this.vertices = vertices;
            this.indices = indices;
        }
    }
}
