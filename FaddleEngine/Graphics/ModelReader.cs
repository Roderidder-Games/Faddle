using System.Globalization;
using System.Linq;

namespace FaddleEngine
{
    public static class ModelReader
    {
        public static Mesh ReadFromFile(string path)
        {
            string file = FileSystem.LoadTextFile(path);

            string[] lines = file.Split('\n');

            int vertexCount = file.Count((c) => c == 'v');
            int indexCount = file.Count((c) => c == 't');

            Vertex[] vertices = new Vertex[vertexCount];
            int[] indices = new int[indexCount * 3];

            int vertexIndex = 0;
            int indexIndex = 0;

            foreach (string line in lines)
            {
                if (line.StartsWith('v'))
                {
                    string curLine = line[2..];

                    string[] vertexValues = curLine.Split(' ');

                    vertices[vertexIndex] = new Vertex(
                        new Vector3(float.Parse(vertexValues[0], NumberStyles.Any, CultureInfo.InvariantCulture), float.Parse(vertexValues[1], NumberStyles.Any, CultureInfo.InvariantCulture), float.Parse(vertexValues[2], NumberStyles.Any, CultureInfo.InvariantCulture)), 
                        new Vector2(float.Parse(vertexValues[3], NumberStyles.Any, CultureInfo.InvariantCulture), float.Parse(vertexValues[4], NumberStyles.Any, CultureInfo.InvariantCulture))
                    );

                    vertexIndex++;
                }
                else if (line.StartsWith('t'))
                {
                    string curLine = line[2..];

                    string[] triangleValues = curLine.Split(' ');

                    indices[indexIndex] = int.Parse(triangleValues[0]);
                    indices[indexIndex + 1] = int.Parse(triangleValues[1]);
                    indices[indexIndex + 2] = int.Parse(triangleValues[2]);

                    indexIndex += 3;
                }
            }

            return new Mesh(vertices, indices);
        }
    }
}
