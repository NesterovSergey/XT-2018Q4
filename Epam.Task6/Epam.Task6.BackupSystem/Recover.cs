using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.Task6.BackupSystem
{
    public class Recover
    {
        private const char SYMBOL = '*';
        private string serviceFileLocation;
        private string folderName;
        private Watcher watcher;
        private DateTime date;

        private object locker = new object();

        public Recover(Watcher watcher)
        {
            this.watcher = watcher;
            this.serviceFileLocation = watcher.MainFileLocation;
            this.folderName = watcher.FolderName;
        }

        public void RunRecover()
        {
            this.watcher.ToCheckMainFile();

            Output.ShowNewLine("Please, enter a date");

            var readLine = Input.Read();
            try
            {
                this.ReadFile(readLine);
            }
            catch (ArgumentException e)
            {
                Output.ShowNewLine(e.Message);
            }
        }

        public void ReadFile(string userDate)
        {
            this.watcher.ToCheckMainFile();

            try
            {
                this.date = DateTime.Parse(userDate);
            }
            catch
            {
                throw new ArgumentException("Please enter time correctly");
            }

            if (this.date > DateTime.Now)
            {
                throw new Exception("Your cannot be more than current date");
            }

            string[] line;

            var allFile = File.ReadAllLines(this.serviceFileLocation).ToList();
            var i = allFile.Count - 1;

            while (i > -1)
            {
                line = allFile[i].Split(SYMBOL);

                if (DateTime.Parse(line[0]) <= this.date)
                {
                    this.watcher.CurrentState = this.date;

                    allFile.RemoveRange(i, allFile.Count - i);
                    File.WriteAllLines(this.serviceFileLocation, allFile);

                    break;
                }

                if (line[1].Equals("Created"))
                {
                    if (string.IsNullOrEmpty(line[3]))
                    {
                        if (Directory.Exists(line[2]))
                        {
                            Directory.Delete(line[2], true);
                        }
                    }
                    else
                    {
                        File.Delete(Path.Combine(line[2], line[3]));
                    }
                }
                else if (line[1].Equals("Deleted"))
                {
                    Directory.CreateDirectory(line[2]);

                    if (!string.IsNullOrEmpty(line[3]))
                    {
                        File.Create(line[3]).Close();
                    }
                }
                else if (line[1].Equals("Renamed"))
                {
                    if (!Directory.Exists(line[2]))
                    {
                        Directory.CreateDirectory(line[2]);
                    }

                    if (string.IsNullOrEmpty(line[4]))
                    {
                        Directory.Move(Path.Combine(line[2], line[3]), Path.Combine(line[2], line[4]));
                    }
                    else
                    {
                        File.Move(Path.Combine(line[2], line[3]), Path.Combine(line[2], line[4]));
                    }
                }
                else if (line[1].Equals("Changed"))
                {
                    if (!Directory.Exists(line[2]))
                    {
                        Directory.CreateDirectory(line[2]);
                    }

                    File.WriteAllText(Path.Combine(line[2], line[3]), "The file was changed");
                }

                i--;
            }

            if (i < 0)
            {
                this.watcher.CurrentState = DateTime.Now;
                File.WriteAllText(this.serviceFileLocation, string.Empty);
            }
        }

        private void ToCheckMainFile()
        {
            this.watcher.ToCheckMainFile();
        }
    }
}
