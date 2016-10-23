using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trecizadatak
{

    public interface IGenericList<X> : IEnumerable<X>
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(X item);

        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(X item);

        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);

        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        X GetElement(int index);

        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(X item);

        /// <summary >
        /// Readonly property . Gets the number of items contained in the collection.
        /// /// </ summary >
        int Count { get; }

        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();

        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(X item);
    }

    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        /// <summary>
        /// number of elements in array
        /// </summary>
        int vel = 0;

        public void init()
        {
            _internalStorage = new X[4];
            vel = 0;
        }
        public void init(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new X[initialSize];
                vel = initialSize;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(X item)
        {
            if (vel == _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, 2 * vel);
            }
            _internalStorage[vel++] = item;
        }


        public bool RemoveAt(int index)
        {
            if (index >= vel)
                return false;
            for (int i = index; i < vel - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            Array.Resize(ref _internalStorage, _internalStorage.Length - 1);
            vel -= 1;
            return true;
        }


        public bool Remove(X item)
        {
            for (int i = 0; i < vel; i++)
            {
                if (((IComparable)(_internalStorage[i])).CompareTo(item) == 0)
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }


        public X GetElement(int index)
        {
            if (index < vel && index >= 0)
                return _internalStorage[index];
            else
                throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < vel; i++)
            {
                if (((IComparable)(_internalStorage[i])).CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return vel;
            }
        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
            vel = 0;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) == -1)
                return false;
            return true;
        }

        // IEnumerable <X> implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        int k;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
            k = -1;
        }

        public X Current
        {
            get
            {
                return (genericList.GetElement(k));
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return (Current);
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            k++;
            return (k < genericList.Count);
        }

        public void Reset()
        {
            k=-1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
