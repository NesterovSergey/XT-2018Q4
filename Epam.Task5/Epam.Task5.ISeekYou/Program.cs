using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Epam.Task5.ISeekYou
{
    public class Program
    {
        private static Stopwatch stopwatch = new Stopwatch();

        private static int numberOfIterations = 10;

        public delegate bool Compare(int number);

        public static int[] SearchMethod(int[] array)
        {
            var positiveElements = new List<int>();

            foreach (var item in array)
            {
                if (item > 0)
                {
                    positiveElements.Add(item);
                }
            }

            return positiveElements.ToArray();
        }

        public static int[] DelegateSearchmethod(int[] array, Compare compare)
        {
            var positiveElements = new List<int>();

            foreach (var item in array)
            {
                if (compare(item))
                {
                    positiveElements.Add(item);
                }
            }

            return positiveElements.ToArray();
        }

        public static int[] AnonimSearchmethod(int[] array, Func<int, bool> searchDelegate)
        {
            var positiveElements = new List<int>();
            foreach (var item in array)
            {
                if (searchDelegate(item))
                {
                    positiveElements.Add(item);
                }
            }

            return positiveElements.ToArray();
        }

        public static int[] LinqSearch(int[] array)
        {
            var positiveElements = array.Where(item => item > 0);

            return positiveElements.ToArray();
        }

        public static void ShowTime(List<double> array)
        {
            string[] names = { "Usual method ", "Instance delegate method ", "Anonymous method", "Lambda method", "Linq method" };
            int i = 0;
            foreach (var item in array)
            {
                Console.Write($"Average time for {names[i]} : ");
                Console.WriteLine(item);
                i++;
            }
        }

        public static void MedianCalculation(int[] array)
        {
            List<double> time = new List<double>();

            var median = new List<TimeSpan>
            {
                Capacity = 1000
            };

            Compare compare = IsPositive;
            Func<int, bool> anonymousMethod = delegate(int x) { return x > 0; };

            stopwatch.Start();
            for (int i = 0; i < numberOfIterations; i++)
            {
                SearchMethod(array);
            }

            time.Add(stopwatch.Elapsed.TotalMilliseconds / numberOfIterations);

            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                DelegateSearchmethod(array, compare);
            }

            time.Add(stopwatch.Elapsed.TotalMilliseconds / numberOfIterations);

            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                AnonimSearchmethod(array, (int x) => x > 0);
            }

            time.Add(stopwatch.Elapsed.TotalMilliseconds / numberOfIterations);

            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                AnonimSearchmethod(array, anonymousMethod);
            }

            time.Add(stopwatch.Elapsed.TotalMilliseconds / numberOfIterations);

            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                LinqSearch(array);
            }

            time.Add(stopwatch.Elapsed.TotalMilliseconds / numberOfIterations);

            ShowTime(time);
        }

        public static void Main(string[] args)
        {
            int[] array = { -1, 2, 0, -4 };

            MedianCalculation(array);
        }

        private static bool IsPositive(int number)
        {
            return number > 0;
        }
    }
}
