using FaddleEngine.Events;
using System.Collections.Generic;

namespace FaddleEngine
{
    public class GameObject
    {
        public readonly string name;
        public readonly Transform transform;

        private readonly List<Component> components = new List<Component>();

        private readonly FaddleEvent onRender = new FaddleEvent();
        private readonly FaddleEvent onUpdate = new FaddleEvent();

        #region CONSTRUCTORS

        public GameObject()
        {
            this.name = "GameObject";
            transform = Transform.Zero;
            AddComponent(transform);
            Application.Instance.objectManager.Add(this);
        }

        public GameObject(string name)
        {
            this.name = name;
            transform = Transform.Zero;
            AddComponent(transform);
            Application.Instance.objectManager.Add(this);
        }

        public GameObject(Transform transform)
        {
            this.name = "GameObject";
            this.transform = transform;
            Application.Instance.objectManager.Add(this);
        }

        public GameObject(string name, Transform transform)
        {
            this.name = name;
            this.transform = transform;
            AddComponent(transform);
            Application.Instance.objectManager.Add(this);
        }

        public GameObject(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.name = "GameObject";
            transform = new Transform(position, rotation, scale);
            AddComponent(transform);
            Application.Instance.objectManager.Add(this);
        }

        public GameObject(string name, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.name = name;
            transform = new Transform(position, rotation, scale);
            AddComponent(transform);
            Application.Instance.objectManager.Add(this);
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

        #endregion

        #region COMPONENT LOGIC

        public bool AddComponent(Component component, bool warnIfExists = true)
        {
            if (components.Find((c) => c.GetType() == component.GetType()) == null)
            {
                components.Add(component);
                if (component.AddParent(this))
                {
                    onUpdate.AddListener(component.OnUpdate);
                    onRender.AddListener(component.OnRender);
                    component.OnInit();
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

        public bool TryRemoveComponent<T>(out Component component) where T : Component
        {
            Component c = components.Find((c) => c.GetType() == typeof(T));

            if (c != null)
            {
                c.OnRemove();
                onUpdate.RemoveListener(c.OnUpdate);
                c.RemoveParent();
                component = c;
                components.Remove(c);
                return true;
            }
            else
            {
                component = null;
                return false;
            }
        }

        public Component GetComponent<T>() where T : Component => components.Find((c) => c.GetType() == typeof(T));
        public bool TryGetComponent<T>(out Component component) where T : Component
        {
            Component c = components.Find((c) => c.GetType() == typeof(T));

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
    }
}
