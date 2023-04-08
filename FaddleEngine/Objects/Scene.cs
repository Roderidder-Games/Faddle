using System.Collections.Generic;

namespace FaddleEngine
{
    public abstract class Scene
    {
        private readonly List<IObject> objects;

        public Scene()
        {
            objects = new List<IObject>();
        }

        public void Add(IObject @object)
        {
            objects.Add(@object);
        }

        internal void Load()
        {
            objects.ForEach(ObjectManager.Add);
        }

        internal void Unload()
        {
            objects.ForEach(ObjectManager.Remove);
        }
    }
}
