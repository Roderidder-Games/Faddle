using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public enum ShapeType
    {
        Box,
        Sphere
    }

    public struct Shape
    {
        public ShapeType type;

        public Vector3 size;

        public float radius;
    }
}
