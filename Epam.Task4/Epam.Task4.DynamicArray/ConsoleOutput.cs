using System;

namespace Epam.Task4.DynamicArray
{
    public class ConsoleOutput
    {
        public void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
        }

        public void Write<T>(T value)
        {
            Console.Write(value);
        }
    }
}
