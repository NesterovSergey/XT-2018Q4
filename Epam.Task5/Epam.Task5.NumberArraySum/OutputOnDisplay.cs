using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.NumberArraySum
{
    public static class OutputOnDisplay
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
