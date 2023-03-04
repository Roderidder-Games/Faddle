using System;

namespace FaddleEngine.Graphics
{
    public class Mesh
    {
        public Vertex[] vertices;
        public int[] indices;

        public Texture texture;

        public Mesh()
        {
            vertices = Array.Empty<Vertex>();
            indices = Array.Empty<int>();
            texture = null;
        }

        public Mesh(Vertex[] vertices, int[] indices, Texture texture = null)
        {
            this.vertices = vertices;
            this.indices = indices;
            this.texture = texture;
        }

        public void SetVertices(Vertex[] vertices)
        {
            this.vertices = vertices;
        }

        public void SetIndices(int[] indices)
        {
            this.indices = indices;
        }

        public void SetTexture(Texture texture)
        {
            this.texture = texture;
        }

        public static Mesh Cube =>
            new(
                new Vertex[]
                {
                    new Vertex(new Vector3(-0.5f, -0.5f, 0.5f), new Vector2(0f, 0f)), //Front-Bottom-Left
                    new Vertex(new Vector3(0.5f, -0.5f, 0.5f), new Vector2(1f, 0f)), //Front-Bottom-Right
                    new Vertex(new Vector3(-0.5f, 0.5f, 0.5f), new Vector2(0f, 1f)), //Front-Upper-Left
                    new Vertex(new Vector3(0.5f, 0.5f, 0.5f), new Vector2(1f, 1f)), //Front-Upper-Right
                    new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), //Back-Bottom-Left
                    new Vertex(new Vector3(0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), //Back-Bottom-Right
                    new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), new Vector2(1f, 1f)), //Back-Upper-Left
                    new Vertex(new Vector3(0.5f, 0.5f, -0.5f), new Vector2(0f, 1f)), //Back-Upper-Right
                    new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), //Left-Bottom-Left
                    new Vertex(new Vector3(-0.5f, -0.5f, 0.5f), new Vector2(1f, 0f)), //Left-Bottom-Right
                    new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), new Vector2(0f, 1f)), //Left-Upper-Left
                    new Vertex(new Vector3(-0.5f, 0.5f, 0.5f), new Vector2(1f, 1f)), //Left-Upper-Right
                    new Vertex(new Vector3(0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), //Right-Bottom-Left
                    new Vertex(new Vector3(0.5f, -0.5f, 0.5f), new Vector2(0f, 0f)), //Right-Bottom-Right
                    new Vertex(new Vector3(0.5f, 0.5f, -0.5f), new Vector2(1f, 1f)), //Right-Upper-Left
                    new Vertex(new Vector3(0.5f, 0.5f, 0.5f), new Vector2(0f, 1f)), //Right-Upper-Right
                    new Vertex(new Vector3(-0.5f, 0.5f, 0.5f), new Vector2(0f, 0f)), //Top-Bottom-Left
                    new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), new Vector2(0f, 1f)), //Top-Bottom-Right
                    new Vertex(new Vector3(0.5f, 0.5f, 0.5f), new Vector2(1f, 0f)), //Top-Upper-Left
                    new Vertex(new Vector3(0.5f, 0.5f, -0.5f), new Vector2(1f, 1f)), //Top-Upper-Right
                    new Vertex(new Vector3(-0.5f, -0.5f, 0.5f), new Vector2(0f, 1f)), //Bottom-Bottom-Left
                    new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), //Bottom-Bottom-Right
                    new Vertex(new Vector3(0.5f, -0.5f, 0.5f), new Vector2(1f, 1f)), //Bottom-Upper-Left
                    new Vertex(new Vector3(0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), //Bottom-Upper-Right
                },
                new int[]
                {
                    0, 2, 3,
                    0, 3, 1,
                    4, 6, 7,
                    4, 7, 5,
                    8, 10, 11,
                    8, 11, 9,
                    12, 14, 15,
                    12, 15, 13,
                    16, 18, 19,
                    16, 19, 17,
                    20, 22, 23,
                    20, 23, 21
                }
            );

        public static Mesh Square =>
            new(
                new Vertex[]
                {
                    new Vertex(new Vector3(-0.5f, -0.5f, 0.5f), new Vector2(0f, 0f)), //Bottom-Left
                    new Vertex(new Vector3(0.5f, -0.5f, 0.5f), new Vector2(1f, 0f)), //Bottom-Right
                    new Vertex(new Vector3(-0.5f, 0.5f, 0.5f), new Vector2(0f, 1f)), //Upper-Left
                    new Vertex(new Vector3(0.5f, 0.5f, 0.5f), new Vector2(1f, 1f)), //Upper-Right
                },
                new int[]
                {
                    0, 2, 3,
                    0, 3, 1
                }
            );
    }
}
