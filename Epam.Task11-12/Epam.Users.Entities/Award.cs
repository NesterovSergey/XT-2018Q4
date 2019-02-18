using System;

namespace Epam.Users.Entities
{
    public class Award
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] Image { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Convert.ToBase64String(Image)}";
        }
    }
}
