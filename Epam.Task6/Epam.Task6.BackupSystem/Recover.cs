using System;
using System.IO;

namespace Epam.Task6.BackupSystem
{
    public class Recover
    {
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

        public void ReadFile(string userDate)
        {
            try
            {
                this.date = DateTime.Parse(userDate);
            }
            catch
            {
                throw new ArgumentException("Please enter time correct");
            }

            if (this.date > DateTime.Now)
            {
                throw new Exception("Your cannot be more than current date");
            }

            this.watcher.CurrentState = this.date;

            var allFile = File.ReadAllLines(this.serviceFileLocation);

            for (int i = allFile.Length - 1; i >= 0; i--)
            {
                var line = allFile[i].Split('*');

                if (DateTime.Parse(line[0]) < this.date)
                {
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
            }
        }

        private void ToCheckMainFile()
        {
            this.watcher.ToCheckMainFile();
        }
    }
}
