using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T item)
        {
            _list.AddLast(item);
        }

        public T Pop()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("This stack is empty");
            }

            T value = _list.Last.Value;
            _list.RemoveLast();

            return value;
        }
        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("This stack is empty");
            }

            return _list.Last.Value;
        }

        public int Count()
        {
            return _list.Count;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public static int Postfix(string expression)
        {
            int popped = 0;
            Stack<int> stack = new Stack<int>();
            foreach (char token in expression)
            {
                if (int.TryParse(token.ToString(), out int tokenInt))
                {
                    stack.Push(tokenInt);
                }
                else
                {
                    popped = stack.Pop();
                    switch (token.ToString())
                    {
                        case "-":
                            stack.Push(stack.Pop() - popped);
                            break;
                        case "+":
                            stack.Push(stack.Pop() + popped);
                            break;
                        case "*":
                            stack.Push(stack.Pop() * popped);
                            break;
                        case "/":
                            stack.Push(stack.Pop() / popped);
                            break;
                    }
                }
            }

            return stack.Pop();
        }
    }
}
