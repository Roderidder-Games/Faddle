using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FaddleEngine
{
    public sealed class Canvas : IObject
    {
        public readonly string name;

        private readonly List<UIElement> elements = new();

        private readonly FaddleEvent onRender = new();
        private readonly FaddleEvent onUpdate = new();

        public Canvas()
        {
            this.name = "Canvas";
            ObjectManager.Add(this);
        }

        public Canvas(Scene scene)
        {
            this.name = "Canvas";
            scene.Add(this);
            ObjectManager.Add(this);
        }

        public Canvas(string name)
        {
            this.name = name;
            ObjectManager.Add(this);
        }

        public Canvas(string name, Scene scene)
        {
            this.name = name;
            scene.Add(this);
            ObjectManager.Add(this);
        }

        internal void Dispose()
        {
            elements.ForEach((e) => e.OnRemove());
        }

        void IObject.OnRender()
        {
            onRender.Fire();
        }

        void IObject.Update()
        {
            onUpdate.Fire();
        }

        public bool AddElement(UIElement element)
        {
            RequireComponentAttribute attrib = element.GetType().GetCustomAttribute<RequireComponentAttribute>();
            if (attrib != null)
            {
                if (!TryGetElement(attrib.type, out _))
                {
                    Log.Error($"Missing {attrib.type.Name} component on canvas {name}!");
                }
            }

            elements.Add(element);
            if (element.AddParent(this))
            {
                onUpdate.AddListener(element.OnUpdate);
                onRender.AddListener(element.OnRender);
                element.OnAdd();
                return true;
            }
            return false;
        }

        public bool TryRemoveElement<T>() where T : UIElement
        {
            UIElement e = elements.Find((c) => (c.GetType() == typeof(T)) || (c.GetType().BaseType == typeof(T)));

            if (e != null)
            {
                e.OnRemove();
                onUpdate.RemoveListener(e.OnUpdate);
                e.RemoveParent();
                elements.Remove(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public T GetElement<T>() where T : UIElement => (T)elements.Find((c) => (c.GetType().BaseType == typeof(T)) || (c.GetType() == typeof(T)));
        public bool TryGetElement<T>(out T component) where T : UIElement
        {
            UIElement e = elements.Find((c) => (c.GetType() == typeof(T)) || (c.GetType().BaseType == typeof(T)));

            if (e != null)
            {
                component = e as T;
                return true;
            }
            else
            {
                component = null;
                return false;
            }
        }

        public bool TryGetElement(Type type, out UIElement component)
        {
            UIElement e = elements.Find((c) => (c.GetType() == type) || (c.GetType().BaseType == type));

            if (e != null)
            {
                component = e;
                return true;
            }
            else
            {
                component = null;
                return false;
            }
        }

        public void Unload()
        {
            elements.ForEach((c) => c.OnRemove());
            ObjectManager.Remove(this);
        }
    }
}
