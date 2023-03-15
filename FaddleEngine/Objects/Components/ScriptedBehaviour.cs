namespace FaddleEngine
{
    public abstract class ScriptedBehaviour : Component
    {
        internal override void OnAdd()
        {
            Add();
        }

        internal override void OnRemove()
        {
            Remove();
        }

        internal override void OnRender()
        {
            Render();
        }

        internal override void OnUpdate()
        {
            Update();
        }

        protected abstract void Add();
        protected abstract void Remove();
        protected virtual void Render()
        {

        }

        protected abstract void Update();
    }
}
