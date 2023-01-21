namespace FaddleEngine
{
    public sealed class Transform : Component
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public static Transform Zero => new Transform(Vector3.Zero, Vector3.Zero, Vector3.Zero);

        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public override void OnInit()
        {
        }

        public override void OnRemove()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}
