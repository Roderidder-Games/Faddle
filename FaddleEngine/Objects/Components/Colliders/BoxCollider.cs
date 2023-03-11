namespace FaddleEngine
{
    public sealed class BoxCollider : Collider
    {
        public Vector2 bounds;

        public BoxCollider(Vector2 bounds)
        {
            this.bounds = bounds;
        }
    }
}
