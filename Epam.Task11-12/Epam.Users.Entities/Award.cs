﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Entities
{
    public class Award
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Image}";
        }
    }
}
