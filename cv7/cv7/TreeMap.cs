using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv7
{
    internal class TreeMap<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node<TKey, TValue> root;

        private int _count = 0;
        public int Count { get => _count;}

        private void ToArray(Node<TKey, TValue>[] arr, ref int idx, Node<TKey, TValue> current)
        {
            if (current == null) { return; }
            arr[idx++] = current;
            ToArray(arr, ref idx, current.Left);
            ToArray(arr, ref idx, current.Right);
        }

        public Node<TKey, TValue>[] ToArray()
        {
            Node<TKey, TValue>[] result = new Node<TKey, TValue>[Count];
            int idx = 0;
            ToArray(result, ref idx, root);
            return result;
            
        }

        private void Set(TKey key, TValue value, Node<TKey, TValue> current)
        {
            if (current.Key.CompareTo(key) < 0)
            {
                if (current.Right == null)
                {
                    current.Right = new Node<TKey, TValue>(key, value);
                } else
                {
                    Set(key, value, current.Right);
                }
            } else if (current.Key.CompareTo(key) > 0)
            {
                if (current.Left == null)
                {
                    current.Left = new Node<TKey, TValue>(key, value);
                } else
                {
                    Set(key, value, current.Left);
                }
            } else
            {
                current.Value = value;
            }
        }

        private TValue Get(TKey key, Node<TKey, TValue> current)
        {
            if (current.Key.CompareTo(key) == 0) return current.Value;

            if (current.Key.CompareTo(key) < 0)
            {
                return Get(key, current.Right);
            } else
            {
                return Get(key, current.Left);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return Get(key, root);
            }
            set
            {
                _count++;
                if (root == null)
                {
                    root = new Node<TKey, TValue>(key, value);
                    return;
                }

                Set(key, value, root);
            }
        }

    }
}
