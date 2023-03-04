using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public class StackList<T>
    {
        public int Count
        {
            get => items.Count;
        }

        private readonly List<T> items = new();

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Count > 0)
            {
                T temp = items[^1];
                items.RemoveAt(items.Count - 1);
                return temp;
            }
            else
            {
                return default;
            }
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
