using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public class Rigidbody : Component
    {
        public Shape shape;

        public Vector3 velocity;
        public Vector3 angularVelocity;

        public float gravity;

        public Rigidbody(Shape shape, float gravity = -1f)
        {
            this.shape = shape;
            this.gravity = gravity;
        }

        internal override void OnAdd()
        {
            velocity.y = gravity;
        }

        internal override void OnRemove()
        {

        }

        internal override void OnUpdate()
        {
            Transform.Position += velocity;
            Quaternion rot = Quaternion.FromEulerAngles(angularVelocity);
            Transform.Rotation += rot;
        }
    }
}
