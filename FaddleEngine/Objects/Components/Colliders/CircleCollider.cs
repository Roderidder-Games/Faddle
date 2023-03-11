using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public class CircleCollider : Collider
    {
        public float radius;

        public CircleCollider(float radius)
        {
            this.radius = radius;
        }
    }
}
