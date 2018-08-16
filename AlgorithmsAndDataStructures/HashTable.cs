using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class HashTable<K, V>
    {
        public HashTable(int n)
        {
            HashTableNode<string, V>[] _arr = new HashTableNode<string, V>[n];
            _count = n;
        }
        public HashTable()
        {
        }
        // Storage of key/value pairs
        // Each key is unique
        // Key is mapped to an index
        // Hashing derives a fixed size result from an input
        //      Algorithm must be Stable, Uniform, Efficient and Secure
        const double _fillFactor = 0.75; // If more than 75% of index's filled, grow
        HashTableNode<string, V>[] _arr = new HashTableNode<string, V>[0];
        int _count = 0;
        int _members = 0;

        //public V Find(string Key)
        //{
        //    int hash = FoldHash(Key);
        //    int index = hash % _count;
        //    V result = _arr[index]._items.Find(Key); //NOT FINISH TODO
        //    return result;
        //}
        public void Insert(string Key, V Value)
        {
            HashTableNodePair<string, V> KVPair = new HashTableNodePair<string, V>();
            KVPair.Key = Key;
            KVPair.Value = Value;

            int hash = FoldHash(Key);
            int index = hash % _count;
            checkFillFactor();

            _arr[index].Add(KVPair);
            _members++;
        }

        public void checkFillFactor()
        {
            if (_members / _count > _fillFactor)
            {
                int newCount = _count * 2;
                HashTableNode<string, V>[] newArr = new HashTableNode<string, V>[newCount];
                _arr.CopyTo(newArr, 0);
            }
        }

        public static int NaiveHash(string input)
        {
            // Terrible approach, add the ascii value of each char and
            // return the int. Insecure and not uniform.
            byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
            int hash = 0;
            foreach (byte character in asciiBytes)
            {
                hash += character;
            }

            return hash;
        }

        public static int FoldHash(string input)
        {
            unchecked
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
                int hash = 0;
                int count = 0;
                string fold = "";
                foreach (byte character in asciiBytes)
                {
                    fold += character.ToString();
                    count++;
                    if (count == 4)
                    {
                        hash = hash + int.Parse(fold);
                        fold = "";
                        count = 0;
                    }
                }

                if (fold != "")
                {
                    hash = hash + int.Parse(fold);
                }

                return Math.Abs(hash);
            }
        }
    }
    
    public class HashTableNode<TKey, TValue>
    {
        public LinkedList<HashTableNodePair<TKey, TValue>> _items;

        public void Add(HashTableNodePair<TKey, TValue> KVPair)
        {
            _items.AddLast(KVPair);
        }
    }
    public class HashTableNodePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
