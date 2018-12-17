using System;

namespace Epam.Task5.NumberArraySum
{
    public class Program
    {
        public static void Show<T>(T element)
        {
            OutputOnDisplay.WriteLine(element);
        }

        public static void ShowArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                OutputOnDisplay.Write($"{item} ");
            }

            OutputOnDisplay.WriteLine(string.Empty);
        }

        public static void Main(string[] args)
        {
            Show("Demonstration of extension of integer and double type");

            int[] intArray = GenerateNewIntArray();
            double[] doubleArray = { 1.3, 3.4 };

            int intSum = intArray.MySum();
            double doubleSum = doubleArray.MySum();

            Show("Randomly generated array: ");
            ShowArray(intArray);

            Show("Sum of integer array: ");
            Show(intSum);

            Show("Sum of double array: ");
            Show(doubleSum);
        }

        private static int[] GenerateNewIntArray()
        {
            int[] array = new int[Randomizer.GeneratePositiveNumber(10)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Randomizer.GenereateNumber(50);
            }

            return array;
        }
    }
}
