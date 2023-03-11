namespace FaddleEngine
{
    [RequireComponent(typeof(Collider))]
    public sealed class Rigidbody : Component
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

        internal override void OnAdd()
        {

        }

        internal override void OnRemove()
        {

        }

        internal override void OnUpdate()
        {
            if (!kinematic)
            {

            }
        }
    }
}
