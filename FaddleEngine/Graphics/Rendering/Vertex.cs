using System;

namespace FaddleEngine.Graphics
{
    public readonly struct VertexAttribute
    {
        public readonly string name;
        public readonly int index;
        public readonly int componentCount;
        public readonly int offset;

        public VertexAttribute(string name, int index, int componentCount, int offset)
        {
            this.name = name;
            this.index = index;
            this.componentCount = componentCount;
            this.offset = offset;
        }
    }

    public sealed class VertexInfo
    {
        public readonly Type type;
        public readonly int byteSize;
        public readonly VertexAttribute[] vertexAttributes;

        public VertexInfo(Type type, params VertexAttribute[] vertexAttributes)
        {
            this.type = type;
            byteSize = 0;

            this.vertexAttributes = vertexAttributes;

            for (int i = 0; i < this.vertexAttributes.Length; i++)
            {
                VertexAttribute attrib = this.vertexAttributes[i];
                byteSize += attrib.componentCount * sizeof(float);
            }
        }
    }

    public readonly struct Vertex
    {
        public static readonly VertexInfo VertexInfo = new VertexInfo(
            typeof(Vertex),
            new VertexAttribute("Position", 0, 3, 0),
            new VertexAttribute("TexCoord", 1, 2, 3 * sizeof(float))
        );

        public readonly Vector3 position;
        public readonly Vector2 texCoord;

        public Vertex(Vector3 position, Vector2 texCoord)
        {
            this.position = position;
            this.texCoord = texCoord;
        }
    }
}
