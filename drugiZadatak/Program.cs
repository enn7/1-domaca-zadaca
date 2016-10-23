namespace drugiZadatak
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    namespace prvaDz
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
            /// </ summary >
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
            int vel = 0;

            public GenericList()
            {
                _internalStorage = new X[4];
            }

            public GenericList(int initialSize)
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
                if (_internalStorage.Length == vel)
                {
                    Array.Resize(ref _internalStorage, vel * 2);
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
                int index = 0;
                for (int i = 0; i < vel; ++i)
                {
                    if (((IComparable)(_internalStorage[i])).CompareTo(item) == 0)
                    {
                        index = i;
                        return RemoveAt(index);
                    }
                }
                return false;
            }
            public X GetElement(int index)
            {
                if (index < vel && index >= 0)
                {
                    return _internalStorage[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
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
            IEnumerator<X> IEnumerable<X>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator<X> GetEnumerator()
            {
                return new GenericListEnumerator<X>(this);
            }
        }

        public class GenericListEnumerator<T> : IEnumerator<T>
        {
            private GenericList<T> genericList;
            private int k;
            public GenericListEnumerator(GenericList<T> genericList)
            {
                this.genericList = genericList;
                k = -1;
            }
            public T Current
            {
                get
                {
                    return genericList.GetElement(k);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return k;
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
}
