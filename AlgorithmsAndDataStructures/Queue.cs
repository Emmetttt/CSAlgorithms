using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class QueueLL<T>
    {
        LinkedList<T> _queue = new LinkedList<T>();

        public void Enqueue(T param)
        {
            _queue.AddLast(param);
        }
        public T Dequeue()
        {  
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T parameter = _queue.First.Value;
            _queue.RemoveFirst();

            return parameter;
        }

        public T Peek()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _queue.First.Value;
        }

        public int Count()
        {
            return _queue.Count;
        }

        public void Clear()
        {
            _queue.Clear();
        }
    }

    public class QueueArr<T>
    {
        T[] _queue = new T[0];
        int _size = 0;
        int _members = 0;
        int _head = 0;

        public void Enqueue(T param)
        {
            if (_size == 0)
            {
                GrowQueue(2);
            }
            else if (_size == _members)
            {
                GrowQueue(2 * _size);
            }
            
            if (_head + _members >= _size)
            {
                _queue[_head + _members - _size] = param;
            }
            else
            {
                _queue[_head + _members] = param;
            }
            _members++;
        }

        public T Dequeue()
        {
            T param = _queue[_head];
            _queue[_head] = default(T);
            if (_head == _size - 1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }
            _members--;
            return param;
        }

        private void GrowQueue(int newSize)
        {
            T[] newQueue = new T[newSize];
            int counter = 0;

            if (_size != 0)
            {
                int ptr = _head;
                while (ptr < _size)
                {
                    newQueue[counter] = _queue[ptr];
                    ptr++;
                    counter++;
                }

                ptr = 0;

                while (ptr < _head)
                {
                    newQueue[counter] = _queue[ptr];
                    ptr++;
                    counter++;
                }
            }
            _size = newSize;
            _head = 0;
            _queue = newQueue;
        }
    }
}
