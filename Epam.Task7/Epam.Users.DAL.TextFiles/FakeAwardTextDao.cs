﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.DAL.TextFiles
{
    public class FakeAwardTextDao : IAwardDao
    {
        private const char Separator = ' ';

        private readonly string name = "Service award file.txt";

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

                return true;
            }
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
    }
}
