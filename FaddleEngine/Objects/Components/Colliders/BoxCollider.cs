using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public class BoxCollider : Collider
    {
        public Vector2 bounds;

        public BoxCollider(Vector2 bounds)
        {
            this.bounds = bounds;
        }
    }
}
