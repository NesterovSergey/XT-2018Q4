using System;

namespace Epam.Task2.NoPositive
{
    public static class Randomizer
    {
        private static Random rand = new Random();

        public static int GenerateInteger(int n)
        {
            return rand.Next(-n, n);
        }
    }
}
