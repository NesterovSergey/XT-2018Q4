using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Entities
{
    public class Account
    {
        public string Username { get; set; }

        public string Role { get; set; }

        public override string ToString()
        {
            return $"{Username} {Role}";
        }
    }
}
