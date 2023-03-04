using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public enum SceneLoadMode
    {
        Additive = 0,
        Singular = 1
    }

    public static class SceneManager
    {
        private static SceneLoadMode loadMode = SceneLoadMode.Singular;
        public static SceneLoadMode LoadMode
        {
            get => loadMode;
            set
            {
                loadMode = value;
                ShiftLoadMode();
            }
        }

        private static readonly StackList<Scene> scenes = new();

        public static void Load(Scene scene)
        {
            if (loadMode == SceneLoadMode.Singular)
            {
                if (scenes.Count > 0)
                {
                    scenes.Pop().Unload();
                }
                scenes.Push(scene);
                scene.Load();
            }
            else if (loadMode == SceneLoadMode.Additive) 
            {
                scenes.Push(scene);
                scene.Load();
            }
        }

        public static void Pop()
        {
            Scene scene = scenes.Pop();

            if (scene != default(Scene))
            {
                scene.Unload();
            }
        }

        public static void Remove(Scene scene)
        {
            scenes.Remove(scene);
            scene.Unload();
        }

        private static void ShiftLoadMode()
        {
            if (loadMode == SceneLoadMode.Singular)
            {
                if (scenes.Count >= 2)
                {
                    for (int i = 1; i < scenes.Count; i++)
                    {
                        scenes.Pop().Unload();
                    }
                }
            }
        }
    }
}
