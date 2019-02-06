using System;
using System.IO;
using System.Linq;

namespace Epam.Task6.BackupSystem
{
    public class Watcher
    {
        private FileSystemWatcher txtWatcher = new FileSystemWatcher();
        private FileSystemWatcher folderWatcher = new FileSystemWatcher();

        private object locker = new object();

        private string path = AppDomain.CurrentDomain.BaseDirectory;
        private string mainFileName = "ServiceFile.txt";
        private string stateFileName = "StateFile.txt";
        private string stateFileLocation;
        private string mainFileLocation;

        private string type;
        private DateTime currentState;

        public Watcher()
        {
            this.FolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderForTask6");

            this.stateFileLocation = Path.Combine(this.path, this.stateFileName);

            this.mainFileLocation = Path.Combine(this.path, this.mainFileName);

            this.ToCheckMainFile();
            this.CurrentState = DateTime.Parse(File.ReadAllText(this.stateFileLocation));

            this.CreateFolder();

            this.txtWatcher.Path = this.FolderPath;
            this.folderWatcher.Path = this.FolderPath;
            this.FolderPath = this.FolderPath;
            this.txtWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.LastWrite;

            this.folderWatcher.NotifyFilter = NotifyFilters.DirectoryName;

            this.folderWatcher.Created += new FileSystemEventHandler(this.ActionEvent);
            this.folderWatcher.Deleted += new FileSystemEventHandler(this.ActionEvent);
            this.folderWatcher.Changed += new FileSystemEventHandler(this.ActionEvent);
            this.folderWatcher.Renamed += new RenamedEventHandler(this.RenameEvent);

            this.txtWatcher.Created += new FileSystemEventHandler(this.ActionEvent);
            this.txtWatcher.Deleted += new FileSystemEventHandler(this.ActionEvent);
            this.txtWatcher.Changed += new FileSystemEventHandler(this.ActionEvent);
            this.txtWatcher.Renamed += new RenamedEventHandler(this.RenameEvent);

            this.txtWatcher.Filter = "*.txt";
            this.txtWatcher.IncludeSubdirectories = true;

            this.folderWatcher.Filter = "*.*";
            this.folderWatcher.IncludeSubdirectories = true;
        }

        public string FolderPath { get; private set; }

        public DateTime CurrentState
        {
            get
            {
                return this.currentState;
            }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Your time cannot be more than the time");
                }

                File.WriteAllText(Path.Combine(this.path, this.stateFileName), DateTime.Now.ToString());
                this.currentState = value;
            }
        }

        public string MainFileLocation
        {
            get
            {
                return this.mainFileLocation;
            }
        }

        public void ToCheckMainFile()
        {
            if (!File.Exists(this.mainFileLocation))
            {
                Output.ShowNewLine("The main file is lost, it was created a new one");
                File.Create(this.mainFileLocation).Close();
            }

            if (!File.Exists(this.stateFileLocation))
            {
                Output.ShowNewLine("The state file is lost, it was created a new one");
                File.Create(this.stateFileLocation).Close();
                File.WriteAllText(this.stateFileLocation, DateTime.Now.ToString());
            }
        }

        public void RunWatcher()
        {
            Output.ShowNewLine("Watcher is launched...");
            Output.ShowNewLine("Enter e to exit");
            Output.ShowLine("Current state is ");
            Output.ShowNewLine(this.currentState);

            this.ToCheckMainFile();

            this.folderWatcher.EnableRaisingEvents = true;
            this.txtWatcher.EnableRaisingEvents = true;

            while (Input.Read() != "e")
            {
                Output.ShowNewLine("Enter 'e' to change mode");
            }

            this.folderWatcher.EnableRaisingEvents = false;
            this.txtWatcher.EnableRaisingEvents = false;
        }

        public void DeleteServiceFiles()
        {
            File.Delete(this.mainFileLocation);
            File.Delete(this.stateFileLocation);

            Output.JumpOnNewLine();
        }

        private void CreateFolder()
        {
            Output.ShowNewLine("Folder was created in the project folder at: ");
            Output.ShowNewLine(FolderPath);
            Output.JumpOnNewLine();

            Directory.CreateDirectory(this.FolderPath);
        }

        private void ActionEvent(object sender, FileSystemEventArgs e)
        {
            this.type = e.ChangeType.ToString();

            Output.ShowNewLine(this.type, e.FullPath);
            if (sender.GetHashCode() == this.txtWatcher.GetHashCode())
            {
                this.AppendToFile(this.type, e.FullPath.Remove(e.FullPath.LastIndexOf('\\')), e.FullPath.Split('\\').Last());
            }
            else
            {
                this.AppendToFile(this.type, e.FullPath);
            }
        }

        private void RenameEvent(object sender, RenamedEventArgs e)
        {
            this.type = e.ChangeType.ToString();

            Output.ShowNewLine(this.type, e.FullPath);

            if (sender.GetHashCode() == this.txtWatcher.GetHashCode())
            {
                this.AppendToFile(this.type, e.FullPath.Remove(e.FullPath.LastIndexOf('\\')), e.Name, e.OldName);
            }
            else
            {
                this.AppendToFile(this.type, e.FullPath.Remove(e.FullPath.LastIndexOf('\\')), e.Name, e.OldName, "+");
            }
        }

        private void AppendToFile(string currentEvent, string fullPath, string name = "", string oldName = "", string isFolder = "")
        {
            var text = string.Join("*", DateTime.Now, currentEvent, fullPath, name, oldName, isFolder);
            lock (this.locker)
            {
                using (StreamWriter sw = new StreamWriter(this.mainFileLocation, true))
                {
                    sw.WriteLine(text);
                }
            }
        }
    }
}
