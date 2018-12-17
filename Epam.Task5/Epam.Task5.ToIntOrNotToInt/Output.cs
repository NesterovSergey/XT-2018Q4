using System;

namespace Epam.Task5.ToIntOrNotToInt
{
    public class Output
    {
        public static void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
        }

        public static void Write<T>(T value)
        {
            Console.Write(value);
        }
    }
}
