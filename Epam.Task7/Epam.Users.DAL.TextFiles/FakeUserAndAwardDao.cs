using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.DAL.TextFiles
{
    public class FakeUserAndAwardDao : IUserAndAwardDao
    {
        private const char Separator = ' ';

        private readonly string fullPath;

        private readonly string name = "Service user and award file.txt";

        private string domain = AppDomain.CurrentDomain.BaseDirectory;

        public FakeUserAndAwardDao()
        {
            this.fullPath = Path.Combine(this.domain, this.name);

            this.CheckFile();
        }

        public void Add(UserAndAward userAndAward)
        {
            var record = $"{userAndAward.UserId} {userAndAward.AwardId}";

            if (this.CheckFile(record))
            {
                throw new ArgumentException("The record already on the list");
            }

            using (StreamWriter sw = new StreamWriter(this.fullPath, true))
            {
                sw.WriteLine($"{userAndAward.UserId} {userAndAward.AwardId}");
            }
        }

        public IEnumerable<Award> GetAll(User user)
        {
            string[] lineArray = File.ReadAllLines(this.fullPath);

            List<Award> list = new List<Award>();

            Award award;

            foreach (var line in lineArray)
            {
                var temp = line.Split(Separator);

                if (int.Parse(temp[0]) == user.Id)
                {
                    award = new Award()
                    {
                        Id = int.Parse(temp[0]),
                    };

                    list.Add(award);
                }
            }

            return list;
        }

        private bool CheckFile(string record)
        {
            return File.ReadAllLines(this.fullPath).Any(element => element == record);
        }

        private void CheckFile()
        {
            if (!File.Exists(this.fullPath))
            {
                File.Create(this.fullPath).Close();
            }
        }
    }
}
