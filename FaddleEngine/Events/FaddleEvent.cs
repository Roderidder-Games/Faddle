using System.Collections.Generic;

namespace FaddleEngine
{
    public sealed class FaddleEvent
    {
        public delegate void EventListener();

        private readonly List<EventListener> listeners = new();

        public void AddListener(EventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(EventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Fire()
        {
            listeners.ForEach((l) => l());
        }
    }

    public sealed class FaddleEvent<T>
    {
        public delegate void EventListener(T arg1);

        private readonly List<EventListener> listeners = new();

        public void AddListener(EventListener listener)
        {
            listeners.Add(listener);
        }

        public void Fire(T arg1)
        {
            listeners.ForEach((l) => l(arg1));
        }
    }

    public sealed class FaddleEvent<T1, T2>
    {
        public delegate void EventListener(T1 arg1, T2 arg2);

        private readonly List<EventListener> listeners = new();

        public void AddListener(EventListener listener)
        {
            listeners.Add(listener);
        }

        public void Fire(T1 arg1, T2 arg2)
        {
            listeners.ForEach((l) => l(arg1, arg2));
        }
    }
}
