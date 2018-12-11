using System;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArray_Hardcore
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
