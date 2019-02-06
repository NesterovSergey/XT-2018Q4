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
                Console.WriteLine($"1. Run the watcher {Environment.NewLine}2. Run the recover {Environment.NewLine}3. Delete service files {Environment.NewLine}*Enter something to exit");
                readLine = Input.Read();

                if (readLine == "1")
                {
                    watcher.RunWatcher();
                }
                else if (readLine == "2")
                {
                    recover.RunRecover();
                }
                else if (readLine == "3")
                {
                    watcher.DeleteServiceFiles();
                    Console.WriteLine("Success!");
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
