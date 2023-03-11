namespace FaddleEngine
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class Animator : Component
    {
        private Animation animation;

        public override void OnAdd()
        {
        }

        public override void OnRemove()
        {
        }

        public override void OnUpdate()
        {
            if (animation == null) return;

            animation.Update(Parent.GetComponent<MeshRenderer>().mesh);
        }

        public void Play(Animation animation)
        {
            animation.OnPlay(Parent.GetComponent<MeshRenderer>().mesh);
            this.animation = animation;
        }
    }
}
