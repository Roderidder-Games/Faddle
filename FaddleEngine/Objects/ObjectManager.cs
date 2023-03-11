using System.Collections.Generic;

namespace FaddleEngine
{
    internal static class ObjectManager
    {
        private static readonly List<GameObject> gameObjects = new();

        public static void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public static void Remove(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public static void OnRender()
        {
            gameObjects.ForEach((g) => g.OnRender());
        }

        public static void Update()
        {
            gameObjects.ForEach((g) => g.Update());
        }
    }
}
