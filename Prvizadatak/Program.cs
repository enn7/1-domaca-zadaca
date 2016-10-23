using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public interface IIntegerList
{
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);

        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(int item);

        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);

        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        int GetElement(int index);

        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);

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
        bool Contains(int item);
}


    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;

        /// <summary>
        /// number of elements in array
        /// </summary>
        int vel = 0;

        public void init()
        {
            _internalStorage = new int[4];
            vel = 0;
        }
        public void init(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new int[initialSize];
                vel = initialSize;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        // ... IIntegerList implementation ...
        public void Add(int item)
        {
            if (vel==_internalStorage.Length)
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
        Array.Resize(ref _internalStorage, _internalStorage.Length- 1);
        vel -= 1;
        return true;
        }


        public bool Remove(int item)
        {
            for (int i = 0; i < vel; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }


        public int GetElement(int index)
        { 
            if (index < vel && index>=0)
                return _internalStorage[index];
            else
                throw new IndexOutOfRangeException();
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < vel; i++)
            {
                if (_internalStorage[i] == item)
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

        public bool Contains(int item)
        {
            if (IndexOf(item) == -1)
                return false;
            return true;
        }
    }


class Program
{
    static void Main(string[] args)
    {
            IntegerList listOfIntegers = new IntegerList();
            listOfIntegers.init();
            listOfIntegers.Add(1);          // [1]
            listOfIntegers.Add(2);          // [1 ,2]
            listOfIntegers.Add(3);          // [1 ,2 ,3]
            listOfIntegers.Add(4);          // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5);          // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0);     // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5);       // [2 ,3 ,4]
            Console.WriteLine(listOfIntegers.Count);            // 3
            Console.WriteLine(listOfIntegers.Remove(100));      // false
            Console.WriteLine(listOfIntegers.RemoveAt(5));      // false
            listOfIntegers.Clear();                             
            Console.WriteLine(listOfIntegers.Count);            // 0
            Console.ReadLine();
    }
}
}