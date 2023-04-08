using System.Collections.Generic;

namespace FaddleEngine
{
    internal static class ObjectManager
    {
        private static readonly List<IObject> objects = new();

        public static void Add(IObject @object)
        {
            objects.Add(@object);
        }

        public static void Remove(IObject @object)
        {
            objects.Remove(@object);
        }

        public static void OnRender()
        {
            objects.ForEach((g) => g.OnRender());
        }

        public static void Update()
        {
            objects.ForEach((g) => g.Update());
        }
    }
}
