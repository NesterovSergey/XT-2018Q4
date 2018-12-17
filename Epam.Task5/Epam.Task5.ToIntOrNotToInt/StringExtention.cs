using System;

namespace Epam.Task5.ToIntOrNotToInt
{
    public static class StringExtention
    {
        private const string IsNotAPositiveNumber = "is not a positive number";
        private const string IsAPositiveNumber = "is a positive number";

        public static string IsPositiveNumber(this string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return IsNotAPositiveNumber;
            }

            for (int i = 0; i < line.Length; i++)
            {
                if (!char.IsNumber(line[i]))
                {
                    return IsNotAPositiveNumber;
                }
            }

            return IsAPositiveNumber;
        }
    }
}
