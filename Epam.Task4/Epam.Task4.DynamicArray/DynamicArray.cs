using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] array;
        private int count;
        private int capacity;

        public DynamicArray() : this(8)
        {
        }

        public DynamicArray(int n)
        {
            this.count = 0;
            this.capacity = n;

            this.array = new T[n];
        }

        public DynamicArray(IEnumerable<T> list)
        {
            this.capacity = 8;

            int i = 0;
            int newCount = (list as IList<T>).Count;

            if (newCount > this.capacity)
            {
                int numberOfTwos = this.CountOfTwos(newCount);
                this.CapacityEncreasing(numberOfTwos);
            }

            this.array = new T[newCount];

            foreach (var item in list)
            {
                this.array[i] = item;
                i++;
            }

            this.count = this.array.Length;
        }

        public T[] Array => this.array;

        public int Length => this.count;

        public int Capacity => this.capacity;

        public T this[int id]
        {
            get
            {
                return this.array[id];
            }

            set
            {
                if (id > this.count || id < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of range of the array");
                }
                else
                {
                    this.array[id] = value;
                }
            }
        }

        public void Add(T item)
        {
            if (this.count != this.capacity)
            {
                this.CapacityEncreasing();

                this.count += 1;
                this.array[this.count] = item;
            }
            else
            {
                this.count += 1;
                this.array[this.count] = item;
            }
        }

        public void AddRange(IEnumerable<T> list)
        {
            int countNewList = (list as IList<T>).Count;

            if (countNewList > this.capacity)
            {
                int numberOfTwos = this.CountOfTwos(countNewList);

                this.CapacityEncreasing(numberOfTwos);
            }

            foreach (var item in list)
            {
                this.Add(item);
            }
        }

        public bool Remove(T deletingElement)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.array[i].Equals(deletingElement))
                {
                    int j = i;
                    while (j != this.count - 2)
                    {
                        this.array[j] = this.array[j + 1];
                        j++;
                    }

                    this.count--;

                    return true;
                }
            }

            return false;
        }

        public bool Insert(int index, T item)
        {
            if (index < 0)
            {
                return false;
            }
            else if (this.count == this.capacity)
            {
                this.CapacityEncreasing();
            }

            this.count++;

            T temporaryElement = this.array[index];
            this.array[index] = item;

            for (int i = index + 1; i < this.count + 1; i++)
            {
                this.array[i] = temporaryElement;
                temporaryElement = this.array[i + 1];
            }

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return this.array.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)this.array).GetEnumerator();
        }

        private void DefaultFill(int n)
        {
            for (int i = 0; i < n; i++)
            {
                this.array[i] = default(T);
            }
        }

        private void CapacityEncreasing()
        {
            this.CapacityEncreasing(1);
        }

        private void CapacityEncreasing(int numberOfTwos)
        {
            for (int i = 0; i < numberOfTwos; i++)
            {
                this.capacity *= 2;
            }

            T[] tempArray = this.array;

            this.array = new T[this.capacity];
            for (int i = 0; i < tempArray.Length; i++)
            {
                this.array[i] = tempArray[i];
            }
        }

        private int CountOfTwos(int count)
        {
            int numberOfTwos = 0;
            int tempCapacity = this.capacity;

            while (count > tempCapacity)
            {
                tempCapacity *= 2;
                numberOfTwos++;
            }

            return numberOfTwos;
        }
    }
}