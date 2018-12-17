using System;

namespace Epam.Task5.SortingUnit
{
    public static class Randomizer
    {
        private static Random random = new Random();

        public static int GenereateNumber(int n)
        {
            return random.Next(-n, n);
        }

        public static int GeneratePositiveNumber(int n)
        {
            return random.Next(2, n);
        }
    }
}
