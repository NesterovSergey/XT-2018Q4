using System;

namespace Epam.Task2._2DArray
{
    public class Randomizer
    {
        private static Random rand = new Random();

        public static int GenerateInteger(int n)
        {
            return rand.Next(-n, n);
        }
    }
}
