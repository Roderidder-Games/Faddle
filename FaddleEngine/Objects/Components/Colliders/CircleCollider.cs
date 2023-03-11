namespace FaddleEngine
{
    public sealed class CircleCollider : Collider
    {
        public float radius;

        public CircleCollider(float radius)
        {
            this.radius = radius;
        }
    }
}
