using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            gameObjects.ForEach((g) => Application.Instance.objectManager.Add(g));
        }

        internal void Unload()
        {
            gameObjects.ForEach((g) => Application.Instance.objectManager.Remove(g));
        }
    }
}
