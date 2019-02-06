using System;

namespace Epam.Task6.BackupSystem
{
    public class Output
    {
        public static void ShowLine<T>(T element)
        {
            Console.Write(element);
        }

        public static void ShowNewLine<T>(T element1, T element2)
        {
            Console.WriteLine("{0}: {1}", element1, element2);
        }

        public static void ShowNewLine<T>(T element)
        {
            Console.WriteLine(element);
        }

        public static void JumpOnNewLine()
        {
            Console.WriteLine();
        }
    }
}
