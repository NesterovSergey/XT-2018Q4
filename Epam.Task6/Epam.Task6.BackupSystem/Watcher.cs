using System;
using System.IO;
using System.Linq;

namespace Epam.Task6.BackupSystem
{
    public class Watcher
    {
        private FileSystemWatcher txtWatcher = new FileSystemWatcher();
        private FileSystemWatcher folderWatcher = new FileSystemWatcher();

        object locker = new object();

        private string path = AppDomain.CurrentDomain.BaseDirectory;
        private string mainFileName = "ServiceFile.txt";
        private string stateFileName = "StateFile.txt";
        private string stateFileLocation;
        private string mainFileLocation;

        private string type;
        private DateTime currentState;

        public string FolderName { get; private set; }
        public DateTime CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Your time cannot be more than the time");
                }

                File.WriteAllText(Path.Combine(path, stateFileName), DateTime.Now.ToString());
                currentState = value;
            }
        }

        public string MainFileLocation
        {
            get
            {
                return mainFileLocation;
            }
            private set
            { }
        }

        public Watcher(string folderPath)
        {
            stateFileLocation = Path.Combine(path, stateFileName);

            mainFileLocation = Path.Combine(this.path, this.mainFileName);

            ToCheckMainFile();
            CurrentState = DateTime.Parse(File.ReadAllText(stateFileLocation));

            txtWatcher.Path = folderPath; ;
            folderWatcher.Path = folderPath;
            this.FolderName = folderPath;
            txtWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.LastWrite;

            folderWatcher.NotifyFilter = NotifyFilters.DirectoryName;

            folderWatcher.Created += new FileSystemEventHandler(ActionEvent);
            folderWatcher.Deleted += new FileSystemEventHandler(ActionEvent);
            folderWatcher.Changed += new FileSystemEventHandler(ActionEvent);
            folderWatcher.Renamed += new RenamedEventHandler(RenameEvent);

            txtWatcher.Created += new FileSystemEventHandler(ActionEvent);
            txtWatcher.Deleted += new FileSystemEventHandler(ActionEvent);
            txtWatcher.Changed += new FileSystemEventHandler(ActionEvent);
            txtWatcher.Renamed += new RenamedEventHandler(RenameEvent);

            txtWatcher.Filter = "*.txt";
            txtWatcher.IncludeSubdirectories = true;

            folderWatcher.Filter = "*.*";
            folderWatcher.IncludeSubdirectories = true;
        }

        private void ActionEvent(object sender, FileSystemEventArgs e)
        {
            type = e.ChangeType.ToString();

            Output.ShowNewLine(type, e.FullPath);
            if (sender.GetHashCode() == txtWatcher.GetHashCode())
            {
                AppendToFile(type, e.FullPath.Remove(e.FullPath.LastIndexOf('\\')), e.FullPath.Split('\\').Last());
            }
            else
            {
                AppendToFile(type, e.FullPath);
            }
        }

        private void RenameEvent(object sender, RenamedEventArgs e)
        {
            type = e.ChangeType.ToString();

            Output.ShowNewLine(type, e.FullPath);

            if (sender.GetHashCode() == txtWatcher.GetHashCode())
            {
                AppendToFile(type, e.FullPath.Remove(e.FullPath.LastIndexOf('\\')), e.Name, e.OldName);
            }
            else
            {
                AppendToFile(type, e.FullPath.Remove(e.FullPath.LastIndexOf('\\')), e.Name, e.OldName, "+");
            }
        }

        private void AppendToFile(string currentEvent, string fullPath, string name = "", string oldName = "", string isFolder = "")
        {
            var text = string.Join("*", DateTime.Now, currentEvent, fullPath, name, oldName, isFolder);
            lock (locker)
            {
                using (StreamWriter sw = new StreamWriter(mainFileLocation, true))
                {
                    sw.WriteLine(text);
                }
            }
        }

        public void ToCheckMainFile()
        {
            if (!File.Exists(mainFileLocation))
            {
                Output.ShowNewLine("The main file is lost, it was created a new one");
                File.Create(mainFileLocation).Close();
            }

            if (!File.Exists(stateFileLocation))
            {
                Output.ShowNewLine("The state file is lost, it was created a new one");
                File.Create(stateFileLocation).Close();
                File.WriteAllText(stateFileLocation, DateTime.Now.ToString());
            }
        }

        public void Run()
        {
            Output.ShowNewLine("Watcher is launched...");
            Output.ShowNewLine("Enter e to exit");
            Output.ShowLine("Current state is ");
            Output.ShowNewLine(currentState);

            folderWatcher.EnableRaisingEvents = true;
            txtWatcher.EnableRaisingEvents = true;

            while (Input.Read() != "e") { };

            folderWatcher.EnableRaisingEvents = false;
            txtWatcher.EnableRaisingEvents = false;
        }
    }
}
