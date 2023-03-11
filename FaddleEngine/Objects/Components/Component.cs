namespace FaddleEngine
{
    public abstract class Component
    {
        public GameObject Parent { get; private set; }
        public Transform Transform => Parent.transform;

        internal bool AddParent(GameObject parent)
        {
            if (Parent != null)
            {
                Log.Error("This component is already attached to a GameObject.");
                return false;
            }
            Parent = parent;
            return true;
        }

        internal void RemoveParent()
        {
            Parent = null;
        }
        /// <summary>
        /// Called on the first frame on which the component inhabits the GameObject.
        /// </summary>
        internal abstract void OnAdd();
        /// <summary>
        /// Called every frame the component has a parent GameObject.
        /// </summary>
        internal abstract void OnUpdate();
        /// <summary>
        /// Called right before the component is removed from it's parent GameObject.
        /// </summary>
        internal abstract void OnRemove();
        internal virtual void OnRender()
        {

        }
    }
}
