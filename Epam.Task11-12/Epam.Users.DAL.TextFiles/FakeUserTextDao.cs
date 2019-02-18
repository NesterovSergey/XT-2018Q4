using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.DAL.TextFiles
{
    public class FakeUserTextDao : IUserDao
    {
        private const char Separator = ' ';

        private readonly string name = "Service user file.txt";

        private readonly string DefaultImageAsset = "Default images file.txt";

        private readonly string fullPath;

        private string domain = AppDomain.CurrentDomain.BaseDirectory;

        public FakeUserTextDao()
        {
            this.fullPath = Path.Combine(this.domain, this.name);

            this.CheckFile();

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

        public void Add(User user)
        {
            user.Id = ++this.Id;

            using (StreamWriter sw = new StreamWriter(this.fullPath, true))
            {
                string[] lineArray = File.ReadAllLines(Path.Combine(domain, DefaultImageAsset));
                user.Image = Convert.FromBase64String(lineArray[0]);

                sw.WriteLine(user);
            }
        }

        public bool Delete(int id)
        {
            var userList = this.GetAll();

            using (StreamWriter sw = new StreamWriter(this.fullPath, false))
            {
                foreach (var user in userList)
                {
                    if (user.Id != id)
                    {
                        sw.WriteLine(user);
                    }
                }

                return true;
            }
        }

        public User GetById(int id)
        {
            return this.GetAll().FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            string[] lineArray = File.ReadAllLines(this.fullPath);

            return lineArray.Select(element =>
            {
                string[] line = element.Split(Separator);

                return new User
                {
                    Id = int.Parse(line[0]),
                    Name = line[1],
                    DateOfBirth = DateTime.Parse(line[2]),
                    Image = Convert.FromBase64String(line[4]),
                };
            });
        }

        private void CheckFile()
        {
            if (!File.Exists(this.fullPath))
            {
                File.Create(this.fullPath).Close();
            }
        }

        public bool Update(int id, string newName, DateTime date, byte[] image)
        {
            var userList = this.GetAll();

            using (StreamWriter sw = new StreamWriter(this.fullPath, false))
            {
                foreach (var user in userList)
                {
                    if (user.Id == id)
                    {
                        if (image.Length == 0)
                        {
                            string[] lineArray = File.ReadAllLines(Path.Combine(domain, DefaultImageAsset));
                            user.Image = Convert.FromBase64String(lineArray[0]);
                        }
                        else
                        {
                            user.Image = image;
                        }

                        if (!string.IsNullOrEmpty(newName))
                        {
                            user.Name = newName;
                        }
                        if (date != default(DateTime))
                        {
                            user.DateOfBirth = date;
                        }
                    }

                    sw.WriteLine(user);
                }

                return true;
            }
        }
    }
}