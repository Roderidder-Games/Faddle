namespace FaddleEngine
{
    public abstract class Component
    {
        public GameObject Parent { get; private set; }

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
        public abstract void OnInit();
        /// <summary>
        /// Called every frame the component has a parent GameObject.
        /// </summary>
        public abstract void OnUpdate();
        /// <summary>
        /// Called right before the component is removed from it's parent GameObject.
        /// </summary>
        public abstract void OnRemove();
        public virtual void OnRender()
        {

        }
    }
}
