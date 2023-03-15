namespace FaddleEngine
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class Animator : Component
    {
        private Animation animation;

        internal override void OnAdd()
        {
        }

        internal override void OnRemove()
        {
        }

        internal override void OnUpdate()
        {
            if (animation == null) return;

            animation.Update(Parent.GetComponent<MeshRenderer>().renderer.mesh);
        }

        public void Play(Animation animation)
        {
            animation.OnPlay(Parent.GetComponent<MeshRenderer>().renderer.mesh);
            this.animation = animation;
        }
    }
}
