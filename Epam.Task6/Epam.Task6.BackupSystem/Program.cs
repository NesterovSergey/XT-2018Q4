using System;

namespace Epam.Task6.BackupSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Output.ShowNewLine("Epam.Task6.BackupSystem");
            Output.ShowNewLine(string.Empty);

            Watcher watcher = new Watcher("D:\\task5");
            Recover recover = new Recover(watcher);

            string readLine;

            while (true)
            {
                Console.WriteLine($"1. Run the watcher {Environment.NewLine}2. Run the recover {Environment.NewLine}Enter something to exit");
                readLine = Input.Read();

                if (readLine == "1")
                {
                    watcher.Run();
                }
                else if (readLine == "2")
                {
                    Output.ShowNewLine("Please, enter a date");

                    readLine = Input.Read();
                    try
                    {
                        recover.ReadFile(readLine);
                    }
                    catch (ArgumentException e)
                    {
                        Output.ShowNewLine(e.Message);
                    }
                }
                else
                {
                    Output.ShowNewLine("Good luck!");
                    break;
                }
            }
        }
    }
}
