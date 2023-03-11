using FaddleEngine.Events;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FaddleEngine
{
    public sealed class GameObject
    {
        public readonly string name;
        public readonly Transform transform;

        private readonly List<Component> components = new();

        private readonly FaddleEvent onRender = new();
        private readonly FaddleEvent onUpdate = new();

        #region CONSTRUCTORS

        public GameObject()
        {
            this.name = "GameObject";
            transform = Transform.Zero;
            AddComponent(transform);
            ObjectManager.Add(this);
        }

        public GameObject(string name)
        {
            this.name = name;
            transform = Transform.Zero;
            AddComponent(transform);
            ObjectManager.Add(this);
        }

        public GameObject(Transform transform)
        {
            this.name = "GameObject";
            this.transform = transform;
            ObjectManager.Add(this);
        }

        public GameObject(string name, Transform transform)
        {
            this.name = name;
            this.transform = transform;
            AddComponent(transform);
            ObjectManager.Add(this);
        }

        public GameObject(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.name = "GameObject";
            transform = new Transform(position, rotation, scale);
            AddComponent(transform);
            ObjectManager.Add(this);
        }

        public GameObject(string name, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.name = name;
            transform = new Transform(position, rotation, scale);
            AddComponent(transform);
            ObjectManager.Add(this);
        }

        public GameObject(Scene scene)
        {
            this.name = "GameObject";
            transform = Transform.Zero;
            AddComponent(transform);
            scene.Add(this);
        }

        public GameObject(string name, Scene scene)
        {
            this.name = name;
            transform = Transform.Zero;
            AddComponent(transform);
            scene.Add(this);
        }

        public GameObject(Transform transform, Scene scene)
        {
            this.name = "GameObject";
            this.transform = transform;
            scene.Add(this);
        }

        public GameObject(string name, Transform transform, Scene scene)
        {
            this.name = name;
            this.transform = transform;
            AddComponent(transform);
            scene.Add(this);
        }

        public GameObject(Vector3 position, Vector3 rotation, Vector3 scale, Scene scene)
        {
            this.name = "GameObject";
            transform = new Transform(position, rotation, scale);
            AddComponent(transform);
            scene.Add(this);
        }

        public GameObject(string name, Vector3 position, Vector3 rotation, Vector3 scale, Scene scene)
        {
            this.name = name;
            transform = new Transform(position, rotation, scale);
            AddComponent(transform);
            scene.Add(this);
        }

        #endregion

        #region INTERNAL METHODS

        internal void OnRender()
        {
            onRender.Fire();
        }

        internal void Update()
        {
            onUpdate.Fire();
        }

        internal void Dispose()
        {
            components.ForEach((c) => c.OnRemove());
        }

        #endregion

        #region COMPONENT LOGIC

        public bool AddComponent(Component component, bool warnIfExists = true)
        {
            if (components.Find((c) => (c.GetType() == component.GetType()) || (c.GetType().BaseType == component.GetType())) == null)
            {
                RequireComponentAttribute attrib = component.GetType().GetCustomAttribute<RequireComponentAttribute>();
                if (attrib != null)
                {
                    if (!TryGetComponent(attrib.type, out _))
                    {
                        Log.Error($"Missing {attrib.type.Name} component on {name}!");
                    }
                }

                components.Add(component);
                if (component.AddParent(this))
                {
                    onUpdate.AddListener(component.OnUpdate);
                    onRender.AddListener(component.OnRender);
                    component.OnAdd();
                    return true;
                }
                return false;
            }
            else
            {
                if (warnIfExists)
                {
                    Log.Warn($"A component of type {component.GetType().Name} already exists on GameObject \"{name}\".");
                }
                return false;
            }
        }

        public bool TryRemoveComponent<T>() where T : Component
        {
            Component c = components.Find((c) => (c.GetType() == typeof(T)) || (c.GetType().BaseType == typeof(T)));

            if (c != null)
            {
                c.OnRemove();
                onUpdate.RemoveListener(c.OnUpdate);
                c.RemoveParent();
                components.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        public T GetComponent<T>() where T : Component => (T)components.Find((c) => (c.GetType().BaseType == typeof(T)) || (c.GetType() == typeof(T)));
        public bool TryGetComponent<T>(out T component) where T : Component
        {
            Component c = components.Find((c) => (c.GetType() == typeof(T)) || (c.GetType().BaseType == typeof(T)));

            if (c != null)
            {
                component = c as T;
                return true;
            }
            else
            {
                component = null;
                return false;
            }
        }

        public bool TryGetComponent(Type type, out Component component)
        {
            Component c = components.Find((c) => (c.GetType() == type) || (c.GetType().BaseType == type));

            if (c != null)
            {
                component = c;
                return true;
            }
            else
            {
                component = null;
                return false;
            }
        }

        #endregion

        public void Unload()
        {
            components.ForEach((c) => c.OnRemove());
            ObjectManager.Remove(this);
        }
    }
}
