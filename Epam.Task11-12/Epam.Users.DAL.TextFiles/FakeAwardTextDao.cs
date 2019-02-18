using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.DAL.TextFiles
{
    public class FakeAwardTextDao : IAwardDao
    {
        private const char Separator = ' ';

        private readonly string name = "Service award file.txt";

        private readonly string defaultImageAsset = "Default images file.txt";

        private readonly string fullPath;

        private string domain = AppDomain.CurrentDomain.BaseDirectory;

        public FakeAwardTextDao()
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

        public void Add(Award award)
        {
            award.Id = ++this.Id;

            using (StreamWriter sw = new StreamWriter(this.fullPath, true))
            {
                if (award.Image == null)
                {
                    string[] lineArray = File.ReadAllLines(Path.Combine(this.domain, this.defaultImageAsset));
                    award.Image = Convert.FromBase64String(lineArray[1]);
                }

                sw.WriteLine(award);
            }
        }

        public bool Delete(int id)
        {
            var awardList = this.GetAll();

            using (StreamWriter sw = new StreamWriter(this.fullPath, false))
            {
                foreach (var award in awardList)
                {
                    if (award.Id != id)
                    {
                        sw.WriteLine(award);
                    }
                }
            }

            return true;
        }

        public Award GetById(int id)
        {
            return this.GetAll().SingleOrDefault(award => award.Id == id);
        }

        public IEnumerable<Award> GetAll()
        {
            string[] lineArray = File.ReadAllLines(this.fullPath);

            return lineArray.Select(element =>
            {
                string[] line = element.Split(Separator);

                return new Award
                {
                    Id = int.Parse(line[0]),
                    Title = line[1],
                    Image = Encoding.ASCII.GetBytes(line[2]),
                };
            });
        }

        public bool Update(int id, string newTitle, byte[] image)
        {
            var awardList = this.GetAll();

            using (StreamWriter sw = new StreamWriter(this.fullPath, false))
            {
                foreach (var award in awardList)
                {
                    if (award.Id == id)
                    {
                        if (image == null)
                        {
                            string[] lineArray = File.ReadAllLines(Path.Combine(this.domain, this.defaultImageAsset));
                            award.Image = Convert.FromBase64String(lineArray[1]);
                        }
                        else
                        {
                            award.Image = image;
                        }

                        award.Title = newTitle;
                    }

                    sw.WriteLine(award);
                }

                return true;
            }
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
