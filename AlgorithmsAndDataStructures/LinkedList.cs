using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures
{
    public class LinkedList
    {
        // Operations - Add, Remove, Find, Enumerate
        public LinkedList()
        {
            Head.Next = Tail;
            Tail = null;
            Count = 0;
        }
        public LinkedList(int HeadVal)
        {
            Head.Next = Tail;
            Head.Value = HeadVal;
            Count = 1;
            Tail = Head;
        }
        public class SingleNode
        {
            public int Value { get; set; }
            public SingleNode Next { get; internal set; }
        }
        
        public class DoubleNode
        {
            public DoubleNode Previous { get; internal set; }
            public int Value { get; set; }
            public DoubleNode Next { get; internal set; }
        }

        public SingleNode Head = new SingleNode();
        public SingleNode Tail = new SingleNode();
        public int Count { get; private set; }
        
        public string PrintList()
        {
            string print = "";
            SingleNode ptr = Head;

            for (int i = 0; i < Count; i++)
            {
                print += ptr.Value;
                if (i != Count - 1)
                {
                    print += ", ";
                }

                ptr = ptr.Next;
            }

            return print;
        }

        public void AddFirst(int nodeVal)
        {
            SingleNode temp = Head;
            SingleNode node = new SingleNode { Value = nodeVal };

            Head = node;
            Head.Next = temp;

            Count++;
            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddEnd(int nodeVal)
        {
            SingleNode node = new SingleNode { Value = nodeVal };
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Count++;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    SingleNode ptr = Head;
                    while (ptr.Next != Tail)
                    {
                        ptr = ptr.Next;
                    }
                    ptr.Next = null;
                    Tail = ptr;
                }
            }

            Count--;
        }

        public void RemoveFront()
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
            }
            Count--;
        }

        IEnumerator<int> GetEnumerator()
        {
            SingleNode current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
