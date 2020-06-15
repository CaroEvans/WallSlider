using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    public class CircularList<T> : IEnumerable<T>
    {
        private readonly Queue<T> _queue;
        private readonly int _capacity;

        public CircularList(int capacity)
        {
            _queue = new Queue<T>(capacity);
            _capacity = capacity;
        }

        public void Add(T item)
        {
            if (_queue.Count == _capacity)
                _queue.Dequeue();
            _queue.Enqueue(item);
        }

        public T[] ToArray()
        {
            return _queue.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _queue.ToArray())
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
