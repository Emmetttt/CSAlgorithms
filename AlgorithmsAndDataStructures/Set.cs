using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class Set<T>: IEnumerable<T>
        where T: IComparable<T>
    {
        // A set is a collection of comparable objects
        // No duplicate items allowed
        public Set()
        {
        }
        public Set(IEnumerable<T> items)
        {
            // Constructed from IEnumerable
            _items.AddRange(items);
        }
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Item already exists in Set.");
            }

            _items.Add(item);
        }
        
        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }
        public List<T> Show()
        {
            _items.Sort();
            return _items;
        }
        public Set<T> Union(Set<T> otherSet)
        {
            // Returned set contains unique items of set1 and current set
            Set<T> result = new Set<T>(_items); // Contains all items in current set
            result.AddRangeSkipDuplicates(otherSet._items); // Add uniques from other set

            return result;
        }
        private void AddRangeSkipDuplicates(List<T> addSet)
        {
            foreach (T item in addSet)
            {
                if (!_items.Contains(item))
                {
                    _items.Add(item);
                }
            }
        }
        public Set<T> Intersection(Set<T> otherSet)
        {
            // Returns common items in otherSet and current Set
            Set<T> resultSet = new Set<T>();
            foreach (T item in otherSet._items)
            {
                if (_items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }
            return resultSet;
        }
        public Set<T> Difference(Set<T> otherSet)
        {
            // Returns items that are in our set but not in otherSet
            Set<T> resultSet = new Set<T>();
            foreach (T item in _items)
            {
                if (!otherSet._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }
            return resultSet;
        }
        public Set<T> SymmetricDifference(Set<T> otherSet)
        {
            // Returns all items that are in either set but not both
            // Difference between the intersection and union
            Set<T> intersection = Intersection(otherSet);
            Set<T> union = Union(otherSet);
            return union.Difference(intersection);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
