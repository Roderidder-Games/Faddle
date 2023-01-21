using System.Collections.Generic;

namespace FaddleEngine
{
    internal class ObjectManager
    {
        private readonly List<GameObject> gameObjects = new List<GameObject>();

        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Remove(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public void OnRender()
        {
            gameObjects.ForEach((g) => g.OnRender());
        }

        public void Update()
        {
            gameObjects.ForEach((g) => g.Update());
        }
    }
}
