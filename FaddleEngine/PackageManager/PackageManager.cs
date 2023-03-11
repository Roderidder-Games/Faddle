using System.Collections.Generic;

namespace FaddleEngine
{
    public static class PackageManager
    {
        private static readonly List<FaddlePackage> packages = new();

        public static bool TryAddPackage(FaddlePackage package)
        {
            if (packages.Find((p) => p.GetType() == package.GetType()) != null)
            {
                Log.Error($"Package {package.name} is already added to the game.");
                return false;
            }

            packages.Add(package);
            package.OnAdd();
            return true;
        }

        internal static void OnUpdate()
        {
            packages.ForEach((p) => p.OnUpdate());
        }

        internal static void OnQuit()
        {
            packages.ForEach((p) => p.OnQuit());
        }

        internal static void OnRender()
        {
            packages.ForEach((p) => p.OnRender());
        }
    }
}
