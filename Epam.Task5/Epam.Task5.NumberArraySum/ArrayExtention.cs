using System;

namespace Epam.Task5.NumberArraySum
{
    public static class ArrayExtention
    {
        public static int MySum(this int[] param)
        {
            int sum = 0;

            for (int i = 0; i < param.Length; i++)
            {
                sum += param[i];
            }

            return sum;
        }

        public static long MySum(this long[] param)
        {
            long sum = 0;

            for (int i = 0; i < param.Length; i++)
            {
                sum += param[i];
            }

            return sum;
        }

        public static double MySum(this double[] param)
        {
            double sum = 0;

            for (int i = 0; i < param.Length; i++)
            {
                sum += param[i];
            }

            return sum;
        }
    }
}
