using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.DAL.TextFiles
{
    public class FakeAccountDao : IAccountDao
    {
        private const char Separator = ' ';

        private const string DefaultRole = "user";

        private readonly string fullPath;

        private readonly string name = "Service account file.txt";

        private object locker;

        private string domain = AppDomain.CurrentDomain.BaseDirectory;

        public FakeAccountDao()
        {
            this.locker = new object();

            this.fullPath = Path.Combine(this.domain, this.name);

            try
            {
                var lastLine = File.ReadAllLines(this.fullPath).Last();
                this.Id = int.Parse(lastLine.Split(Separator)[0]);
            }
            catch
            {
                this.Id = 0;
            }
        }

        public int Id { get; private set; }

        public string LogIn(string username)
        {
            var list = this.GetAllLines();

            string[] temp;

            foreach (var line in list)
            {
                temp = line.Split(Separator);

                if (temp[0] == username)
                {
                    return temp[1];
                }
            }

            throw new ArgumentException("There is no user with your username");
        }

        public string GetRole(string username)
        {
            var list = this.GetAllLines();

            string[] temp;

            foreach (var line in list)
            {
                temp = line.Split(Separator);

                if (temp[0] == username)
                {
                    return temp[2];
                }
            }

            return "none";
        }

        public bool Registration(string username, string password)
        {
            var list = this.GetAllLines();

            string[] temp;

            foreach (var line in list)
            {
                temp = line.Split(Separator);

                if (temp[0] == username)
                {
                    throw new ArgumentException("Username with this name already exists");
                }
            }

            using (StreamWriter sw = new StreamWriter(this.fullPath, true))
            {
                sw.WriteLine("{1}{0}{2}{0}{3}", Separator, username, password, DefaultRole);
            }

            return true;
        }

        public void AssignRole(string username, string role)
        {
            string[] list = this.GetAllLines().ToArray();

            string[] temp;

            int i;

            for (i = 0; i < list.Length; i++)
            {
                temp = list[i].Split(Separator);

                if (temp[0] == username)
                {
                    list[i] = string.Format("{1}{0}{2}{0}{3}", Separator, username, temp[1], role);

                    break;
                }
            }

            if (i < list.Length)
            {
                File.WriteAllLines(this.fullPath, list);
            }
            else
            {
                throw new ArgumentException("There is no user with your username");
            }
        }

        public IEnumerable<Account> GetAll()
        {
            string[] lineArray = File.ReadAllLines(this.fullPath);

            return lineArray.Select(element =>
            {
                string[] line = element.Split(Separator);

                return new Account
                {
                    Username = line[0],
                    Role = line[2],
                };
            });
        }

        private IEnumerable<string> GetAllLines()
        {
            string[] temp;

            lock (this.locker)
            {
                temp = File.ReadAllLines(this.fullPath);
            }

            return temp;
        }

        private void CheckFile()
        {
            if (!File.Exists(this.fullPath))
            {
                throw new Exception("File is disappeared");
            }
        }
    }
}
