using System;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArray
{
    public class Program
    {
        private static ConsoleOutput output = new ConsoleOutput();

        public static void Main(string[] args)
        {
            IEnumerable<int> testArray = new List<int>() { 1, 2, 3 };

            var array = new DynamicArray<int>();

            array = new DynamicArray<int>(16);

            array = new DynamicArray<int>(testArray);

            array.Add(18);

            array.AddRange(testArray);

            array.Remove(2);

            array.Insert(1, 13);

            output.WriteLine(array.Length);

            output.WriteLine(array.Capacity);

            output.WriteLine(array[2]);
        }
    }
}
