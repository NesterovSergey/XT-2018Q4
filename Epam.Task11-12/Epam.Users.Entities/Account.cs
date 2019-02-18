using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Role { get; set; }

        public override string ToString()
        {
            return $"{Username} {Role}";
        }
    }
}
