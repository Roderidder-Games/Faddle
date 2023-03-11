using System.Collections.Generic;

namespace FaddleEngine
{
    public abstract class Scene
    {
        private readonly List<GameObject> gameObjects;

        public Scene()
        {
            gameObjects = new List<GameObject>();
        }

        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        internal void Load()
        {
            gameObjects.ForEach((g) => ObjectManager.Add(g));
        }

        internal void Unload()
        {
            gameObjects.ForEach((g) => ObjectManager.Remove(g));
        }
    }
}
