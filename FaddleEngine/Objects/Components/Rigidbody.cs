namespace FaddleEngine
{
    [RequireComponent(typeof(Collider))]
    public class Rigidbody : Component
    {
        public float mass;
        public bool kinematic;

        public Vector3 linearVelocity;

        public Rigidbody(float mass, bool kinematic)
        {
            this.mass = mass;
            this.kinematic = kinematic;
            linearVelocity = Vector3.Zero;
        }

        public override void OnAdd()
        {

        }

        public override void OnRemove()
        {

        }

        public override void OnUpdate()
        {
            if (!kinematic)
            {

            }
        }
    }
}
