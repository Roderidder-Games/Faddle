namespace FaddleEngine
{
    public abstract class FaddlePackage
    {
        internal readonly string name;

        public FaddlePackage(string name)
        {
            this.name = name;
        }

        internal void OnAddedInt()
        {
            OnAdd();
        }

        public abstract void OnAdd();
        public abstract void OnUpdate();
        public abstract void OnRender();
        public abstract void OnQuit();
    }
}
